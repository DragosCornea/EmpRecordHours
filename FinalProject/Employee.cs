using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace FinalProject
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\corne\OneDrive\Documents\MyEmployeeDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void button1_Click(object sender, EventArgs e)
        {
            if (EmpIdTb.Text == "" || EmpNameTb.Text == "" || EmpPhoneTb.Text == "" || EmpAddCb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into Employeetbl1 values('" + EmpIdTb.Text + "','" + EmpNameTb.Text + "','" + EmpAddCb.Text + "','" + EmpPosCb.SelectedItem.ToString() + "','" + EmpDOB.Value.Date + "','" + EmpPhoneTb.Text + "','" + EmpEduCb.SelectedItem.ToString() + "','" + EmpGenCb.SelectedItem.ToString() + "','" + EmpGateCb.SelectedItem.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Added Successfully");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void populate()
        {
            Con.Open();
            string query = " select * from EmployeeTbl1";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            EmpDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Employee_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (EmpIdTb.Text == "")
            {
                MessageBox.Show("Enter Employee ID");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from EmployeeTbl1 where Empid='" + EmpIdTb.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Deleted Successfully");
                    Con.Close();
                    populate();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void EmpDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EmpIdTb.Text = EmpDGV.SelectedRows[0].Cells[0].Value.ToString();
            EmpNameTb.Text = EmpDGV.SelectedRows[0].Cells[1].Value.ToString();
            EmpAddCb.Text = EmpDGV.SelectedRows[0].Cells[2].Value.ToString();
            EmpPosCb.Text = EmpDGV.SelectedRows[0].Cells[3].Value.ToString();
            EmpDOB.Text = EmpDGV.SelectedRows[0].Cells[4].Value.ToString();
            EmpPhoneTb.Text = EmpDGV.SelectedRows[0].Cells[5].Value.ToString();
            EmpEduCb.Text = EmpDGV.SelectedRows[0].Cells[6].Value.ToString();
            EmpGenCb.Text = EmpDGV.SelectedRows[0].Cells[7].Value.ToString();
            EmpGateCb.Text = EmpDGV.SelectedRows[0].Cells[8].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (EmpIdTb.Text == "" || EmpNameTb.Text == "" || EmpPhoneTb.Text == "" || EmpAddCb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update EmployeeTbl1 set Empname='" + EmpNameTb.Text + "', empadd='" + EmpAddCb.Text + "',emppos='" + EmpPosCb.SelectedItem.ToString() + "',empdob='" + EmpDOB.Value.Date + "',empphone='" + EmpPhoneTb.Text + "',empedu='" + EmpEduCb.SelectedItem.ToString() + "',empgen='" + EmpGenCb.SelectedItem.ToString() + "'where Empid='" + EmpIdTb.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Enmployee Updated Successfully");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
        int duration = 0;// durata in secunde
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            duration++;// incrementam durata pt timer
            TimeSpan t = TimeSpan.FromSeconds(duration);// ne folosim de constructorul timespan pt formatul de h/m/s

            string answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s",
                            t.Hours,
                            t.Minutes,
                            t.Seconds);
            CheckInTb.Text = answer.ToString();//salvam in variabila locala answer formatul 
   
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("Checked Out from Work");
        }

        private void CheckInBtn_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
        }

        private void CheckOutBtn_Click(object sender, EventArgs e)
        {
            timer2.Stop();
        }
    }
}
