
using Group4_Lab3.DAL;
using Group4_Lab3.DTL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group4_Lab3.GUI
{
    public partial class BorrowerGUI : Form
    {
        BorrowerDAO m;
        Borrower b;
        public BorrowerGUI()
        {
            InitializeComponent();

            m = new BorrowerDAO();
            showData();
        }

        private void showData()
        {
            DataTable dt = m.getAllMember();
            DataView dv = new DataView(dt);
            dataGridView1.DataSource = dv;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text.Equals("Add"))
            {
                txtAdr.Text = "";
                txtEmail.Text = "";
                txtName.Text = "";
                txtPhone.Text = "";
                txtSex.Text = "";
                btnAdd.Text = "Save";
                txtborrowerNumber.ReadOnly = true;
                txtborrowerNumber.Text = "" + (m.GetBorrowerNumberMax() + 1);
                setBtn(1);
            }
            else
            {
                b = new Borrower(int.Parse(txtborrowerNumber.Text), txtName.Text, Char.Parse(txtSex.Text), txtAdr.Text, txtPhone.Text, txtEmail.Text);
                //b.Name = txtName.Text;
                //b.Address = txtAdr.Text;
                //b.Email = txtEmail.Text;
                //b.Sex = Char.Parse(txtSex.Text);
                //b.Telephone = txtPhone.Text;

                if (m.Insert(b))
                {
                    MessageBox.Show("Add success!!!");
                }
                else { MessageBox.Show("Can't add borrower!!!"); }
                showData();
                btnAdd.Text = "Add";
                txtborrowerNumber.ReadOnly = false;
               
                setBtn(2);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void setReadOnly(Boolean b)
        {
            //txtborrowerNumber.ReadOnly = b;
            txtEmail.ReadOnly = b;
            txtName.ReadOnly = b;
            txtPhone.ReadOnly = b;
            txtSex.ReadOnly = b;
            txtAdr.ReadOnly = b;

        }


        private void setBtn(int c)
        {
            switch (c)
            {
                case 1:

                    setTxtEnable(true);
                    setReadOnly(false);
                    btnDelete.Enabled = false;
                    btnEdit.Enabled = false;
                    btnFilter.Enabled = false;
                    break;
                case 2:
                    setTxtEnable(false);
                    setReadOnly(false);
                    btnDelete.Enabled = !false;
                    btnEdit.Enabled = !false;
                    btnFilter.Enabled = !false;
                    break;
                case 3:

                    setReadOnly(false);
                    btnEdit.Text = "Save";
                    btnDelete.Enabled = false;
                    btnAdd.Enabled = false;
                    btnFilter.Enabled = false;
                    break;
                case 4:
                    setReadOnly(true);
                    btnEdit.Text = "Edit";
                    btnDelete.Enabled = !false;
                    btnAdd.Enabled = !false;
                    btnFilter.Enabled = !false;
                    break;
            }

        }
        private void setTxtEnable(Boolean b)
        {
            //txtborrowerNumber.Enabled = !b;
            txtEmail.Enabled = b;
            txtName.Enabled = b;
            txtPhone.Enabled = b;
            txtSex.Enabled = b;
            txtAdr.Enabled = b;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtborrowerNumber.Text = dataGridView1.Rows[e.RowIndex].Cells["borrowerNumber"].Value.ToString();
            txtName.Text = dataGridView1.Rows[e.RowIndex].Cells["name"].Value.ToString();
            txtPhone.Text = dataGridView1.Rows[e.RowIndex].Cells["telephone"].Value.ToString();
            txtSex.Text = dataGridView1.Rows[e.RowIndex].Cells["sex"].Value.ToString();
            txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells["email"].Value.ToString();
            txtAdr.Text = dataGridView1.Rows[e.RowIndex].Cells["address"].Value.ToString();
            setTxtEnable(true);
            setReadOnly(true);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please chose a row");
                return;
            }
            else
            {
                if (btnEdit.Text.Equals("Edit"))
                {

                    setBtn(3);

                }

                else
                {

                    int borrowerNumber = int.Parse(dataGridView1.SelectedRows[0].Cells["borrowerNumber"].Value.ToString());

                    b = new Borrower(borrowerNumber, txtName.Text, Char.Parse(txtSex.Text), txtAdr.Text, txtPhone.Text, txtEmail.Text);
                    //b.BorrowerNumber = borrowerNumber;
                   // b.Name = txtName.Text;
                    //b.Address = txtAdr.Text;
                    //b.Email = txtEmail.Text;
                    //b.Sex = txtSex.Text;
                    //b.Telephone = txtPhone.Text;
                    if (m.Edit(b))
                    {
                        MessageBox.Show("Edit success");
                        showData();
                    }
                    else
                    {
                        MessageBox.Show("You can Edit this borrower!!!");
                    }
                    setBtn(4);
                }

            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please chose a row");
                return;
            }
            else
            {
                int b = int.Parse(dataGridView1.SelectedRows[0].Cells["borrowerNumber"].Value.ToString());

                DialogResult dr = MessageBox.Show(String.Format("Do you want to delete this Borrower {0}?", b), "Confirm deteting", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No) return;

                if (m.Delete(b))
                {
                    MessageBox.Show("Delete success");
                    showData();
                }
                else
                {
                    MessageBox.Show("You can delete this borrower!!!");
                }

            }

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                DataView dv = (DataView)dataGridView1.DataSource;
                dv.RowFilter = "borrowerNumber = " + txtborrowerNumber.Text + "";

                // dv.RowFilter = "bookNumber = " + textBox1.Text;
                
                dataGridView1.DataSource = dv;
            }
            catch
            {
                MessageBox.Show("Can filter!!");
            }
        }
    }

}
