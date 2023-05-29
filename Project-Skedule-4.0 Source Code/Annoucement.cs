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
    public partial class Announcement : Form
    {
        public Announcement()
        {
            InitializeComponent();
        }



        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OleDb.16.0; Data Source =skdl.accdb");

        OleDbCommand cmd = new OleDbCommand();

        OleDbDataAdapter adapter = new OleDbDataAdapter();

        DataTable dt;

        void fill_announcement()
        {
            try
            {
                conn = new OleDbConnection("Provider=Microsoft.ACE.OleDb.16.0; Data Source =skdl.accdb");

                dt = new DataTable();


                adapter = new OleDbDataAdapter("SELECT * FROM notice_table", conn);



                conn.Open();


                adapter.Fill(dt);


                 dgw_announce.DataSource = dt;


                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if(SystemManage.id== SystemManage.CR_id)
            {

                try
                {
                    string query = "INSERT INTO notice_table (notice) VALUES" + "(@ntc)";


                    cmd = new OleDbCommand(query, conn);


                    cmd.Parameters.AddWithValue("@ntc", txt_notice.Text);





                    conn.Open();


                    cmd.ExecuteNonQuery();


                    conn.Close();


                    MessageBox.Show("Announcement Declared!");


                    fill_announcement();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("You are not the CR");
            }

            txt_notice.Clear();

           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Announcement_Load(object sender, EventArgs e)
        {
            fill_announcement();
        }
        string f;
        private void dgw_announce_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                f = dgw_announce.CurrentRow.Cells[0].Value.ToString();
            }
            catch
            {
                f = "No announcement to delete!";
            }
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            if (f != "No announcement to delete!")
            {
                try
                {

                    string query = "DELETE FROM notice_table where UID=@id";



                    cmd = new OleDbCommand(query, conn);



                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(f));


                    conn.Open();


                    cmd.ExecuteNonQuery();


                    conn.Close();


                    MessageBox.Show("Announcement Deleted!");


                    fill_announcement();
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
