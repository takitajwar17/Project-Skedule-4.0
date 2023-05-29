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

namespace Skedule_v3
{
    public partial class Form1 : Form
    {
       

        public Form1()
        {
            InitializeComponent();
        }


        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OleDb.16.0; Data Source =skdl.accdb");

        OleDbCommand cmd = new OleDbCommand();

        void StudentListReload()
        {
            conn.Close();   

            SystemManage.StudentList.Clear();

            try
            {

                conn.Open();

                string t = " Select * from st_table";

                cmd = new OleDbCommand(t,conn);

                OleDbDataReader dr;

                dr= cmd.ExecuteReader();

                while (dr.Read())
                {

                    Student currentstudent= new Student(dr["email"].ToString(), dr["first_name"].ToString(), dr["last_name"].ToString(),Convert.ToInt32(dr["st_id"]), dr["pass"].ToString());

                    SystemManage.StudentList.Add(currentstudent);
                }
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSignup_Click(object sender, EventArgs e)
        {
            string email = textBoxSignupEmail.Text;
            int studentID = Convert.ToInt32( textBoxSignupUsername.Text);
            string password = textBoxSignupPassword.Text;
            string confirmPassword = textBoxSignupConfirmPass.Text;
            string firstname = textBoxSignupFirstname.Text;
            string lastname = textBoxSignupLastname.Text;
          
            

            if (email != "" && studentID>0 && password != "" && firstname != "" && lastname != "")
            {
                

                if (password == confirmPassword )
                {
                    try
                    {
                        conn.Close();
                        conn.Open();


                        string t = "INSERT INTO st_table (email,st_id,pass,first_name,last_name) VALUES" + "(@email,@u_id,@pass,@f_name,@l_name)";

                        cmd = new OleDbCommand(t, conn);

                        cmd.Parameters.AddWithValue("@email", email);

                        cmd.Parameters.AddWithValue("@u_name", studentID );

                        cmd.Parameters.AddWithValue("@pass", password);

                        cmd.Parameters.AddWithValue("@f_name", firstname);

                        cmd.Parameters.AddWithValue("@l_name", lastname);

                      




                        cmd.ExecuteNonQuery();
                        conn.Close();


                        MessageBox.Show("You've Registered in the System Successfully!");

                        StudentListReload();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                  

                }
            }
            // Clear the signup form
            textBoxSignupEmail.Text = "";
            textBoxSignupUsername.Text = "";
            textBoxSignupPassword.Text = "";
            textBoxSignupConfirmPass.Text = "";
            textBoxSignupFirstname.Text = "";
            textBoxSignupLastname.Text = "";
           
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StudentListReload();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            bool check = false;

            for(int i=0;i<SystemManage.StudentList.Count;i++)
            {
                if (Convert.ToInt32(textBoxLoginUsername.Text) == SystemManage.StudentList[i].studentID  &&  textBoxLoginPassword.Text == SystemManage.StudentList[i].password)
                {
                    SystemManage.id = SystemManage.StudentList[i].studentID;
                    this.Hide();

                   new Dashboard().Show();

                    check= true;

                    break;
                }
            }

            if(!check)
            {
                MessageBox.Show("Invalid UserId or Password!");
            }



        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

     
    }
    
}
