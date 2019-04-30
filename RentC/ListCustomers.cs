using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentC
{
    public partial class ListCustomers : Form
    {
        public ListCustomers()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ListCustomers_Load(object sender, EventArgs e)
        {
            CustomersGridView.DataSource = GetCustomersList("all");
            CustomersGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private DataTable GetCustomersList(string lookFor)
        {
            DatabaseConnection connection = new DatabaseConnection();

            string getCustomersList = "";

            if (lookFor == "all")
                getCustomersList = "SELECT CustomerID as 'Client ID', NAme as 'Client Name', BirthDate as 'Birth Date', Location FROM Customers order by CustomerID";
            else if (lookFor == "active")
                getCustomersList = "SELECT CustomerID as 'Client ID', NAme as 'Client Name', BirthDate as 'Birth Date', Location FROM Customers WHERE IsDeleted = 0 order by CustomerID";
            else if (lookFor == "inactive")
                getCustomersList = "SELECT CustomerID as 'Client ID', NAme as 'Client Name', BirthDate as 'Birth Date', Location FROM Customers WHERE IsDeleted = 1 order by CustomerID";

            return connection.GetTableFromDatabase(getCustomersList);
        }

        private void ShowActiveButton_Click(object sender, EventArgs e)
        {
            if (ShowActiveButton.Text == "Show Active Customers")
            {
                CustomersGridView.DataSource = GetCustomersList("active");
                ShowActiveButton.Text = "Show Inactive Customers";
            }
            else if (ShowActiveButton.Text == "Show Inactive Customers")
            {
                CustomersGridView.DataSource = GetCustomersList("inactive");
                ShowActiveButton.Text = "Show Active Customers";
            }

        }

        private void ShowAllButton_Click(object sender, EventArgs e)
        {
            CustomersGridView.DataSource = GetCustomersList("all");
        }
    }
}
