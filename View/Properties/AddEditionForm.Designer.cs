namespace View.Properties
{
	partial class AddEditionForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.lblEditionType = new System.Windows.Forms.Label();
			this.cmbEditionTypes = new System.Windows.Forms.ComboBox();
			this.lblTitle = new System.Windows.Forms.Label();
			this.lblPublishingHouse = new System.Windows.Forms.Label();
			this.txtTitle = new System.Windows.Forms.TextBox();
			this.txtPublishingHouse = new System.Windows.Forms.TextBox();
			this.txtCity = new System.Windows.Forms.TextBox();
			this.lblYear = new System.Windows.Forms.Label();
			this.lblCity = new System.Windows.Forms.Label();
			this.lblNumPages = new System.Windows.Forms.Label();
			this.cmbLanguages = new System.Windows.Forms.ComboBox();
			this.lblLanguage = new System.Windows.Forms.Label();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnCreateRandomData = new System.Windows.Forms.Button();
			this.txtUniversity = new System.Windows.Forms.TextBox();
			this.lblUniversity = new System.Windows.Forms.Label();
			this.lblSpecialityCode = new System.Windows.Forms.Label();
			this.lblDegree = new System.Windows.Forms.Label();
			this.lblAuthors = new System.Windows.Forms.Label();
			this.gridAuthors = new System.Windows.Forms.DataGridView();
			this.txtNumPages = new System.Windows.Forms.MaskedTextBox();
			this.txtYear = new System.Windows.Forms.MaskedTextBox();
			this.txtSpecialityCode = new System.Windows.Forms.MaskedTextBox();
			this.txtDegree = new System.Windows.Forms.TextBox();
			this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.btnAddAuthor = new System.Windows.Forms.Button();
			this.btnRemoveAuthor = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.gridAuthors)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
			this.SuspendLayout();
			// 
			// lblEditionType
			// 
			this.lblEditionType.AutoSize = true;
			this.lblEditionType.Location = new System.Drawing.Point(12, 13);
			this.lblEditionType.Name = "lblEditionType";
			this.lblEditionType.Size = new System.Drawing.Size(66, 13);
			this.lblEditionType.TabIndex = 0;
			this.lblEditionType.Text = "Edition Type";
			// 
			// cmbEditionTypes
			// 
			this.cmbEditionTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEditionTypes.FormattingEnabled = true;
			this.cmbEditionTypes.Location = new System.Drawing.Point(128, 10);
			this.cmbEditionTypes.Name = "cmbEditionTypes";
			this.cmbEditionTypes.Size = new System.Drawing.Size(138, 21);
			this.cmbEditionTypes.TabIndex = 1;
			this.cmbEditionTypes.SelectedIndexChanged += new System.EventHandler(this.cmbEditionTypes_SelectedIndexChanged);
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Location = new System.Drawing.Point(12, 40);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(27, 13);
			this.lblTitle.TabIndex = 2;
			this.lblTitle.Text = "Title";
			// 
			// lblPublishingHouse
			// 
			this.lblPublishingHouse.AutoSize = true;
			this.lblPublishingHouse.Location = new System.Drawing.Point(12, 148);
			this.lblPublishingHouse.Name = "lblPublishingHouse";
			this.lblPublishingHouse.Size = new System.Drawing.Size(89, 13);
			this.lblPublishingHouse.TabIndex = 4;
			this.lblPublishingHouse.Text = "Publishing House";
			// 
			// txtTitle
			// 
			this.txtTitle.Location = new System.Drawing.Point(128, 37);
			this.txtTitle.Name = "txtTitle";
			this.txtTitle.Size = new System.Drawing.Size(413, 20);
			this.txtTitle.TabIndex = 6;
			// 
			// txtPublishingHouse
			// 
			this.txtPublishingHouse.Location = new System.Drawing.Point(128, 145);
			this.txtPublishingHouse.Name = "txtPublishingHouse";
			this.txtPublishingHouse.Size = new System.Drawing.Size(199, 20);
			this.txtPublishingHouse.TabIndex = 7;
			// 
			// txtCity
			// 
			this.txtCity.Location = new System.Drawing.Point(128, 91);
			this.txtCity.Name = "txtCity";
			this.txtCity.Size = new System.Drawing.Size(199, 20);
			this.txtCity.TabIndex = 10;
			// 
			// lblYear
			// 
			this.lblYear.AutoSize = true;
			this.lblYear.Location = new System.Drawing.Point(12, 67);
			this.lblYear.Name = "lblYear";
			this.lblYear.Size = new System.Drawing.Size(29, 13);
			this.lblYear.TabIndex = 9;
			this.lblYear.Text = "Year";
			// 
			// lblCity
			// 
			this.lblCity.AutoSize = true;
			this.lblCity.Location = new System.Drawing.Point(12, 94);
			this.lblCity.Name = "lblCity";
			this.lblCity.Size = new System.Drawing.Size(24, 13);
			this.lblCity.TabIndex = 8;
			this.lblCity.Text = "City";
			// 
			// lblNumPages
			// 
			this.lblNumPages.AutoSize = true;
			this.lblNumPages.Location = new System.Drawing.Point(393, 67);
			this.lblNumPages.Name = "lblNumPages";
			this.lblNumPages.Size = new System.Drawing.Size(88, 13);
			this.lblNumPages.TabIndex = 12;
			this.lblNumPages.Text = "Number of pages";
			// 
			// cmbLanguages
			// 
			this.cmbLanguages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbLanguages.FormattingEnabled = true;
			this.cmbLanguages.Location = new System.Drawing.Point(128, 118);
			this.cmbLanguages.Name = "cmbLanguages";
			this.cmbLanguages.Size = new System.Drawing.Size(138, 21);
			this.cmbLanguages.TabIndex = 15;
			// 
			// lblLanguage
			// 
			this.lblLanguage.AutoSize = true;
			this.lblLanguage.Location = new System.Drawing.Point(12, 121);
			this.lblLanguage.Name = "lblLanguage";
			this.lblLanguage.Size = new System.Drawing.Size(55, 13);
			this.lblLanguage.TabIndex = 14;
			this.lblLanguage.Text = "Language";
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(8, 320);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(174, 23);
			this.btnOk.TabIndex = 16;
			this.btnOk.Text = "Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(188, 320);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(174, 23);
			this.btnCancel.TabIndex = 17;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnCreateRandomData
			// 
			this.btnCreateRandomData.Location = new System.Drawing.Point(368, 320);
			this.btnCreateRandomData.Name = "btnCreateRandomData";
			this.btnCreateRandomData.Size = new System.Drawing.Size(174, 23);
			this.btnCreateRandomData.TabIndex = 18;
			this.btnCreateRandomData.Text = "Create Random Data";
			this.btnCreateRandomData.UseVisualStyleBackColor = true;
			this.btnCreateRandomData.Click += new System.EventHandler(this.btnCreateRandomData_Click);
			// 
			// txtUniversity
			// 
			this.txtUniversity.Location = new System.Drawing.Point(128, 118);
			this.txtUniversity.Name = "txtUniversity";
			this.txtUniversity.Size = new System.Drawing.Size(199, 20);
			this.txtUniversity.TabIndex = 20;
			// 
			// lblUniversity
			// 
			this.lblUniversity.AutoSize = true;
			this.lblUniversity.Location = new System.Drawing.Point(12, 121);
			this.lblUniversity.Name = "lblUniversity";
			this.lblUniversity.Size = new System.Drawing.Size(53, 13);
			this.lblUniversity.TabIndex = 19;
			this.lblUniversity.Text = "University";
			// 
			// lblSpecialityCode
			// 
			this.lblSpecialityCode.AutoSize = true;
			this.lblSpecialityCode.Location = new System.Drawing.Point(12, 175);
			this.lblSpecialityCode.Name = "lblSpecialityCode";
			this.lblSpecialityCode.Size = new System.Drawing.Size(80, 13);
			this.lblSpecialityCode.TabIndex = 23;
			this.lblSpecialityCode.Text = "Speciality Code";
			// 
			// lblDegree
			// 
			this.lblDegree.AutoSize = true;
			this.lblDegree.Location = new System.Drawing.Point(12, 148);
			this.lblDegree.Name = "lblDegree";
			this.lblDegree.Size = new System.Drawing.Size(42, 13);
			this.lblDegree.TabIndex = 21;
			this.lblDegree.Text = "Degree";
			// 
			// lblAuthors
			// 
			this.lblAuthors.AutoSize = true;
			this.lblAuthors.Location = new System.Drawing.Point(12, 202);
			this.lblAuthors.Name = "lblAuthors";
			this.lblAuthors.Size = new System.Drawing.Size(43, 13);
			this.lblAuthors.TabIndex = 25;
			this.lblAuthors.Text = "Authors";
			// 
			// gridAuthors
			// 
			this.gridAuthors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridAuthors.GridColor = System.Drawing.SystemColors.ControlLight;
			this.gridAuthors.Location = new System.Drawing.Point(128, 199);
			this.gridAuthors.MultiSelect = false;
			this.gridAuthors.Name = "gridAuthors";
			this.gridAuthors.Size = new System.Drawing.Size(414, 87);
			this.gridAuthors.TabIndex = 26;
			// 
			// txtNumPages
			// 
			this.txtNumPages.Location = new System.Drawing.Point(509, 66);
			this.txtNumPages.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.txtNumPages.Mask = "0000";
			this.txtNumPages.Name = "txtNumPages";
			this.txtNumPages.Size = new System.Drawing.Size(30, 20);
			this.txtNumPages.TabIndex = 27;
			this.txtNumPages.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
			// 
			// txtYear
			// 
			this.txtYear.Location = new System.Drawing.Point(128, 64);
			this.txtYear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.txtYear.Mask = "0000";
			this.txtYear.Name = "txtYear";
			this.txtYear.Size = new System.Drawing.Size(30, 20);
			this.txtYear.TabIndex = 28;
			this.txtYear.ValidatingType = typeof(int);
			// 
			// txtSpecialityCode
			// 
			this.txtSpecialityCode.Location = new System.Drawing.Point(128, 172);
			this.txtSpecialityCode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.txtSpecialityCode.Mask = "00,00,00";
			this.txtSpecialityCode.Name = "txtSpecialityCode";
			this.txtSpecialityCode.Size = new System.Drawing.Size(48, 20);
			this.txtSpecialityCode.TabIndex = 29;
			// 
			// txtDegree
			// 
			this.txtDegree.Location = new System.Drawing.Point(128, 145);
			this.txtDegree.Name = "txtDegree";
			this.txtDegree.Size = new System.Drawing.Size(199, 20);
			this.txtDegree.TabIndex = 22;
			// 
			// errorProvider
			// 
			this.errorProvider.ContainerControl = this;
			// 
			// btnAddAuthor
			// 
			this.btnAddAuthor.Location = new System.Drawing.Point(128, 291);
			this.btnAddAuthor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnAddAuthor.Name = "btnAddAuthor";
			this.btnAddAuthor.Size = new System.Drawing.Size(213, 19);
			this.btnAddAuthor.TabIndex = 30;
			this.btnAddAuthor.Text = "Add author";
			this.btnAddAuthor.UseVisualStyleBackColor = true;
			this.btnAddAuthor.Click += new System.EventHandler(this.btnAddAuthor_Click);
			// 
			// btnRemoveAuthor
			// 
			this.btnRemoveAuthor.Location = new System.Drawing.Point(345, 291);
			this.btnRemoveAuthor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnRemoveAuthor.Name = "btnRemoveAuthor";
			this.btnRemoveAuthor.Size = new System.Drawing.Size(197, 19);
			this.btnRemoveAuthor.TabIndex = 31;
			this.btnRemoveAuthor.Text = "Delete author";
			this.btnRemoveAuthor.UseVisualStyleBackColor = true;
			this.btnRemoveAuthor.Click += new System.EventHandler(this.btnRemoveAuthor_Click);
			// 
			// AddEditionForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(568, 348);
			this.Controls.Add(this.btnRemoveAuthor);
			this.Controls.Add(this.btnAddAuthor);
			this.Controls.Add(this.txtSpecialityCode);
			this.Controls.Add(this.txtYear);
			this.Controls.Add(this.txtNumPages);
			this.Controls.Add(this.gridAuthors);
			this.Controls.Add(this.lblAuthors);
			this.Controls.Add(this.lblSpecialityCode);
			this.Controls.Add(this.txtDegree);
			this.Controls.Add(this.lblDegree);
			this.Controls.Add(this.txtUniversity);
			this.Controls.Add(this.lblUniversity);
			this.Controls.Add(this.btnCreateRandomData);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.cmbLanguages);
			this.Controls.Add(this.lblLanguage);
			this.Controls.Add(this.lblNumPages);
			this.Controls.Add(this.txtCity);
			this.Controls.Add(this.lblYear);
			this.Controls.Add(this.lblCity);
			this.Controls.Add(this.txtPublishingHouse);
			this.Controls.Add(this.txtTitle);
			this.Controls.Add(this.lblPublishingHouse);
			this.Controls.Add(this.lblTitle);
			this.Controls.Add(this.cmbEditionTypes);
			this.Controls.Add(this.lblEditionType);
			this.Name = "AddEditionForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add Edition";
			this.Load += new System.EventHandler(this.AddEditionForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.gridAuthors)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblEditionType;
		private System.Windows.Forms.ComboBox cmbEditionTypes;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Label lblPublishingHouse;
		private System.Windows.Forms.TextBox txtTitle;
		private System.Windows.Forms.TextBox txtPublishingHouse;
		private System.Windows.Forms.TextBox txtCity;
		private System.Windows.Forms.Label lblYear;
		private System.Windows.Forms.Label lblCity;
		private System.Windows.Forms.Label lblNumPages;
		private System.Windows.Forms.ComboBox cmbLanguages;
		private System.Windows.Forms.Label lblLanguage;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnCreateRandomData;
		private System.Windows.Forms.TextBox txtUniversity;
		private System.Windows.Forms.Label lblUniversity;
		private System.Windows.Forms.Label lblSpecialityCode;
		private System.Windows.Forms.Label lblDegree;
		private System.Windows.Forms.Label lblAuthors;
		private System.Windows.Forms.DataGridView gridAuthors;
		private System.Windows.Forms.MaskedTextBox txtNumPages;
		private System.Windows.Forms.MaskedTextBox txtYear;
		private System.Windows.Forms.MaskedTextBox txtSpecialityCode;
		private System.Windows.Forms.TextBox txtDegree;
		private System.Windows.Forms.ErrorProvider errorProvider;
		private System.Windows.Forms.Button btnRemoveAuthor;
		private System.Windows.Forms.Button btnAddAuthor;
	}
}