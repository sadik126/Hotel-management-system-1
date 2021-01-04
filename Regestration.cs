
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_management_system
{
    public partial class Regestration : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["hotel7star"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;
        public Regestration()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Homepage hp = new Homepage();
            hp.Show();
            this.Hide();
        }

        private void save_Click(object sender, EventArgs e)

        {
            Regex r = new Regex(@"^[0-9]{11}$");
            if (textBox2.Text=="")
            {
                MessageBox.Show("Empty text");
            }
            else if(textBox1.Text=="")
            {
                MessageBox.Show("Empty text");
            }
            else if(phone.Text=="" && r.IsMatch(phone.Text))
            {
                MessageBox.Show("Invalid phone number");
            }
            else if(address.Text=="")
            {
                MessageBox.Show("Empty text");
            }
            else if (comboBox1.Text=="")
            {
                MessageBox.Show("Empty combobox");
            }
            else if(radioButton1.Checked==false && radioButton2.Checked==false)
            {
                MessageBox.Show("Empty gender");
            }
            else if(dateTimePicker1.Text=="")
            {
                MessageBox.Show("Empty date");
            }
            else if(roomno.Text=="")
            {
                MessageBox.Show("Empty room");
            }
            else
            { 
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["hotel7star"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select roomno from customers where roomno='" + roomno.Text + "' ", con);

            DataTable dt = new DataTable();
            da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    MessageBox.Show("Already booked");
                }
                else
                {
                    con.Open();
                    
                    string gen = null;
                    if (radioButton1.Checked)
                    {
                        gen = radioButton1.Text;
                    }
                    else
                    {
                        gen = radioButton2.Text;
                    }
                    string sql = "INSERT INTO customers (name,email,phone,status,address,roomno,gender,birthdate) VALUES('" + textBox2.Text + "','" + textBox1.Text + "','" + phone.Text + "','" + comboBox1.Text + "','" + address.Text + "','" + roomno.Text + "','" + gen + "','" + dateTimePicker1.Text + "')";
                    SqlCommand command = new SqlCommand(sql, con);
                    int result = command.ExecuteNonQuery();




                    if (result == 1 )

                    {

                        MessageBox.Show("Customer added successfully.");
                        this.cleardata();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("there is an error.please fill up the valid data");
                    }
                }

            }








        }
        public void cleardata()
        {
            textBox2.Text = "";
            textBox1.Text = "";
            phone.Text = "";
            comboBox1.Text = "";
            address.Text = "";
            roomno.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            dateTimePicker1.Text = "";
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            


        }

        private void phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if(!char.IsDigit(ch)&& ch !=8 && ch!=46)
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if(!char.IsControl(ch)&&!char.IsLetter(ch)&&ch!=32)
            {
                e.Handled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
