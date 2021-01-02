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
    public partial class view_image : Form
    {
        public view_image()
        {
            InitializeComponent();
            pictureBox2.Visible = false;
            pictureBox1.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Homepage hp = new Homepage();
            hp.Show();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Visible == true)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = true;
                pictureBox4.Visible = false;
            }
            else if(pictureBox1.Visible == true)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
            }
            else if(pictureBox3.Visible==true)
            {
                pictureBox3.Visible = false;
                pictureBox2.Visible = false;
                pictureBox1.Visible = false;
                pictureBox4.Visible = true;
            }
            else if (pictureBox4.Visible==true)
            {
                pictureBox3.Visible = false;
                pictureBox2.Visible = false;
                pictureBox1.Visible = true;
                pictureBox4.Visible = false;
            }
            else if(pictureBox5.Visible==true)
            {
                pictureBox6.Visible = true;
                pictureBox5.Visible = false;
                pictureBox7.Visible = false;

            }
            else if(pictureBox6.Visible==true)
            {
                pictureBox7.Visible = true;
                pictureBox6.Visible = false;
                pictureBox5.Visible = false;
            }
            else if (pictureBox7.Visible==true)
            {
                pictureBox7.Visible = false;
                pictureBox6.Visible = false;
                pictureBox5.Visible = true;
            }
            else if(pictureBox8.Visible==true)
            {
                pictureBox9.Visible = true;
                pictureBox8.Visible = false;
                pictureBox10.Visible = false;

            }
            else if(pictureBox9.Visible==true)
            {
                pictureBox9.Visible = false;
                pictureBox7.Visible = false;
                pictureBox5.Visible = false;
                pictureBox6.Visible = false;
                pictureBox8.Visible = false;
                pictureBox10.Visible = true;
            }
            else if(pictureBox10.Visible==true)
            {
                pictureBox7.Visible = false;
                pictureBox8.Visible = true;
                pictureBox9.Visible = false;
                pictureBox10.Visible = false;
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            
           
            
            pictureBox2.Visible = true;
            pictureBox5.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            
               
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            pictureBox5.Visible = true;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
           
            pictureBox1.Visible = false;
            pictureBox4.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            pictureBox8.Visible = true;
            pictureBox5.Visible = false;
        }
    }
}
