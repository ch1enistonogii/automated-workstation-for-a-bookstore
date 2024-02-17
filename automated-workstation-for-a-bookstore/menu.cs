using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace automated_workstation_for_a_bookstore
{
    public partial class menu : Form
    {
        private readonly IConnectionProvider connectionProvider;

        public menu(IConnectionProvider connectionProvider)
        {
            InitializeComponent();
            this.connectionProvider = connectionProvider;
        }

        private void menu_Load(object sender, EventArgs e)
        {

        }

        private void openCashboxButton_Click(object sender, EventArgs e)
        {
            cashbox cashboxForm = new cashbox(connectionProvider);
            this.Hide();
            cashboxForm.FormClosed += (s, args) => this.Close();
            cashboxForm.Show();
        }

        private void openRedactorButton_Click(object sender, EventArgs e)
        {
            redactor redactorForm = new redactor(connectionProvider);
            this.Hide();
            redactorForm.FormClosed += (s, args) => this.Close();
            redactorForm.Show();
        }
    }
}

