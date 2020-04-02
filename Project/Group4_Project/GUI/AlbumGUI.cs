using Group4_Project.DAL;
using Group4_Project.DTL;
using Group4_Project.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Group4_Project.DAL;
using Lab3.DTL;

namespace Group4_Project.GUI
{
    public partial class AlbumGUI : Form
    {
        DataTable dt_list = new DataTable();
        int check = 0;
        int accountid = 0;
        Account a = new Account(2, "Quan", "Nguyen", "Ha Noi", "Ha Noi", "Hoa Lac", "Viet Nam", "0966 848 112","quannd@gmail.com", "1");
        public AlbumGUI()
        {
            dt_list.Columns.Add(new DataColumn("albumid", typeof(int)));
            dt_list.Columns.Add(new DataColumn("title", typeof(string)));
            dt_list.Columns.Add(new DataColumn("price", typeof(float)));
            dt_list.Columns.Add(new DataColumn("albumurl", typeof(string)));
            dt_list.Columns.Add(new DataColumn("amount", typeof(int)));

            InitializeComponent();
            //get Genres
            DataTable dt = GenreDAO.getAllGenres();
            DataRow r = dt.NewRow();
            r["genreid"] = -1;
            r["name"] = "----- ALL -----";
            dt.Rows.Add(r);

            comboBox1.DataSource = dt; 
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "genreid";

            comboBox1.SelectedIndex = dt.Rows.Count - 1;

            // get Arits

            DataTable dt1 = ArtistDAO.getAllArtist();
            DataRow r1 = dt1.NewRow();
            r1["artistid"] = -1;
            r1["name"] = "----- ALL -----";
            dt1.Rows.Add(r1);

            comboBox2.DataSource = dt1;
            comboBox2.DisplayMember = "name";
            comboBox2.ValueMember = "artistid";


            comboBox2.SelectedIndex = dt1.Rows.Count - 1;

            loadData();
        }

        public void loadData()
        {
            lbName.Text = "Hello, " + a.firstname + " " + a.lastname;
            check++;
            try
            {
                if(check > 4)
                {
                    int genreid = int.Parse(comboBox1.SelectedValue.ToString());
                    int artistid = int.Parse(comboBox2.SelectedValue.ToString());
                    DataTable dt = AlbumDAO.GetAlbum(genreid, artistid);
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = dt;
                }     
            }
            catch (Exception ex)
            {
                return;
            }
            
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0 )
            {
                bool check = true;
                foreach (DataRow rd1 in dt_list.Rows)
                {
                    if (rd1["albumid"].ToString() == dataGridView1.Rows[e.RowIndex].Cells["albumid"].Value.ToString())
                    {
                        rd1["amount"] = int.Parse(rd1["amount"].ToString()) + 1;
                        check = false;
                        break;
                    }
                }
                if (check)
                {
                    DataRow rd = dt_list.NewRow();
                    rd[0] = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["albumid"].Value.ToString());
                    rd[1] = dataGridView1.Rows[e.RowIndex].Cells["title"].Value.ToString();
                    rd[2] = float.Parse(dataGridView1.Rows[e.RowIndex].Cells["price"].Value.ToString());
                    rd[3] = dataGridView1.Rows[e.RowIndex].Cells["albumurl"].Value.ToString();
                    rd[4] = 1;
                    dt_list.Rows.Add(rd);
                }
                MessageBox.Show("Add Successfully !!!");
            }
        }

        private void btMyCart_Click(object sender, EventArgs e)
        {
            MyCartForm mc = new MyCartForm(dt_list, a);
            mc.ShowDialog();
        }
    }
}
