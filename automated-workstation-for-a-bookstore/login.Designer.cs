namespace automated_workstation_for_a_bookstore
{
    partial class login
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
            groupBox1 = new GroupBox();
            textBoxIP = new TextBox();
            groupBox2 = new GroupBox();
            textBoxPort = new TextBox();
            groupBox3 = new GroupBox();
            textBoxDatabase = new TextBox();
            groupBox4 = new GroupBox();
            textBoxUser = new TextBox();
            groupBox5 = new GroupBox();
            textBoxPassword = new TextBox();
            CheckConnectionButton = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBoxIP);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(261, 63);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Путь";
            // 
            // textBoxIP
            // 
            textBoxIP.Location = new Point(6, 22);
            textBoxIP.Name = "textBoxIP";
            textBoxIP.Size = new Size(249, 23);
            textBoxIP.TabIndex = 1;
            textBoxIP.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBoxPort);
            groupBox2.Location = new Point(12, 81);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(261, 63);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Порт";
            // 
            // textBoxPort
            // 
            textBoxPort.Location = new Point(6, 22);
            textBoxPort.Name = "textBoxPort";
            textBoxPort.Size = new Size(249, 23);
            textBoxPort.TabIndex = 1;
            textBoxPort.TabStop = false;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(textBoxDatabase);
            groupBox3.Location = new Point(12, 150);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(261, 63);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "База данных";
            // 
            // textBoxDatabase
            // 
            textBoxDatabase.Location = new Point(6, 22);
            textBoxDatabase.Name = "textBoxDatabase";
            textBoxDatabase.Size = new Size(249, 23);
            textBoxDatabase.TabIndex = 1;
            textBoxDatabase.TabStop = false;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(textBoxUser);
            groupBox4.Location = new Point(12, 219);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(261, 63);
            groupBox4.TabIndex = 2;
            groupBox4.TabStop = false;
            groupBox4.Text = "Пользователь";
            // 
            // textBoxUser
            // 
            textBoxUser.Location = new Point(6, 22);
            textBoxUser.Name = "textBoxUser";
            textBoxUser.Size = new Size(249, 23);
            textBoxUser.TabIndex = 1;
            textBoxUser.TabStop = false;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(textBoxPassword);
            groupBox5.Location = new Point(12, 288);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(261, 63);
            groupBox5.TabIndex = 2;
            groupBox5.TabStop = false;
            groupBox5.Text = "Пароль";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(6, 22);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(249, 23);
            textBoxPassword.TabIndex = 1;
            // 
            // CheckConnectionButton
            // 
            CheckConnectionButton.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            CheckConnectionButton.Location = new Point(12, 357);
            CheckConnectionButton.Name = "CheckConnectionButton";
            CheckConnectionButton.Size = new Size(261, 63);
            CheckConnectionButton.TabIndex = 3;
            CheckConnectionButton.Text = "Проверить соединение";
            CheckConnectionButton.UseVisualStyleBackColor = true;
            CheckConnectionButton.Click += CheckConnectionButton_Click;
            // 
            // login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(287, 433);
            Controls.Add(CheckConnectionButton);
            Controls.Add(groupBox2);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox5);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Логин";
            Load += login_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox textBoxIP;
        private GroupBox groupBox2;
        private TextBox textBoxPort;
        private GroupBox groupBox3;
        private TextBox textBoxDatabase;
        private GroupBox groupBox4;
        private TextBox textBoxUser;
        private GroupBox groupBox5;
        private TextBox textBoxPassword;
        private Button CheckConnectionButton;
    }
}