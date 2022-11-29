using c969.Database;
using c969.Model;
using c969.View_Controller;
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

namespace c969.View
{
    public partial class MainScreen : Form
    {

        static DateTime currentDT = DateTime.Now;
        public static int currentYear = currentDT.Year;
        public static int currentMonth = currentDT.Month;
        public static Appointment selectedAppointment;
        public static bool firstLoad;
        public static bool monthlyView = true;
        public static int dayCount = DateTime.DaysInMonth(currentYear, currentMonth);
        public static DateTime boxDate;

        public static DateTime startOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
        public static DateTime endOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Saturday);

        public MainScreen()
        {
            InitializeComponent();
        }

        private void MainScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            if (monthlyView)
            {
                dayContainer.Controls.Clear();
                setMonthName();
                displayDaysMonthly();
            }
            else{
                setWeekLabel();
                dayContainer.Controls.Clear();
                displayDaysWeekly();
            }

            if (firstLoad == true) {
                displayReminder();
            }
        }

        private void setMonthName() {
            weekLabel.Visible = false;
            monthLabel.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(currentMonth) + " " + currentYear;
        }
        private void setWeekLabel() {
            weekLabel.Text = "Week Of: " + startOfWeek.ToString("MM/dd/yyyy") + " - "+ endOfWeek.ToString("MM/dd/yyyy");
            weekLabel.Visible = true;
        }

        private void displayDaysWeekly() {


            for (int i = startOfWeek.Day; i < startOfWeek.Day + 7; i++)
            {
                UserControlDay day = new UserControlDay();

                if (i == DateTime.Now.Day && DateTime.Now.Month == currentMonth && DateTime.Now.Year == currentYear)
                {
                    day.BackColor = Color.DeepSkyBlue;
                }

                if (i <= dayCount)
                {
                    day.setDayNumber(i);
                }
                else if(i >= dayCount){
                    day.setDayNumber(i - dayCount);
                }

                day.displayAppointmentsByWeek();
                dayContainer.Controls.Add(day);
            }
        }

        private void displayDaysMonthly() {

            //grab the start of the month day
            DateTime monthStart = new DateTime(currentYear, currentMonth, 1);

            //grab the number of days in the current month
            int dayCount = DateTime.DaysInMonth(currentYear, currentMonth);

            int weekday = Convert.ToInt32(monthStart.DayOfWeek.ToString("d")) + 1;
            
            //blank days on calendar
            for (int i = 1; i < weekday; i++) {
                UserControlBlank blank = new UserControlBlank();
                dayContainer.Controls.Add(blank);
            }

            //non blank days on calendar
            for (int i = 1; i <= dayCount; i++) {
                UserControlDay days = new UserControlDay();
                days.setDayNumber(i);
                dayContainer.Controls.Add(days);
                days.displayAppointments(currentMonth, currentYear);
                if (i == DateTime.Now.Day && DateTime.Now.Month == currentMonth && DateTime.Now.Year == currentYear)
                {
                    days.BackColor = Color.DeepSkyBlue;
                }
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            dayContainer.Controls.Clear();
            if (monthlyView)
            {
                if (currentMonth == 12)
                {
                    currentYear += 1;
                    currentMonth = 1;
                    displayDaysMonthly();
                    setMonthName();
                }
                else
                {
                    currentMonth += 1;
                    displayDaysMonthly();
                    setMonthName();
                }
            }
            else
            {
                startOfWeek = startOfWeek.AddDays(7);
                endOfWeek = endOfWeek.AddDays(7);
                displayDaysWeekly();
                setWeekLabel();
            }
        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            dayContainer.Controls.Clear();
            if (monthlyView)
            {
                if (currentMonth == 1)
                {
                    currentYear -= 1;
                    currentMonth = 12;
                    displayDaysMonthly();
                    setMonthName();
                }
                else
                {
                    currentMonth -= 1;
                    displayDaysMonthly();
                    setMonthName();

                }
            }
            else
            {
                startOfWeek = startOfWeek.AddDays(-7);
                endOfWeek = endOfWeek.AddDays(-7);
                displayDaysWeekly();
                setWeekLabel();
            }

        }

        private void displayReminder() {
            DateTime currentTime = DateTime.Now; 

            foreach (Appointment appt in Appointment.GetAppointmentsLocal().ToList()) {
                DateTime start = DateTime.Parse(appt.startTime);

                if (currentTime.Day == start.Day && currentTime.Month == start.Month && currentTime.Year == start.Year) {
                    TimeSpan howClose = start - currentTime;
                    int minutes = (int)Math.Ceiling(howClose.TotalMinutes);
                    if (minutes <= 15 && minutes >= 0)
                    {
                        MessageBox.Show("The Following appointment is coming up: " + "\n \n'" + appt.title + "' at " + appt.startTime
                            + " in " + minutes + " minutes!");
                    }
                }
            }
        }

        private void manageCust_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form customerScreen = new ManageCustomers();
            customerScreen.ShowDialog();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form login = new Login();
            login.ShowDialog();
        }

        private void genReport_Click(object sender, EventArgs e)
        {
            Form reportPage = new Report();
            reportPage.ShowDialog();
        }

        private void editApp_Click(object sender, EventArgs e)
        {

            if (UserControlDay.selectedDate != DateTime.MinValue) {

                selectedAppointment = Appointment.dbGetByDateTime(UserControlDay.selectedDate.ToString("yyyy-MM-dd HH:mm:ss"));

                if (selectedAppointment != null)
                {
                    this.Hide();
                    Form editApptPage = new EditAppointment();
                    editApptPage.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No Appointment Selected!");
                }
            }
            else
            {
                MessageBox.Show("Please pick a day by double clicking it!");
            }


        }

        private void deleteApp_Click(object sender, EventArgs e)
        {
            selectedAppointment = Appointment.dbGetByDateTime(UserControlDay.selectedDate.ToString("yyyy-MM-dd HH:mm:ss"));

            if (selectedAppointment != null)
            {
                DialogResult confirmation = MessageBox.Show("Are you sure you want to delete this appointment?",
                         "Confirm", MessageBoxButtons.YesNo);
                if (confirmation == DialogResult.Yes) {
                    string query = "Delete from appointment Where appointmentID = @id";

                    try
                    {

                        MySqlCommand command = new MySqlCommand(query, DBConnection.conn);
                        command.Parameters.AddWithValue("@id", selectedAppointment.id);
                        command.ExecuteNonQuery();
                        this.dayContainer.Controls.Clear();
                        MainScreen_Load(sender, e);
                    }

                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Failed To Delete Appointment!");
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("No Appointment Selected!");
            }
        }

        private void addApp_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form addPage = new AddAppointment();
            addPage.ShowDialog();
        }

        private void changeViewButton_Click(object sender, EventArgs e)
        {
            monthlyView = !monthlyView;
            if (monthlyView)
            {
                dayContainer.Controls.Clear();
                setMonthName();
                displayDaysMonthly();
            }
            else{
                setWeekLabel();
                dayContainer.Controls.Clear();
                displayDaysWeekly();
            }

        }
    }
}
