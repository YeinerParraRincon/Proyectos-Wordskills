namespace SESSION5
{
    partial class Form3
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
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            button2 = new Button();
            button1 = new Button();
            textBox2 = new TextBox();
            numericUpDown1 = new NumericUpDown();
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            dateTimePicker1 = new DateTimePicker();
            numericUpDown2 = new NumericUpDown();
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(205, 345);
            label6.Name = "label6";
            label6.Size = new Size(85, 20);
            label6.TabIndex = 32;
            label6.Text = "Description";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(217, 217);
            label5.Name = "label5";
            label5.Size = new Size(41, 20);
            label5.TabIndex = 31;
            label5.Text = "Date";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(217, 166);
            label4.Name = "label4";
            label4.Size = new Size(38, 20);
            label4.TabIndex = 30;
            label4.Text = "Cost";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(217, 122);
            label3.Name = "label3";
            label3.Size = new Size(42, 20);
            label3.TabIndex = 29;
            label3.Text = "price";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(186, 76);
            label2.Name = "label2";
            label2.Size = new Size(104, 20);
            label2.TabIndex = 28;
            label2.Text = "Product Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(217, 33);
            label1.Name = "label1";
            label1.Size = new Size(69, 20);
            label1.TabIndex = 27;
            label1.Text = "Category";
            // 
            // button2
            // 
            button2.Location = new Point(469, 485);
            button2.Name = "button2";
            button2.Size = new Size(127, 37);
            button2.TabIndex = 26;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(296, 485);
            button1.Name = "button1";
            button1.Size = new Size(127, 37);
            button1.TabIndex = 25;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(296, 342);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(319, 124);
            textBox2.TabIndex = 24;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(312, 115);
            numericUpDown1.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(284, 27);
            numericUpDown1.TabIndex = 23;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(495, 281);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(90, 24);
            checkBox2.TabIndex = 22;
            checkBox2.Text = "Seasonal";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(312, 281);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(72, 24);
            checkBox1.TabIndex = 21;
            checkBox1.Text = "Active";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(308, 217);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(288, 27);
            dateTimePicker1.TabIndex = 20;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(308, 159);
            numericUpDown2.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(288, 27);
            numericUpDown2.TabIndex = 19;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(312, 73);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(284, 27);
            textBox1.TabIndex = 18;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(312, 30);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(284, 28);
            comboBox1.TabIndex = 17;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 552);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(numericUpDown1);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(dateTimePicker1);
            Controls.Add(numericUpDown2);
            Controls.Add(textBox1);
            Controls.Add(comboBox1);
            Name = "Form3";
            Text = "Form3";
            Load += Form3_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button button2;
        private Button button1;
        private TextBox textBox2;
        private NumericUpDown numericUpDown1;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private DateTimePicker dateTimePicker1;
        private NumericUpDown numericUpDown2;
        private TextBox textBox1;
        private ComboBox comboBox1;
    }
}