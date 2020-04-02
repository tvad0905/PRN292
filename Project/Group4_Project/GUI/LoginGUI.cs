using Group4_Project.DAL;
using Group4_Project.DTL;
using Group4_Project.GUI;
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
    public partial class LoginGUI : Form
    {
        MainGUI m;
        MyCartForm mcf;
        Account a = new Account();
        public void setAccount(Account a)
        {
            this.a = a ;
            txtUsername.Text = a.username;
            txtPassword.Text = a.password;
        }

        public LoginGUI(MainGUI m)
        {
            InitializeComponent();
            this.m = m;
            this.a = m.A;
            checkLogin();
        }
        public void checkLogin()
        {
            if (a.username != null && a.username != "")
            {
                DialogResult dr = MessageBox.Show("You has already login !! Do you want to logout ? (Yes/No)", "Notification !!!", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    MessageBox.Show("You signed out !!!");
                    m.removeAccount();
                    this.Enabled = true;
                }
                else
                {
                    this.Enabled = false;
                }

            }
        }
        bool checkMCF = false;
        public LoginGUI(MainGUI m, MyCartForm mcf)
        {
            InitializeComponent();
            this.m = m;
            this.mcf = mcf;
            checkMCF = true;
            checkLogin();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            String usn = txtUsername.Text.Trim();
            String ps = txtPassword.Text.Trim();
            if (usn.Length == 0 || ps.Length == 0)
            {
                MessageBox.Show("User Name or Password can't be blank");
                return;
            }

            DataTable dt = AccountDAO.getLogUser(usn, ps);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("User Name or Password is incorrect");
                return;
            }

            a = new Account();
            a.setInfor(dt);

            //test log
            Label l1 = new Label();
            l1.Text = a.username;
            this.Controls.Add(l1);
            MessageBox.Show("login success");
            m.A = a;
            if (checkMCF)
            {
                mcf.A = a;
                mcf.setText();
            }
            this.Close();
            //
            //this.f.Form1_Load(new object(), new EventArgs());
        }

        private void btSignUp_Click(object sender, EventArgs e)
        {
            RegisterForm r = new RegisterForm(this);
            r.ShowDialog();
            /*
            if (r.DialogResult == true)
            {
                DataTable dt = AccountDAO.getLogUser(r.usn, r.ps);
                User.setInfor(dt);
                checkLog = true; // test
                this.f.Form1_Load(new object(), new EventArgs());
            }
            */
        }
    }
}
