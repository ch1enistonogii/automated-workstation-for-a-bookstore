namespace automated_workstation_for_a_bookstore
{
    partial class addBook
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
            groupBox16 = new GroupBox();
            BookType_comboBox = new ComboBox();
            groupBox15 = new GroupBox();
            BookPubyear_textBox = new TextBox();
            groupBox14 = new GroupBox();
            BookGenre_comboBox = new ComboBox();
            groupBox13 = new GroupBox();
            BookCategory_comboBox = new ComboBox();
            groupBox12 = new GroupBox();
            addbook_button = new Button();
            preview_button = new Button();
            BookID_checkBox = new CheckBox();
            groupBox10 = new GroupBox();
            BookAgelimit_comboBox = new ComboBox();
            groupBox9 = new GroupBox();
            BookLang_comboBox = new ComboBox();
            groupBox8 = new GroupBox();
            BookPubhouse_textBox = new TextBox();
            groupBox7 = new GroupBox();
            BookAuthor_textBox = new TextBox();
            groupBox11 = new GroupBox();
            groupBox5 = new GroupBox();
            BookCost_textBox = new TextBox();
            groupBox6 = new GroupBox();
            openFileDialog_button = new PictureBox();
            ImgPath_textBox = new TextBox();
            groupBox4 = new GroupBox();
            BookName_textBox = new TextBox();
            groupBox3 = new GroupBox();
            BookID_textBox = new TextBox();
            groupBox2 = new GroupBox();
            hidePreview_button = new PictureBox();
            dataGridView1 = new DataGridView();
            openFileDialog1 = new OpenFileDialog();
            groupBox1.SuspendLayout();
            groupBox16.SuspendLayout();
            groupBox15.SuspendLayout();
            groupBox14.SuspendLayout();
            groupBox13.SuspendLayout();
            groupBox12.SuspendLayout();
            groupBox10.SuspendLayout();
            groupBox9.SuspendLayout();
            groupBox8.SuspendLayout();
            groupBox7.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)openFileDialog_button).BeginInit();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)hidePreview_button).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox16);
            groupBox1.Controls.Add(groupBox15);
            groupBox1.Controls.Add(groupBox14);
            groupBox1.Controls.Add(groupBox13);
            groupBox1.Controls.Add(groupBox12);
            groupBox1.Controls.Add(groupBox10);
            groupBox1.Controls.Add(groupBox9);
            groupBox1.Controls.Add(groupBox8);
            groupBox1.Controls.Add(groupBox7);
            groupBox1.Controls.Add(groupBox5);
            groupBox1.Controls.Add(groupBox6);
            groupBox1.Controls.Add(groupBox4);
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1068, 178);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Добавление данных в таблицу \"Книги\"";
            // 
            // groupBox16
            // 
            groupBox16.Controls.Add(BookType_comboBox);
            groupBox16.Location = new Point(598, 101);
            groupBox16.Name = "groupBox16";
            groupBox16.Size = new Size(144, 73);
            groupBox16.TabIndex = 9;
            groupBox16.TabStop = false;
            groupBox16.Text = "Тип обложки";
            // 
            // BookType_comboBox
            // 
            BookType_comboBox.DisplayMember = "Русский язык";
            BookType_comboBox.FormattingEnabled = true;
            BookType_comboBox.Items.AddRange(new object[] { "Твердый переплет", "Мягкая обложка", "Переплет из картона", "Интегральнй переплет", "Суперобложка", "Спираль", "Кожанный переплет", "Твердая Обложка", "Ламинированный картон", "Жесткая подложка", "МДФ" });
            BookType_comboBox.Location = new Point(6, 22);
            BookType_comboBox.Name = "BookType_comboBox";
            BookType_comboBox.Size = new Size(131, 23);
            BookType_comboBox.TabIndex = 2;
            BookType_comboBox.Text = "Твердый переплет";
            // 
            // groupBox15
            // 
            groupBox15.Controls.Add(BookPubyear_textBox);
            groupBox15.Location = new Point(478, 101);
            groupBox15.Name = "groupBox15";
            groupBox15.Size = new Size(114, 73);
            groupBox15.TabIndex = 8;
            groupBox15.TabStop = false;
            groupBox15.Text = "Год издания";
            // 
            // BookPubyear_textBox
            // 
            BookPubyear_textBox.Location = new Point(6, 22);
            BookPubyear_textBox.Name = "BookPubyear_textBox";
            BookPubyear_textBox.Size = new Size(102, 23);
            BookPubyear_textBox.TabIndex = 2;
            // 
            // groupBox14
            // 
            groupBox14.Controls.Add(BookGenre_comboBox);
            groupBox14.Location = new Point(233, 101);
            groupBox14.Name = "groupBox14";
            groupBox14.Size = new Size(239, 73);
            groupBox14.TabIndex = 8;
            groupBox14.TabStop = false;
            groupBox14.Text = "Жанр";
            // 
            // BookGenre_comboBox
            // 
            BookGenre_comboBox.DisplayMember = "Русский язык";
            BookGenre_comboBox.FormattingEnabled = true;
            BookGenre_comboBox.Items.AddRange(new object[] { "Фэнтези", "Роман", "Детективы", "Фантастика", "Поэзия", "Приключения", "Ужасы", "Триллеры", "Проза" });
            BookGenre_comboBox.Location = new Point(5, 22);
            BookGenre_comboBox.Name = "BookGenre_comboBox";
            BookGenre_comboBox.Size = new Size(228, 23);
            BookGenre_comboBox.TabIndex = 3;
            // 
            // groupBox13
            // 
            groupBox13.Controls.Add(BookCategory_comboBox);
            groupBox13.Location = new Point(6, 101);
            groupBox13.Name = "groupBox13";
            groupBox13.Size = new Size(221, 73);
            groupBox13.TabIndex = 8;
            groupBox13.TabStop = false;
            groupBox13.Text = "Категория";
            // 
            // BookCategory_comboBox
            // 
            BookCategory_comboBox.DisplayMember = "Русский язык";
            BookCategory_comboBox.FormattingEnabled = true;
            BookCategory_comboBox.Items.AddRange(new object[] { "Художественная литература", "Психологическая литература", "Детская литература", "Учебники и пособия", "Эзотерика", "Комиксы и графическая литература", "Искусство и культура", "Дом, досуг, хобби" });
            BookCategory_comboBox.Location = new Point(4, 22);
            BookCategory_comboBox.Name = "BookCategory_comboBox";
            BookCategory_comboBox.Size = new Size(211, 23);
            BookCategory_comboBox.TabIndex = 3;
            BookCategory_comboBox.Text = "Художеcтвенная литература";
            BookCategory_comboBox.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // groupBox12
            // 
            groupBox12.Controls.Add(addbook_button);
            groupBox12.Controls.Add(preview_button);
            groupBox12.Controls.Add(BookID_checkBox);
            groupBox12.Location = new Point(956, 0);
            groupBox12.Name = "groupBox12";
            groupBox12.Size = new Size(112, 174);
            groupBox12.TabIndex = 10;
            groupBox12.TabStop = false;
            groupBox12.Text = "Дополнительно";
            // 
            // addbook_button
            // 
            addbook_button.Location = new Point(6, 126);
            addbook_button.Name = "addbook_button";
            addbook_button.Size = new Size(100, 37);
            addbook_button.TabIndex = 2;
            addbook_button.Text = "Добавить";
            addbook_button.UseVisualStyleBackColor = true;
            addbook_button.Click += addbook_button_Click;
            // 
            // preview_button
            // 
            preview_button.Location = new Point(6, 83);
            preview_button.Name = "preview_button";
            preview_button.Size = new Size(100, 37);
            preview_button.TabIndex = 1;
            preview_button.Text = "Предпросмотр";
            preview_button.UseVisualStyleBackColor = true;
            preview_button.Click += preview_button_Click;
            // 
            // BookID_checkBox
            // 
            BookID_checkBox.AutoSize = true;
            BookID_checkBox.Location = new Point(6, 22);
            BookID_checkBox.Name = "BookID_checkBox";
            BookID_checkBox.Size = new Size(68, 19);
            BookID_checkBox.TabIndex = 0;
            BookID_checkBox.Text = "Свой ID";
            BookID_checkBox.UseVisualStyleBackColor = true;
            BookID_checkBox.CheckedChanged += BookIDchecbox_CheckedChanged;
            // 
            // groupBox10
            // 
            groupBox10.Controls.Add(BookAgelimit_comboBox);
            groupBox10.Location = new Point(871, 101);
            groupBox10.Name = "groupBox10";
            groupBox10.Size = new Size(79, 73);
            groupBox10.TabIndex = 8;
            groupBox10.TabStop = false;
            groupBox10.Text = "Возр. огр.";
            // 
            // BookAgelimit_comboBox
            // 
            BookAgelimit_comboBox.DisplayMember = "Русский язык";
            BookAgelimit_comboBox.FormattingEnabled = true;
            BookAgelimit_comboBox.Items.AddRange(new object[] { "18+", "16+", "12+", "6+", "3+", "0+" });
            BookAgelimit_comboBox.Location = new Point(6, 22);
            BookAgelimit_comboBox.Name = "BookAgelimit_comboBox";
            BookAgelimit_comboBox.Size = new Size(67, 23);
            BookAgelimit_comboBox.TabIndex = 1;
            BookAgelimit_comboBox.Text = "18+";
            // 
            // groupBox9
            // 
            groupBox9.Controls.Add(BookLang_comboBox);
            groupBox9.Location = new Point(742, 101);
            groupBox9.Name = "groupBox9";
            groupBox9.Size = new Size(123, 73);
            groupBox9.TabIndex = 7;
            groupBox9.TabStop = false;
            groupBox9.Text = "Язык";
            // 
            // BookLang_comboBox
            // 
            BookLang_comboBox.DisplayMember = "Русский язык";
            BookLang_comboBox.FormattingEnabled = true;
            BookLang_comboBox.Items.AddRange(new object[] { "Русский язык", "Английский язык", "Казахский язык", "Немецкий язык", "Китайский язык", "Французский язык", "Японский язык", "Испанский язык", "Корейский язык" });
            BookLang_comboBox.Location = new Point(6, 22);
            BookLang_comboBox.Name = "BookLang_comboBox";
            BookLang_comboBox.Size = new Size(110, 23);
            BookLang_comboBox.TabIndex = 0;
            BookLang_comboBox.Text = "Русский язык";
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(BookPubhouse_textBox);
            groupBox8.Location = new Point(788, 22);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(162, 73);
            groupBox8.TabIndex = 6;
            groupBox8.TabStop = false;
            groupBox8.Text = "Издатель";
            // 
            // BookPubhouse_textBox
            // 
            BookPubhouse_textBox.Location = new Point(6, 22);
            BookPubhouse_textBox.Name = "BookPubhouse_textBox";
            BookPubhouse_textBox.Size = new Size(150, 23);
            BookPubhouse_textBox.TabIndex = 3;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(BookAuthor_textBox);
            groupBox7.Controls.Add(groupBox11);
            groupBox7.Location = new Point(599, 22);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(183, 73);
            groupBox7.TabIndex = 5;
            groupBox7.TabStop = false;
            groupBox7.Text = "Автор";
            // 
            // BookAuthor_textBox
            // 
            BookAuthor_textBox.Location = new Point(6, 22);
            BookAuthor_textBox.Name = "BookAuthor_textBox";
            BookAuthor_textBox.Size = new Size(171, 23);
            BookAuthor_textBox.TabIndex = 2;
            // 
            // groupBox11
            // 
            groupBox11.Location = new Point(47, 79);
            groupBox11.Name = "groupBox11";
            groupBox11.Size = new Size(130, 73);
            groupBox11.TabIndex = 9;
            groupBox11.TabStop = false;
            groupBox11.Text = "Тип";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(BookCost_textBox);
            groupBox5.Location = new Point(333, 22);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(114, 73);
            groupBox5.TabIndex = 4;
            groupBox5.TabStop = false;
            groupBox5.Text = "Цена";
            // 
            // BookCost_textBox
            // 
            BookCost_textBox.Location = new Point(6, 22);
            BookCost_textBox.Name = "BookCost_textBox";
            BookCost_textBox.Size = new Size(102, 23);
            BookCost_textBox.TabIndex = 1;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(openFileDialog_button);
            groupBox6.Controls.Add(ImgPath_textBox);
            groupBox6.Location = new Point(453, 22);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(140, 73);
            groupBox6.TabIndex = 4;
            groupBox6.TabStop = false;
            groupBox6.Text = "Картинка";
            // 
            // openFileDialog_button
            // 
            openFileDialog_button.BackColor = SystemColors.ActiveBorder;
            openFileDialog_button.Location = new Point(112, 22);
            openFileDialog_button.Name = "openFileDialog_button";
            openFileDialog_button.Size = new Size(22, 23);
            openFileDialog_button.SizeMode = PictureBoxSizeMode.Zoom;
            openFileDialog_button.TabIndex = 10;
            openFileDialog_button.TabStop = false;
            openFileDialog_button.Click += openFileDialog_button_Click_1;
            // 
            // ImgPath_textBox
            // 
            ImgPath_textBox.Location = new Point(6, 22);
            ImgPath_textBox.Name = "ImgPath_textBox";
            ImgPath_textBox.Size = new Size(100, 23);
            ImgPath_textBox.TabIndex = 1;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(BookName_textBox);
            groupBox4.Location = new Point(105, 22);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(222, 73);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "Название";
            // 
            // BookName_textBox
            // 
            BookName_textBox.Location = new Point(6, 22);
            BookName_textBox.Name = "BookName_textBox";
            BookName_textBox.Size = new Size(210, 23);
            BookName_textBox.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(BookID_textBox);
            groupBox3.Location = new Point(6, 22);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(93, 73);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "ID товара";
            // 
            // BookID_textBox
            // 
            BookID_textBox.Enabled = false;
            BookID_textBox.Location = new Point(5, 22);
            BookID_textBox.Name = "BookID_textBox";
            BookID_textBox.Size = new Size(82, 23);
            BookID_textBox.TabIndex = 3;
            BookID_textBox.Text = "0";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(hidePreview_button);
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Location = new Point(12, 196);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1068, 177);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Предпросмотр";
            groupBox2.Visible = false;
            // 
            // hidePreview_button
            // 
            hidePreview_button.Location = new Point(1038, 0);
            hidePreview_button.Name = "hidePreview_button";
            hidePreview_button.Size = new Size(24, 19);
            hidePreview_button.SizeMode = PictureBoxSizeMode.Zoom;
            hidePreview_button.TabIndex = 2;
            hidePreview_button.TabStop = false;
            hidePreview_button.Visible = false;
            hidePreview_button.Click += hidePreview_button_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 22);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 100;
            dataGridView1.Size = new Size(1056, 141);
            dataGridView1.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // addBook
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1086, 195);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "addBook";
            Text = "addBook";
            Load += addBook_Load;
            groupBox1.ResumeLayout(false);
            groupBox16.ResumeLayout(false);
            groupBox15.ResumeLayout(false);
            groupBox15.PerformLayout();
            groupBox14.ResumeLayout(false);
            groupBox13.ResumeLayout(false);
            groupBox12.ResumeLayout(false);
            groupBox12.PerformLayout();
            groupBox10.ResumeLayout(false);
            groupBox9.ResumeLayout(false);
            groupBox8.ResumeLayout(false);
            groupBox8.PerformLayout();
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)openFileDialog_button).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)hidePreview_button).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private DataGridView dataGridView1;
        private CheckBox BookID_checkBox;
        private GroupBox groupBox3;
        private TextBox BookID_textBox;
        private GroupBox groupBox7;
        private GroupBox groupBox5;
        private GroupBox groupBox6;
        private GroupBox groupBox4;
        private GroupBox groupBox10;
        private GroupBox groupBox9;
        private GroupBox groupBox8;
        private GroupBox groupBox11;
        private TextBox BookName_textBox;
        private TextBox BookCost_textBox;
        private TextBox BookAuthor_textBox;
        private TextBox BookPubhouse_textBox;
        private GroupBox groupBox12;
        private GroupBox groupBox15;
        private GroupBox groupBox14;
        private GroupBox groupBox13;
        private GroupBox groupBox16;
        private ComboBox BookLang_comboBox;
        private ComboBox BookAgelimit_comboBox;
        private ComboBox BookType_comboBox;
        private ComboBox BookGenre_comboBox;
        private ComboBox BookCategory_comboBox;
        private OpenFileDialog openFileDialog1;
        private Button addbook_button;
        private Button preview_button;
        private TextBox BookPubyear_textBox;
        private PictureBox hidePreview_button;
        private TextBox ImgPath_textBox;
        private PictureBox openFileDialog_button;
    }
}