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
    public partial class Routine : Form
    {
        public Routine()
        {
            InitializeComponent();
        }
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OleDb.16.0; Data Source =skdl.accdb");

        OleDbCommand cmd = new OleDbCommand();

        OleDbDataAdapter adapter = new OleDbDataAdapter();

        DataTable dt;

        void fill_routine()
        {
            try
            {
                conn = new OleDbConnection("Provider=Microsoft.ACE.OleDb.16.0; Data Source =skdl.accdb");

                dt = new DataTable();


                adapter = new OleDbDataAdapter("SELECT * FROM routine_table where st_id=" + SystemManage.id + "", conn);



                conn.Open();


                adapter.Fill(dt);


                dgw_routine.DataSource = dt;


                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            string _subject = subjecttext.Text;
            string _date = dateTimePicker1.Text.ToString();
            string _room = roomtext.Text;
            string _time = timetext.Text;
            string _teacher = teachertext.Text;
            string _day= daytext.Text;

            try
            {
                string t = "INSERT INTO routine_table (Day_,Date_,Room_no,Time_,Teacher_,Subject_,st_id) VALUES" + "(@day,@_date,@room,@times,@teacher,@sub,@id)";

                cmd = new OleDbCommand(t, conn);


                cmd.Parameters.AddWithValue("@_day", _day);

                cmd.Parameters.AddWithValue("@_date", _date);

                cmd.Parameters.AddWithValue("@room", _room);

                cmd.Parameters.AddWithValue("@times", _time);

                cmd.Parameters.AddWithValue("@teacher", _teacher);

                cmd.Parameters.AddWithValue("@sub", _subject);


                cmd.Parameters.AddWithValue("@id", SystemManage.id);


                conn.Open();


                cmd.ExecuteNonQuery();


                conn.Close();


                MessageBox.Show("Class date is set");


                fill_routine();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            subjecttext.Clear();
            roomtext.Clear();
            timetext.Clear();
            teachertext.Clear();
            daytext.Clear();
        }

       private void btn_update_Click(object sender, EventArgs e)
        {
            string _subject = subjecttext.Text;
            string _date = dateTimePicker1.Text.ToString();
            string _room = roomtext.Text;
            string _time = timetext.Text;
            string _teacher = teachertext.Text;
            string _day = daytext.Text;

            if (f != "No quiz Left!")
            {
                try
                {
                    string query = "Update routine_table SET Subject_=@sub,Date_=@_dt,Room_no=@room,Time_=@time,Teacher_=@teacher_,Day_=@day where Serial=@sl";

                    cmd = new OleDbCommand(query, conn);

                    cmd.Parameters.AddWithValue("@sub", _subject);
                    cmd.Parameters.AddWithValue("@teacher", _teacher);
                    cmd.Parameters.AddWithValue("@room", _room);
                    cmd.Parameters.AddWithValue("@time", _time);
                    cmd.Parameters.AddWithValue("@day",_day );
                    cmd.Parameters.AddWithValue("@_dt", _date);

                    cmd.Parameters.AddWithValue("@sl", f);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    fill_routine();
                    MessageBox.Show("Routine info Updated!");


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
        

        private void btn_remove_Click(object sender, EventArgs e)
        {
            if (f != "No class Left!")
            {
                try
                {
                    string query = "DELETE FROM routine_table where serial=@sl";

                    cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("@sl", Convert.ToInt32(f));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Class Deleted!");

                    fill_routine();

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

        private void Routine_Load(object sender, EventArgs e)
        {
            fill_routine();
        }

        private void dgw_routine_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                f = dgw_routine.CurrentRow.Cells[0].Value.ToString();
            }
            catch
            {
                f = "No class Left!";
            }
        }

        private void dgw_routine_AutoSizeColumnsModeChanged(object sender, DataGridViewAutoSizeColumnsModeEventArgs e)
        {

        }

        private void buttondash_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Dashboard().Show();
        }
    }
}
