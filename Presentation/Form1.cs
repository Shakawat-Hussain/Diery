using Diery.Access;
using Diery.Presentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diery
{
    public partial class Form1 : Form
    {
        Entri a;
        public static string Un;
         public Form1()
        {
            InitializeComponent();
            this.a = new Entri();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string Inf;
            if (checkBox1.Checked)
            {
                Inf = "MobileNo";
                Assgn();
            }
            else
            {
                Inf = "Username";
                Un = textBox1.Text;
            }
            a.Connection();
            SqlDataReader reader = this.a.Reader("Select * from Userdata where "+Inf+"='" + textBox1.Text + "'and Password='" + textBox2.Text + "'");
            
                if (!reader.HasRows)
                {
                    
                MessageBox.Show("Incorrect details");
                a.ConClose();

                }
                else
                {

           
                
               
                MessageBox.Show("Login successful");
                reader.Close();
                a.ConClose();
                Home h = new Home();
                h.Show();
                this.Hide();
            }
            
           
        }
        public void Assgn()
        {
           
            a.Connection();
            SqlDataReader reader = this.a.Reader("Select Username from Userdata where MobileNo ='" + textBox1.Text + "'");
            while (reader.Read())
            {
               
                Un = reader["Username"].ToString();
            }
            
            reader.Close();
            a.ConClose();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Signup s = new Signup();
            s.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("If you want to Login with MobileNo you might check the box");
        }
    }
}
