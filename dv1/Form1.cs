using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace dv1
{
    public partial class Form1 : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public Form1()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=login.accdb;Persist Security Info = False;";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select * from logindatabase where Username = '" + usernametext.Text + "' and Password='" + passwordtext.Text + "'";
            OleDbDataReader reader = command.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count = count + 1;
            }
            if (count == 1)
            {
                checkConnection.Text = "Connection Success";
                MessageBox.Show("Welcome to Lab");
                connection.Close();
                this.FormClosing -= new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
                Application.Exit();
            }
            if (count > 1)
            {
                MessageBox.Show("Duplicate Username and Password");
            }
            else
            {
                MessageBox.Show("Wrong Username and Password");
                checkConnection.Text = "Connection Failed";
            }
            connection.Close();



        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }




    }
}
