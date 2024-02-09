namespace automated_workstation_for_a_bookstore
{
    partial class menu
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
            openCashboxButton = new Button();
            openRedactorButton = new Button();
            SuspendLayout();
            // 
            // openCashboxButton
            // 
            openCashboxButton.Location = new Point(125, 161);
            openCashboxButton.Name = "openCashboxButton";
            openCashboxButton.Size = new Size(227, 106);
            openCashboxButton.TabIndex = 0;
            openCashboxButton.Text = "Касса";
            openCashboxButton.UseVisualStyleBackColor = true;
            openCashboxButton.Click += openCashboxButton_Click;
            // 
            // openRedactorButton
            // 
            openRedactorButton.Location = new Point(437, 161);
            openRedactorButton.Name = "openRedactorButton";
            openRedactorButton.Size = new Size(227, 106);
            openRedactorButton.TabIndex = 1;
            openRedactorButton.Text = "Редактор БД";
            openRedactorButton.UseVisualStyleBackColor = true;
            openRedactorButton.Click += openRedactorButton_Click;
            // 
            // menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(openRedactorButton);
            Controls.Add(openCashboxButton);
            Name = "menu";
            Text = "menu";
            Load += menu_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button openCashboxButton;
        private Button openRedactorButton;
    }
}