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
    public partial class BorrowGUI : Form
    {
        DataView dv;
        Copy c;
        Reservation r;

        enum errorBorrow
        {
            OK,
            Connect,
            CopyNotExist,
            CopyReferenced,
            CopyBorrowed,
            CopyReserved
        };

        public BorrowGUI()
        {
            InitializeComponent();

            comboBox1.DataSource = new BorrowerDAO().getAllMember();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "BorrowerNumber";

            txtBorrowerNumber.Text = comboBox1.SelectedValue.ToString();
            txtName.Text = comboBox1.Text;
            //txtBorrowedDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //txtDueDate.Text = DateTime.Now.AddDays(20).ToString("dd/MM/yyyy");
            displayButtons(1);
        }


        

       

        private errorBorrow checkCondition(int borrowerNumber, int copyNumber, out Copy c, out Reservation r)
        {
            c = null;
            r = null;


            c = new CopyDAO().GetCopy(copyNumber);
            if (c == null) return errorBorrow.CopyNotExist;
            if (c.Type == 'R') return errorBorrow.CopyReferenced;
            if (c.Type == 'B') return errorBorrow.CopyBorrowed;

            // Check if this book is reserved by others and you are not at the first of the reservation list
            int bookNumber = c.BookNumber;
            r = new ReserveDAO().GetFirstReservation(bookNumber);
            if (r != null && r.BorrowerNumber != borrowerNumber) return errorBorrow.CopyReserved;
            return errorBorrow.OK;

        }


        

        private void borrow(CirculatedCopy cc, Copy c, Reservation r)
        {
            // Insert borrow record
            if (cc == null) return;
            new CirculatedCopyDAO().Insert(cc);

            // update type = 'B' at Copy
            if (c == null) return;
            c.Type = 'B';
            new CopyDAO().Update(c);


            // update status = 'A' at Reservation
            if (r == null) return;
            r.Status = 'A';
            new ReserveDAO().Update(r);


        }


        // get all borrowed copies by this borrower and display 
        private void View()
        {
            DataTable dt = new CirculatedCopyDAO().GetBorrowedCopies(int.Parse(txtBorrowerNumber.Text));
            dataGridView1.DataSource = dt;
            this.dataGridView1.Columns["borrowedDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            this.dataGridView1.Columns["dueDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            this.dataGridView1.Columns["returnedDate"].DefaultCellStyle.Format = "dd/MM/yyyy";

            
            int count = dataGridView1.Rows.Count;
            lbNumberOfBorrowedBooks.Text = count.ToString();
            if (count >= 5)
            {
                MessageBox.Show("You has borrowed 5 books, so you can't borrow any more!");
                //MessageBox.Show("You borrowed 5 books, so you can't borrow any more!");
                txtBorrowerNumber.Focus();
                return;
            }
        }


        private void displayButtons(int state)
        {
            switch (state)
            {
                // to enter member and check member
                case 1:
                    txtBorrowerNumber.Enabled = true;
                    btnMember.Enabled = true;

                    txtCopyNumber.Enabled = false;
                    btnCondition.Enabled = false;

                    dateTimePicker1.Enabled = false;
                    btnBorrow.Enabled = false;
                    break;
                // to check condition
                case 2:
                    txtBorrowerNumber.Enabled = false;
                    btnMember.Enabled = false;

                    txtCopyNumber.Enabled = true;
                    btnCondition.Enabled = true;

                    dateTimePicker1.Enabled = false;
                    btnBorrow.Enabled = false;
                    break;
                // to borrow
                case 3:
                    txtBorrowerNumber.Enabled = false;
                    btnMember.Enabled = false;

                    txtCopyNumber.Enabled = false;
                    btnCondition.Enabled = false;

                    txtDueDate.Text = dateTimePicker1.Value.AddDays(14).ToString("dd/MM/yyyy");
                    dateTimePicker1.Enabled = true;
                    btnBorrow.Enabled = true;
                    break;

            }

        }


        private void BorrowGUI_Load(object sender, EventArgs e)
        {

        }

        private void btnMember_Click(object sender, EventArgs e)
        {
            int borrowerNumber;
            try
            {
                borrowerNumber = int.Parse(txtBorrowerNumber.Text);
            }
            catch
            {
                MessageBox.Show("Borrower number must be a integer!");
                txtBorrowerNumber.Focus();
                return;
            }
            Borrower b = new BorrowerDAO().GetBorrower(borrowerNumber);
            if (b == null)
            {
                MessageBox.Show(String.Format("Borrower number {0} does't exist!", borrowerNumber));
                txtBorrowerNumber.Focus();
                return;
            }
            txtName.Text = b.Name;

            View();

            displayButtons(2);

            r = null;
            c = null;
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {

            CirculatedCopy cc = new CirculatedCopy(int.Parse(txtCopyNumber.Text), int.Parse(txtBorrowerNumber.Text),
                DateTime.ParseExact(dateTimePicker1.Text, "dd/MM/yyyy", null), DateTime.ParseExact(txtDueDate.Text, "dd/MM/yyyy", null));

            borrow(cc, c, r);

            View();
            displayButtons(1);
        }

        private void btnCondition_Click(object sender, EventArgs e)
        {
            int copyNumber;
            try
            {
                copyNumber = int.Parse(txtCopyNumber.Text);
            }
            catch
            {
                MessageBox.Show("Copy number must be a integer!");
                txtCopyNumber.Focus();
                return;
            }

            errorBorrow error = checkCondition(int.Parse(txtBorrowerNumber.Text), int.Parse(txtCopyNumber.Text), out c, out r);
            string str = "";
            switch (error)
            {
                case errorBorrow.CopyNotExist:
                    str = "No this copy number, so you can't borrow!";
                    txtCopyNumber.Focus();
                    break;
                case errorBorrow.CopyReferenced:
                    str = "It is referenced, so you can't borrow!";
                    txtCopyNumber.Focus();
                    break;
                case errorBorrow.CopyBorrowed:
                    str = "It is borrwed, so you can't borrow!";
                    txtCopyNumber.Focus();
                    break;
                case errorBorrow.CopyReserved:
                    str = "It is reserved by other, so you can't borrow!";
                    txtCopyNumber.Focus();
                    break;
                case errorBorrow.Connect:
                    str = "Can't connect to Database, so you can't borrow!";
                    break;

            }


            if (str != "")
            {
                MessageBox.Show(str);
                return;
            }
            displayButtons(3);
        }

        private void txtBorrowedDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtDueDate.Text = DateTime.ParseExact(dateTimePicker1.Text, "dd/MM/yyyy", null).AddDays(20).ToString("dd/MM/yyyy");
            }catch
            {
                return;
            }
            
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            txtDueDate.Text = dateTimePicker1.Value.AddDays(14).ToString("dd/MM/yyyy");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBorrowerNumber.Text = comboBox1.SelectedValue.ToString();
            txtName.Text = comboBox1.Text;
        }
    }
}
