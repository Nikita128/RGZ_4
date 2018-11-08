namespace RGZ_4
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label6 = new System.Windows.Forms.Label();
            this.x2TextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.x1TextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nTextBox = new System.Windows.Forms.TextBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nl2RadioButton = new System.Windows.Forms.RadioButton();
            this.nl1RadioButton = new System.Windows.Forms.RadioButton();
            this.l2RadioButton = new System.Windows.Forms.RadioButton();
            this.l1RadioButton = new System.Windows.Forms.RadioButton();
            this.adaptButton = new System.Windows.Forms.Button();
            this.showButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(118, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "u кон.";
            // 
            // x2TextBox
            // 
            this.x2TextBox.Location = new System.Drawing.Point(160, 68);
            this.x2TextBox.Name = "x2TextBox";
            this.x2TextBox.Size = new System.Drawing.Size(52, 20);
            this.x2TextBox.TabIndex = 28;
            this.x2TextBox.Text = "5";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "u нач.";
            // 
            // x1TextBox
            // 
            this.x1TextBox.Location = new System.Drawing.Point(57, 68);
            this.x1TextBox.Name = "x1TextBox";
            this.x1TextBox.Size = new System.Drawing.Size(50, 20);
            this.x1TextBox.TabIndex = 26;
            this.x1TextBox.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Область определения:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Размер выборки n";
            // 
            // nTextBox
            // 
            this.nTextBox.Location = new System.Drawing.Point(131, 11);
            this.nTextBox.Name = "nTextBox";
            this.nTextBox.Size = new System.Drawing.Size(81, 20);
            this.nTextBox.TabIndex = 23;
            this.nTextBox.Text = "100";
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(17, 168);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(99, 41);
            this.generateButton.TabIndex = 22;
            this.generateButton.Text = "Сгенерировать";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Параметры аддитивной помехи:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "d";
            // 
            // dTextBox
            // 
            this.dTextBox.Location = new System.Drawing.Point(147, 124);
            this.dTextBox.Name = "dTextBox";
            this.dTextBox.Size = new System.Drawing.Size(65, 20);
            this.dTextBox.TabIndex = 19;
            this.dTextBox.Text = "0,6";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "m";
            // 
            // mTextBox
            // 
            this.mTextBox.Location = new System.Drawing.Point(42, 124);
            this.mTextBox.Name = "mTextBox";
            this.mTextBox.Size = new System.Drawing.Size(65, 20);
            this.mTextBox.TabIndex = 17;
            this.mTextBox.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nl2RadioButton);
            this.groupBox1.Controls.Add(this.nl1RadioButton);
            this.groupBox1.Controls.Add(this.l2RadioButton);
            this.groupBox1.Controls.Add(this.l1RadioButton);
            this.groupBox1.Location = new System.Drawing.Point(232, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(154, 117);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выбор объекта";
            // 
            // nl2RadioButton
            // 
            this.nl2RadioButton.AutoSize = true;
            this.nl2RadioButton.Location = new System.Drawing.Point(17, 88);
            this.nl2RadioButton.Name = "nl2RadioButton";
            this.nl2RadioButton.Size = new System.Drawing.Size(99, 17);
            this.nl2RadioButton.TabIndex = 31;
            this.nl2RadioButton.TabStop = true;
            this.nl2RadioButton.Text = "y = 0.7sin(x) + 1";
            this.nl2RadioButton.UseVisualStyleBackColor = true;
            this.nl2RadioButton.CheckedChanged += new System.EventHandler(this.nl2RadioButton_CheckedChanged);
            // 
            // nl1RadioButton
            // 
            this.nl1RadioButton.AutoSize = true;
            this.nl1RadioButton.Location = new System.Drawing.Point(17, 65);
            this.nl1RadioButton.Name = "nl1RadioButton";
            this.nl1RadioButton.Size = new System.Drawing.Size(97, 17);
            this.nl1RadioButton.TabIndex = 32;
            this.nl1RadioButton.TabStop = true;
            this.nl1RadioButton.Text = "y = 3x^2 - x + 5";
            this.nl1RadioButton.UseVisualStyleBackColor = true;
            this.nl1RadioButton.CheckedChanged += new System.EventHandler(this.nl1RadioButton_CheckedChanged);
            // 
            // l2RadioButton
            // 
            this.l2RadioButton.AutoSize = true;
            this.l2RadioButton.Location = new System.Drawing.Point(17, 42);
            this.l2RadioButton.Name = "l2RadioButton";
            this.l2RadioButton.Size = new System.Drawing.Size(77, 17);
            this.l2RadioButton.TabIndex = 33;
            this.l2RadioButton.TabStop = true;
            this.l2RadioButton.Text = "y = 0.5x - 1";
            this.l2RadioButton.UseVisualStyleBackColor = true;
            this.l2RadioButton.CheckedChanged += new System.EventHandler(this.l2RadioButton_CheckedChanged);
            // 
            // l1RadioButton
            // 
            this.l1RadioButton.AutoSize = true;
            this.l1RadioButton.Location = new System.Drawing.Point(17, 19);
            this.l1RadioButton.Name = "l1RadioButton";
            this.l1RadioButton.Size = new System.Drawing.Size(53, 17);
            this.l1RadioButton.TabIndex = 34;
            this.l1RadioButton.TabStop = true;
            this.l1RadioButton.Text = "y = 6x";
            this.l1RadioButton.UseVisualStyleBackColor = true;
            this.l1RadioButton.CheckedChanged += new System.EventHandler(this.l1RadioButton_CheckedChanged);
            // 
            // adaptButton
            // 
            this.adaptButton.Enabled = false;
            this.adaptButton.Location = new System.Drawing.Point(147, 168);
            this.adaptButton.Name = "adaptButton";
            this.adaptButton.Size = new System.Drawing.Size(107, 41);
            this.adaptButton.TabIndex = 32;
            this.adaptButton.Text = "Скорректировать параметры";
            this.adaptButton.UseVisualStyleBackColor = true;
            this.adaptButton.Click += new System.EventHandler(this.adaptButton_Click);
            // 
            // showButton
            // 
            this.showButton.Enabled = false;
            this.showButton.Location = new System.Drawing.Point(287, 168);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(99, 41);
            this.showButton.TabIndex = 33;
            this.showButton.Text = "Показать график";
            this.showButton.UseVisualStyleBackColor = true;
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 220);
            this.Controls.Add(this.showButton);
            this.Controls.Add(this.adaptButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.x2TextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.x1TextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nTextBox);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mTextBox);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "РГЗ 4";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox x2TextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox x1TextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox nTextBox;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox dTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox mTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton nl2RadioButton;
        private System.Windows.Forms.RadioButton nl1RadioButton;
        private System.Windows.Forms.RadioButton l2RadioButton;
        private System.Windows.Forms.RadioButton l1RadioButton;
        private System.Windows.Forms.Button adaptButton;
        private System.Windows.Forms.Button showButton;
    }
}


