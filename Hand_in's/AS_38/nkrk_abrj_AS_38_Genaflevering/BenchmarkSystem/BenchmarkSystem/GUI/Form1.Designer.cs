namespace BenchmarkSystem.GUI
{
	partial class Form1
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.jobIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.useruserIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.numberOfDelaysDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dBJobSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
			this.benchmarkDBDataSet1 = new BenchmarkDBDataSet1();
			this.dB_JobSetTableAdapter = new BenchmarkDBDataSet1TableAdapters.DB_JobSetTableAdapter();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dBJobSetBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.benchmarkDBDataSet1)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button1.Location = new System.Drawing.Point(12, 265);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "New job";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button2.Location = new System.Drawing.Point(93, 265);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "Refresh";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.AutoGenerateColumns = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.jobIdDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.useruserIdDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.numberOfDelaysDataGridViewTextBoxColumn});
			this.dataGridView1.DataSource = this.dBJobSetBindingSource;
			this.dataGridView1.Location = new System.Drawing.Point(13, 13);
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.Size = new System.Drawing.Size(557, 246);
			this.dataGridView1.TabIndex = 3;
			this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
			// 
			// jobIdDataGridViewTextBoxColumn
			// 
			this.jobIdDataGridViewTextBoxColumn.DataPropertyName = "jobId";
			this.jobIdDataGridViewTextBoxColumn.HeaderText = "jobId";
			this.jobIdDataGridViewTextBoxColumn.Name = "jobIdDataGridViewTextBoxColumn";
			this.jobIdDataGridViewTextBoxColumn.ReadOnly = true;
			this.jobIdDataGridViewTextBoxColumn.Width = 60;
			// 
			// statusDataGridViewTextBoxColumn
			// 
			this.statusDataGridViewTextBoxColumn.DataPropertyName = "status";
			this.statusDataGridViewTextBoxColumn.HeaderText = "status";
			this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
			this.statusDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// useruserIdDataGridViewTextBoxColumn
			// 
			this.useruserIdDataGridViewTextBoxColumn.DataPropertyName = "user_userId";
			this.useruserIdDataGridViewTextBoxColumn.HeaderText = "user_userId";
			this.useruserIdDataGridViewTextBoxColumn.Name = "useruserIdDataGridViewTextBoxColumn";
			this.useruserIdDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// typeDataGridViewTextBoxColumn
			// 
			this.typeDataGridViewTextBoxColumn.DataPropertyName = "type";
			this.typeDataGridViewTextBoxColumn.HeaderText = "type";
			this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
			this.typeDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// numberOfDelaysDataGridViewTextBoxColumn
			// 
			this.numberOfDelaysDataGridViewTextBoxColumn.DataPropertyName = "numberOfDelays";
			this.numberOfDelaysDataGridViewTextBoxColumn.HeaderText = "numberOfDelays";
			this.numberOfDelaysDataGridViewTextBoxColumn.Name = "numberOfDelaysDataGridViewTextBoxColumn";
			this.numberOfDelaysDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// dBJobSetBindingSource
			// 
			this.dBJobSetBindingSource.DataMember = "DB_JobSet";
			this.dBJobSetBindingSource.DataSource = this.bindingSource1;
			// 
			// bindingSource1
			// 
			this.bindingSource1.DataSource = this.benchmarkDBDataSet1;
			this.bindingSource1.Position = 0;
			// 
			// benchmarkDBDataSet1
			// 
			this.benchmarkDBDataSet1.DataSetName = "BenchmarkDBDataSet1";
			this.benchmarkDBDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// dB_JobSetTableAdapter
			// 
			this.dB_JobSetTableAdapter.ClearBeforeFill = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 300);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximumSize = new System.Drawing.Size(600, 5000);
			this.MinimumSize = new System.Drawing.Size(600, 270);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dBJobSetBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.benchmarkDBDataSet1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.BindingSource bindingSource1;
		private BenchmarkDBDataSet1 benchmarkDBDataSet1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.BindingSource dBJobSetBindingSource;
		private BenchmarkDBDataSet1TableAdapters.DB_JobSetTableAdapter dB_JobSetTableAdapter;
		private System.Windows.Forms.DataGridViewTextBoxColumn jobIdDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn useruserIdDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn numberOfDelaysDataGridViewTextBoxColumn;
	}
}