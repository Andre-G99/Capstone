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
    public partial class EditAppointment : Form
    {
        public DateTime start = DateTime.Parse(MainScreen.selectedAppointment.startTime).ToLocalTime();
        public DateTime end = DateTime.Parse(MainScreen.selectedAppointment.endTime).ToLocalTime();
        public TimeSpan openTime = new TimeSpan(8, 0, 0);
        public TimeSpan closeTime = new TimeSpan(17, 0, 0);

        public EditAppointment()
        {
            InitializeComponent();
        }

        private void EditAppointment_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet.customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.dataSet.customer);
            
            if (start.IsDaylightSavingTime() && DateTime.Now.IsDaylightSavingTime() == false)
            {
                start = start.AddHours(-1);
                end = end.AddHours(-1);
            }

            startPicker.CustomFormat = "MM/dd/yyyy hh:mm tt";
            endPicker.CustomFormat = "MM/dd/yyyy hh:mm tt";

            custBox.Text = MainScreen.selectedAppointment.customerID.ToString();
            titleBox.Text = MainScreen.selectedAppointment.title;
            startPicker.Value = start;
            descBox.Text = MainScreen.selectedAppointment.description;
            locationBox.Text = MainScreen.selectedAppointment.location;
            contactBox.Text = MainScreen.selectedAppointment.contact;
            typeBox.Text = MainScreen.selectedAppointment.type;
            endPicker.Value = end;
            urlBox.Text = MainScreen.selectedAppointment.url;

            custBox.Enabled = false;
        }

        public bool validateAppointment(Appointment appt) {

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
                else if (TimeSpan.Compare(startPicker.Value.TimeOfDay, openTime) == -1
                    || TimeSpan.Compare(endPicker.Value.TimeOfDay, closeTime) > 0
                    || startPicker.Value.Date != endPicker.Value.Date)
                {
                    MessageBox.Show("Start & End Times Must Be between 8:00 AM & 5:00 PM & Be On The Same Date In Local Time!");
                    return false;
                }
                else if (Appointment.findAppointmentTime(startPicker.Value, endPicker.Value, appt.id))
                {
                    MessageBox.Show("Appointment Time Interferes With Another Appointment!");
                    return false;
                }
                else {
                    return true;
                }
            }
        }

        public bool validateTextBoxes() {

            if (string.IsNullOrEmpty(titleBox.Text) || String.IsNullOrWhiteSpace(titleBox.Text)) {
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
            MainScreen.firstLoad = false;
            mainScreen.ShowDialog();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string format = "yyyy-MM-dd HH:mm";

            Appointment updatedAppt = new Appointment();
            string offset = DateTimeOffset.Now.ToString().Substring(DateTimeOffset.Now.ToString().IndexOf('M') + 2);

            updatedAppt.id = MainScreen.selectedAppointment.id;
            updatedAppt.customerID = Convert.ToInt32(custBox.Text);
            updatedAppt.userID = MainScreen.selectedAppointment.userID;
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
            updatedAppt.createDate = MainScreen.selectedAppointment.createDate;
            updatedAppt.createdBy = MainScreen.selectedAppointment.createdBy;
            updatedAppt.lastUpdatedBy = Login.userName;

            //appointment validation
            if (validateAppointment(updatedAppt))
            {
                updatedAppt.updateApp();
                MessageBox.Show("Appointment Successfully Updated!");
                this.Hide();
                Form mainScreen = new MainScreen();
                MainScreen.firstLoad = false;
                mainScreen.ShowDialog();
            }
            else {
                MessageBox.Show("Appointment Failed To Update!");
            }
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
            else
            {
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
