namespace automated_workstation_for_a_bookstore
{
    partial class orders
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
            refresh_button = new Button();
            dataGridView1 = new DataGridView();
            groupBox2 = new GroupBox();
            ordertime_label = new Label();
            orderlist_label = new Label();
            ordercost_label = new Label();
            orderid_label = new Label();
            menuStrip1 = new MenuStrip();
            кассаToolStripMenuItem = new ToolStripMenuItem();
            открытьToolStripMenuItem = new ToolStripMenuItem();
            открытьВНовойВкладкеToolStripMenuItem = new ToolStripMenuItem();
            редакторToolStripMenuItem = new ToolStripMenuItem();
            открытьToolStripMenuItem1 = new ToolStripMenuItem();
            открытьВНовойВкладкеToolStripMenuItem1 = new ToolStripMenuItem();
            чекиToolStripMenuItem = new ToolStripMenuItem();
            открытьToolStripMenuItem2 = new ToolStripMenuItem();
            открытьВНовойВкладкеToolStripMenuItem2 = new ToolStripMenuItem();
            print_button = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox2.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(refresh_button);
            groupBox1.Controls.Add(dataGridView1);
            groupBox1.Location = new Point(12, 37);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(462, 564);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Чеки";
            // 
            // refresh_button
            // 
            refresh_button.Location = new Point(13, 530);
            refresh_button.Name = "refresh_button";
            refresh_button.Size = new Size(114, 28);
            refresh_button.TabIndex = 1;
            refresh_button.Text = "Обновить";
            refresh_button.UseVisualStyleBackColor = true;
            refresh_button.Click += refresh_button_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(13, 22);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(439, 502);
            dataGridView1.TabIndex = 0;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(print_button);
            groupBox2.Controls.Add(ordertime_label);
            groupBox2.Controls.Add(orderlist_label);
            groupBox2.Controls.Add(ordercost_label);
            groupBox2.Controls.Add(orderid_label);
            groupBox2.Location = new Point(480, 37);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(599, 564);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Просмотр";
            // 
            // ordertime_label
            // 
            ordertime_label.AutoSize = true;
            ordertime_label.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            ordertime_label.Location = new Point(18, 65);
            ordertime_label.Name = "ordertime_label";
            ordertime_label.Size = new Size(39, 20);
            ordertime_label.TabIndex = 3;
            ordertime_label.Text = "time";
            ordertime_label.Visible = false;
            // 
            // orderlist_label
            // 
            orderlist_label.AutoSize = true;
            orderlist_label.Font = new Font("Segoe UI", 10.25F, FontStyle.Regular, GraphicsUnit.Point);
            orderlist_label.Location = new Point(198, 34);
            orderlist_label.MinimumSize = new Size(390, 520);
            orderlist_label.Name = "orderlist_label";
            orderlist_label.Size = new Size(390, 520);
            orderlist_label.TabIndex = 2;
            orderlist_label.Text = "books";
            orderlist_label.Visible = false;
            // 
            // ordercost_label
            // 
            ordercost_label.AutoSize = true;
            ordercost_label.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            ordercost_label.Location = new Point(17, 96);
            ordercost_label.Name = "ordercost_label";
            ordercost_label.Size = new Size(36, 20);
            ordercost_label.TabIndex = 1;
            ordercost_label.Text = "cost";
            ordercost_label.Visible = false;
            // 
            // orderid_label
            // 
            orderid_label.AutoSize = true;
            orderid_label.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            orderid_label.Location = new Point(17, 34);
            orderid_label.Name = "orderid_label";
            orderid_label.Size = new Size(22, 20);
            orderid_label.TabIndex = 0;
            orderid_label.Text = "id";
            orderid_label.Visible = false;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { кассаToolStripMenuItem, редакторToolStripMenuItem, чекиToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1091, 24);
            menuStrip1.TabIndex = 4;
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
            открытьToolStripMenuItem.Click += открытьToolStripMenuItem_Click;
            // 
            // открытьВНовойВкладкеToolStripMenuItem
            // 
            открытьВНовойВкладкеToolStripMenuItem.Name = "открытьВНовойВкладкеToolStripMenuItem";
            открытьВНовойВкладкеToolStripMenuItem.Size = new Size(213, 22);
            открытьВНовойВкладкеToolStripMenuItem.Text = "Открыть в новой вкладке";
            открытьВНовойВкладкеToolStripMenuItem.Click += открытьВНовойВкладкеToolStripMenuItem_Click;
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
            // чекиToolStripMenuItem
            // 
            чекиToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { открытьToolStripMenuItem2, открытьВНовойВкладкеToolStripMenuItem2 });
            чекиToolStripMenuItem.Name = "чекиToolStripMenuItem";
            чекиToolStripMenuItem.Size = new Size(46, 20);
            чекиToolStripMenuItem.Text = "Чеки";
            // 
            // открытьToolStripMenuItem2
            // 
            открытьToolStripMenuItem2.Name = "открытьToolStripMenuItem2";
            открытьToolStripMenuItem2.Size = new Size(213, 22);
            открытьToolStripMenuItem2.Text = "Открыть";
            // 
            // открытьВНовойВкладкеToolStripMenuItem2
            // 
            открытьВНовойВкладкеToolStripMenuItem2.Name = "открытьВНовойВкладкеToolStripMenuItem2";
            открытьВНовойВкладкеToolStripMenuItem2.Size = new Size(213, 22);
            открытьВНовойВкладкеToolStripMenuItem2.Text = "Открыть в новой вкладке";
            // 
            // print_button
            // 
            print_button.Location = new Point(6, 530);
            print_button.Name = "print_button";
            print_button.Size = new Size(114, 28);
            print_button.TabIndex = 2;
            print_button.Text = "Печать";
            print_button.UseVisualStyleBackColor = true;
            print_button.Click += print_button_Click;
            // 
            // orders
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1091, 613);
            Controls.Add(menuStrip1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "orders";
            Text = "orders";
            Load += orders_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private DataGridView dataGridView1;
        private GroupBox groupBox2;
        private Label ordertime_label;
        private Label orderlist_label;
        private Label ordercost_label;
        private Label orderid_label;
        private Button refresh_button;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem кассаToolStripMenuItem;
        private ToolStripMenuItem открытьToolStripMenuItem;
        private ToolStripMenuItem открытьВНовойВкладкеToolStripMenuItem;
        private ToolStripMenuItem редакторToolStripMenuItem;
        private ToolStripMenuItem открытьToolStripMenuItem1;
        private ToolStripMenuItem открытьВНовойВкладкеToolStripMenuItem1;
        private ToolStripMenuItem чекиToolStripMenuItem;
        private ToolStripMenuItem открытьToolStripMenuItem2;
        private ToolStripMenuItem открытьВНовойВкладкеToolStripMenuItem2;
        private Button print_button;
    }
}