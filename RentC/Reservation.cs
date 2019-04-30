using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentC
{
    public class Reservation
    {
        public int carID;

        public int customerID;

        public int reservStatsID;

        public DateTime startDate;

        public DateTime endDate;

        public string location;

        public string couponCode;

        public Reservation()
        {
        }

        public string CompareDateValidation(DateTime fixedDate, DateTime checkedDate)
        {
            if (DateTime.Compare(checkedDate, fixedDate) >= 0)
                return "";

            return "Please make sure the date is equal or bigger than ";
        }

        public string CheckDateOverlap(DateTime startDate, DateTime endDate, int carID)
        {
            DatabaseConnection connection = new DatabaseConnection();

            List<DateTime> dates = connection.GetDatesFromDatabase(carID);

            if (dates.Count > 0)
                for(int i = 0; i < dates.Count; i+=2)
                {
                    if (!(startDate > dates[i + 1] || endDate < dates[i]))
                        return "This car is rented between " + dates[i].Date.ToShortDateString()+ " and " + dates[i + 1].Date.ToShortDateString(); 
                }

            return "";
        }
    }
}
