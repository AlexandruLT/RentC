using System;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace RentC
{
    public partial class RegisterNewCarRent : Form
    {
        public RegisterNewCarRent()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (ValidateCarRent(PlateTextBox.Text.Trim(), IDTextBox.Text.Trim(), StartDateTimePicker.Value.Date, EndDateTimePicker.Value.Date, CityTextBox.Text.Trim()))
            {
                AddCarRentToDatabase(PlateTextBox.Text.Trim(), IDTextBox.Text.Trim(), StartDateTimePicker.Value.Date, EndDateTimePicker.Value.Date, CityTextBox.Text.Trim());
                Close();
            }
        }

        // Fileds Input Validation
        private bool ValidateCarRent(string plate, string clientID, DateTime startDate, DateTime endDate, string city)
        {
            Reservation reservation = new Reservation();
            Car car = new Car();
            Customer customer = new Customer();

            string plateError = "";
            string IDError = "";
            string startDateError = "";
            string endDateError = "";
            string cityError = "";
            string overlapDates = "";

            // Plate check
            plateError = car.CarPlateValidation(plate);

            // ClientID check
            IDError = customer.ClientIDValidation(clientID);

            // Start-End Date check
            startDateError = reservation.CompareDateValidation(DateTime.Today, startDate);

            if (startDateError == "")
            {
                endDateError = reservation.CompareDateValidation(startDate, endDate);

                if (endDateError != "")
                {
                    endDateError += " the start date";
                }
            }
            else
            {
                startDateError += " today";
            }

            // Date Overlap check

            if (startDateError == "" && endDateError == "" && plateError == "")
                plateError = reservation.CheckDateOverlap(startDate, endDate, car.GetCarIDByPlate(plate));

            // City check
            cityError = customer.LocationValidation(city);

            // Return true if all the data is correct/no error message
            if (plateError == "" && IDError == "" && startDateError == "" && endDateError == "" && cityError == "" && overlapDates == "")
            {

                return true;
            }

            PlateErrorLabel.Text = plateError;
            IDErrorLabel.Text = IDError;
            StartErrorLabel.Text = startDateError;
            EndErrorLabel.Text = endDateError;
            CityErrorLabel.Text = cityError;

            return false;
        }


        // Inserting the new rent in the Database
        private void AddCarRentToDatabase(string plate, string clientID, DateTime startDate, DateTime endDate, string city)
        {
            DatabaseConnection connection = new DatabaseConnection();
            Car car = new RentC.Car();
            Customer customer = new Customer();

            string addRent = "INSERT INTO Reservations " +
                             "VALUES(@CarID,@CustomerID, 1, @StartDate, @EndDate, @Location, NULL);";

            SqlCommand command = new SqlCommand(addRent);

            car.carID = car.GetCarIDByPlate(plate);

            command.Parameters.AddWithValue("@CarID", car.carID);
            command.Parameters.AddWithValue("@CustomerID", int.Parse(clientID));
            command.Parameters.AddWithValue("@StartDate", startDate);
            command.Parameters.AddWithValue("@EndDate", endDate);
            command.Parameters.AddWithValue("@Location", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(city.ToLower()));

            connection.AddDataToDatabase(command);
        }
    }
}
