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
        string User,Pics;
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

      
        private void button1_Click(object sender, EventArgs e)
        {
            a.Connection();
            a.Execute("Insert into Events (Name,Date,Pictures,Description,Username) Values('" + textBox1.Text + "','" + dateTimePicker1.Text + "','" + Pics + "','" + textBox3.Text + "','" + User + "')");
            MessageBox.Show("Event addess successfully");
            a.ConClose();
        }

        private void AllDrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            Folders.Items.Clear();

            try
            {
                DriveInfo deive = (DriveInfo)AllDrives.SelectedItem;

                foreach (DirectoryInfo drinfo in deive.RootDirectory.GetDirectories())

                    Folders.Items.Add(drinfo);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Folders_SelectedIndexChanged(object sender, EventArgs e)
        {
            Files.Items.Clear();
            try
            {
                DirectoryInfo drin = (DirectoryInfo)Folders.SelectedItem;
                foreach (FileInfo fl in drin.GetFiles())
                    Files.Items.Add(fl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddEvents_Load(object sender, EventArgs e)
        {
            foreach (DriveInfo drv in DriveInfo.GetDrives())
                AllDrives.Items.Add(drv);
        }

        private void Files_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fname = Files.SelectedItem.ToString();
          // string fname=""+ Files.SelectedItem + "";
           string fullPath = Path.GetFullPath(fname).ToString();
            Pics = fullPath;
            
          
        }
    }
}
