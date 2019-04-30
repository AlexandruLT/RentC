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
    public partial class UpdateCarRent : Form
    {
        Reservation initialRes = new Reservation();

        public UpdateCarRent()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (ValidateCarRent(PlateTextBox.Text, IDTextBox.Text, StartDateTimePicker.Value.Date, EndDateTimePicker.Value.Date, CityTextBox.Text))
            {
                UpdateCarRentInDatabase(PlateTextBox.Text, IDTextBox.Text, StartDateTimePicker.Value.Date, EndDateTimePicker.Value.Date, CityTextBox.Text);
                Close();
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            GetRentForUpdate(PlateTextBox.Text, IDTextBox.Text, StartDateTimePicker.Checked);
        }

        private void StartDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            StartDateTimePicker.CustomFormat = "yyyy-MM-dd";
        }

        private void EndDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            EndDateTimePicker.CustomFormat = "yyyy-MM-dd";
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (DeleteRent(PlateTextBox.Text, IDTextBox.Text))
                Close();
        }

        private bool ValidateCarRent(string plate, string clientID, DateTime startDate, DateTime endDate, string city)
        {
            if (SearchButton.Text == "Clear")
            {
                Reservation reservation = new Reservation();
                Car car = new Car();
                Customer customer = new Customer();

                string plateError = "";
                string IDError = "";
                string startDateError = "";
                string endDateError = "";
                string cityError = "";

                // Plate check
                plateError = car.CarPlateValidation(plate);

                // ClientID check
                IDError = customer.ClientIDValidation(clientID);

                // Start-End Date check
                startDateError = reservation.CompareDateValidation(DateTime.Now, startDate);

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
                    startDateError += " the initial start date";
                }

                // City check
                cityError = customer.LocationValidation(city);

                // Return true if all the data is correct/no error message
                if (plateError == "" && IDError == "" && startDateError == "" && endDateError == "" && cityError == "")
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
            else
                MessageBox.Show("Please Search for an active rent before pressing Update");

            return false;
        }

        private void UpdateCarRentInDatabase(string plate, string clientID, DateTime startDate, DateTime endDate, string city)
        {
            Car car = new Car();
            DatabaseConnection connection = new DatabaseConnection();

            string addRent = "UPDATE Reservations " +
                                "SET StartDate = @StartDate, EndDate = @EndDate, Location = @Location WHERE CarID = @CarID AND CustomerID = @CustomerID AND StartDate = @InitialStartDate";

            SqlCommand command = new SqlCommand(addRent);

            car.carID = car.GetCarIDByPlate(plate);

            command.Parameters.AddWithValue("CarID", car.carID);
            command.Parameters.AddWithValue("CustomerID", int.Parse(clientID));
            command.Parameters.AddWithValue("StartDate", startDate);
            command.Parameters.AddWithValue("InitialStartDate", initialRes.startDate);
            command.Parameters.AddWithValue("EndDate", endDate);
            command.Parameters.AddWithValue("Location", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(city.ToLower()));

            connection.AddDataToDatabase(command);

            MessageBox.Show("Rent Updated");
        }

        private void GetRentForUpdate(string plate, string clientID, bool startDateChecked)
        {
            if (SearchButton.Text == "Clear")
            {
                Clear();
            }
            else
            {
                if (plate.Trim() != "" || clientID.Trim() != "")
                {
                    Car car = new Car();
                    Customer customer = new Customer();

                    string IDError = "";
                    string plateError = "";

                    if (plate.Trim() != "")
                    {
                        plateError = car.CarPlateValidation(plate);
                    }
                    if (clientID.Trim() != "")
                    {
                        IDError = customer.ClientIDValidation(clientID);
                    }

                    if ((plateError == "" && IDError == "This field is required") || (IDError == "" && plateError == "This field is required") || (plateError == "" && IDError == ""))
                    {
                        DatabaseConnection connection = new DatabaseConnection();
                        List<Reservation> res = new List<Reservation>();

                        string getRent = "";
                        string lookFor = "";
                        string dates = "";

                        if (plate.Trim() != "" && clientID.Trim() != "" && startDateChecked)
                        {
                            getRent = "SELECT CarID, CustomerID, StartDate, EndDate, Location FROM Reservations WHERE CustomerID = @CustomerID AND CarID = @CarID AND StartDate = @StartDate AND ReservStatsID = 1";
                            lookFor = "plateAndIDAndDate";
                        }
                        else if (plate.Trim() != "" && clientID.Trim() != "")
                        {
                            getRent = "SELECT CarID, CustomerID, StartDate, EndDate, Location FROM Reservations WHERE CustomerID = @CustomerID AND CarID = @CarID AND ReservStatsID = 1";
                            lookFor = "plateAndID";
                        }
                        else if (plate.Trim() != "")
                        {
                            getRent = "SELECT CarID, CustomerID, StartDate, EndDate, Location FROM Reservations WHERE CarID = @CarID AND ReservStatsID = 1";
                            lookFor = "plate";
                        }
                        else if (clientID.Trim() != "")
                        {
                            getRent = "SELECT CarID, CustomerID, StartDate, EndDate, Location FROM Reservations WHERE CustomerID = @CustomerID AND ReservStatsID = 1";
                            lookFor = "ID";
                        }

                        SqlCommand command = new SqlCommand(getRent);

                        if (lookFor == "plateAndID" && plateError == "" && IDError == "")
                        {
                            car.carID = car.GetCarIDByPlate(plate);

                            command.Parameters.AddWithValue("CarID", car.carID);
                            command.Parameters.AddWithValue("CustomerID", int.Parse(clientID));
                        }
                        else if (lookFor == "plate" && plateError == "")
                        {
                            car.carID = car.GetCarIDByPlate(plate);

                            command.Parameters.AddWithValue("CarID", car.carID);
                        }
                        else if (lookFor == "ID" && IDError == "")
                        {
                            command.Parameters.AddWithValue("CustomerID", int.Parse(clientID));
                        }
                        else if (lookFor == "plateAndIDAndDate" && plateError == "" && IDError == "")
                        {
                            car.carID = car.GetCarIDByPlate(plate);

                            command.Parameters.AddWithValue("CarID", car.carID);
                            command.Parameters.AddWithValue("CustomerID", int.Parse(clientID));
                            command.Parameters.AddWithValue("StartDate", StartDateTimePicker.Value.Date);
                        }


                        res = connection.GetRentForUpdate(command);
                        IDError = "";
                        plateError = "";

                        string errorMessage = "";

                        if (lookFor == "plate")
                        {
                            if (res.Count > 1)
                            {
                                errorMessage = "This car is rented more than 1 time. Please add the Client ID field and press Search again";
                            }
                            else if (res.Count == 0)
                            {
                                errorMessage = "There is no active rent for this car";
                            }
                        }
                        else if (lookFor == "ID")
                        {
                            if (res.Count > 1)
                            {
                                errorMessage = "This client has multiple active rents. Please add the Car Plate and press Search again";
                            }
                            else if (res.Count == 0)
                            {
                                errorMessage = "There is no active rent for this customer";
                            }
                        }
                        else if (lookFor == "plateAndID")
                        {
                            if (res.Count > 1)
                            {
                                for (int i = 0; i < res.Count; i++)
                                    dates += "\n" + res[i].startDate.ToShortDateString();

                                errorMessage = "This car is rented for this customer on the following start dates :" + dates + "\nPlease select one of these dates as a start date before pressing Search.";
                            }
                            else if (res.Count == 0)
                            {
                                errorMessage = "There is no active rent for this customer/car";
                            }
                        }
                        else
                        {
                            StartDateTimePicker.CustomFormat = " ";
                            StartDateTimePicker.Checked = false;

                            errorMessage = "There isn't a rent for this client and car on this date. Please press Search again using only the Car Plate and Client ID";
                        }

                        if (res.Count == 1)
                        {
                            StartDateTimePicker.Checked = true;
                            StartDateTimePicker.CustomFormat = "yyyy-MM-dd";
                            EndDateTimePicker.CustomFormat = "yyyy-MM-dd";

                            IDTextBox.Text = res[0].customerID.ToString();
                            PlateTextBox.Text = car.GetCarPlateByID(res[0].carID);
                            StartDateTimePicker.Value = res[0].startDate;
                            EndDateTimePicker.Value = res[0].endDate;
                            CityTextBox.Text = res[0].location;

                            IDTextBox.ReadOnly = true;
                            PlateTextBox.ReadOnly = true;

                            initialRes = res[0];

                            SearchButton.Text = "Clear";
                        }
                        else
                            MessageBox.Show(errorMessage);
                    }

                    IDErrorLabel.Text = IDError;
                    PlateErrorLabel.Text = plateError;
                }
                else
                {
                    MessageBox.Show("Please fill the Car Plate field or the Client ID field before pressing Search");
                }
            }
        }

        private void Clear()
        {
            IDTextBox.ReadOnly = false;
            PlateTextBox.ReadOnly = false;

            IDTextBox.Text = "";
            PlateTextBox.Text = "";
            StartDateTimePicker.CustomFormat = " ";
            StartDateTimePicker.Checked = false;
            EndDateTimePicker.CustomFormat = " ";
            CityTextBox.Text = "";

            initialRes = new Reservation();

            SearchButton.Text = "Search";
        }

        private bool DeleteRent(string plate, string clientID)
        {
            if (SearchButton.Text == "Clear")
            {
                Car car = new Car();
                DatabaseConnection connection = new DatabaseConnection();

                string addRent = "UPDATE Reservations " +
                                 "SET ReservStatsID = 3 WHERE CarID = @CarID AND CustomerID = @CustomerID AND StartDate = @InitialStartDate";

                SqlCommand command = new SqlCommand(addRent);

                car.carID = car.GetCarIDByPlate(plate);

                command.Parameters.AddWithValue("CarID", car.carID);
                command.Parameters.AddWithValue("CustomerID", int.Parse(clientID));
                command.Parameters.AddWithValue("InitialStartDate", initialRes.startDate);

                connection.AddDataToDatabase(command);

                MessageBox.Show("Rent Deleted");
                return true;
            }
            else
                MessageBox.Show("Please Search for an active Rent before pressing Delete");

            return false;
        }

        private void UpdateCarRent_Load(object sender, EventArgs e)
        {
            StartDateTimePicker.Value = DateTime.Today;
            EndDateTimePicker.Value = DateTime.Today;

            StartDateTimePicker.CustomFormat = " ";
            EndDateTimePicker.CustomFormat = " ";
        }
    }
}
