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
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnLoad = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnSearch = new System.Windows.Forms.Button();
			this.btnRemove = new System.Windows.Forms.Button();
			this.gridEditions = new System.Windows.Forms.DataGridView();
			this.groupBoxEditions.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridEditions)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBoxEditions
			// 
			this.groupBoxEditions.AutoSize = true;
			this.groupBoxEditions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.groupBoxEditions.Controls.Add(this.panel1);
			this.groupBoxEditions.Controls.Add(this.gridEditions);
			this.groupBoxEditions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBoxEditions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.groupBoxEditions.Location = new System.Drawing.Point(0, 0);
			this.groupBoxEditions.Margin = new System.Windows.Forms.Padding(6);
			this.groupBoxEditions.Name = "groupBoxEditions";
			this.groupBoxEditions.Padding = new System.Windows.Forms.Padding(6);
			this.groupBoxEditions.Size = new System.Drawing.Size(1128, 390);
			this.groupBoxEditions.TabIndex = 0;
			this.groupBoxEditions.TabStop = false;
			this.groupBoxEditions.Text = "Available editions";
			// 
			// panel1
			// 
			this.panel1.AutoSize = true;
			this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panel1.Controls.Add(this.btnLoad);
			this.panel1.Controls.Add(this.btnSave);
			this.panel1.Controls.Add(this.btnAdd);
			this.panel1.Controls.Add(this.btnSearch);
			this.panel1.Controls.Add(this.btnRemove);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(6, 312);
			this.panel1.Margin = new System.Windows.Forms.Padding(6);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(9);
			this.panel1.Size = new System.Drawing.Size(1116, 72);
			this.panel1.TabIndex = 5;
			// 
			// btnLoad
			// 
			this.btnLoad.Location = new System.Drawing.Point(754, 14);
			this.btnLoad.Margin = new System.Windows.Forms.Padding(6);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new System.Drawing.Size(175, 42);
			this.btnLoad.TabIndex = 6;
			this.btnLoad.Text = "Load";
			this.btnLoad.UseVisualStyleBackColor = true;
			this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(567, 14);
			this.btnSave.Margin = new System.Windows.Forms.Padding(6);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(175, 42);
			this.btnSave.TabIndex = 5;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(6, 15);
			this.btnAdd.Margin = new System.Windows.Forms.Padding(6);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(175, 42);
			this.btnAdd.TabIndex = 1;
			this.btnAdd.Text = "Add Edition";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(380, 14);
			this.btnSearch.Margin = new System.Windows.Forms.Padding(6);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(175, 42);
			this.btnSearch.TabIndex = 4;
			this.btnSearch.Text = "Search";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// btnRemove
			// 
			this.btnRemove.Location = new System.Drawing.Point(193, 14);
			this.btnRemove.Margin = new System.Windows.Forms.Padding(6);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(175, 42);
			this.btnRemove.TabIndex = 2;
			this.btnRemove.Text = "Remove Edition";
			this.btnRemove.UseVisualStyleBackColor = true;
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// gridEditions
			// 
			this.gridEditions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridEditions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridEditions.Location = new System.Drawing.Point(13, 37);
			this.gridEditions.Margin = new System.Windows.Forms.Padding(6);
			this.gridEditions.Name = "gridEditions";
			this.gridEditions.ReadOnly = true;
			this.gridEditions.Size = new System.Drawing.Size(1109, 277);
			this.gridEditions.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1128, 390);
			this.Controls.Add(this.groupBoxEditions);
			this.Margin = new System.Windows.Forms.Padding(6);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Bibliographic List";
			this.Activated += new System.EventHandler(this.MainForm_Activated);
			this.groupBoxEditions.ResumeLayout(false);
			this.groupBoxEditions.PerformLayout();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridEditions)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBoxEditions;
		private System.Windows.Forms.Button btnRemove;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.DataGridView gridEditions;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnLoad;
		private System.Windows.Forms.Button btnSave;
	}
}