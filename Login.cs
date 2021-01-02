using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_management_system
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtusername.Text == "" || password.Text == "")
            {
                MessageBox.Show("Username or password can not be empty");
            }
            else
            {
                Userservice userService = new Userservice();
                bool result = userService.LoginValidation(txtusername.Text, password.Text);
                if (result)
                {
                    Homepage hp = new Homepage();
                    hp.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Username or password");
                }
            }
        }

        private void login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Signup su = new Signup();
            su.Show();
            this.Hide();
        }
    }
    
}
