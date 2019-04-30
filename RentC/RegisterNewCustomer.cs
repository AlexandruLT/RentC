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
    public partial class RegisterNewCustomer : Form
    {
        public RegisterNewCustomer()
        {
            InitializeComponent();
        }

        private void RegisterNewCustomer_Load(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            IDValueLabel.Text = customer.GetClientID();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (ValidateNewCustomer(NameTextBox.Text, BirthDateTimePicker.Value.Date, LocationTextBox.Text))
            {
                AddCustomerToDatabse(NameTextBox.Text.Trim(), BirthDateTimePicker.Value.Date, LocationTextBox.Text.Trim());
                Close();
            }
        }


        private bool ValidateNewCustomer(string name, DateTime birthDate, string location)
        {
            Customer customer = new Customer();

            string nameError = "";
            string birthError = "";
            string locationError = "";

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

        

        private void AddCustomerToDatabse(string name, DateTime birthDate, string location)
        {
            DatabaseConnection connection = new DatabaseConnection();

            string addRent = "INSERT INTO Customers " +
                             "VALUES(@Name, @BirthDate, @Location, 0);";

            SqlCommand command = new SqlCommand(addRent);
            
            command.Parameters.AddWithValue("@Name", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower()));
            command.Parameters.AddWithValue("@BirthDate", birthDate);
            command.Parameters.AddWithValue("@Location", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(location.ToLower()));

            connection.AddDataToDatabase(command);
        }
    }
}
