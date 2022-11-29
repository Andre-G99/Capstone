using c969.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c969.Model
{
    public class Customer : Table
    {
        private string _name;
        private int _addressID;
        private int _active;

        //class properties
        public string name { 
            get { return _name; }
            set { _name = value; }
        }
        public int addressID 
        {
            get { return _addressID; }
            set { _addressID = value; }
        }
        public int active 
        {
            get { return _active; }
            set { _active = value; }
        }

        //db getters

        public static BindingList<Customer> getCustomerList() {

            string query = "Select * from customer;";

            BindingList<Customer> customerList = new BindingList<Customer>();

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    //create an appointment object and add it to the appointment list
                    Customer cust = new Customer();
                    cust.id = (int)reader[0];
                    cust.name = reader[1].ToString();
                    cust.addressID = (int)reader[2];
                    cust.createDate = reader[4].ToString();
                    cust.createdBy = reader[5].ToString();
                    cust.lastUpdate = reader[6].ToString();
                    cust.lastUpdatedBy = reader[7].ToString();

                    if (reader[3].ToString() == "True")
                    {
                        cust.active = 1;
                    }
                    else { cust.active = 0; }


                    customerList.Add(cust);
                }
                // close the reader
                reader.Close();
                //return the list of appointments
                return customerList;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;

            }
        }
        public string getName(int id) {
            string query = "Select customerName from `customer` WHERE customerID = @id;";
            try
            {
                MySqlCommand command = new MySqlCommand(query, DBConnection.conn);
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                MySqlDataReader reader = command.ExecuteReader();
                reader.Read();

                //grab and set the customer name
                name = reader[0].ToString();

                reader.Close();

                return name;
            }
            catch (MySqlException ex)
            {
                return ex.Message;

            }
        }
        public int getActive() {
            string query = "Select active from `customer` WHERE customerID = @id;";
            try
            {
                MySqlCommand command = new MySqlCommand(query, DBConnection.conn);
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                MySqlDataReader reader = command.ExecuteReader();
                reader.Read();

                //grab and set the customer name
                active = (int)reader[0];

                reader.Close();

                return active;
            }
            catch (MySqlException)
            {
                return 0;

            }
        }

        public static List<string> getCustomerNames()
        {

            // create list of users
            List<string> customerList = new List<string>();

            string query = "SELECT customerName FROM customer";

            MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                customerList.Add(reader[0].ToString());
            }
            reader.Close();
            return customerList;
        }

        // other class methods
        public static int findCustomer(string name, int addressID, string zipcode) {
            string query = "Select * from customer WHERE (customerName = @name and addressID = @addressID and postalCode = @zipcode);";
            try
            {
                MySqlCommand command = new MySqlCommand(query, DBConnection.conn);
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                command.Parameters.Add("@addressID", MySqlDbType.Int32).Value = addressID;
                command.Parameters.Add("@zipcode", MySqlDbType.VarChar).Value = zipcode;

                int idFound = Convert.ToInt32(command.ExecuteScalar());
                return idFound;
            }
            catch
            {
                return 0;
            }
        }
        public static int findCustomer(string name, int addressID)
        {
            string query = "Select * from customer WHERE (customerName = @name and addressID = @addressID);";
            try
            {
                MySqlCommand command = new MySqlCommand(query, DBConnection.conn);
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                command.Parameters.Add("@addressID", MySqlDbType.Int32).Value = addressID;
                int idFound = Convert.ToInt32(command.ExecuteScalar());
                return idFound;
            }
            catch
            {
                return 0;
            }
        }

        public static int findAddressID(string name, int id)
        {
            string query = "Select addressID from customer WHERE (customerName = @name and customerID = @id);";
            try
            {
                MySqlCommand command = new MySqlCommand(query, DBConnection.conn);
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                int idFound = Convert.ToInt32(command.ExecuteScalar());
                return idFound;
            }
            catch
            {
                return 0;
            }
        }

        public string updateCustomer() {
            string query = "UPDATE `customer` SET customerName = @name, addressID = @addressID, lastUpdate = NOW(), lastUpdateBy = @user WHERE customerID = @id";
            try
            {
                MySqlCommand command = new MySqlCommand(query, DBConnection.conn);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@addressID", addressID);
                command.Parameters.AddWithValue("@active", active);
                command.Parameters.AddWithValue("@createDate", createDate);
                command.Parameters.AddWithValue("@user", lastUpdatedBy);
                command.ExecuteNonQuery();

                return "Customer Successfully Updated!";
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;

            }
        }

        public string saveData()
        {

            string query = "INSERT INTO `customer` VALUES" + "(@id, @name, @addressID, @active, NOW(), @user, NOW(), @user)";
            try
            {
                MySqlCommand command = new MySqlCommand(query, DBConnection.conn);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@addressID", addressID);
                command.Parameters.AddWithValue("@active", active);
                command.Parameters.AddWithValue("@createDate", createDate);
                command.Parameters.AddWithValue("@user", createdBy);
                command.ExecuteNonQuery();

                return "Customer Successfully Added!";
            }
            catch (MySqlException ex)
            {
                return ex.Message;

            }
        }

        public string validateInput()
        {
            bool validName;
            bool validAddressID;

            if (String.IsNullOrEmpty(name) || String.IsNullOrWhiteSpace(name))
            {
                validName = false;
            }
            else {
                validName = true;
            }

            if (addressID <= 0) {
                validAddressID = false;
            }
            else {
                validAddressID = true;
            }

            if (validName && validAddressID)
            {
                return "valid";
            }
            else if (validName == false && validAddressID == true)
            {
                return "invalid name";
            }
            else if (validName == true && validAddressID == false)
            {
                return "invalid address";
            }
            else {
                return "invalid both";
            }
        }
    }
}
