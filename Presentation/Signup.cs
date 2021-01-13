using Diery.Access;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diery.Presentation
{
    public partial class Signup : Form
    {
        Entri a;
        public Signup()
        {
            InitializeComponent();
            this.a = new Entri();
        }

        private void Signup_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

       public void AddUser()
        {
           // a.Connection();
            a.Execute("Insert into Userdata (Username,Password,MobileNo) Values('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"')");
            
           // a.ConClose();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            a.Connection();

            SqlDataReader reader = this.a.Reader("Select * from Userdata where Username='"+textBox1.Text+"'");
            if (!reader.HasRows)
            {
               
                reader.Close();
                AddUser();
                a.ConClose();
                MessageBox.Show("User created Successfully");
                Thread.Sleep(2000);
                Form1 f1 = new Form1();
                f1.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("There is already a User with this name");
                reader.Close();
                a.ConClose();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
    }
}
