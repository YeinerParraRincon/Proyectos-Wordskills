namespace SESION
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
            button1 = new Button();
            button2 = new Button();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label6 = new Label();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(148, 32);
            label1.Name = "label1";
            label1.Size = new Size(60, 20);
            label1.TabIndex = 5;
            label1.Text = "OrderId";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(92, 105);
            label2.Name = "label2";
            label2.Size = new Size(116, 20);
            label2.TabIndex = 6;
            label2.Text = "Costumer Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(115, 168);
            label3.Name = "label3";
            label3.Size = new Size(83, 20);
            label3.TabIndex = 7;
            label3.Text = "Order Date";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(99, 219);
            label4.Name = "label4";
            label4.Size = new Size(99, 20);
            label4.TabIndex = 8;
            label4.Text = "Total Amount";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(107, 275);
            label5.Name = "label5";
            label5.Size = new Size(91, 20);
            label5.TabIndex = 9;
            label5.Text = "Order Status";
            // 
            // button1
            // 
            button1.Location = new Point(205, 575);
            button1.Name = "button1";
            button1.Size = new Size(160, 29);
            button1.TabIndex = 11;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(408, 575);
            button2.Name = "button2";
            button2.Size = new Size(160, 29);
            button2.TabIndex = 12;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(278, 32);
            label7.Name = "label7";
            label7.Size = new Size(0, 20);
            label7.TabIndex = 14;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(278, 105);
            label8.Name = "label8";
            label8.Size = new Size(0, 20);
            label8.TabIndex = 15;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(278, 178);
            label9.Name = "label9";
            label9.Size = new Size(0, 20);
            label9.TabIndex = 16;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(270, 228);
            label10.Name = "label10";
            label10.Size = new Size(0, 20);
            label10.TabIndex = 17;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(278, 275);
            label11.Name = "label11";
            label11.Size = new Size(0, 20);
            label11.TabIndex = 18;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Cursor = Cursors.Hand;
            label6.Location = new Point(99, 321);
            label6.Name = "label6";
            label6.Size = new Size(135, 20);
            label6.TabIndex = 19;
            label6.Text = " Actualizar Estado :";
            label6.Click += label6_Click;
            // 
            // button3
            // 
            button3.Location = new Point(240, 321);
            button3.Name = "button3";
            button3.Size = new Size(109, 29);
            button3.TabIndex = 20;
            button3.Text = "Procesando";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(240, 356);
            button4.Name = "button4";
            button4.Size = new Size(109, 29);
            button4.TabIndex = 21;
            button4.Text = "Completado";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(240, 391);
            button5.Name = "button5";
            button5.Size = new Size(109, 29);
            button5.TabIndex = 22;
            button5.Text = "Cancelado";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 640);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(label6);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form5";
            Text = "Order Details View";
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
        private Button button1;
        private Button button2;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label6;
        private Button button3;
        private Button button4;
        private Button button5;
    }
}