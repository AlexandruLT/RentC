using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace RentC
{
    public class Car
    {
        public int carID;

        public string plate;

        public string manufacturer;

        public string model;

        public double pricePerDay;

        public Car()
        {
        }

        public string CarPlateValidation(string carPlate)
        {
            string errorMessage;

            if (string.IsNullOrWhiteSpace(carPlate))
            {
                errorMessage = "This field is required";
            }
            else if (!Regex.IsMatch(carPlate, @"[A-Za-z]{2}\s[0-9]{2}\s[A-Za-z]{3}"))
            {
                errorMessage = "Please use the correct format. E.g. AB 12 ABC";
                
            }
            else
            {
                errorMessage = GetCarIDByPlate(carPlate) == 0 ? "This Car Plate doesn't exist in the database":"";
            }
            return errorMessage;
        }

        public int GetCarIDByPlate(string plate)
        {
            DatabaseConnection connection = new DatabaseConnection();

            string getCarID = "SELECT CarID FROM Cars WHERE Plate=@Plate;";

            SqlCommand command = new SqlCommand(getCarID);
            command.Parameters.AddWithValue("Plate", plate);

            string value = connection.GetValueFromDatabase(command);

            if (value != "")
                return int.Parse(value);
            else
                return 0;
        }

        public string GetCarPlateByID(int carID)
        {
            DatabaseConnection connection = new DatabaseConnection();

            string getCarID = "SELECT Plate FROM Cars WHERE CarID = @CarID;";

            SqlCommand command = new SqlCommand(getCarID);
            command.Parameters.AddWithValue("CarID", carID);

            string value = connection.GetValueFromDatabase(command);

            if (value != "")
                return value;
            else
                return "";
        }
    }
}
