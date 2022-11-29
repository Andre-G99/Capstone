using c969.Database;
using c969.Model;
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
    public partial class UserControlDay : UserControl
    {
        public static UserControlDay selectedDay;
        public static DateTime selectedDate;

        public UserControlDay()
        {
            InitializeComponent();
        }

        public void adjustDate() {
            if (MainScreen.startOfWeek.Month < MainScreen.endOfWeek.Month)
            {
                MainScreen.currentMonth = MainScreen.startOfWeek.Month;
                MainScreen.dayCount = DateTime.DaysInMonth(MainScreen.currentYear, MainScreen.currentMonth);
                if (MainScreen.currentMonth > 12)
                {
                    MainScreen.currentYear += 1;
                    MainScreen.currentMonth = 1;
                }
            }
            else if (MainScreen.startOfWeek.Month > MainScreen.endOfWeek.Month)
            {
                MainScreen.currentMonth = MainScreen.startOfWeek.Month;
                if (MainScreen.currentMonth < 1)
                {
                    MainScreen.currentYear -= 1;
                    MainScreen.currentMonth = 12;
                }
            }
        }

        public void setDayNumber(int dayNumber) {
            numberLabel.Text = dayNumber + "";
        }
        public int getDayNumber() { return Convert.ToInt32(numberLabel.Text); }

        public void displayAppointmentsByWeek() {

            int weekNumber = Appointment.getWeekNumber(MainScreen.startOfWeek.ToString("yyyy-MM-dd HH:mm:ss"));
            List<string> nameList = Appointment.GetAppointmentNamesByWeek(weekNumber);
            List<string> newList = new List<string>();

            string dateString = MainScreen.currentYear + "/" + MainScreen.currentMonth + "/" + getDayNumber().ToString();

            adjustDate();

            if (nameList != null)
            {
                apptList.Visible = true;
                //configure look of listbox
                Font SmallFont = new Font("Microsoft Sans Serif", 9);
                apptList.ScrollAlwaysVisible = false;
                apptList.Width = 166;
                apptList.Font = SmallFont;
                apptList.ForeColor = Color.White;
                apptList.BackColor = Color.FromArgb(45, 45, 45);
                apptList.BorderStyle = BorderStyle.None;

                for (int i = 0; i < nameList.Count; i++)
                {
                    DateTime date = DateTime.Parse(nameList[i].Substring(nameList[i].IndexOf('-') + 2));
                    int comparedWeek = Appointment.getWeekNumber(date.ToString("yyyy-MM-dd HH:mm:ss"));
                    //if the list contains the date of current the current day being rendered
                    if (comparedWeek == weekNumber && date.Day == getDayNumber())
                    {
                        string title = nameList[i].Split('-')[0];
                        string time = nameList[i].Split('-')[1].Split(' ')[2].Substring(0, 5) + " "+ nameList[i].Split('-')[1].Split(' ')[3];

                        if(time.Last() == ':') { 
                            time.Remove(time.Last());
                        }

                        //make a new list
                        newList.Add(title + " - " + time);
                    }
                }

                if (newList.Count() > 0)
                {
                    apptList.DataSource = newList;
                    apptPanel.Controls.Add(apptList);
                }

                if (DateTime.Now.Day == getDayNumber() && DateTime.Now.Year == MainScreen.currentYear && DateTime.Now.Month == MainScreen.currentMonth)
                {
                    apptList.BackColor = Color.DeepSkyBlue;
                }
            }
            else
            {
                apptList.Visible = false;
            }
        }

        public void displayAppointments(int currentMonth, int currentYear) {

            //set the datasource
            List<string>nameList = Appointment.GetAppointmentNames(currentMonth, currentYear, getDayNumber());

            if (nameList != null)
            {
                apptList.DataSource = nameList;
                apptList.Visible = true;
                //configure look of listbox
                Font SmallFont = new Font("Microsoft Sans Serif", 9);
                apptList.ScrollAlwaysVisible = false;
                apptList.Width = 166;
                apptList.Font = SmallFont;
                apptList.ForeColor = Color.White;
                apptList.BackColor = Color.FromArgb(45, 45, 45);
                apptList.BorderStyle = BorderStyle.None;

                if (DateTime.Now.Day == getDayNumber() && DateTime.Now.Year == currentYear && DateTime.Now.Month == currentMonth)
                {
                    apptList.BackColor = Color.DeepSkyBlue;
                }

                //add the listbox to the panel
                apptPanel.Controls.Add(apptList);
            }
            else {
                apptList.Visible = false;
            }
        }

        public DateTime setDate(int currentMonth, int currentYear, int currentDay)
        {
            if (selectedDay.apptList.SelectedItem != null)
            {
                int index = selectedDay.apptList.SelectedItem.ToString().IndexOf('-') + 1;
                string time = selectedDay.apptList.SelectedItem.ToString().Substring(index);
                string dateString = currentYear + "/" + currentMonth + "/" + currentDay + time;
                string offset = DateTimeOffset.Now.ToString().Substring(DateTimeOffset.Now.ToString().IndexOf('M') + 2);

                DateTime date = DateTime.Parse(dateString);


                if(offset == "+00:00") { 
                    return date;
                }
                else { 
                if (date.IsDaylightSavingTime() && DateTime.Now.IsDaylightSavingTime() == false)
                {
                    return date.AddHours(1).ToUniversalTime();
                }
                else if (date.IsDaylightSavingTime() == false && DateTime.Now.IsDaylightSavingTime() == true)
                {
                    return date.AddHours(-1).ToUniversalTime();
                }
                else
                {
                    return date.ToUniversalTime();
                }
            }


            }
            else {
                return DateTime.MinValue;
            }
        }

        public void UserControlDay_Click(object sender, EventArgs e)
        {
            if (selectedDay != null)
            {
                selectedDay.BorderStyle = BorderStyle.FixedSingle;
                selectedDay = this;
                selectedDay.BorderStyle = BorderStyle.Fixed3D;
                selectedDate = setDate(MainScreen.currentMonth, MainScreen.currentYear, getDayNumber());
            }
            else if (MainScreen.startOfWeek.Month < MainScreen.endOfWeek.Month && MainScreen.startOfWeek.Year == MainScreen.endOfWeek.Year && getDayNumber() >= 1 && getDayNumber() <= 6) { 
                
                selectedDay = this;
                selectedDay.BorderStyle = BorderStyle.Fixed3D;
                selectedDate = setDate(MainScreen.endOfWeek.Month, MainScreen.currentYear, getDayNumber());
            }
            else if (MainScreen.startOfWeek.Month < MainScreen.endOfWeek.Month && MainScreen.startOfWeek.Year < MainScreen.endOfWeek.Year && getDayNumber() >= 1 && getDayNumber() <= 6) { 
                
                selectedDay = this;
                selectedDay.BorderStyle = BorderStyle.Fixed3D;
                selectedDate = setDate(MainScreen.endOfWeek.Month, MainScreen.endOfWeek.Year, getDayNumber());
            }
            else {
                selectedDay = this;
                selectedDay.BorderStyle = BorderStyle.Fixed3D;
                selectedDate = setDate(MainScreen.currentMonth, MainScreen.currentYear, getDayNumber());
            }
        }
    }
}
