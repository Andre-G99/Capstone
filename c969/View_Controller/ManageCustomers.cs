using c969.Database;
using c969.Model;
using c969.View_Controller;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c969.View
{
    public partial class ManageCustomers : Form
    {
        public static Customer selectedCustomer;
        public ManageCustomers()
        {
            InitializeComponent();
        }

        private void ManageCustomers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet.address' table. You can move, or remove it, as needed.
            this.addressTableAdapter.Fill(this.dataSet.address);
            // TODO: This line of code loads data into the 'dataSet.customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.dataSet.customer);

            //set character limits to the text boxes equal to the limits in the database
            countryBox.MaxLength = 50;
            cityBox.MaxLength = 50;
            addressBox.MaxLength = 50;
            phoneBox.MaxLength = 20;
            postalBox.MaxLength = 10;
            nameBox.MaxLength = 45;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = customerRecords.CurrentRow;
            switch (selectedRow)
            {
                default:
                    DialogResult confirmation = MessageBox.Show("Are you sure you want to delete this customer?",
                         "Confirm", MessageBoxButtons.YesNo);
                    if (confirmation == DialogResult.Yes)
                    {
                        string query = "Delete from customer Where customerID = @customerID";

                         try
                          {

                              MySqlCommand command = new MySqlCommand(query, DBConnection.conn);
                              command.Parameters.AddWithValue("@customerID", customerRecords.SelectedCells[0].Value);
                              command.ExecuteNonQuery();
                              ManageCustomers_Load(sender, e);
                          }

                         catch(MySqlException ex) {
                            
                            // prevent deletion of customers who have appointments linked to them
                            if (DBConnection.findLinkedAppointments((int)customerRecords.SelectedCells[0].Value))
                            {
                                MessageBox.Show("Cannot Delete Customer With Linked Appointments!");
                            }
                            else {
                                MessageBox.Show(ex.Message);
                            }
                         }
                    }
                    break;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //declare objects
            Customer customer = new Customer();
            Country country = new Country();
            City city = new City();
            Address address = new Address();

            //first we assign the text box values to their respective properties
            country.setName(countryBox.Text);
            city.setName(cityBox.Text);
            address.setAddress(addressBox.Text);
            address.setPostalCode(postalBox.Text);
            address.setPhone(phoneBox.Text);

            // check the database to see if the country, city, and address exist, if they dont' we create them
            // see class method for details
            country.checkCountryAndSave();
            city.checkCityAndSave(country);
            address.checkAndSaveAddress(city);

            //set customer properties
            customer.id = customer.generateID("customer");
            customer.name = nameBox.Text;
            customer.active = 1;
            customer.createdBy = Login.userName;
            customer.addressID = address.id;

            //add the customer and update the data grid view

            if (Customer.findCustomer(nameBox.Text, customer.addressID) == 0) {
                addCustomer(validateAll(), customer);
            }
            else {
                MessageBox.Show("Customer already in database!");
            }

            // refresh the list of customers;
            ManageCustomers_Load(sender, e);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            nameBox.Clear();
            addressBox.Clear();
            countryBox.Clear();
            phoneBox.Clear();
            cityBox.Clear();
            postalBox.Clear();
        }

        //adding customer, using this method to give confirmation that customer was added or that it wasn't
        private bool addCustomer(bool isValid, Customer customer) {
            switch (isValid)
            {
                case false:
                    MessageBox.Show("Customer Not Added!");
                    return false;
                case true:
                    MessageBox.Show(customer.saveData());
                    return true;
                default:
                    return false;
            }
        }

        private bool validateAll() {
            if (phoneBox.Text == "" || nameBox.Text == "" || phoneBox.Text == "" || addressBox.Text == "" || cityBox.Text == "" || countryBox.Text == "" || postalBox.Text == "")
            {
                MessageBox.Show("All fields must be filled!");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            Customer tempCustHolder = new Customer();
            DataGridViewSelectedRowCollection selectedRow = customerRecords.SelectedRows;
            if (selectedRow.Count == 1) {
                foreach (DataGridViewRow row in selectedRow)
                {
                    int tempID = (int)row.Cells[0].Value;
                    selectedCustomer = tempCustHolder;
                    selectedCustomer.id = tempID;
                    selectedCustomer.name = row.Cells[1].Value.ToString();
                    selectedCustomer.addressID = (int)row.Cells[2].Value;
                }
            }

            this.Hide();
            Form editScreen = new EditCustomer();
            editScreen.ShowDialog();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form mainScreen = new MainScreen();
            mainScreen.ShowDialog();
        }
    }
}
