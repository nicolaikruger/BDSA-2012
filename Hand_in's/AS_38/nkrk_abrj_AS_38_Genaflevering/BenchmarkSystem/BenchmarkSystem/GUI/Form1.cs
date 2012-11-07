using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BenchmarkSystem.GUI
{
	public partial class Form1 : Form
	{

        public Form2 form2;
		public Form1()
		{
			InitializeComponent();
			form2 = new Form2();
		}

		private void button1_Click(object sender, EventArgs e)
		{
           form2.ShowDialog(this);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			// TODO: This line of code loads data into the 'benchmarkDBDataSet1.DB_JobSet' table. You can move, or remove it, as needed.
			this.dB_JobSetTableAdapter.ClearBeforeFill = true;
			this.dB_JobSetTableAdapter.Fill(this.benchmarkDBDataSet1.DB_JobSet);
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.dB_JobSetTableAdapter.Fill(this.benchmarkDBDataSet1.DB_JobSet);
		}
	}
}
