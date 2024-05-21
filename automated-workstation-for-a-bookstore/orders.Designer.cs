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
            label1 = new Label();
            groupBox1 = new GroupBox();
            dataGridView1 = new DataGridView();
            groupBox2 = new GroupBox();
            ordertime_label = new Label();
            orderlist_label = new Label();
            ordercost_label = new Label();
            orderid_label = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(25, 36);
            label1.Name = "label1";
            label1.Size = new Size(59, 25);
            label1.TabIndex = 0;
            label1.Text = "Чеки";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dataGridView1);
            groupBox1.Location = new Point(12, 80);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(462, 486);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Чеки";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(13, 22);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(439, 458);
            dataGridView1.TabIndex = 0;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(ordertime_label);
            groupBox2.Controls.Add(orderlist_label);
            groupBox2.Controls.Add(ordercost_label);
            groupBox2.Controls.Add(orderid_label);
            groupBox2.Location = new Point(480, 80);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(599, 486);
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
            // 
            // orderlist_label
            // 
            orderlist_label.AutoSize = true;
            orderlist_label.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            orderlist_label.Location = new Point(232, 34);
            orderlist_label.Name = "orderlist_label";
            orderlist_label.Size = new Size(49, 20);
            orderlist_label.TabIndex = 2;
            orderlist_label.Text = "books";
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
            // 
            // orders
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1091, 613);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "orders";
            Text = "orders";
            Load += orders_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
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
    }
}