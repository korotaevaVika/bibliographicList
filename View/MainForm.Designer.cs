namespace View
{
	partial class MainForm
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
			this.groupBoxEditions = new System.Windows.Forms.GroupBox();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.btnRemove = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.gridEditions = new System.Windows.Forms.DataGridView();
			this.btnSearch = new System.Windows.Forms.Button();
			this.groupBoxEditions.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridEditions)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBoxEditions
			// 
			this.groupBoxEditions.Controls.Add(this.btnSearch);
			this.groupBoxEditions.Controls.Add(this.btnRefresh);
			this.groupBoxEditions.Controls.Add(this.btnRemove);
			this.groupBoxEditions.Controls.Add(this.btnAdd);
			this.groupBoxEditions.Controls.Add(this.gridEditions);
			this.groupBoxEditions.Location = new System.Drawing.Point(22, 22);
			this.groupBoxEditions.Margin = new System.Windows.Forms.Padding(6);
			this.groupBoxEditions.Name = "groupBoxEditions";
			this.groupBoxEditions.Padding = new System.Windows.Forms.Padding(6);
			this.groupBoxEditions.Size = new System.Drawing.Size(1069, 395);
			this.groupBoxEditions.TabIndex = 0;
			this.groupBoxEditions.TabStop = false;
			this.groupBoxEditions.Text = "Available editions";
			// 
			// btnRefresh
			// 
			this.btnRefresh.Location = new System.Drawing.Point(487, 331);
			this.btnRefresh.Margin = new System.Windows.Forms.Padding(6);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(226, 42);
			this.btnRefresh.TabIndex = 3;
			this.btnRefresh.Text = "Refresh";
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// btnRemove
			// 
			this.btnRemove.Location = new System.Drawing.Point(249, 332);
			this.btnRemove.Margin = new System.Windows.Forms.Padding(6);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(226, 42);
			this.btnRemove.TabIndex = 2;
			this.btnRemove.Text = "Remove Edition";
			this.btnRemove.UseVisualStyleBackColor = true;
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(13, 332);
			this.btnAdd.Margin = new System.Windows.Forms.Padding(6);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(226, 42);
			this.btnAdd.TabIndex = 1;
			this.btnAdd.Text = "Add Edition";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// gridEditions
			// 
			this.gridEditions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridEditions.Location = new System.Drawing.Point(13, 37);
			this.gridEditions.Margin = new System.Windows.Forms.Padding(6);
			this.gridEditions.Name = "gridEditions";
			this.gridEditions.ReadOnly = true;
			this.gridEditions.Size = new System.Drawing.Size(1036, 282);
			this.gridEditions.TabIndex = 0;
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(725, 331);
			this.btnSearch.Margin = new System.Windows.Forms.Padding(6);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(226, 42);
			this.btnSearch.TabIndex = 4;
			this.btnSearch.Text = "Search";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1107, 436);
			this.Controls.Add(this.groupBoxEditions);
			this.Margin = new System.Windows.Forms.Padding(6);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Bibliographic List";
			this.Activated += new System.EventHandler(this.MainForm_Activated);
			this.groupBoxEditions.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridEditions)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBoxEditions;
		private System.Windows.Forms.Button btnRemove;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.DataGridView gridEditions;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.Button btnSearch;
	}
}