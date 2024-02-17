using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace automated_workstation_for_a_bookstore
{
    public partial class cashbox : Form
    {
        private readonly IConnectionProvider connectionProvider;
        NpgsqlConnection connection;
        public cashbox(IConnectionProvider connectionProvider)
        {
            InitializeComponent();
            this.connectionProvider = connectionProvider;
            connection = connectionProvider.GetConnection();
        }

        private void cashbox_Load(object sender, EventArgs e)
        {

        }

        private void открытьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            redactor redactorForm = new redactor(connectionProvider);
            this.Hide();
            redactorForm.FormClosed += (s, args) => this.Close();
            redactorForm.Show();
        }

        private void открытьВНовойВкладкеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            redactor redactorForm = new redactor(connectionProvider);
            redactorForm.Show();
        }
    }
}
