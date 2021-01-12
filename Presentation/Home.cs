﻿using Diery.Access;
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
    public partial class Home : Form
    {
        Entri a;
        Event et = new Event();
        public Home()
        {
            InitializeComponent();
            this.a = new Entri();
        }

        private void Home_Load(object sender, EventArgs e)
        {


            string Person = Form1.Un;
            dataGridView1.DataSource = et.Alllist("Select * from Events where Username='" + Person + "'");
            listBox1.DataSource = et.EventNames();
            foreach (DriveInfo drv in DriveInfo.GetDrives())
                listBox2.Items.Add(drv);
               
            
           
            a.ConClose();

        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string Person = Form1.Un;
            dataGridView1.DataSource = et.Alllist("Select * from Events where Name='" + listBox1.SelectedItem + "'and Username='"+Person+"'");
            //comboBox1.DataSource = listBox1.SelectedItem;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddEvents ad = new AddEvents();
            ad.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            a.Connection();
            a.Execute("Delete from Events where Name='"+listBox1.SelectedItem+"'");
            Home_Load(sender,e);
            a.ConClose();
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            a.Connection();
            a.Execute("Update dbo.Events set " +comboBox1.Text+"='"+textBox1.Text+"' where Name='"+listBox1.SelectedItem+"'");
            Home_Load(sender,e);
            a.ConClose();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            
            try 
            {
                DriveInfo deive = (DriveInfo)listBox2.SelectedItem;
                
                foreach (DirectoryInfo drinfo in deive.RootDirectory.GetDirectories())
                
                    listBox3.Items.Add(drinfo);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
                listBox4.Items.Clear();
                try
                {
                    DirectoryInfo drin = (DirectoryInfo)listBox3.SelectedItem;
                    foreach (FileInfo fl in drin.GetFiles())
                        listBox4.Items.Add(fl);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }

