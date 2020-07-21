using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using View.Properties;

namespace View
{
	public partial class MainForm : Form
	{
		List<IEdition> editions;

		public MainForm()
		{
			editions = new List<IEdition>();
			InitializeComponent();

			gridEditions.Columns.Add("Title", "Title");
			gridEditions.Columns.Add("File Name", "File Name");

			gridEditions.ReadOnly = true;
			gridEditions.AutoSizeColumnsMode =
				DataGridViewAutoSizeColumnsMode.Fill;
			gridEditions.AllowUserToAddRows = false;
			gridEditions.AllowUserToOrderColumns = false;
			gridEditions.SelectionMode =
				DataGridViewSelectionMode.FullRowSelect;

			#if !DEBUG
			gridEditions.Columns["File Name"].Visible = false;
			#endif
		}

		#region Button Handlers
		private void btnAdd_Click(object sender, EventArgs e)
		{
			AddEditionForm addEditionForm = new AddEditionForm();
			addEditionForm.Show();
		}

		private void btnRemove_Click(object sender, EventArgs e)
		{
			if (gridEditions.SelectedRows.Count > 0)
			{
				foreach (DataGridViewRow row in gridEditions.SelectedRows)
				{
					if (!row.IsNewRow)
						File.Delete(row.Cells["File Name"].Value.ToString());
				}
			}
			ReadEditions();
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			ReadEditions();
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			SearchForm searchForm = new SearchForm();
			searchForm.Editions = editions;
			searchForm.Show();
		}
		#endregion Button Handlers

		private void MainForm_Activated(object sender, EventArgs e)
		{
			ReadEditions();
		}

		/// <summary>
		/// Метод для чтения сохраненных изданий
		/// </summary>
		private void ReadEditions()
		{
			gridEditions.Rows.Clear();
			editions.Clear();

			string directory = Directory.GetCurrentDirectory();
			directory += "\\Editions";
			Directory.CreateDirectory(directory);
			DirectoryInfo d = new DirectoryInfo(directory);
			XmlSerializer reader = null;
			Type editionType = null;
			IEdition edition = null;
			Assembly assembly = typeof(IEdition).Assembly;
			string typeName;
			List<Person> authors = new List<Person>();
			string exceptionMessage = string.Empty;

			XmlAttributes attrs = new XmlAttributes();
			attrs.XmlIgnore = true;
			attrs.XmlElements.Add(
				new XmlElementAttribute()
				{
					ElementName = "Authors"
				});

			XmlAttributeOverrides attrOverrides =
				new XmlAttributeOverrides();

			assembly.GetTypes().ToList().
				Where(x => x.IsClass &&
					x.GetInterfaces().Contains(typeof(IEdition))).
					ToList().ForEach(type =>
					{
						attrOverrides.Add(type, "Authors", attrs);
					});

			foreach (var file in d.GetFiles("*.bib"))
			{
				try
				{
					typeName = "Model." +
						file.Name.Substring(0, file.Name.IndexOf("_"));

					editionType = assembly.GetType(typeName);
					reader = new XmlSerializer(editionType, attrOverrides);
					authors = new List<Person>();

					using (Stream stream =
						new FileStream(file.FullName, FileMode.Open))
					{
						edition = (IEdition)(Convert.ChangeType(
							reader.Deserialize(stream), editionType));

						StreamReader streamReader = new StreamReader(stream);
						streamReader.BaseStream.Position = 0;

						XmlReaderSettings settings = new XmlReaderSettings
						{
							IgnoreComments = true,
							IgnoreWhitespace = true
						};

						using (XmlReader xmlReader =
							XmlReader.Create(streamReader, settings))
						{
							while (!xmlReader.EOF)
							{
								if (xmlReader.Name != "Person")
								{
									xmlReader.ReadToFollowing("Person");
								}

								if (!xmlReader.EOF)
								{
									XElement person = (XElement)XNode.ReadFrom(xmlReader);
									Person author = new Person
									{
										FirstName = (string)person.Element("FirstName"),
										SecondName = (string)person.Element("SecondName"),
										Patronymic = (string)person.Element("Patronymic")
									};
									authors.Add(author);
								}
							}
						}

						editionType.GetProperty("Authors").SetValue(
							Convert.ChangeType(edition, editionType),
							authors);
						editions.Add(edition);

						gridEditions.Rows.Add(
							edition.StandartName,
							file.FullName
							);
					}
				}
				catch (Exception)
				{
					exceptionMessage += file.Name + "\n";
				}
			}

			gridEditions.Update();
			gridEditions.Refresh();

			if (!string.IsNullOrEmpty(exceptionMessage))
			{
				MessageBox.Show(
					"Error while parsing " + exceptionMessage,
					"Loading Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			}
		}
	}
}