using System;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace RentC
{
    public class Customer
    {
        public int clientID;

        public string name;

        public DateTime birthDate;

        public string location;

        public Customer()
        {
        }


        public string BirthDateValidation(DateTime birthDate)
        {
            string errorMessage = "";

            int age = DateTime.Now.Year - birthDate.Year;

            if (DateTime.Now.Month < birthDate.Month || (DateTime.Now.Month == birthDate.Month && DateTime.Now.Day < birthDate.Day))
                age--;

            if (age < 18)
                errorMessage = "Customer must be at least 18 years old";

            return errorMessage;
        }

        public int GetClientID(string clientID)
        {
            DatabaseConnection connection = new DatabaseConnection();

            string getClientID = "SELECT CustomerID FROM Customers WHERE CustomerID=@ClientID AND IsDeleted = 0;";

            SqlCommand command = new SqlCommand(getClientID);

            command.Parameters.AddWithValue("ClientID", clientID);

            string value = connection.GetValueFromDatabase(command);

            if (value != "")
                return int.Parse(value);
            else
                return 0;
        }

        public string ClientIDValidation(string clientID)
        {
            string errorMessage;

            if (string.IsNullOrWhiteSpace(clientID))
            {
                errorMessage = "This field is required";
            }
            else if (!int.TryParse(clientID, out this.clientID))
            {
                errorMessage = "Please use only numbers for the Client ID";
            }
            else
            {
                errorMessage = (GetClientID(clientID) == 0 ? "This Client ID doesn't exist" : "");
            }
            return errorMessage;
        }

        public string LocationValidation(string location)
        {
            string errorMessage;

            if (string.IsNullOrWhiteSpace(location))
            {
                errorMessage = "This field is required";
            }
            else if (location.Length > 50)
            {
                errorMessage = "Please introduce maximum 50 characters";
            }
            else
            {
                if (!Regex.IsMatch(location, @"^[\p{L}\s'.-]+$"))
                    errorMessage = "Please only use letters for the location";
                else
                    errorMessage = "";
            }

            return errorMessage;
        }

        public string NameValidation(string name)
        {
            string errorMessage;

            if (string.IsNullOrWhiteSpace(name))
            {
                errorMessage = "This field is required";
            }
            else if (!Regex.IsMatch(name, @"^[\p{L}\s'.-]+$"))
            {
                errorMessage = "Please only use letters for the name";
            }
            else if (name.Length > 50)
            {
                errorMessage = "Please introduce maximum 50 characters";
            }
            else
            {
                errorMessage = (!name.Trim().Contains(" ") ? "Please fill with the First and Last name" : "");
            }
            return errorMessage;
        }

        public string GetClientID()
        {
            
            DatabaseConnection connection = new DatabaseConnection();

            string getClientID = "SELECT IDENT_CURRENT('Customers');";

            SqlCommand command = new SqlCommand(getClientID);

            return (int.Parse(connection.GetValueFromDatabase(command)) + 1).ToString();
        }
    }
}
