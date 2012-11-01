using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Jobs;

namespace BenchmarkSystem.GUI
{
	public partial class Form2 : Form
	{
        public event Action<Job> JobSubmittedClick;
		public Form2()
		{
			InitializeComponent();
		}

		private void Form2_Load(object sender, EventArgs e)
		{

		}

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
			clearFields();
        }

        private void okay_Click(object sender, EventArgs e)
        {
            Owner owner = new Owner(owner_text.Text);
            int cpu = int.Parse(cpu_combobox.SelectedItem.ToString());
            int runtime = int.Parse(runtime_text.Text);
            Job job = new Job(cpu, runtime, owner, f => "Hello");
            JobSubmittedClick(job);
            this.Hide();
			clearFields();
        }

		private void clearFields()
		{
			owner_text.Text = string.Empty;
			cpu_combobox.SelectedItem = 0;
			runtime_text.Text = string.Empty;
		}
	}
}
