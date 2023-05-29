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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Skedule_v3
{
    public partial class Quiz : Form
    {
        public Quiz()
        {
            InitializeComponent();
        }

        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OleDb.16.0; Data Source =skdl.accdb");

        OleDbCommand cmd = new OleDbCommand();

        OleDbDataAdapter adapter = new OleDbDataAdapter();

        DataTable dt;

        void fill_quiz()
        {
            try
            {
                conn = new OleDbConnection("Provider=Microsoft.ACE.OleDb.16.0; Data Source =skdl.accdb");

                dt = new DataTable();


                adapter = new OleDbDataAdapter("SELECT * FROM quiz_table where st_id="+SystemManage.id+"", conn);



                conn.Open();


                adapter.Fill(dt);


                dgw_quiz.DataSource = dt;


                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }  


        private void buttonLogin_Click(object sender, EventArgs e)
        {

            string _subject = subjecttext.Text;
            string _quiz_date = dateTimePicker1.Text.ToString();
            string _room = roomtext.Text;
            string _time = timetext.Text;
            string _syllabus = syllabustext.Text;

            try
            {
                string t = "INSERT INTO quiz_table (subject1,quizdate1,roomno1,time1,syllabus1,st_id) VALUES" + "(@sub,@q_date,@room,@times,@syllabuss,@id)";

                cmd = new OleDbCommand(t, conn);

                cmd.Parameters.AddWithValue("@sub", _subject);

                cmd.Parameters.AddWithValue("@q_date", _quiz_date);

                cmd.Parameters.AddWithValue("@room", _room);

                cmd.Parameters.AddWithValue("@times", _time);

                cmd.Parameters.AddWithValue("@syllabuss", _syllabus);

                cmd.Parameters.AddWithValue("@id",SystemManage.id);


                conn.Open();


                cmd.ExecuteNonQuery();


                conn.Close();


                MessageBox.Show("Quiz/Exam date is set");


                fill_quiz();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            subjecttext.Clear();
            
            roomtext.Clear();
            timetext.Clear();
            syllabustext.Clear();

         
        }

        private void Quiz_Load(object sender, EventArgs e)
        {
            fill_quiz();
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            if (f != "No quiz Left!")
            {
                try
                {
                    string query = "DELETE FROM quiz_table where serial=@sl";

                    cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("@sl", Convert.ToInt32(f));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Quiz Deleted!");

                    fill_quiz();

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

        private void dgw_quiz_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            string _subject = subjecttext.Text;
            string _quiz_date = dateTimePicker1.Text.ToString();
            string _room = roomtext.Text;
            string _time = timetext.Text;
            string _syllabus = syllabustext.Text;
            if (f != "No quiz Left!")
            {
                try
                {
                    string query = "Update quiz_table SET subject1=@sub,quizdate1=@qz_dt,roomno1=@room,time1=@time,syllabus1=@syllabus where Serial=@sl";

                    cmd = new OleDbCommand(query, conn);

                    cmd.Parameters.AddWithValue("@sub", _subject);
                    cmd.Parameters.AddWithValue("@qz_dt", _quiz_date);
                    cmd.Parameters.AddWithValue("@room", _room);
                    cmd.Parameters.AddWithValue("@time", _time);
                    cmd.Parameters.AddWithValue("@syllabus", _syllabus);

                    cmd.Parameters.AddWithValue("@sl", f);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    fill_quiz();
                    MessageBox.Show("Quiz info Updated!");


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

        string f;
        private void dgw_quiz_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                f = dgw_quiz.CurrentRow.Cells[0].Value.ToString();
            }
            catch
            {
                f = "No quiz Left!";
            }

        }

        private void gunaControlBox2_Click(object sender, EventArgs e)
        {

        }

        private void buttondash_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Dashboard().Show();
        }

        private void labelLogin_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void roomtext_TextChanged(object sender, EventArgs e)
        {

        }

        private void syllabustext_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void subjecttext_TextChanged(object sender, EventArgs e)
        {

        }

        private void timetext_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void gunaControlBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
