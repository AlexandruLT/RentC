using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
namespace RentC
{
    public partial class ListRents : Form
    {
        public ListRents()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ListRents_Load(object sender, EventArgs e)
        {
            RentsGridView.DataSource = GetRentsList("all");
            RentsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ActiveButton_Click(object sender, EventArgs e)
        {
            if (ActiveButton.Text == "Show Active Rents")
            {
                RentsGridView.DataSource = GetRentsList("active");
                ActiveButton.Text = "Show Inactive Rents";
            }
            else
            {
                RentsGridView.DataSource = GetRentsList("inactive");
                ActiveButton.Text = "Show Active Rents";
            }
        }

        private void AllButton_Click(object sender, EventArgs e)
        {
            RentsGridView.DataSource = GetRentsList("all");
        }

        private DataTable GetRentsList(string lookFor)
        {
            DatabaseConnection connection = new DatabaseConnection();
            string getRentsList = "";
 
            if (lookFor == "active")
                getRentsList = "SELECT Plate as 'Car Plate', CustomerID as 'Customer ID', StartDate as 'Start Date', EndDate as 'End Date', Location " +
                                "FROM(SELECT CarID, CustomerID, StartDate, EndDate, Location FROM Reservations WHERE ReservStatsID = 1) " +
                                "Reservations LEFT JOIN Cars on Reservations.CarID = Cars.CarID order by Reservations.CarID";

            else if (lookFor == "inactive")
                getRentsList = "SELECT Plate as 'Car Plate', CustomerID as 'Customer ID', StartDate as 'Start Date', EndDate as 'End Date', Location " +
                                "FROM(SELECT CarID, CustomerID, StartDate, EndDate, Location FROM Reservations WHERE ReservStatsID = 2) " +
                                "Reservations LEFT JOIN Cars on Reservations.CarID = Cars.CarID order by Reservations.CarID";

            else if (lookFor == "deleted")
                getRentsList = "SELECT Plate as 'Car Plate', CustomerID as 'Customer ID', StartDate as 'Start Date', EndDate as 'End Date', Location " +
                                "FROM(SELECT CarID, CustomerID, StartDate, EndDate, Location FROM Reservations WHERE ReservStatsID = 3) " +
                                "Reservations LEFT JOIN Cars on Reservations.CarID = Cars.CarID order by Reservations.CarID";

            else
                getRentsList = "SELECT Plate as 'Car Plate', CustomerID as 'Customer ID', StartDate as 'Start Date', EndDate as 'End Date', Location " +
                                "FROM(SELECT CarID, CustomerID, StartDate, EndDate, Location FROM Reservations WHERE ReservStatsID = 1 OR ReservStatsID = 2) " +
                                "Reservations LEFT JOIN Cars on Reservations.CarID = Cars.CarID order by Reservations.CarID";

            return connection.GetTableFromDatabase(getRentsList);
        }

        private void DeletedRentsButton_Click(object sender, EventArgs e)
        {
            RentsGridView.DataSource = GetRentsList("deleted");
        }
    }
}
