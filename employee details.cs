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
    public partial class employee_details : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["hotel7star"].ConnectionString);
        SqlDataAdapter adpt;
        SqlCommand cmd;
        DataTable dt;
        private int indexRow;

        public employee_details()
        {
            InitializeComponent();
            this.showdata();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Homepage hp = new Homepage();
            hp.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            adpt = new SqlDataAdapter("delete from employees where name='" + textBox1.Text + "'", con);

            dt = new DataTable();
            adpt.Fill(dt);
            if (textBox1.Text == "")
            {
                MessageBox.Show("Text box Empty");

            }


            else
            {
                MessageBox.Show("deleted");
                textBox1.Text = "";
                this.showdata();
                

            }
        }

        private void employee_details_Load(object sender, EventArgs e)
        {

        }
        public void showdata()
        {
            adpt = new SqlDataAdapter("select * from employees", con);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.showdata();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex; // get the selected Row Index
            DataGridViewRow row = dataGridView1.Rows[indexRow];

            textBox3id.Text = row.Cells[0].Value.ToString();
            textBox2name.Text = row.Cells[1].Value.ToString();
           textboxemail.Text = row.Cells[2].Value.ToString();
            phone.Text = row.Cells[3].Value.ToString();
            textBox5address.Text = row.Cells[4].Value.ToString();
            textBox4stuts.Text = row.Cells[5].Value.ToString();
            textBox7gender.Text = row.Cells[6].Value.ToString();
           
            dateTimePicker1.Text = row.Cells[7].Value.ToString();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            DataGridViewRow newDataRow = dataGridView1.Rows[indexRow];
            newDataRow.Cells[0].Value = textBox3id.Text;
            newDataRow.Cells[1].Value = textBox2name.Text;
            newDataRow.Cells[2].Value = textboxemail.Text;
            newDataRow.Cells[3].Value = phone.Text;
            newDataRow.Cells[4].Value = textBox5address.Text;
            newDataRow.Cells[5].Value = textBox4stuts.Text;
            newDataRow.Cells[6].Value = textBox7gender.Text;
            
            newDataRow.Cells[7].Value = dateTimePicker1.Text;
            adpt = new SqlDataAdapter("update  employees set name='" + textBox2name.Text + "',email='" + textboxemail.Text + "',phone='" + phone.Text + "',status='" + textBox4stuts.Text + "',address='" + textBox5address.Text + "',gender='" + textBox7gender.Text + "',birthdate='" + dateTimePicker1.Text + "' where Id='" + textBox3id.Text + "'", con);


            dt = new DataTable();
            adpt.Fill(dt);

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("name like '%{0}%'", textBox3.Text);
                dataGridView1.DataSource = dv.ToTable();
            }
        }
    }
}
