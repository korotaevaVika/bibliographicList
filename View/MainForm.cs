using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using View.Properties;

namespace View
{
	public partial class MainForm : Form
	{
		/// <summary>
		/// Список изданий
		/// </summary>
		List<IEdition> editions;

		/// <summary>
		/// Конструктор
		/// </summary>
		public MainForm()
		{
			editions = new List<IEdition>();
			InitializeComponent();

			gridEditions.Columns.Add("Title", "Title");

			gridEditions.ReadOnly = true;
			gridEditions.AutoSizeColumnsMode =
				DataGridViewAutoSizeColumnsMode.Fill;
			gridEditions.AllowUserToAddRows = false;
			gridEditions.AllowUserToOrderColumns = false;
			gridEditions.SelectionMode =
				DataGridViewSelectionMode.FullRowSelect;

			gridEditions.SelectionChanged += gridViewSelectionChanged;

			SetButtonsEnable();
		}
		#region Button Handlers

		/// <summary>
		/// Открытие формы добавления издания
		/// </summary>
		private void btnAdd_Click(object sender, EventArgs e)
		{
			AddEditionForm addEditionForm = new AddEditionForm();
			addEditionForm.CallerForm = this;
			addEditionForm.Show();

			SetButtonsEnable();
		}

		/// <summary>
		/// Удаление издания из списка
		/// </summary>
		private void btnRemove_Click(object sender, EventArgs e)
		{
			if (gridEditions.SelectedRows.Count > 0)
			{
				foreach (DataGridViewRow row in gridEditions.SelectedRows)
				{
					if (!row.IsNewRow)
					{
						string standartName =
							row.Cells["Title"].Value.ToString();

						var editionToRemove = editions.FirstOrDefault(
							x => x.StandartName == standartName);

						if (editionToRemove != null)
							editions.Remove(editionToRemove);

						gridEditions.Rows.RemoveAt(row.Index);
					}
				}
			}
			SetButtonsEnable();
		}

		/// <summary>
		/// Меняет свойства Enable кнопок 
		/// при добавлении/удалении изданий
		/// </summary>
		private void SetButtonsEnable()
		{
			if (editions.Count == 0)
			{
				btnSave.Enabled = false;
				btnRemove.Enabled = false;
				btnSearch.Enabled = false;
			}
			else
			{
				btnSave.Enabled = true;
				btnRemove.Enabled = true;
				btnSearch.Enabled = true;
			}
		}

		/// <summary>
		///  Изменяет свойство Enable кнопки удаления
		///  издания из списка при изменения выбранных
		///  строк таблицы gridEditions
		/// </summary>
		private void gridViewSelectionChanged(object sender, EventArgs e)
		{
			if (gridEditions.SelectedRows.Count > 0)
				btnRemove.Enabled = true;
			else
				btnRemove.Enabled = false;
		}

		/// <summary>
		/// Открытие формы поиска
		/// </summary>
		private void btnSearch_Click(object sender, EventArgs e)
		{
			SearchForm searchForm = new SearchForm();
			searchForm.Editions = editions;
			searchForm.Show();
		}

		private void MainForm_Activated(object sender, EventArgs e)
		{
			SetButtonsEnable();
		}

		/// <summary>
		/// Метод добавляющий новое издание в список
		/// </summary>
		/// <param name="edition">Новое издание</param>
		internal void AddEdition(IEdition edition)
		{
			editions.Add(edition);
			gridEditions.Rows.Clear();
			editions.ForEach(x =>
				gridEditions.Rows.Add(x.StandartName));

			gridEditions.Update();
			gridEditions.Refresh();

			SetButtonsEnable();
		}

		/// <summary>
		/// Сохраняет список изданий в файл типа .bib
		/// </summary>
		private void btnSave_Click(object sender, EventArgs e)
		{
			Stream stream;
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				Filter = "bib files (*.bib)|*.bib|All files (*.*)|*.*",
				FilterIndex = 1,
				InitialDirectory = Directory.GetCurrentDirectory(),
				RestoreDirectory = true
			};

			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				if ((stream = saveFileDialog.OpenFile()) != null)
				{
					try
					{
						stream.Seek(0, SeekOrigin.Begin);
						stream.Write(Encoding.ASCII.GetBytes("<root>"),
							0, "<root>".Length);

						var emptyNs = new XmlSerializerNamespaces(
							new[] { XmlQualifiedName.Empty });

						editions.ForEach(edition =>
						{
							using (XmlWriter xmlWriter = XmlWriter.Create(
								stream,
								new XmlWriterSettings
								{
									OmitXmlDeclaration = true,
									Indent = true
								}))
							{
								new XmlSerializer(edition.GetType()).Serialize(
									xmlWriter, edition, emptyNs);
							}
						});
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Error!",
							MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					stream.Seek(0, SeekOrigin.End);
					stream.Write(Encoding.ASCII.GetBytes("</root>"),
						0, "</root>".Length);
					stream.Close();
				}
			}
		}

		/// <summary>
		/// Загружает содержимое файла типа .bib
		/// в список изданий 
		/// </summary>
		private void btnLoad_Click(object sender, EventArgs e)
		{
			Stream fileStream;
			OpenFileDialog openFileDialog = new OpenFileDialog();
			string filePath;
			string fileContent = string.Empty;

			openFileDialog.Filter = "bib files (*.bib)|*.bib";
			openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
			openFileDialog.RestoreDirectory = true;

			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				filePath = openFileDialog.FileName;
				fileStream = openFileDialog.OpenFile();

				using (StreamReader streamReader = new StreamReader(fileStream))
				{
					fileContent = streamReader.ReadToEnd();
				}

				gridEditions.Rows.Clear();
				editions.Clear();

				XElement xRoot = XElement.Parse(
					fileContent,
					LoadOptions.SetLineInfo);

				var allNodes = xRoot.DescendantNodesAndSelf();
				var nodesToSerialize = new List<XElement>();
				string[] arrEditionTypes = Enum.GetNames(typeof(EditionTypes));

				foreach (var node in allNodes)
				{
					if (node is XElement)
					{
						string name = ((XElement)node).Name.LocalName;
						if (arrEditionTypes.Contains(name))
							nodesToSerialize.Add((XElement)node);
					}
				}

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

				foreach (var xml in nodesToSerialize)
				{
					try
					{
						typeName = "Model." + xml.Name.LocalName;
						editionType = assembly.GetType(typeName);
						reader = new XmlSerializer(editionType, attrOverrides);
						authors = new List<Person>();

						using (TextReader stream = new StringReader(xml.ToString()))
						{
							edition = (IEdition)(Convert.ChangeType(
									reader.Deserialize(stream), editionType));
						}
						using (TextReader stream = new StringReader(xml.ToString()))
						{
							XmlReaderSettings settings = new XmlReaderSettings
							{
								IgnoreComments = true,
								IgnoreWhitespace = true
							};

							using (XmlReader xmlReader =
							XmlReader.Create(stream, settings))
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

								editionType.GetProperty("Authors").SetValue(
									Convert.ChangeType(edition, editionType),
									authors);

								editions.Add(edition);
								gridEditions.Rows.Add(edition.StandartName);
							}
						}
					}
					catch (Exception ex)
					{
						exceptionMessage += "Error while loading file \n";
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
				SetButtonsEnable();
			}
		}
		#endregion Button Handlers
	}
}