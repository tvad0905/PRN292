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
    public partial class ReserveGUI : Form
    {
        public ReserveGUI()
        {
            InitializeComponent();
            displayButtons(1);
        }

        private void displayButtons(int state)
        {
            switch (state)
            {
                // to enter member and check member
                case 1:
                    txtMemberCode.Enabled = true;
                    btCheckMember.Enabled = true;

                    txtBookNumber.Enabled = false;
                    btCheckReservation.Enabled = false;

                    txtDate.Enabled = false;
                    btReserve.Enabled = false;
                    break;
                // to check condition
                case 2:
                    txtMemberCode.Enabled = false;
                    btCheckMember.Enabled = false;

                    txtBookNumber.Enabled = true;
                    btCheckReservation.Enabled = true;

                    txtDate.Enabled = false;
                    btReserve.Enabled = false;
                    break;
                // to borrow
                case 3:
                    txtMemberCode.Enabled = false;
                    btCheckMember.Enabled = false;

                    txtBookNumber.Enabled = false;
                    btCheckReservation.Enabled = false;

                    txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    txtDate.Enabled = true;
                    btReserve.Enabled = true;
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
            if (dataGridView1.Rows.Count >= 1)
            {
                MessageBox.Show("You has already reserved !!!");
                txtMemberCode.Focus();
                return ;
            }

            displayButtons(2);
        }

        private bool checkCondition(int borrowerNumber, int bookNumber)
        {

            DataTable dt = new CopyDAO().GetAllCopyByBookNumber(bookNumber);
            if(dt.Rows.Count == 0)
            {
                MessageBox.Show("Book Number has not existed !!");
                txtBookNumber.Focus();
                return false;
            }
            foreach(DataRow rd in dt.Rows)
            {
                if (rd["type"].ToString().Equals("A"))
                {
                    MessageBox.Show("The book is available !!!");
                    return false;
                } 
            }
            foreach (DataRow rd in dt.Rows)
            {
                if (rd["type"].ToString().Equals("B"))
                {
                    return true;
                }


            }
            MessageBox.Show("All copy is reference !!!");
            return false;
        }

        private void btCheckReservation_Click(object sender, EventArgs e)
        {
            int bookNumber = int.Parse(txtBookNumber.Text);
            int borrowerNumber = int.Parse(txtMemberCode.Text);
            if(!checkCondition(borrowerNumber, bookNumber))
            {
                return;
            }

            displayButtons(3);
        }

        private void View()
        {
            DataTable dt = new ReserveDAO().SelectDS(int.Parse(txtMemberCode.Text), 'R');
            dataGridView1.DataSource = dt;
            this.dataGridView1.Columns["date"].DefaultCellStyle.Format = "dd/MM/yyyy";
            int n = dataGridView1.Rows.Count - 1;
            if (n < 0) lbNumberOfReservedBooks.Text = "0";
            else
            {
                lbNumberOfReservedBooks.Text = n.ToString();
            }
        }

        private void btReserve_Click(object sender, EventArgs e)
        {
            Reservation rs = new Reservation(int.Parse(txtMemberCode.Text), int.Parse(txtBookNumber.Text), DateTime.Now);
            new ReserveDAO().Insert(rs);

            View();

            displayButtons(1);
        }
    }
}
