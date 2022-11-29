using c969.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c969.Model
{
    public class Appointment : Table
    {

        //class fields
        private int _customerID;
        private int _userID;
        private string _title;
        private string _description;
        private string _location;
        private string _contact;
        private string _type;
        private string _url;
        private string _startTime;
        private string _endTime;

        //class properties
        public int customerID
        {
            get { return _customerID; }
            set { _customerID = value; }
        }
        public int userID
        {
            get { return _userID; }
            set { _userID = value; }
        }
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string description
        {
            get { return _description; }
            set { _description = value; }
        }
        public string location
        {
            get { return _location; }
            set { _location = value; }
        }
        public string contact
        {
            get { return _contact; }
            set { _contact = value; }
        }
        public string type
        {
            get { return _type; }
            set { _type = value; }
        }
        public string url
        {
            get { return _url; }
            set { _url = value; }
        }
        public string startTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }
        public string endTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }

        //database getter; used for getting appt info when editing the info
        public void dbGetter(int id)
        {
            string query = "Select * from `appointment` WHERE appointmentID = @id;";
            try
            {
                // create and open the reader
                MySqlCommand command = new MySqlCommand(query, DBConnection.conn);
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                MySqlDataReader reader = command.ExecuteReader();
                reader.Read();

                //grab and set the appointment info
                id = (int)reader[0];
                _customerID = (int)reader[1];
                _userID = (int)reader[2];
                _title = reader[3].ToString();
                _description = reader[4].ToString();
                _location = reader[5].ToString();
                _contact = reader[6].ToString();
                _type = reader[7].ToString();
                _url = reader[8].ToString();
                _startTime = reader[9].ToString();
                _endTime = reader[10].ToString();
                createDate = reader[11].ToString();

                // close the reader
                reader.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

        // get appointment matching the passed date and time
        public static Appointment dbGetByDateTime(string date)
        {
            string query = "Select * from `appointment` WHERE start = @date;";
            try
            {
                Appointment appt = new Appointment();
                // create and open the reader
                MySqlCommand command = new MySqlCommand(query, DBConnection.conn);
                command.Parameters.Add("@date", MySqlDbType.DateTime).Value = date;
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows == false)
                {
                    reader.Close();
                    return null;
                }
                else
                {
                    reader.Read();

                    //grab and set the appointment info
                    appt.id = (int)reader[0];
                    appt.customerID = (int)reader[1];
                    appt.userID = (int)reader[2];
                    appt.title = reader[3].ToString();
                    appt.description = reader[4].ToString();
                    appt.location = reader[5].ToString();
                    appt.contact = reader[6].ToString();
                    appt.type = reader[7].ToString();
                    appt.url = reader[8].ToString();
                    appt.startTime = reader[9].ToString();
                    appt.endTime = reader[10].ToString();
                    appt.createDate = reader[11].ToString();
                    appt.createdBy = reader[12].ToString();
                    appt.lastUpdate = reader[13].ToString();
                    appt.lastUpdatedBy = reader[14].ToString();

                    // close the reader
                    reader.Close();
                    return appt;
                }
            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;

            }
        }

        //get a weekNumber from the Database
        public static int getWeekNumber(string date) {
            // set up time difference and find current date
            DBConnection.closeConnection();
            int week;

            //find all appointments at the converted time
            string query = "Select WEEK(@date);";
            try
            {
                DBConnection.startConnection();
                MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
                cmd.Parameters.Add("@date", MySqlDbType.DateTime).Value = date;
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows == false)
                {
                    reader.Close();
                    return -1;
                }
                else
                {
                    reader.Read();
                    week = Convert.ToInt32(reader[0].ToString());
                    // close the reader
                    reader.Close();

                    //return the list
                    return week;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        //return list of names and local start time of appointments for the weeks
        public static List<string> GetAppointmentNamesByWeek(int week)
        {

            //create list
            List<string> apptList = new List<string>();

            // set up time difference and find current date
            string timeOffset = TimeZoneInfo.Local.GetUtcOffset(DateTimeOffset.Now).ToString().Substring(0, 5);

            if (timeOffset[0] == '0') { 
                timeOffset = '+' + timeOffset;
            }
            else { 
                timeOffset = TimeZoneInfo.Local.GetUtcOffset(DateTimeOffset.Now).ToString().Substring(0, 6);
            }

            int userID = User.findUserID(Login.userName);
            DBConnection.closeConnection();

            //find all appointments at the converted time
            string query = "Select title, CONVERT_TZ(`start`,'+00:00', @offset) from `appointment` WHERE WEEK(CONVERT_TZ(`start`,'+00:00', @offset))= @week AND userID = @userID ORDER BY start;";
            try
            {
                DBConnection.startConnection();
                MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
                cmd.Parameters.Add("@offset", MySqlDbType.String).Value = timeOffset;
                cmd.Parameters.Add("@week", MySqlDbType.Int32).Value = week;
                cmd.Parameters.Add("@userID", MySqlDbType.Int32).Value = userID;
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows == false)
                {
                    reader.Close();
                    return null;
                }
                else
                {
                    while (reader.Read())
                    {
                        //rawDate is converted time from utc in the database to user's local time
                        string rawDate = reader[1].ToString();
                        DateTime convertedTime = DateTime.Parse(rawDate);

                        //add the appointment to the listbox
                        apptList.Add(reader[0].ToString() + " - " + convertedTime);
                    }
                    // close the reader
                    reader.Close();

                    //return the list
                    return apptList;
                }
            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
        }

        //return list of names and local start time of appointments for the month
        public static List<string> GetAppointmentNames(int currentMonth, int currentYear, int currentDay)
        {

            //create listbox
            List<string> apptList = new List<string>();

            // set up time difference and find current date
            string date = currentYear + "-" + currentMonth + "-" + currentDay;
            string timeOffset = TimeZoneInfo.Local.GetUtcOffset(DateTimeOffset.Now).ToString().Substring(0, 5);

            if (timeOffset[0] == '0') { 
                timeOffset = '+' + timeOffset;
            }
            else { 
                timeOffset = TimeZoneInfo.Local.GetUtcOffset(DateTimeOffset.Now).ToString().Substring(0, 6);
            }

            int userID = User.findUserID(Login.userName);
            DBConnection.closeConnection();

            //find all appointments at the converted time
            string query = "Select title, CONVERT_TZ(`start`,'+00:00', @offset) from `appointment` WHERE DATE(CONVERT_TZ(`start`,'+00:00', @offset))= @date AND userID = @userID ORDER BY start;";
            try
            {
                DBConnection.startConnection();
                MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
                cmd.Parameters.Add("@offset", MySqlDbType.String).Value = timeOffset;
                cmd.Parameters.Add("@date", MySqlDbType.DateTime).Value = date;
                cmd.Parameters.Add("@userID", MySqlDbType.Int32).Value = userID;
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows == false)
                {
                    reader.Close();
                    return null;
                }
                else
                {
                    while (reader.Read())
                    {
                        //rawDate is converted time from utc in the database to user's local time
                        string rawDate = reader[1].ToString();
                        DateTime convertedTime = DateTime.Parse(rawDate);

                        //format the time to have "AM" and "PM"s
                        string formattedTime = string.Format("{0:hh:mm tt}", convertedTime);

                        //if the date matches the appointment time add it
                        if (convertedTime.Month == currentMonth && convertedTime.Year == currentYear && convertedTime.Day == currentDay)
                        {
                            //add the appointment to the listbox
                            apptList.Add(reader[0].ToString() + " - " + formattedTime);
                        }
                    }
                    // close the reader
                    reader.Close();

                    //return the list
                    return apptList;
                }
            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message + "por favor");
                return null;
            }
        }

        // return list of appointments in local time
        public static List<Appointment> GetAppointmentsLocal()
        {
            DateTime convertedTime;

            // make a list of all appointments from the database
            List<Appointment> appointmentList = new List<Appointment>();
            string query = "SELECT * FROM appointment";

            MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                //create an appointment object and add it to the appointment list
                Appointment app = new Appointment();
                app.id = (int)reader[0];
                app.customerID = ((int)reader[1]);
                app.userID = (int)reader[2];
                app.title = reader[3].ToString();
                app.description = reader[4].ToString();
                app.location = reader[5].ToString();
                app.contact = reader[6].ToString();
                app.type = reader[7].ToString();
                app.url = reader[8].ToString();
                app.startTime = reader[9].ToString();
                app.endTime = reader[10].ToString();
                app.createDate = reader[11].ToString();
                app.createdBy = reader[12].ToString();
                app.lastUpdate = reader[13].ToString();
                app.lastUpdatedBy = reader[13].ToString();

                if (DateTime.Parse(app.startTime).IsDaylightSavingTime() && DateTime.Now.IsDaylightSavingTime() == false)
                {
                    //convert start time to local time
                    convertedTime = DateTime.Parse(app.startTime).ToLocalTime().AddHours(1);
                    app.startTime = convertedTime.ToString();
                }
                else
                {
                    convertedTime = DateTime.Parse(app.startTime).ToLocalTime();
                    app.startTime = convertedTime.ToString();
                }

                appointmentList.Add(app);
            }
            reader.Close();
            return appointmentList;
        }

        //db getter by user
        public static BindingList<Appointment> dbGetterByUser(int id)
        {

            BindingList<Appointment> appointmentList = new BindingList<Appointment>();

            string query = "Select * from `appointment` WHERE userID = @id;";
            try
            {

                MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    //create an appointment object and add it to the appointment list
                    Appointment app = new Appointment();
                    app.id = (int)reader[0];
                    app._customerID = (int)reader[1];
                    app._userID = (int)reader[2];
                    app._title = reader[3].ToString();
                    app._description = reader[4].ToString();
                    app._location = reader[5].ToString();
                    app._contact = reader[6].ToString();
                    app._type = reader[7].ToString();
                    app._url = reader[8].ToString();
                    app._startTime = reader[9].ToString();
                    app._endTime = reader[10].ToString();
                    app.createDate = reader[11].ToString();
                    app.createdBy = reader[12].ToString();
                    app.lastUpdate = reader[13].ToString();
                    app.lastUpdatedBy = reader[14].ToString();
                    appointmentList.Add(app);
                }
                // close the reader
                reader.Close();
                //return the list of appointments
                return appointmentList;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;

            }
        }

        public static bool findAppointmentTime(DateTime start, DateTime end, int apptID)
        {

            int currentUserID = User.findUserID(Login.userName);
            string format = "yyyy-MM-dd HH:mm";
            string query;

            string offset = DateTimeOffset.Now.ToString().Substring(DateTimeOffset.Now.ToString().IndexOf('M') + 2);

            //no use of parameters here since datetime and the appointmentID are gathered either programmtically or via a datetime picker which leaves little room for injection from the input methods

            if (offset != "+00:00")
            {
                query = "Select start, end, appointmentID from `appointment` WHERE userID =" + currentUserID + " AND DATE(start) = DATE('" + start.ToUniversalTime().ToString(format) + "')" +
                " AND DATE(end) = DATE('"+ end.ToUniversalTime().ToString(format) + "');";
            }
            else
            {
                query = "Select start, end, appointmentID from `appointment` WHERE userID =" + currentUserID + " AND DATE(start) = DATE('" + start.ToString(format) + "')" +
                " AND DATE(end) = DATE('" + end.ToString(format) + "');";
            }
            DBConnection.closeConnection();

            try
            {
                DBConnection.startConnection();
                MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                //start reading
                reader.Read();

                //grab the start and end dates and look for a match
                if (reader.HasRows && offset != "+00:00")
                {
                    DateTime apptStart = start.ToUniversalTime();
                    DateTime apptEnd = end.ToUniversalTime();
                    DateTime appt2Start = DateTime.Parse(reader[0].ToString());
                    DateTime appt2End = DateTime.Parse(reader[1].ToString());

                    if (appt2Start < apptStart && appt2End > apptStart && (int)reader[2] != apptID)
                    {
                        //close the reader
                        reader.Close();
                        //return true to indicate that there was a match
                        return true;
                    }
                    else if (appt2Start >= apptEnd && appt2End < apptEnd && (int)reader[2] != apptID)
                    {
                        //close the reader
                        reader.Close();
                        //return true to indicate that there was a match
                        return true;
                    }
                    else if (appt2Start >= apptStart && appt2End <= apptEnd && (int)reader[2] != apptID)
                    {
                        //close the reader
                        reader.Close();
                        //return true to indicate that there was a match
                        return true;
                    }
                    else if (appt2Start > apptStart && appt2Start < apptEnd && (int)reader[2] != apptID)
                    {
                        //close the reader
                        reader.Close();
                        //return true to indicate that there was a match
                        return true;
                    }
                    else if (appt2Start <= apptStart && appt2End >= apptEnd && (int)reader[2] != apptID)
                    {
                        //close the reader
                        reader.Close();
                        //return true to indicate that there was a match
                        return true;
                    }

                    else {
                        // close the reader
                           reader.Close();
                        //return false to indicate that there was no match
                            return false;
                    }
                }
                else
                {

                    DateTime apptStart = start;
                    DateTime apptEnd = end;
                    DateTime appt2Start = DateTime.Parse(reader[0].ToString());
                    DateTime appt2End = DateTime.Parse(reader[1].ToString());

                    if (appt2Start < apptStart && appt2End > apptStart && (int)reader[2] != apptID)
                    {
                        //close the reader
                        reader.Close();
                        //return true to indicate that there was a match
                        return true;
                    }
                    else if (appt2Start >= apptEnd && appt2End < apptEnd && (int)reader[2] != apptID)
                    {
                        //close the reader
                        reader.Close();
                        //return true to indicate that there was a match
                        return true;
                    }
                    else if (appt2Start >= apptStart && appt2End <= apptEnd && (int)reader[2] != apptID)
                    {
                        //close the reader
                        reader.Close();
                        //return true to indicate that there was a match
                        return true;
                    }
                    else if (appt2Start > apptStart && appt2Start < apptEnd && (int)reader[2] != apptID)
                    {
                        //close the reader
                        reader.Close();
                        //return true to indicate that there was a match
                        return true;
                    }
                    else if (appt2Start <= apptStart && appt2End >= apptEnd && (int)reader[2] != apptID)
                    {
                        //close the reader
                        reader.Close();
                        //return true to indicate that there was a match
                        return true;
                    }

                    else
                    {
                        // close the reader
                        reader.Close();
                        //return false to indicate that there was no match
                        return false;
                    }
                }

            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
        }

        //update appointments
        public bool updateApp() {
            string query = "UPDATE `appointment` SET customerID = @customerID, userID = @userID, title = @title, description = @description, " +
                "location = @location, contact = @contact, type = @type, url = @url, start = @start, end = @end, " +
                "createDate = @createDate, createdBy = @createdBy, lastUpdate = NOW(), lastUpdateBy = @user " +
                "WHERE appointmentID = @id;";
            DBConnection.closeConnection();
            try
            {
                DBConnection.startConnection();
                MySqlCommand command = new MySqlCommand(query, DBConnection.conn);
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                command.Parameters.Add("@customerID", MySqlDbType.Int32).Value = customerID;
                command.Parameters.Add("@userID", MySqlDbType.Int32).Value = userID;
                command.Parameters.Add("@title", MySqlDbType.VarChar).Value = title;
                command.Parameters.Add("@description", MySqlDbType.Text).Value = description;
                command.Parameters.Add("@location", MySqlDbType.Text).Value = location;
                command.Parameters.Add("@contact", MySqlDbType.Text).Value = contact;
                command.Parameters.Add("@type", MySqlDbType.Text).Value = type;
                command.Parameters.Add("@url", MySqlDbType.VarChar).Value = url;
                command.Parameters.Add("@start", MySqlDbType.VarChar).Value = startTime;
                command.Parameters.Add("@end", MySqlDbType.VarChar).Value = endTime;
                command.Parameters.Add("@createDate", MySqlDbType.VarChar).Value = DateTime.Parse(createDate).ToString("yyyy-MM-dd HH:mm:ss");
                command.Parameters.Add("@createdBy", MySqlDbType.VarChar).Value = createdBy;
                command.Parameters.Add("@user", MySqlDbType.VarChar).Value = lastUpdatedBy;
                command.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;

            }
        }

        public string saveData()
        {

            string query = "INSERT INTO `appointment` VALUES" + "(@id, @customerID, @userID, @title, @description, @location, " +
                "@contact, @type, @url, @start, @end, " + 
                "NOW(), @createdBy, NOW(), @user);";

            DBConnection.closeConnection();
            try
            {
                DBConnection.startConnection();

                MySqlCommand command = new MySqlCommand(query, DBConnection.conn);
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                command.Parameters.Add("@customerID", MySqlDbType.Int32).Value = customerID;
                command.Parameters.Add("@userID", MySqlDbType.Int32).Value = userID;
                command.Parameters.Add("@title", MySqlDbType.VarChar).Value = title;
                command.Parameters.Add("@description", MySqlDbType.Text).Value = description;
                command.Parameters.Add("@location", MySqlDbType.Text).Value = location;
                command.Parameters.Add("@contact", MySqlDbType.Text).Value = contact;
                command.Parameters.Add("@type", MySqlDbType.Text).Value = type;
                command.Parameters.Add("@url", MySqlDbType.VarChar).Value = url;
                command.Parameters.Add("@start", MySqlDbType.VarChar).Value = startTime;
                command.Parameters.Add("@end", MySqlDbType.VarChar).Value = endTime;
                command.Parameters.Add("@createdBy", MySqlDbType.VarChar).Value = createdBy;
                command.Parameters.Add("@user", MySqlDbType.VarChar).Value = lastUpdatedBy;
                command.ExecuteNonQuery();

                return "Appointment Successfully Added!";
            }
            catch(MySqlException ex)
            {
                return ex.Message;
            }
        }
    }
}
