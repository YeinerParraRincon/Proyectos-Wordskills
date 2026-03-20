namespace SESSION5
{
    partial class Form5
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            button1 = new Button();
            button2 = new Button();
            label11 = new Label();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(107, 29);
            label1.Name = "label1";
            label1.Size = new Size(62, 20);
            label1.TabIndex = 0;
            label1.Text = "OrderID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(107, 71);
            label2.Name = "label2";
            label2.Size = new Size(116, 20);
            label2.TabIndex = 1;
            label2.Text = "Costumer Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(107, 117);
            label3.Name = "label3";
            label3.Size = new Size(83, 20);
            label3.TabIndex = 2;
            label3.Text = "Order Date";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(107, 170);
            label4.Name = "label4";
            label4.Size = new Size(99, 20);
            label4.TabIndex = 3;
            label4.Text = "Total Amount";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(107, 216);
            label5.Name = "label5";
            label5.Size = new Size(91, 20);
            label5.TabIndex = 4;
            label5.Text = "Order Status";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(274, 29);
            label6.Name = "label6";
            label6.Size = new Size(0, 20);
            label6.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(274, 71);
            label7.Name = "label7";
            label7.Size = new Size(0, 20);
            label7.TabIndex = 6;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(274, 117);
            label8.Name = "label8";
            label8.Size = new Size(0, 20);
            label8.TabIndex = 7;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(274, 159);
            label9.Name = "label9";
            label9.Size = new Size(0, 20);
            label9.TabIndex = 8;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(274, 216);
            label10.Name = "label10";
            label10.Size = new Size(0, 20);
            label10.TabIndex = 9;
            // 
            // button1
            // 
            button1.Location = new Point(216, 377);
            button1.Name = "button1";
            button1.Size = new Size(159, 61);
            button1.TabIndex = 10;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(406, 377);
            button2.Name = "button2";
            button2.Size = new Size(159, 61);
            button2.TabIndex = 11;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Cursor = Cursors.Hand;
            label11.Location = new Point(107, 254);
            label11.Name = "label11";
            label11.Size = new Size(124, 20);
            label11.TabIndex = 12;
            label11.Text = "Actualizar Estado";
            label11.Click += label11_Click;
            // 
            // button3
            // 
            button3.Location = new Point(237, 254);
            button3.Name = "button3";
            button3.Size = new Size(138, 29);
            button3.TabIndex = 13;
            button3.Text = "Procesando";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(237, 289);
            button4.Name = "button4";
            button4.Size = new Size(138, 29);
            button4.TabIndex = 14;
            button4.Text = "Complete";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(237, 324);
            button5.Name = "button5";
            button5.Size = new Size(138, 29);
            button5.TabIndex = 15;
            button5.Text = "Cancelado";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(label11);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form5";
            Text = "Form5";
            Load += Form5_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Button button1;
        private Button button2;
        private Label label11;
        private Button button3;
        private Button button4;
        private Button button5;
    }
}