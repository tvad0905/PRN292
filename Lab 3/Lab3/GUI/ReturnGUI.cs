using Lab3.DAL;
using Lab3.DTL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3.GUI
{
    public partial class ReturnGUI : Form
    {
        DataView dv;
        public ReturnGUI()
        {
            InitializeComponent();
            displayButtons(1);
            txtReturnDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void displayButtons(int state)
        {
            switch (state)
            {
                // to enter member and check Member
                case 1:
                    txtMemberCode.Enabled = true;
                    btCheckMember.Enabled = true;

                    dataGridView1.Enabled = false;
                    btConfirmFine.Enabled = false;

                    txtReturnDate.Enabled = false;
                    btReturn.Enabled = false;
                    break;
                // to Confirm fine
                case 2:
                    txtMemberCode.Enabled = false;
                    btCheckMember.Enabled = false;

                    dataGridView1.Enabled = true;
                    btConfirmFine.Enabled = true;

                    txtReturnDate.Enabled = false;
                    btReturn.Enabled = false;

                    break;
                // to Return
                case 3:
                    txtMemberCode.Enabled = false;
                    btCheckMember.Enabled = false;

                    btConfirmFine.Enabled = false;
                    dataGridView1.Enabled = false;

                    txtReturnDate.Enabled = true;
                    btReturn.Enabled = true;
                    break;

            }

        }

        private void btCheckMember_Click(object sender, EventArgs e)
        {
            int borrowerNumber;
            try
            {
                borrowerNumber = int.Parse(txtMemberCode.Text);
            }
            catch
            {
                MessageBox.Show("Borrower number must be a integer!");
                txtMemberCode.Focus();
                return;
            }
            Borrower b = new BorrowerDAO().GetBorrower(borrowerNumber);
            if (b == null)
            {
                MessageBox.Show(String.Format("Borrower number {0} does't exist!", borrowerNumber));
                txtMemberCode.Focus();
                return;
            }
            txtName.Text = b.Name;

            
            View();

            displayButtons(2);

        }
        private void View()
        {
            DataTable dt =new CirculatedCopyDAO().GetBorrowedCopies(int.Parse(txtMemberCode.Text));
            dataGridView1.DataSource = dt;
            this.dataGridView1.Columns["borrowedDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            this.dataGridView1.Columns["dueDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            this.dataGridView1.Columns["returnedDate"].DefaultCellStyle.Format = "dd/MM/yyyy";

            lbNumberOfBorrowedBooks.Text = dt.Rows.Count.ToString();
        }

        private bool isSelected()
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Don't have any book to return!");
                return false;
            }
            if (dataGridView1.SelectedRows[0].Cells["copyNumber"].Value == null)
            {
                MessageBox.Show("You must select a book in the list to return!");
                return false;
            }
            if(dataGridView1.SelectedRows[0].Cells["returnedDate"].Value.ToString() != "")
            {
                MessageBox.Show("This copy returned!");
                return false;
            }
            return true;


        }

        private void btConfirmFine_Click(object sender, EventArgs e)
        {
            if (!isSelected()) return;
            double fine = 0;
            foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
            {
                fine += (int)(DateTime.Now - Convert.ToDateTime(dr.Cells["dueDate"].Value.ToString())).TotalDays;
            }

            if(fine <= 0) txtFindAmount.Text = "0";
            else txtFindAmount.Text = fine.ToString("C2");

            displayButtons(3);

        }

        private void Return(CirculatedCopy cc)
        {
            CirculatedCopyDAO ccd = new CirculatedCopyDAO();
            ccd.Update(cc);

            Copy c = new CopyDAO().GetCopy(cc.CopyNumber);

            // if copy is reference
            if (c.Type == 'R') return;
            // update type = 'A' in copy
            c.Type = 'A';
            new CopyDAO().Update(c);

        }

        private void btReturn_Click(object sender, EventArgs e)
        {
            double fine, fineTotal = 0;
            try
            {
                DateTime.ParseExact(txtReturnDate.Text, "dd/MM/yyyy", null);
            }
            catch
            {
                MessageBox.Show("Format of date must be 'dd/MM/yyyy'!");
                return;
            }

            CirculatedCopy cc;

            foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
            {
                fine = 0;
                if (DateTime.ParseExact(txtReturnDate.Text, "dd/MM/yyyy", null) > Convert.ToDateTime(dr.Cells["dueDate"].Value.ToString()))
                    fine = (int)(DateTime.Now - Convert.ToDateTime(dr.Cells["dueDate"].Value.ToString())).TotalDays;

                fineTotal += fine;

                cc = new CirculatedCopy(int.Parse(dr.Cells["copyNumber"].Value.ToString()), int.Parse(dr.Cells["borrowerNumber"].Value.ToString()),
                    Convert.ToDateTime(dr.Cells["borrowedDate"].Value.ToString()), Convert.ToDateTime(dr.Cells["dueDate"].Value.ToString()));
                cc.Id = int.Parse(dr.Cells["ID"].Value.ToString());
                cc.ReturnedDate = DateTime.ParseExact(txtReturnDate.Text, "dd/MM/yyyy", null);
                cc.FineAmount = fine;

                Return(cc);

            }


            View();

            displayButtons(1);

        }

        private void txtReturnDate_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                DateTime.ParseExact(txtReturnDate.Text, "dd/MM/yyyy", null);
                e.Cancel = false;
            }
            catch
            {
                MessageBox.Show("Format date must be 'dd/MM/yyyy'!");
                txtReturnDate.Focus();
                e.Cancel = true;
            }


        }
    }

}

