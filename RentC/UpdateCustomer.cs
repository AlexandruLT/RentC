using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentC
{
    public partial class UpdateCustomer : Form
    {
        private int initialID;

        public UpdateCustomer()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (ValidateCustomer(IDTextBox.Text, NameTextBox.Text, BirthDateTimePicker.Value, LocationTextBox.Text))
            {
                UpdateCustomerInDatabase(IDTextBox.Text, NameTextBox.Text, BirthDateTimePicker.Value, LocationTextBox.Text);
                Close();
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            initialID = GetCustomerForUpdate(IDTextBox.Text);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DeleteCustomer(IDTextBox.Text);
        }

        private bool ValidateCustomer(string clientID, string name, DateTime birthDate, string location)
        {
            Customer customer = new Customer();

            string nameError = "";
            string birthError = "";
            string locationError = "";

            // ID check
            if (clientID == initialID.ToString())
            {
                // Name check
                nameError = customer.NameValidation(name);

                // BirthDate check
                birthError = customer.BirthDateValidation(birthDate);

                // Location check
                locationError = customer.LocationValidation(location);


                if (nameError == "" && birthError == "" && locationError == "") return true;

                NameErrorLabel.Text = nameError;
                BirthErrorLabel.Text = birthError;
                LocationErrorLabel.Text = locationError;

                return false;
            }
            else if (clientID == "")
            {
                IDErrorLabel.Text = "This field is required";
                return false;
            }
            else
            {
                MessageBox.Show("Please press Search before trying to update");
                return false;
            }

        }


        private int GetCustomerForUpdate(string clientID)
        {

            DatabaseConnection connection = new DatabaseConnection();
            Customer initialCustomer = new Customer();

            IDErrorLabel.Text = initialCustomer.ClientIDValidation(clientID);
            if (IDErrorLabel.Text == "")
            {
                string getCustomer = "SELECT Name, BirthDate, Location from Customers WHERE CustomerID = @CustomerID AND IsDeleted = 0";

                SqlCommand command = new SqlCommand(getCustomer);

                command.Parameters.AddWithValue("CustomerID", int.Parse(clientID));

                initialCustomer = connection.GetCustomerForUpdate(command);

                initialCustomer.clientID = int.Parse(clientID);
                NameTextBox.Text = initialCustomer.name;
                BirthDateTimePicker.Value = initialCustomer.birthDate;
                LocationTextBox.Text = initialCustomer.location;

                return initialCustomer.clientID;
            }


            return 0;
        }

        private void UpdateCustomerInDatabase(string clientID, string name, DateTime birthDate, string location)
        {
            DatabaseConnection connection = new DatabaseConnection();

            string updateCustomer = "UPDATE Customers " +
                             "SET Name=@Name, BirthDate=@BirthDate, Location=@Location " +
                             "WHERE CustomerID=@CustomerID;";

            SqlCommand command = new SqlCommand(updateCustomer);

            command.Parameters.AddWithValue("CustomerID", int.Parse(clientID));
            command.Parameters.AddWithValue("Name", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower()));
            command.Parameters.AddWithValue("BirthDate", BirthDateTimePicker.Value.Date);
            command.Parameters.AddWithValue("Location", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(location.ToLower()));

            connection.AddDataToDatabase(command);

            MessageBox.Show("Customer Updated");
        }

        private void DeleteCustomerInDatabase(string clientID)
        {
            DatabaseConnection connection = new DatabaseConnection();

            string deleteCustomer = "UPDATE Customers " +
                             "SET IsDeleted = 1 " +
                             "WHERE CustomerID=@CustomerID;";

            SqlCommand command = new SqlCommand(deleteCustomer);

            command.Parameters.AddWithValue("CustomerID", int.Parse(clientID));

            connection.AddDataToDatabase(command);

            MessageBox.Show("Customer Deleted");
        }

        private void DeleteCustomer(string clientID)
        {
            if (clientID.Trim() == initialID.ToString())
            {
                if (MessageBox.Show("Are you sure you want to delete this customer?", "Delete Customer", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    DeleteCustomerInDatabase(clientID);
            }
            else if (clientID.Trim() == "")
            {
                IDErrorLabel.Text = "This field is required";
            }
            else
            {
                MessageBox.Show("Please press Search before trying to update");
            }
        }
    }
}
