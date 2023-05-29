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
    public partial class Assignment : Form
    {
        public Assignment()
        {
            InitializeComponent();
        }

        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OleDb.16.0; Data Source =skdl.accdb");

        OleDbCommand cmd = new OleDbCommand();

        OleDbDataAdapter adapter = new OleDbDataAdapter();

        DataTable dt;

        void fill_assignment()
        {
            try
            {
                conn = new OleDbConnection("Provider=Microsoft.ACE.OleDb.16.0; Data Source =skdl.accdb");

                dt = new DataTable();


                adapter = new OleDbDataAdapter("SELECT * FROM assignment_table where st_id=" + SystemManage.id + "", conn);



                conn.Open();


                adapter.Fill(dt);


                dgw_assignment.DataSource = dt;


                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Assignment_Load(object sender, EventArgs e)
        {
            fill_assignment();
        }


        private void addButton_Click(object sender, EventArgs e)
        {
            string _subject = subjecttext.Text;
            string _deadline = dateTimePicker1.Text.ToString();
            string _teacher = teachertext.Text;
            string _task = tasktext.Text;

            try
            {
                string t = "INSERT INTO assignment_table (Subject,Deadline,Teacher,Task,st_id) VALUES" + "(@sub,@q_date,@teacher,@task,@id)";

                cmd = new OleDbCommand(t, conn);

                cmd.Parameters.AddWithValue("@sub", _subject);

                cmd.Parameters.AddWithValue("@q_date",_deadline);

                cmd.Parameters.AddWithValue("@teacher", _teacher);

                cmd.Parameters.AddWithValue("@task", _task);

                

                cmd.Parameters.AddWithValue("@id", SystemManage.id);


                conn.Open();


                cmd.ExecuteNonQuery();


                conn.Close();


                MessageBox.Show("Assignment is set");


                fill_assignment();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            subjecttext.Clear();

            teachertext.Clear();
            subjecttext.Clear();
            tasktext.Clear();

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            string _subject = subjecttext.Text;
            string _deadline = dateTimePicker1.Text.ToString();
            string _teacher = teachertext.Text;
            string _task = tasktext.Text;


            if (f != "No assignment Left!")
            {
                try
                {
                    string query = "Update assignment_table SET Subject=@sub,Deadline=@qz_dt,Teacher=@teacher,Task=@task where Serial=@sl";

                    cmd = new OleDbCommand(query, conn);

                    cmd.Parameters.AddWithValue("@sub", _subject);
                    cmd.Parameters.AddWithValue("@qz_dt", _deadline);
                    cmd.Parameters.AddWithValue("@teacher", _teacher);
                    
                    cmd.Parameters.AddWithValue("@task", _task);

                    cmd.Parameters.AddWithValue("@sl", f);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    fill_assignment();
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

        private void btn_remove_Click(object sender, EventArgs e)
        {
            if (f != "No assignment Left!")
            {
                try
                {
                    string query = "DELETE FROM assignment_table where serial=@sl";

                    cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("@sl", Convert.ToInt32(f));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Assignment Deleted!");

                    fill_assignment();

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
        private void dgw_assignment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                f = dgw_assignment.CurrentRow.Cells[0].Value.ToString();
            }
            catch
            {
                f = "No assignment Left!";
            }

        }

        private void buttondash_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Dashboard().Show();
        }
    }
}
