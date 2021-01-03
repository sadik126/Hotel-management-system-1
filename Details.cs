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
    public partial class Details : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["hotel7star"].ConnectionString);
        SqlDataAdapter adpt;
        SqlCommand cmd;
        DataTable dt;
        private int indexRow;

        public Details()
        {
            InitializeComponent();
            this.showdata();
        }
        public void showdata()
        {
            adpt = new SqlDataAdapter("select * from customers", con);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Homepage hp = new Homepage();
            hp.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            adpt = new SqlDataAdapter("delete from customers where name='" + textBox2.Text + "'", con);

            dt = new DataTable();
            adpt.Fill(dt);
            if (textBox2.Text == "")
            {
                MessageBox.Show("Text box Empty");

            }


            else
            {
                MessageBox.Show("deleted");
                this.showdata();


            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            DataGridViewRow newDataRow = dataGridView1.Rows[indexRow];
            newDataRow.Cells[0].Value = textBox5name.Text;
            newDataRow.Cells[1].Value = textBox2email.Text;
            newDataRow.Cells[2].Value = textBox4phone.Text;
            newDataRow.Cells[3].Value = textBox3address.Text;
            newDataRow.Cells[4].Value = status.Text;
            newDataRow.Cells[5].Value = gender.Text;
            newDataRow.Cells[6].Value = textBox5roomno.Text;
            newDataRow.Cells[7].Value = textBox1.Text;
            newDataRow.Cells[8].Value = dateTimePicker1.Text;
            adpt = new SqlDataAdapter("update  customers set name='" + textBox2email.Text + "',email='" + textBox4phone.Text + "',phone='" + textBox3address.Text + "',status='" + status.Text + "',address='" + gender.Text + "',roomno='" + textBox5roomno.Text + "',gender='" + gender.Text + "',birthdate='" + dateTimePicker1.Text + "' where Id='" + textBox5name.Text + "'", con);


            dt = new DataTable();
            adpt.Fill(dt);

        }

        private void details_Load(object sender, EventArgs e)
        {
            
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex; // get the selected Row Index
            DataGridViewRow row = dataGridView1.Rows[indexRow];

            textBox5name.Text = row.Cells[0].Value.ToString();
            textBox2email.Text = row.Cells[1].Value.ToString();
            textBox4phone.Text = row.Cells[2].Value.ToString();
            textBox3address.Text = row.Cells[3].Value.ToString();
            status.Text = row.Cells[4].Value.ToString();
            gender.Text = row.Cells[5].Value.ToString();
            textBox5roomno.Text = row.Cells[6].Value.ToString();
            textBox1.Text = row.Cells[7].Value.ToString();
            dateTimePicker1.Text = row.Cells[8].Value.ToString();

            adpt = new SqlDataAdapter("update  customers set name='" + textBox2email.Text + "',email='" + textBox4phone.Text + "',phone='" + textBox3address.Text + "',status='" + status.Text + "',address='"+gender.Text+"',roomno='"+textBox5roomno.Text+"',gender='"+gender.Text+"',birthdate='"+dateTimePicker1.Text+"' where Id='" + textBox5name.Text + "'", con);


            dt = new DataTable();
            adpt.Fill(dt);



            


        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)13)
            {
                DataView dv = dt .DefaultView;
                dv.RowFilter = string.Format("name like '%{0}%'", textBox3.Text);
                dataGridView1.DataSource = dv.ToTable();
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.showdata();
        }
    }
}

