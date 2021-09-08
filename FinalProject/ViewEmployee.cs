using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace FinalProject
{
    public partial class ViewEmployee : Form
    {
        public ViewEmployee()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\corne\OneDrive\Documents\MyEmployeeTbll.mdf;Integrated Security=True;Connect Timeout=30");
        private void fetchempdata()
        {
            Con.Open();
            string query = "select * from Table where EmpId='" + empidTb.Text + "'";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                empidlbl.Text = dr["Empid"].ToString();
                empnamelbl.Text = dr["Empname"].ToString();
                empaddlbl.Text = dr["Empadd"].ToString();
                empposlbl.Text= dr["Emppos"].ToString();
                empphonelbl.Text = dr["Empphone"].ToString();
                empedulbl.Text = dr["Empedu"].ToString();
                empgenlbl.Text= dr["EmpGen"].ToString();
                empdoblbl.Text = dr["EmpDob"].ToString();

                empidlbl.Visible = true;
                empnamelbl.Visible = true;
                empaddlbl.Visible = true;
                empposlbl.Visible = true;
                empphonelbl.Visible = true;
                empedulbl.Visible = true;
                empgenlbl.Visible = true;
                empdoblbl.Visible = true;

            }
            Con.Close();
        }
        private void ViewEmployee_Load(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fetchempdata();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
    }
}
