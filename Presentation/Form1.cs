﻿using Diery.Access;
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
            a.Connection();
            SqlDataReader reader = this.a.Reader("Select * from Userdata where Username='" + textBox1.Text + "'and Password='" + textBox2.Text + "'");
            
                if (!reader.HasRows)
                {
                    
                MessageBox.Show("Incorrect details");
                a.ConClose();

                }
                else
                {
                Un = textBox1.Text;
                MessageBox.Show("Login successful");
                reader.Close();
                a.ConClose();
                Home h = new Home();
                h.Show();
                this.Hide();
            }
            
           
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
    }
}