using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentC
{
    public partial class ListCars : Form
    {
        public ListCars()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ListCars_Load(object sender, EventArgs e)
        {
            CarsGridView.DataSource = GetCarsList();
            CarsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private DataTable GetCarsList()
        {
            DatabaseConnection connection = new DatabaseConnection();

            string getCarsList = "SELECT CarID as 'Car ID', Plate, Manufacturer, Model, PricePerDay as 'Price Per Day' FROM Cars order by CarID";

            return connection.GetTableFromDatabase(getCarsList);
        }
    }
}
