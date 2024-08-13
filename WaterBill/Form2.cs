using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaterBill
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
            InitializeCustomerTypeComboBox();
            InitializeListView();
        }

        private void InitializeCustomerTypeComboBox()
        {
            comboBoxCustomerType.Items.Add("Household");
            comboBoxCustomerType.Items.Add("Administrative agencies and public services");
            comboBoxCustomerType.Items.Add("Production unit");
            comboBoxCustomerType.Items.Add("Business service");
        }

        private void InitializeListView()
        {
            listViewResults.View = View.Details;
            listViewResults.FullRowSelect = true;
            listViewResults.GridLines = true;

            listViewResults.Columns.Add("Name", 100);
            listViewResults.Columns.Add("Phone", 100);
            listViewResults.Columns.Add("Customer Type", 150);
            listViewResults.Columns.Add("Total Bill", 80);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            string phone = textBoxPhone.Text;
            int customerType = comboBoxCustomerType.SelectedIndex + 1;
            int numberOfPeople = (int)numericUpDownPeople.Value;

            if (customerType.ToString() == "Household")
            {
                numberOfPeople = (int)numericUpDownPeople.Value;
            }
            else
            {
                numberOfPeople = 1;
            }

            if (!double.TryParse(textBoxLastMonth.Text, out double lastMonth) ||
                !double.TryParse(textBoxThisMonth.Text, out double thisMonth))
            {
                MessageBox.Show("Please enter valid numbers for Last Month and This Month readings.", "Invalid Input",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            

            double consume = thisMonth - lastMonth;
            double bill = WaterBill(customerType, (int)consume, numberOfPeople);
            double totalBill = bill * 1.1;

            ListViewItem item = new ListViewItem(new string[] {
            name,
            phone,
            comboBoxCustomerType.Text,
            totalBill.ToString("F2")
            });

            listViewResults.Items.Add(item);
        }


        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listViewResults.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in listViewResults.SelectedItems)
                {
                    listViewResults.Items.Remove(item);
                }
            }
            else
            {
                MessageBox.Show("Please select an item to remove.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

       
        private double WaterBill(int type, double consume, int number)
        {
            double bill = 0;

            switch (type)
            {
                case 1: // Household
                    if (consume <= 10)
                        bill = 5.973 * consume;
                    else if (consume <= 20)
                        bill = (5.973 * 10) + (7.052 * (consume - 10));
                    else if (consume <= 30)
                        bill = (5.973 * 10) + (7.052 * 10) + (8.699 * (consume - 20));
                    else
                        bill = (5.973 * 10) + (7.052 * 10) + (8.699 * 10) + (15.929 * (consume - 30));
                    break;
                case 2: // Administrative agencies and public services
                    bill = 9.955 * consume;
                    break;
                case 3: // Production unit
                    bill = 11.615 * consume;
                    break;
                case 4: // Business service
                    bill = 22.068 * consume;
                    break;
                default:
                    MessageBox.Show("Invalid customer type.");
                    break;
            }
            return bill;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            textBoxLastMonth.Clear();
            textBoxThisMonth.Clear();
            textBoxName.Clear();
            textBoxPhone.Clear();
        }
     
    }
}


