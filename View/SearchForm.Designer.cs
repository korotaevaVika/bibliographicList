namespace View
{
	partial class SearchForm
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
			this.groupBoxParameters = new System.Windows.Forms.GroupBox();
			this.btnSearch = new System.Windows.Forms.Button();
			this.txtValue = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbParameters = new System.Windows.Forms.ComboBox();
			this.lblParameter = new System.Windows.Forms.Label();
			this.groupBoxResults = new System.Windows.Forms.GroupBox();
			this.gridEditions = new System.Windows.Forms.DataGridView();
			this.groupBoxParameters.SuspendLayout();
			this.groupBoxResults.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridEditions)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBoxParameters
			// 
			this.groupBoxParameters.Controls.Add(this.btnSearch);
			this.groupBoxParameters.Controls.Add(this.txtValue);
			this.groupBoxParameters.Controls.Add(this.label1);
			this.groupBoxParameters.Controls.Add(this.cmbParameters);
			this.groupBoxParameters.Controls.Add(this.lblParameter);
			this.groupBoxParameters.Location = new System.Drawing.Point(12, 12);
			this.groupBoxParameters.Name = "groupBoxParameters";
			this.groupBoxParameters.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.groupBoxParameters.Size = new System.Drawing.Size(584, 51);
			this.groupBoxParameters.TabIndex = 0;
			this.groupBoxParameters.TabStop = false;
			this.groupBoxParameters.Text = "Search Parameters";
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(502, 23);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(71, 20);
			this.btnSearch.TabIndex = 6;
			this.btnSearch.Text = "Search";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// txtValue
			// 
			this.txtValue.Location = new System.Drawing.Point(286, 23);
			this.txtValue.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.txtValue.Name = "txtValue";
			this.txtValue.Size = new System.Drawing.Size(192, 20);
			this.txtValue.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(247, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(34, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Value";
			// 
			// cmbParameters
			// 
			this.cmbParameters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbParameters.FormattingEnabled = true;
			this.cmbParameters.Location = new System.Drawing.Point(67, 21);
			this.cmbParameters.Name = "cmbParameters";
			this.cmbParameters.Size = new System.Drawing.Size(131, 21);
			this.cmbParameters.TabIndex = 3;
			// 
			// lblParameter
			// 
			this.lblParameter.AutoSize = true;
			this.lblParameter.Location = new System.Drawing.Point(5, 27);
			this.lblParameter.Name = "lblParameter";
			this.lblParameter.Size = new System.Drawing.Size(55, 13);
			this.lblParameter.TabIndex = 2;
			this.lblParameter.Text = "Parameter";
			// 
			// groupBoxResults
			// 
			this.groupBoxResults.Controls.Add(this.gridEditions);
			this.groupBoxResults.Location = new System.Drawing.Point(12, 69);
			this.groupBoxResults.Name = "groupBoxResults";
			this.groupBoxResults.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.groupBoxResults.Size = new System.Drawing.Size(584, 159);
			this.groupBoxResults.TabIndex = 7;
			this.groupBoxResults.TabStop = false;
			this.groupBoxResults.Text = "Search Results";
			// 
			// gridEditions
			// 
			this.gridEditions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridEditions.Location = new System.Drawing.Point(8, 26);
			this.gridEditions.Name = "gridEditions";
			this.gridEditions.ReadOnly = true;
			this.gridEditions.Size = new System.Drawing.Size(565, 128);
			this.gridEditions.TabIndex = 1;
			// 
			// SearchForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(601, 236);
			this.Controls.Add(this.groupBoxResults);
			this.Controls.Add(this.groupBoxParameters);
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "SearchForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Search";
			this.Load += new System.EventHandler(this.SearchForm_Load);
			this.groupBoxParameters.ResumeLayout(false);
			this.groupBoxParameters.PerformLayout();
			this.groupBoxResults.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridEditions)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBoxParameters;
		private System.Windows.Forms.TextBox txtValue;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbParameters;
		private System.Windows.Forms.Label lblParameter;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.GroupBox groupBoxResults;
		private System.Windows.Forms.DataGridView gridEditions;
	}
}