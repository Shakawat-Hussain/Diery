using Diery.Access;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diery.Presentation
{
    public partial class AddEvents : Form
    {
        Entri a = new Entri();
        string User;
        public AddEvents()
        {
            InitializeComponent();
            User = Form1.Un;
        }

        private void AddEvents_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

       public void Pics()
        {
            //OpenFileDialog
        }
        private void button1_Click(object sender, EventArgs e)
        {
            a.Connection();
            a.Execute("Insert into Events (Name,Date,Pictures,Description,Username) Values('" + textBox1.Text + "','" + dateTimePicker1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + User + "')");
            MessageBox.Show("Event addess successfully");
            a.ConClose();
        }

    }
}
