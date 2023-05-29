using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skedule_v3
{
    public partial class SelfAssesment : Form
    {
        public SelfAssesment()
        {
            InitializeComponent();
        }
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OleDb.16.0; Data Source =skdl.accdb");

        OleDbCommand cmd = new OleDbCommand();

        OleDbDataAdapter adapter = new OleDbDataAdapter();

        DataTable dt;

        void fill_selfassesment()
        {
            try
            {
                conn = new OleDbConnection("Provider=Microsoft.ACE.OleDb.16.0; Data Source =skdl.accdb");

                dt = new DataTable();


                adapter = new OleDbDataAdapter("SELECT * FROM selfassesment_table where st_id=" + SystemManage.id + "", conn);



                conn.Open();


                adapter.Fill(dt);


                dgw_self.DataSource = dt;


                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void labelLogin_Click(object sender, EventArgs e)
        {

        }

        private void SelfAssesment_Load(object sender, EventArgs e)
        {
            fill_selfassesment();
        }

        string f;
        private void dgw_self_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                f = dgw_self.CurrentRow.Cells[0].Value.ToString();
            }
            catch
            {
                f = "No result Left!";
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string _subject = subjecttext.Text;
            string _quiz = quiztext.Text;
            string _mid= midtext.Text;
            string _final= finaltext.Text;
            string _attendance= attendancetext.Text;

            try
            {
                string t = "INSERT INTO selfassesment_table (Subject,Quiz,Mid,Final,Attendance,st_id) VALUES" + "(@sub1,@quiz,@mid,@final,@attendance,@id)";

                cmd = new OleDbCommand(t, conn);

                cmd.Parameters.AddWithValue("@sub1", _subject);

                cmd.Parameters.AddWithValue("@quiz", _quiz);

                cmd.Parameters.AddWithValue("@mid", _mid);

                cmd.Parameters.AddWithValue("@final", _final);

                cmd.Parameters.AddWithValue("@attendance", _attendance);

                cmd.Parameters.AddWithValue("@id", SystemManage.id);


                conn.Open();


                cmd.ExecuteNonQuery();


                conn.Close();


                MessageBox.Show("ASSESMENT is ADDED");


                fill_selfassesment();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            subjecttext.Clear();
            midtext.Clear();
            attendancetext.Clear();
            finaltext.Clear();
            quiztext.Clear();   

            
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {

            if (f != "No result Left!")
            {
                try
                {
                    string query = "DELETE FROM selfassesment_table where serial=@sl";

                    cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("@sl", Convert.ToInt32(f));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Quiz Deleted!");

                    fill_selfassesment();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show(f);
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            string _subject = subjecttext.Text;
            string _quiz = quiztext.Text;
            string _mid = midtext.Text;
            string _final = finaltext.Text;
            string _attendance = attendancetext.Text;

            if (f != "No quiz Left!")
            {
                try
                {
                    string query = "Update selfassesment_table SET Subject=@sub,Quiz=@qz,Mid=@mid,Final=@final,Attendance=@attendance where Serial=@sl";

                    cmd = new OleDbCommand(query, conn);

                    cmd.Parameters.AddWithValue("@sub", _subject);
                    cmd.Parameters.AddWithValue("@qz", _quiz);
                    cmd.Parameters.AddWithValue("@mid", _mid);
                    cmd.Parameters.AddWithValue("@final", _final);
                    cmd.Parameters.AddWithValue("@attendance", _attendance);

                    cmd.Parameters.AddWithValue("@sl", f);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    fill_selfassesment();
                    MessageBox.Show("Assesment info Updated!");


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show(f);
            }

        }

        private void buttondash_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Dashboard().Show();
        }
    }
}
