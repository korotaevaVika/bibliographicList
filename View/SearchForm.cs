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
		public List<IEdition> Editions { get; set; }

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

		private void SearchForm_Load(object sender, EventArgs e)
		{
			Editions.ForEach(x => gridEditions.Rows.Add(x.StandartName));
			cmbParameters.DataSource = parameters;
		}

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
