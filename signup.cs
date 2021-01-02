using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_management_system
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void save_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["hotel7star"].ConnectionString);

            con.Open();
            string sql = "INSERT INTO users (username,password,confirmpassword) VALUES('" + username.Text + "','" + password.Text + "','" + confirmpassword.Text + "')";
            SqlCommand command = new SqlCommand(sql, con);
            int result = command.ExecuteNonQuery();
            if (result > 0)
            {
                MessageBox.Show("sign up successfully.");
            }
            else
            {
                MessageBox.Show("there is an error.");
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }
    }
}
