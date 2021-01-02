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
    public partial class add_room : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["hotel7star"].ConnectionString);
        SqlDataAdapter adpt;
        DataTable dt;
        private int indexRow;

        public add_room()
        {
            InitializeComponent();
            this.showdata();
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (save.Text == "")
            {
                MessageBox.Show("Text box Empty");
            }
            else if (guna2Button2.Text == "")
            {
                MessageBox.Show("Text box Empty");

            }
            else if (comboBox1.Text == "")
            {
                MessageBox.Show("combo box Empty");
            }
            else if (comboBox2.Text == "")
            {
                MessageBox.Show("combo box Empty");
            }


            else
            {
                








                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["hotel7star"].ConnectionString);
                SqlDataAdapter da = new SqlDataAdapter("select roomNo from rooms where roomNo='" + roomno.Text + "' ", con);

                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    MessageBox.Show("Already booked");
                }
                else
                {
                    con.Open();
                    string sql = "INSERT INTO rooms (roomNo,roomType,bed,price) VALUES('" + roomno.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + price.Text + "')";
                    SqlCommand command = new SqlCommand(sql, con);
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Saved");
                        MessageBox.Show("Thank you");
                        this.refreshdata();
                        this.cleardata();

                    }
                    else
                    {
                        MessageBox.Show("there is an error.");
                    }
                }
            }
              
        }
        public void showdata()
        {
            adpt = new SqlDataAdapter("select * from rooms", con);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public void refreshdata()
        {
            this.showdata();
        }
        public void cleardata()
        {
            roomno.Text = "";
            price.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox1.Text = "";
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Homepage hp = new Homepage();
            hp.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            adpt = new SqlDataAdapter("delete from rooms where roomNo='" + textBox1.Text + "'", con);

            dt = new DataTable();
            adpt.Fill(dt);
            if (textBox1.Text == "")
            {
                MessageBox.Show("Text box Empty");
                
            }


            else
            {
                MessageBox.Show("deleted");
                this.refreshdata();
                this.cleardata();

            }
        }

        private void add_room_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            this.showdata();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            indexRow = e.RowIndex; // get the selected Row Index
            DataGridViewRow row = dataGridView1.Rows[indexRow];

            roomno.Text = row.Cells[1].Value.ToString();
            comboBox1.Text = row.Cells[2].Value.ToString();
            comboBox2.Text = row.Cells[3].Value.ToString();
            price.Text = row.Cells[4].Value.ToString();
            textBox2.Text = row.Cells[0].Value.ToString();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            DataGridViewRow newDataRow = dataGridView1.Rows[indexRow];
            newDataRow.Cells[1].Value = roomno.Text;
            newDataRow.Cells[2].Value = comboBox1.Text;
           
            newDataRow.Cells[3].Value = comboBox2.Text;
            newDataRow.Cells[4].Value = price.Text;
            newDataRow.Cells[0].Value = textBox2.Text;


            adpt = new SqlDataAdapter("update  rooms set roomNo='" + roomno.Text + "',roomType='"+comboBox1.Text+"',bed='"+comboBox2.Text+"',price='"+price.Text+"' where roomid='" + textBox2.Text + "'", con);


            dt = new DataTable();
            adpt.Fill(dt);

            

            this.cleardata();

          
        }

        private void roomno_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void price_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
    }
    

}
