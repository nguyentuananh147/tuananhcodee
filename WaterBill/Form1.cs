using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WaterBill
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            string pass = tbPass.Text;

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter your name !", "Notice",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbName.Focus();
            }

            else if (string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Please enter password !", "Notice",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbPass.Focus();
            }

            else
            {
                if (name == "tuananh" && pass == "123")
                {
                    Form2 MainForm = new Form2();
                    MainForm.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Your name or password is incorrect", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
