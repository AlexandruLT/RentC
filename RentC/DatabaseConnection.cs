using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace RentC
{
    public class DatabaseConnection
    {
        private SqlConnection connect = new SqlConnection("Data Source=(local)\\SQLEXPRESS;Initial Catalog = academy_net; Integrated Security = True");

        public DataTable GetTableFromDatabase(string query)
        {
            DataTable databaseTable = new DataTable();

            connect.Open();
            SqlCommand command = new SqlCommand(query, connect);
            databaseTable.Load(command.ExecuteReader());
            connect.Close();

            return databaseTable;
        }

        public void AddDataToDatabase(SqlCommand command)
        {
            connect.Open();
            command.Connection = connect;
            command.CommandType = CommandType.Text;
            command.ExecuteNonQuery();
            connect.Close();
        }

        public string GetValueFromDatabase(SqlCommand command)
        {
            string value = "";
            SqlDataReader databaseValue;

            connect.Open();
            command.Connection = connect;
            command.CommandType = CommandType.Text;
            databaseValue = command.ExecuteReader();
            if (databaseValue.Read())
                value = databaseValue.GetValue(0).ToString();
            connect.Close();

            return value;
        }

        public List<Reservation> GetRentForUpdate(SqlCommand command)
        {
            SqlDataReader databaseValue;
            List<Reservation> resList = new List<Reservation>();
           

            connect.Open();
            command.Connection = connect;
            command.CommandType = CommandType.Text;
            databaseValue = command.ExecuteReader();
            while (databaseValue.Read())
            {
                Reservation res = new Reservation();

                res.carID = databaseValue.GetInt32(0);
                res.customerID = databaseValue.GetInt32(1);
                res.startDate = databaseValue.GetDateTime(2);
                res.endDate = databaseValue.GetDateTime(3);
                res.location = databaseValue.GetValue(4).ToString();
                resList.Add(res);
            }
            connect.Close();

            return resList;
        }

        public Customer GetCustomerForUpdate(SqlCommand command)
        {
            SqlDataReader databaseValue;
            Customer customer = new Customer();

            connect.Open();
            command.Connection = connect;
            command.CommandType = CommandType.Text;
            databaseValue = command.ExecuteReader();
            if (databaseValue.Read())
            {
                customer.name = databaseValue.GetValue(0).ToString();
                customer.birthDate = databaseValue.GetDateTime(1);
                customer.location = databaseValue.GetValue(2).ToString();
            }
            connect.Close();

            return customer;
        }

        public List<DateTime> GetDatesFromDatabase(int carID)
        {
            string getDates = "SELECT StartDate, EndDate FROM Reservations WHERE CarID = @CarID AND ReservStatsID = 1";

            SqlDataReader databaseValue;
            SqlCommand command = new SqlCommand(getDates);
            List<DateTime> dates = new List<DateTime>();

            command.Parameters.AddWithValue("CarID", carID);

            connect.Open();
            command.Connection = connect;
            command.CommandType = CommandType.Text;
            databaseValue = command.ExecuteReader();
            while(databaseValue.Read())
            {
                dates.Add(databaseValue.GetDateTime(0).Date);
                dates.Add(databaseValue.GetDateTime(1).Date);
            }
            connect.Close();

            return dates;
        }


    }

    
}
