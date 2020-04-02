using Group4_Project.DAL;
using Group4_Project.DTL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group4_Project.GUI
{
    public partial class RegisterForm : Form
    {
        public String usn, ps;
        LoginGUI lgui;
        Account a;
        TextBox[] listTextBox1, listTextBox2;

        private void btSignUp_Click(object sender, EventArgs e)
        {
            foreach (TextBox t in listTextBox1)
            {
                if (t.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Must fill in all text box of Main information");
                    return;
                }

            }

            if(!AccountDAO.checkUsername(textBox1.Text))
            {
                MessageBox.Show("Username has existed !! Try another username !!!", "Notification !!!", MessageBoxButtons.OK);
                return;
            }

            if (AccountDAO.insertRegister(listTextBox1, listTextBox2))
            {
                usn = textBox1.Text;
                ps = textBox2.Text;
                MessageBox.Show("Register successully !!!", "Notification", MessageBoxButtons.OK);
                DataTable dt = AccountDAO.getLogUser(usn, ps);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("User Name or Password is incorrect");
                    return;
                }

                a = new Account();
                a.setInfor(dt);
                lgui.setAccount(a);
                this.Close();
            }
            else
            {
                MessageBox.Show("Register Fail");
                return;
            }
        }

        public RegisterForm()
        {
            InitializeComponent();

                                            //usname    password  firstN    lastN     email
            listTextBox1 = new TextBox[] { textBox1, textBox2, textBox3, textBox4, textBox5 };
                                            //address  city      state      country   phone
            listTextBox2 = new TextBox[] { textBox6, textBox7, textBox8, textBox9, textBox10 };
        }
        public RegisterForm(LoginGUI m) : this()
        {
            this.lgui = m;
        }
    }
}
