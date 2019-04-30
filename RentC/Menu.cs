using System;
using System.Windows.Forms;

namespace RentC
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void RegisterCarRentButton_Click(object sender, EventArgs e)
        {
            RegisterNewCarRent RegisterNewCarRentForm = new RegisterNewCarRent();
            RegisterNewCarRentForm.ShowDialog();
        }

        private void UpdateCarRentButton_Click(object sender, EventArgs e)
        {
            UpdateCarRent UpdateCarRentForm = new UpdateCarRent();
            UpdateCarRentForm.ShowDialog();
        }

        private void ListRentsButton_Click(object sender, EventArgs e)
        {
            ListRents ListRentsForm = new ListRents();
            ListRentsForm.ShowDialog();
        }

        private void ListCarsButtons_Click(object sender, EventArgs e)
        {
            ListCars ListCarsForm = new ListCars();
            ListCarsForm.ShowDialog();
        }

        private void RegisterCustomerButton_Click(object sender, EventArgs e)
        {
            RegisterNewCustomer RegisterNewCustomerForm = new RegisterNewCustomer();
            RegisterNewCustomerForm.ShowDialog();
        }

        private void UpdateCustomerButton_Click(object sender, EventArgs e)
        {
            UpdateCustomer UpdateCustomerForm = new UpdateCustomer();
            UpdateCustomerForm.ShowDialog();
        }

        private void ListCustomerButton_Click(object sender, EventArgs e)
        {
            ListCustomers ListCustomersForm = new ListCustomers();
            ListCustomersForm.ShowDialog();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
