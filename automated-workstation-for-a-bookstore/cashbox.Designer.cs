namespace automated_workstation_for_a_bookstore
{
    partial class cashbox
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
            menuStrip1 = new MenuStrip();
            кассаToolStripMenuItem = new ToolStripMenuItem();
            открытьToolStripMenuItem = new ToolStripMenuItem();
            открытьВНовойВкладкеToolStripMenuItem = new ToolStripMenuItem();
            редакторToolStripMenuItem = new ToolStripMenuItem();
            открытьToolStripMenuItem1 = new ToolStripMenuItem();
            открытьВНовойВкладкеToolStripMenuItem1 = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { кассаToolStripMenuItem, редакторToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // кассаToolStripMenuItem
            // 
            кассаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { открытьToolStripMenuItem, открытьВНовойВкладкеToolStripMenuItem });
            кассаToolStripMenuItem.Name = "кассаToolStripMenuItem";
            кассаToolStripMenuItem.Size = new Size(50, 20);
            кассаToolStripMenuItem.Text = "Касса";
            // 
            // открытьToolStripMenuItem
            // 
            открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            открытьToolStripMenuItem.Size = new Size(213, 22);
            открытьToolStripMenuItem.Text = "Открыть";
            // 
            // открытьВНовойВкладкеToolStripMenuItem
            // 
            открытьВНовойВкладкеToolStripMenuItem.Name = "открытьВНовойВкладкеToolStripMenuItem";
            открытьВНовойВкладкеToolStripMenuItem.Size = new Size(213, 22);
            открытьВНовойВкладкеToolStripMenuItem.Text = "Открыть в новой вкладке";
            // 
            // редакторToolStripMenuItem
            // 
            редакторToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { открытьToolStripMenuItem1, открытьВНовойВкладкеToolStripMenuItem1 });
            редакторToolStripMenuItem.Name = "редакторToolStripMenuItem";
            редакторToolStripMenuItem.Size = new Size(69, 20);
            редакторToolStripMenuItem.Text = "Редактор";
            // 
            // открытьToolStripMenuItem1
            // 
            открытьToolStripMenuItem1.Name = "открытьToolStripMenuItem1";
            открытьToolStripMenuItem1.Size = new Size(213, 22);
            открытьToolStripMenuItem1.Text = "Открыть";
            открытьToolStripMenuItem1.Click += открытьToolStripMenuItem1_Click;
            // 
            // открытьВНовойВкладкеToolStripMenuItem1
            // 
            открытьВНовойВкладкеToolStripMenuItem1.Name = "открытьВНовойВкладкеToolStripMenuItem1";
            открытьВНовойВкладкеToolStripMenuItem1.Size = new Size(213, 22);
            открытьВНовойВкладкеToolStripMenuItem1.Text = "Открыть в новой вкладке";
            открытьВНовойВкладкеToolStripMenuItem1.Click += открытьВНовойВкладкеToolStripMenuItem1_Click;
            // 
            // cashbox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            Name = "cashbox";
            Text = "cashbox";
            Load += cashbox_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem кассаToolStripMenuItem;
        private ToolStripMenuItem открытьToolStripMenuItem;
        private ToolStripMenuItem открытьВНовойВкладкеToolStripMenuItem;
        private ToolStripMenuItem редакторToolStripMenuItem;
        private ToolStripMenuItem открытьToolStripMenuItem1;
        private ToolStripMenuItem открытьВНовойВкладкеToolStripMenuItem1;
    }
}