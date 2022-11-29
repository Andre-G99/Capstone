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
    public partial class AddAppointment : Form
    {
        public TimeSpan openTime = new TimeSpan(8, 0, 0);
        public TimeSpan closeTime = new TimeSpan(17, 0, 0);

        public AddAppointment()
        {
            InitializeComponent();
        }

        private void AddAppointment_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet.customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.dataSet.customer);

            startPicker.CustomFormat = "MM/dd/yyyy hh:mm tt";
            endPicker.CustomFormat = "MM/dd/yyyy hh:mm tt";
            custBox.Text = customerRecords.SelectedCells[0].Value.ToString();
            custBox.Enabled = false;

        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string format = "yyyy-MM-dd HH:mm";

            Appointment updatedAppt = new Appointment();

            string offset = DateTimeOffset.Now.ToString().Substring(DateTimeOffset.Now.ToString().IndexOf('M') + 2);

            updatedAppt.id = updatedAppt.generateID("appointment");
            updatedAppt.customerID = Convert.ToInt32(custBox.Text);
            updatedAppt.userID = User.findUserID(Login.userName);
            updatedAppt.title = titleBox.Text;
            updatedAppt.description = descBox.Text;
            updatedAppt.location = locationBox.Text;
            updatedAppt.contact = contactBox.Text;
            updatedAppt.type = typeBox.Text;
            updatedAppt.url = urlBox.Text;

            if(offset == "+00:00") { 
                updatedAppt.startTime = startPicker.Value.ToString(format);
                updatedAppt.endTime = endPicker.Value.ToString(format);
            }
            else { 
                updatedAppt.startTime = startPicker.Value.ToUniversalTime().ToString(format);
                updatedAppt.endTime = endPicker.Value.ToUniversalTime().ToString(format);
            }
            updatedAppt.createdBy = Login.userName;
            updatedAppt.lastUpdatedBy = Login.userName;

            //appointment validation
            if (validateAppointment(updatedAppt))
            {
                MessageBox.Show(updatedAppt.saveData());
                this.Hide();
                Form mainScreen = new MainScreen();
                MainScreen.firstLoad = false;
                mainScreen.ShowDialog();
            }
            else
            {
                MessageBox.Show("Appointment Not Added!");
            }
        }

        public bool validateAppointment(Appointment appt)
        {
            TimeSpan start = new TimeSpan(startPicker.Value.TimeOfDay.Hours, startPicker.Value.TimeOfDay.Minutes, 0);
            TimeSpan end = new TimeSpan(startPicker.Value.TimeOfDay.Hours, startPicker.Value.TimeOfDay.Minutes, 0);

            if (validateTextBoxes() == false)
            {
                MessageBox.Show("All fields must be filled!");
                return false;
            }
            else
            {
                if (DateTime.Compare(startPicker.Value, endPicker.Value) >= 0)
                {
                    MessageBox.Show("Start Time Must Be Earlier Than End Time!");
                    return false;
                }
                else if (TimeSpan.Compare(start, openTime) == -1
                    || TimeSpan.Compare(end, closeTime) > 0
                    || startPicker.Value.Day != endPicker.Value.Day)
                {
                    MessageBox.Show("Start & End Times Must Be between 8:00 AM & 5:00 PM & Be On The Same Date In Local Time!");
                    return false;
                }
                else if (Appointment.findAppointmentTime(startPicker.Value, endPicker.Value, appt.id))
                {
                    MessageBox.Show("Appointment Time Interferes With Another Appointment!");
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public bool validateTextBoxes()
        {

            if (string.IsNullOrEmpty(titleBox.Text) || String.IsNullOrWhiteSpace(titleBox.Text))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(descBox.Text) || String.IsNullOrWhiteSpace(descBox.Text))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(locationBox.Text) || String.IsNullOrWhiteSpace(locationBox.Text))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(contactBox.Text) || String.IsNullOrWhiteSpace(contactBox.Text))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(urlBox.Text) || String.IsNullOrWhiteSpace(urlBox.Text))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(typeBox.Text) || String.IsNullOrWhiteSpace(typeBox.Text))
            {
                return false;
            }

            return true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainScreen mainScreen = new MainScreen();
            mainScreen.ShowDialog();
        }

        private void customerRecords_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            custBox.Text = customerRecords.SelectedCells[0].Value.ToString();
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchBox.Text) == false)
            {
                //create a binding list of appointemnts for the selected user
                BindingList<Customer> customers = new BindingList<Customer>(Customer.getCustomerList().Where(cust => cust.name.ToLower().Contains(searchBox.Text.ToLower())).ToList());

                //set the data sources for the datagridview
                customerRecords.DataSource = customers;

                customerRecords.Columns[0].DataPropertyName = "id";
                customerRecords.Columns[1].DataPropertyName = "name";

                //update the datagridview
                customerRecords.Update();
                customerRecords.Refresh();
            }
            else {
                customerRecords.Columns[0].DataPropertyName = "customerID";
                customerRecords.Columns[1].DataPropertyName = "customerName";
                customerRecords.DataSource = this.dataSet.customer;

                //update the datagridview
                customerRecords.Update();
                customerRecords.Refresh();
            }
        }
    }
}
