using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace View
{
	public partial class SearchForm : Form
	{
		private List<string> parameters;
		/// <summary>
		/// Список сохраненных изданий
		/// </summary>
		public List<IEdition> Editions { get; set; }

		/// <summary>
		/// Конструктор
		/// </summary>
		public SearchForm()
		{
			parameters = new List<string>(){
				"Authors",
				"Title",
				"Year",
			};

			InitializeComponent();

			gridEditions.Columns.Add("Title", "Title");

			gridEditions.ReadOnly = true;
			gridEditions.AutoSizeColumnsMode =
				DataGridViewAutoSizeColumnsMode.Fill;
			gridEditions.AllowUserToAddRows = false;
			gridEditions.AllowUserToDeleteRows = false;
			gridEditions.AllowUserToOrderColumns = false;
			gridEditions.SelectionMode =
				DataGridViewSelectionMode.FullRowSelect;
		}

		/// <summary>
		/// Добавление имен изданий по ГОСТ в таблицу при загрузке формы
		/// </summary>
		private void SearchForm_Load(object sender, EventArgs e)
		{
			Editions.ForEach(x => gridEditions.Rows.Add(x.StandartName));
			cmbParameters.DataSource = parameters;
		}

		/// <summary>
		/// Метод осуществляет поиск издания 
		/// по атрибуту, выбранному пользователем
		/// </summary>
		private void btnSearch_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtValue.Text))
			{
				MessageBox.Show("Define what you're searching for..",
					"Please, fill the value",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			else
			{
				string param = cmbParameters.SelectedItem.ToString();
				string value = txtValue.Text;
				List<IEdition> searchResults = new List<IEdition>();

				switch (param)
				{
					case "Authors":
						Editions.ForEach(
							x =>
							{
								x.Authors.ForEach(a => System.Diagnostics.Debug.WriteLine(a.ToString()));
								if (x.Authors.Any(p => p.ToString().Contains(value)))
									searchResults.Add(x);
							});
						break;

					case "Title":
						Editions.ForEach(
							x =>
							{
								if (x.Title.Contains(value))
									searchResults.Add(x);
							});
						break;

					case "Year":
						Editions.ForEach(
							x =>
							{
								if (x.Year.ToString() == value)
									searchResults.Add(x);
							});
						break;
					default:
						break;
				}

				gridEditions.Rows.Clear();
				searchResults.ForEach(
					x => gridEditions.Rows.Add(x.StandartName));
				gridEditions.Update();
				gridEditions.Refresh();
			}
		}
	}
}
