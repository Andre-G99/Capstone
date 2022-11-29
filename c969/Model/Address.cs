using c969.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c969.Model
{
    public class Address : Table
    {
        private string address;
        private string address2;
        private int cityID;
        private string postalCode;
        private string phoneNumber;

        //setters
        public void setAddress(string addrss) {
            address = addrss;
        }
        public void setAddress2(string addrss2) {
            address2 = addrss2;
        }
        public void setCityID(int id) {
            cityID = id;
        }
        public void setPostalCode(string code) {
            postalCode = code;
        }
        public void setPhone(string phone) {
            phoneNumber = phone;
        }

        //getters
        public string getAddress() { return address; }
        public string getAddress2() { return address2; }
        public int getCityID() { return cityID; }
        public string getPostal() { return postalCode; }
        public string getPhone() { return phoneNumber; }

        // use dbGetter when you are going to edit an address and do not have the info other than the id
        public void dbGetter(int id) {

            string query = "Select * from `address` WHERE addressID = @id;";
            try
            {
                // create and open the reader
                MySqlCommand command = new MySqlCommand(query, DBConnection.conn);
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                MySqlDataReader reader = command.ExecuteReader();
                reader.Read();

                //grab and set the customer name
                address = reader[1].ToString();
                cityID = (int)reader[3];
                postalCode = reader[4].ToString();
                phoneNumber = reader[5].ToString();
      
                // close the reader
                reader.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);

            }
        }

        public bool checkAndSaveAddress(City city) {
            //check to see if the address that is currently entered in the text box is in the database
            if (this.findAddress(city.id, getAddress(), getPhone(), getPostal()) != 0)
            {
                //if it is, assign it the correct address id and city id
                this.id = this.findAddress(city.id, getAddress(), getPhone(), getPostal());
                this.setCityID(city.id);
                return true;
            }
            else
            {
                // if it isn't, generate it a new id
                this.id = (this.generateID("address"));
                // i can just assign it the city.id value since by the time this code is reached the city will be created already
                this.setCityID(city.id);
                createdBy = Login.userName;
                lastUpdate = DateTime.Now.ToString("YYYY-MM-DD hh:mm:ss");
                lastUpdatedBy = Login.userName;
                //add address to db
                //simultaneously add and validate user input
                if (this.validateInput())
                {
                    this.saveData();
                    return true;
                }
                else
                {
                    this.id = 0;
                    return false;
                }
            }
        }

        public int findAddress(int id, string name, string phone, string postal)
        {

            string query = "Select * from address WHERE (cityId = @id and address = @name and phone = @phone"
                + " and postalCode = @postal);";
            try
            {
                MySqlCommand command = new MySqlCommand(query, DBConnection.conn);
                //add parameters
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                command.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone;
                command.Parameters.Add("@postal", MySqlDbType.VarChar).Value = postal;

                int idFound = Convert.ToInt32(command.ExecuteScalar());
                return idFound;
            }
            catch
            {
                return 0;

            }

        }

        public string saveData()
        {
            string query = "INSERT INTO `address` VALUES" + "(@id, @address, @address2, " + "(SELECT cityID FROM city WHERE cityID = @cityID), @postalCode, @phone, NOW(), @user, NOW(), @user)";
            try
            {
                address2 = " ";
                MySqlCommand command = new MySqlCommand(query, DBConnection.conn);
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                command.Parameters.Add("@cityID", MySqlDbType.Int32).Value = cityID;
                command.Parameters.Add("@address", MySqlDbType.VarChar).Value = address;
                command.Parameters.Add("@address2", MySqlDbType.VarChar).Value = address2;
                command.Parameters.Add("@postalCode", MySqlDbType.VarChar).Value = postalCode;
                command.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phoneNumber;
                command.Parameters.Add("@user", MySqlDbType.VarChar).Value = createdBy;
                command.ExecuteNonQuery();

                return "address success";
            }
            catch (MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message) ;
                return ex.Message;

            }
        }

        public bool validateInput()
        {
            bool validAddress;
            bool validCityID;
            bool validPostalCode;
            bool validPhoneNumber;

            if (String.IsNullOrEmpty(phoneNumber) || String.IsNullOrWhiteSpace(phoneNumber))
            {
                validPhoneNumber = false;
            }
            else {
                validPhoneNumber = true;
            }

            if (int.TryParse(postalCode, out int code))
            {
                Convert.ToInt32(code);

                if (code < 0 || (String.IsNullOrEmpty(postalCode.ToString()) || String.IsNullOrWhiteSpace(postalCode.ToString())))
                {
                    validPostalCode = false;
                }
                else
                {
                    validPostalCode = true;
                }

            }
            else {
                validPostalCode = false;
            }

            if (String.IsNullOrEmpty(address) || String.IsNullOrWhiteSpace(address))
            {
                validAddress = false;
            }
            else
            {
                validAddress = true;
            }

            if (cityID <= 0)
            {
                validCityID = false;
            }
            else
            {
                validCityID = true;
            }

            if (validAddress && validCityID && validPostalCode && validPhoneNumber)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
