namespace BenchmarkSystem.GUI
{
	partial class Form2
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
<<<<<<< HEAD
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(163, 26);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(100, 20);
			this.textBox1.TabIndex = 0;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(163, 62);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(100, 20);
			this.textBox2.TabIndex = 1;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(163, 103);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(100, 20);
			this.textBox3.TabIndex = 2;
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(163, 140);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(100, 20);
			this.textBox4.TabIndex = 3;
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(163, 184);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(100, 20);
			this.textBox5.TabIndex = 4;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(56, 211);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 5;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(163, 210);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 6;
			this.button2.Text = "button2";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// Form2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(275, 246);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox5);
			this.Controls.Add(this.textBox4);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Name = "Form2";
			this.Text = "Form2";
			this.Load += new System.EventHandler(this.Form2_Load);
			this.ResumeLayout(false);
			this.PerformLayout();
=======
            this.owner = new System.Windows.Forms.Label();
            this.cpu_combobox = new System.Windows.Forms.ComboBox();
            this.owner_text = new System.Windows.Forms.TextBox();
            this.number_of_cpu = new System.Windows.Forms.Label();
            this.runtime = new System.Windows.Forms.Label();
            this.runtime_text = new System.Windows.Forms.TextBox();
            this.okay = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // owner
            // 
            this.owner.AutoSize = true;
            this.owner.Location = new System.Drawing.Point(12, 22);
            this.owner.Name = "owner";
            this.owner.Size = new System.Drawing.Size(41, 13);
            this.owner.TabIndex = 0;
            this.owner.Text = "Owner:";
            // 
            // cpu_combobox
            // 
            this.cpu_combobox.FormattingEnabled = true;
            this.cpu_combobox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cpu_combobox.Location = new System.Drawing.Point(116, 52);
            this.cpu_combobox.Name = "cpu_combobox";
            this.cpu_combobox.Size = new System.Drawing.Size(67, 21);
            this.cpu_combobox.TabIndex = 1;
            // 
            // owner_text
            // 
            this.owner_text.Location = new System.Drawing.Point(116, 22);
            this.owner_text.Name = "owner_text";
            this.owner_text.Size = new System.Drawing.Size(67, 20);
            this.owner_text.TabIndex = 2;
            // 
            // number_of_cpu
            // 
            this.number_of_cpu.AutoSize = true;
            this.number_of_cpu.Location = new System.Drawing.Point(12, 52);
            this.number_of_cpu.Name = "number_of_cpu";
            this.number_of_cpu.Size = new System.Drawing.Size(81, 13);
            this.number_of_cpu.TabIndex = 3;
            this.number_of_cpu.Text = "Number of CPU";
            // 
            // runtime
            // 
            this.runtime.AutoSize = true;
            this.runtime.Location = new System.Drawing.Point(12, 91);
            this.runtime.Name = "runtime";
            this.runtime.Size = new System.Drawing.Size(49, 13);
            this.runtime.TabIndex = 4;
            this.runtime.Text = "Runtime:";
            // 
            // runtime_text
            // 
            this.runtime_text.Location = new System.Drawing.Point(116, 91);
            this.runtime_text.Name = "runtime_text";
            this.runtime_text.Size = new System.Drawing.Size(67, 20);
            this.runtime_text.TabIndex = 5;
            // 
            // okay
            // 
            this.okay.Location = new System.Drawing.Point(15, 147);
            this.okay.Name = "okay";
            this.okay.Size = new System.Drawing.Size(75, 23);
            this.okay.TabIndex = 6;
            this.okay.Text = "Create job";
            this.okay.UseVisualStyleBackColor = true;
            this.okay.Click += new System.EventHandler(this.okay_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(108, 147);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 7;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 184);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.okay);
            this.Controls.Add(this.runtime_text);
            this.Controls.Add(this.runtime);
            this.Controls.Add(this.number_of_cpu);
            this.Controls.Add(this.owner_text);
            this.Controls.Add(this.cpu_combobox);
            this.Controls.Add(this.owner);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.Text = "New job";
            this.ResumeLayout(false);
            this.PerformLayout();
>>>>>>> Created form2 and added functionality to it

		}

		#endregion

<<<<<<< HEAD
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
=======
        private System.Windows.Forms.Label owner;
        private System.Windows.Forms.ComboBox cpu_combobox;
        private System.Windows.Forms.TextBox owner_text;
        private System.Windows.Forms.Label number_of_cpu;
        private System.Windows.Forms.Label runtime;
        private System.Windows.Forms.TextBox runtime_text;
        private System.Windows.Forms.Button okay;
        private System.Windows.Forms.Button cancel;
>>>>>>> Created form2 and added functionality to it
	}
}