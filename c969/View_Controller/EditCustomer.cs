using c969.Model;
using c969.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c969.View_Controller
{
    public partial class EditCustomer : Form
    {
        Address newAddress = new Address();
        City newCity = new City();
        Country newCountry = new Country();
        Customer customer = ManageCustomers.selectedCustomer;

    public EditCustomer()
        {
            InitializeComponent();
        }

        private void EditCustomer_Load(object sender, EventArgs e)
        {

            //call the get methods to grab info from the db
            newAddress.dbGetter(customer.addressID);
            newCity.GetCityInfo(newAddress.getCityID());
            newCountry.getNameDB(newCity.getCountryID());

            //fill the text box with the info of the customer the user chooses to edit
            
            nameBox.Text = customer.getName(customer.id);
            cityBox.Text = newCity.getName();
            countryBox.Text = newCountry.getName();
            addressBox.Text = newAddress.getAddress();
            postalBox.Text = newAddress.getPostal();
            phoneBox.Text = newAddress.getPhone();
        }

        private bool validateAll()
        {
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

        private void saveButton_Click(object sender, EventArgs e)
        {
            //set customer properties
            customer.name = nameBox.Text;
            customer.lastUpdate = DateTime.Now.ToString("YYYY-MM-DD hh:mm:ss");
            customer.lastUpdatedBy = Login.userName;

            //set city properties
            newCity.setName(cityBox.Text);

            //set country properties
            newCountry.setName(countryBox.Text);

            //set address properties
            newAddress.setAddress(addressBox.Text);
            newAddress.setPostalCode(postalBox.Text);
            newAddress.setPhone(phoneBox.Text);

            //check to see if country, city, and address are already in the db, if they are not we create them
            newCountry.checkCountryAndSave();
            newCity.checkCityAndSave(newCountry);
            newAddress.checkAndSaveAddress(newCity);

            //final validation for text boxes
            if (validateAll() && Customer.findCustomer(nameBox.Text, customer.addressID, newAddress.getPostal()) == 0)
            {
                //update the customer in the db
                customer.addressID = newAddress.id;
                MessageBox.Show(customer.updateCustomer());

                this.Hide();
                ManageCustomers manageScreen = new ManageCustomers();
                manageScreen.ShowDialog();
            }
            else if (validateAll() && Customer.findCustomer(nameBox.Text, customer.addressID, newAddress.getPostal()) != 0) 
            {

                //if customer is already in the database there is no need to add them again
                MessageBox.Show("Customer Already Exists!");
            }
            else {
                //error msg
                MessageBox.Show("Customer Failed To Update!");
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form manageScreen = new ManageCustomers();
            manageScreen.ShowDialog();
        }
    }
}
