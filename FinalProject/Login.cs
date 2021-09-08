using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Uidtb.Text=="" ||PassTb.Text=="")
            {
                MessageBox.Show("Enter user name or user password");
            }
            else if (Uidtb.Text == "Admin" && PassTb.Text =="Admin123")
            {
                this.Hide();
                Home home = new Home();
                home.Show();
            }
            else if (Uidtb.Text == "Employee" && PassTb.Text == "Employee123")
            {
                this.Hide();
                Home home = new Home();
                home.Show();
            }
            else
            {
                MessageBox.Show("Wrong user name or Password");
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
