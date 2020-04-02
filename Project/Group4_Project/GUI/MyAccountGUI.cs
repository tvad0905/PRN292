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
    public partial class MyAccountGUI : Form
    {
        Account a = new Account(2, "Quan", "Nguyen", "Ha Noi", "Ha Noi", "Hoa Lac", "Viet Nam", "0966 848 112", "quannd@gmail.com", "1");
        public MyAccountGUI()
        {
            InitializeComponent();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            displayUser();
            if (btEdit.Text == "Edit")
            {
                btEdit.Text = "Save";
            }
            else
            {
                btEdit.Text = "Edit";
                //update user database              
                a = new Account(a.id, txtFirstName.Text, txtLastName.Text, txtAddress.Text, txtCity.Text, txtState.Text, txtCountry.Text , txtPhone.Text, txtEmail.Text, a.type);
                AccountDAO.UpdateAccount(a);
            }
        }
        public void displayUser()
        {
            txtFirstName.ReadOnly = !txtFirstName.ReadOnly;
            txtLastName.ReadOnly = !txtLastName.ReadOnly;
            txtAddress.ReadOnly = !txtAddress.ReadOnly;
            txtEmail.ReadOnly = !txtEmail.ReadOnly;
            txtPhone.ReadOnly = !txtPhone.ReadOnly;
            txtCity.ReadOnly = !txtCity.ReadOnly;
            txtCountry.ReadOnly = !txtCountry.ReadOnly;
            txtState.ReadOnly = !txtState.ReadOnly;
        }
    }
}
