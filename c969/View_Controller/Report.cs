using c969.Database;
using c969.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c969.View_Controller
{
    public partial class Report : Form
    {
        List<Appointment> appointmentList = new List<Appointment>();
        List<string> typeList = new List<string>();

        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            appointmentList = Appointment.GetAppointmentsLocal();
            foreach (Appointment app in appointmentList){
                // make a list of types of appointments
                if (!typeList.Contains(app.type))
                {
                    typeList.Add(app.type);
                }
            }
            
            //set datasources for comboboxes
            userBox.DataSource = User.getUsers();
            customerBox.DataSource = Customer.getCustomerNames();
            monthBox.DataSource = DateTimeFormatInfo.CurrentInfo.MonthNames;
            typeBox.DataSource = typeList;
            apptTypeBox2.DataSource = typeList;
        }

        private void generateFirstReport_Click(object sender, EventArgs e)
        {
            //set the month and type equal to the options the user has selected from the combo boxes
            int month = monthBox.SelectedIndex + 1;
            string type = typeBox.SelectedItem.ToString();

            // here we use a lambda expression to find the number of appointments that are in the selected month and match the selected type
            // using a lambda expression is significantly more efficient than manually looping through the list and counting the match cases
            int numberOfAppt = appointmentList.Where(appt => appt.startTime.Substring(0, appt.startTime.IndexOf("/")) == month.ToString() && appt.type == type).Count();

            // display the result
            resultLabel.Text = numberOfAppt + " appointment(s) of type '" +  type + "' in the month of " + monthBox.SelectedItem.ToString();
        }

        private void genSchedule_Click(object sender, EventArgs e)
        {
            //create a binding list of appointemnts for the selected user
            BindingList<Appointment> appts = Appointment.dbGetterByUser(User.findUserID(userBox.SelectedItem.ToString()));

            //set the data sources for the datagridview
            scheduleGrid.DataSource = appts;

            //update the datagridview
            scheduleGrid.Update();
            scheduleGrid.Refresh();
        }

        private void generateThirdReport_Click(object sender, EventArgs e)
        {
            // set customer and type equal to what the user has selected
            string customer = customerBox.SelectedItem.ToString();
            string type = apptTypeBox2.SelectedItem.ToString();

            //set the customerID equal to the customer the user has selected
            int customerID = Customer.findCustomer(customerBox.Text, Customer.findAddressID(customerBox.Text, customerBox.SelectedIndex + 1));

            // on the line below we use a lambda expression in order to easily find the number of appointments that match that customer ID and appointment type
            // using a lambda expression here is significantly more efficient than looping through the list to find our matching appointments and counting them through the loop
            int numberOfAppt = appointmentList.Where(appt => appt.customerID == customerID  && appt.type == type).Count();

            // display result
            result2Label.Text = numberOfAppt + " appointment(s) of type '" + type + "' for the customer: " + customerBox.SelectedItem.ToString();
        }
    }
}
