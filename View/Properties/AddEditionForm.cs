using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace View.Properties
{
	/// <summary>
	/// Доступные типы изданий
	/// </summary>
	public enum EditionTypes
	{
		Book,
		Dissertation
	}

	public partial class AddEditionForm : Form
	{
		DataTable dtAuthors;
		EditionTypes editionType;

		public AddEditionForm()
		{
			InitializeComponent();

			dtAuthors = new DataTable();
			dtAuthors.Columns.Add("Second Name");
			dtAuthors.Columns.Add("First Name");
			dtAuthors.Columns.Add("Patronymic");
			gridAuthors.DataSource = dtAuthors;
			gridAuthors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			gridAuthors.AllowUserToAddRows = false;
			gridAuthors.AllowUserToDeleteRows = false;
			gridAuthors.AllowUserToOrderColumns = false;
			#if !DEBUG
			btnCreateRandomData.Visible = false;
			#endif
		}

		private void AddEditionForm_Load(object sender, EventArgs e)
		{
			cmbEditionTypes.DataSource = Enum.GetValues(typeof(EditionTypes));
			cmbLanguages.DataSource = Enum.GetValues(typeof(LanguageMode));

			txtNumPages.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
			txtNumPages.HidePromptOnLeave = true;

			txtYear.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
			txtYear.HidePromptOnLeave = true;

			Controls.Cast<Control>().Where(x => x.Name.StartsWith("lbl")).
				ToList().ForEach(x => x.TabIndex = 0);

			string[] fields = new string[]
			{
				"cmbEditionTypes",
				"txtTitle",
				"txtYear",
				"txtNumPages",
				"txtCity",
				"cmbLanguages",
				"txtPublishingHouse",
				"txtUniversity",
				"txtDegree",
				"txtSpecialityCode",
				"gridAuthors",
				"btnOk",
				"btnCancel",
				"btnCreateRandomData"
			};

			int tabIndex = 1;
			foreach (string field in fields)
			{
				Controls[field].TabIndex = tabIndex;
				tabIndex++;
			}

			txtCity.TextChanged += TextValidationEventHandler;
			txtDegree.TextChanged += TextValidationEventHandler;
			txtNumPages.TextChanged += TextValidationEventHandler;
			txtPublishingHouse.TextChanged += TextValidationEventHandler;
			txtSpecialityCode.TextChanged += TextValidationEventHandler;
			txtTitle.TextChanged += TextValidationEventHandler;
			txtUniversity.TextChanged += TextValidationEventHandler;
			txtYear.TextChanged += TextValidationEventHandler;

			gridAuthors.CellValidating += gridAuthors_CellValidating;
			gridAuthors.CellEndEdit += gridAuthors_CellEndEdit;
		}

		#region Main Buttons Handlers
		private void btnOk_Click(object sender, EventArgs e)
		{
			try
			{
				List<Person> authors = new List<Person>();
				foreach (DataRow row in dtAuthors.Rows)
				{
					authors.Add(
						new Person()
						{
							SecondName = (string)row[0],
							FirstName = (string)row[1],
							Patronymic = (string)row[2]
						});
				}

				Type type = typeof(IEdition).Assembly.
					GetType("Model." + editionType.ToString());
				type.GetProperty("Authors").SetValue(
						Convert.ChangeType(edition, type),
						authors);

				var writer = new XmlSerializer(edition.GetType());

				StringBuilder filePath = new StringBuilder(
					Directory.GetCurrentDirectory());
				filePath.Append("\\Editions\\").
					Append(edition.GetType().Name).
					Append("_").
					Append(DateTime.Now.ToString("yyyyMMddHHmmssffff")).
					Append(".bib");

				using (var file = File.Create(filePath.ToString()))
				{
					writer.Serialize(file, edition);
					file.Close();
				}
				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error!",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnCreateRandomData_Click(object sender, EventArgs e)
		{
			string[] names = new string[] { "John", "Mary", "Peter" };
			string[] surnames = new string[] { "Smith", "Black", "White" };
			int authorsNum = 1;
			dtAuthors.Clear();
			Random random = new Random();
			if (editionType == EditionTypes.Book)
			{
				authorsNum = random.Next(1, 3);
			}

			DataRow row;
			for (int i = 0; i < authorsNum; i++)
			{
				row = dtAuthors.NewRow();
				row[0] = getRandomItem(surnames);
				row[1] = getRandomItem(names);
				row[2] = "";
				dtAuthors.Rows.Add(row);
			}

			string[] cities = new string[] { "Moscow", "Tomsk", "Omsk" };
			string[] titles = new string[] { "Work", "Best work" };
			string[] publishHouses = new string[] { "ABC", "XYZ", "OPS" };
			string[] univers = new string[] { "MSU", "MISIS", "VLSU" };
			string[] degrees = new string[] { "bachelor", "master" };
			string[] specCodes = new string[] { "19.99.89", "02.01.03" };
			int[] years = new int[] { 1999, 2002, 2015, 2020, 1984 };
			int[] numPages = new int[] { 28, 312, 100, 99, 427 };

			txtCity.Text = getRandomItem(cities);
			txtTitle.Text = getRandomItem(titles);
			txtYear.Text = getRandomItem(years).ToString();
			txtNumPages.Text = getRandomItem(numPages).ToString();

			if (editionType == EditionTypes.Book)
			{
				txtPublishingHouse.Text = getRandomItem(publishHouses);
			}
			else
			{
				txtUniversity.Text = getRandomItem(univers);
				txtDegree.Text = getRandomItem(degrees);
				txtSpecialityCode.Text = getRandomItem(specCodes);
			}
		}
		#endregion Main Buttons Handlers

		#region Controls Hadlers
		private void cmbEditionTypes_SelectedIndexChanged(object sender, EventArgs e)
		{
			editionType = (EditionTypes)(cmbEditionTypes.SelectedItem);
			if (editionType == EditionTypes.Book)
			{
				lblUniversity.Visible = false;
				txtUniversity.Visible = false;
				lblDegree.Visible = false;
				txtDegree.Visible = false;
				lblSpecialityCode.Visible = false;
				txtSpecialityCode.Visible = false;

				lblPublishingHouse.Visible = true;
				txtPublishingHouse.Visible = true;
				lblLanguage.Visible = true;
				cmbLanguages.Visible = true;

				lblAuthors.Location = new Point(12, 175);
				gridAuthors.Location = new Point(128, 172);
				btnAddAuthor.Location = new Point(128, 172 + 92);
				btnRemoveAuthor.Location = new Point(345, 172 + 92);

				edition = new Book();
			}
			else
			{
				lblUniversity.Visible = true;
				txtUniversity.Visible = true;
				lblDegree.Visible = true;
				txtDegree.Visible = true;
				lblSpecialityCode.Visible = true;
				txtSpecialityCode.Visible = true;

				lblPublishingHouse.Visible = false;
				txtPublishingHouse.Visible = false;
				lblLanguage.Visible = false;
				cmbLanguages.Visible = false;

				lblAuthors.Location = new Point(12, 202);
				gridAuthors.Location = new Point(128, 199);
				btnAddAuthor.Location = new Point(128, 199 + 92);
				btnRemoveAuthor.Location = new Point(345, 199 + 92);

				while (dtAuthors.Rows.Count > 1)
				{
					dtAuthors.Rows.RemoveAt(dtAuthors.Rows.Count - 1);
				}
				edition = new Dissertation();
			}
			CheckAuthorsCount();
		}

		private void TextChangedEventHandler(object sender, EventArgs e)
		{
			Regex regex = new Regex(@"^[A-Za-zА-Яа-я_ _-]+$");
			TextBox textBox = (TextBox)sender;
			string text = textBox.Text;

			if (!regex.IsMatch(text))
			{
				textBox.Text = Regex.Replace(text, @"[^A-Za-zА-Яа-я_ _-]", "");
				textBox.SelectionStart = textBox.Text.Length;
			}
		}

		private void TextValidationEventHandler(object sender, EventArgs e)
		{
			Control control = null;

			if (sender is TextBox)
			{
				control = (TextBox)sender;
			}
			else if (sender is MaskedTextBox)
			{
				control = (MaskedTextBox)sender;
			}

			try
			{
				var property = Edition.GetType().GetProperties().
					FirstOrDefault(x => control.Name.Contains(x.Name));

				property.SetValue(Edition,
					Convert.ChangeType(control.Text, property.PropertyType));

				errorProvider.SetError(control, null);
			}
			catch (Exception ex)
			{
				string exceptionMessage =
					ex.InnerException != null ?
					ex.InnerException.Message :
					ex.Message;

				if (e is CancelEventArgs)
				{
					((CancelEventArgs)e).Cancel = true;
				}
				errorProvider.SetError(control, exceptionMessage);
			}
		}
		
		#endregion Controls Hadlers

		#region Authors Grid Handlers
		private void btnAddAuthor_Click(object sender, EventArgs e)
		{
			DataRow row = dtAuthors.NewRow();
			dtAuthors.Rows.Add(row);
			CheckAuthorsCount();
		}

		private void btnRemoveAuthor_Click(object sender, EventArgs e)
		{
			foreach (DataGridViewRow row in gridAuthors.SelectedRows)
			{
				gridAuthors.Rows.RemoveAt(row.Index);
			}
			CheckAuthorsCount();
		}

		private void gridAuthors_CellValidating(object sender,
			DataGridViewCellValidatingEventArgs e)
		{
			string headerText =
				gridAuthors.Columns[e.ColumnIndex].HeaderText;

			if (headerText.Equals("Patronymic"))
				return;

			if (string.IsNullOrWhiteSpace(
				e.FormattedValue.ToString()))
			{
				gridAuthors.Rows[e.RowIndex].ErrorText =
					headerText + " must not be empty";
				e.Cancel = true;
			}
		}

		void gridAuthors_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			gridAuthors.Rows[e.RowIndex].ErrorText = string.Empty;
		}
		#endregion Authors Grid Handlers

		#region Properties
		private IEdition edition;
		public IEdition Edition
		{
			get
			{
				return edition;
			}
			set
			{
				edition = value;
			}
		}
		#endregion Properties

		#region Methods
		/// <summary>
		/// Метод для получения случайного элемента из массива
		/// </summary>
		/// <typeparam name="T">тип элемента</typeparam>
		/// <param name="array">массив элементов</param>
		/// <returns></returns>
		private T getRandomItem<T>(T[] array)
		{
			Random random = new Random((DateTime.Now.Millisecond));
			int index = random.Next(0, array.Length);
			return array[index];
		}

		/// <summary>
		/// Метод регулирует доступность
		/// кнопки добавления автора к изданию
		/// </summary>
		private void CheckAuthorsCount()
		{
			if (editionType == EditionTypes.Dissertation
				&& dtAuthors.Rows.Count == 1)
			{
				btnAddAuthor.Enabled = false;
			}
			else
			{
				btnAddAuthor.Enabled = true;
			}
		}
		#endregion Methods
	}
}