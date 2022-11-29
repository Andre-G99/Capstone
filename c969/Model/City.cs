using c969.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c969.Model
{
    public class City : Table
    {
        private string name;
        private int countryID;

        //getters and setters
        public string getName() { return name; }
        public int getCountryID() { return countryID; }
        public void setName(string cityName) { name = cityName; }
        public void setCountryID(int country) { countryID = country; }

        // db getter
        public void GetCityInfo(int idNumber)
        {

            string query = "Select * from `city` WHERE cityID = @id;";
            try
            {
                // create and open the reader
                MySqlCommand command = new MySqlCommand(query, DBConnection.conn);
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = idNumber;
                MySqlDataReader reader = command.ExecuteReader();
                reader.Read();

                //grab and set the city name and country id
                id = (int)reader[0];
                name = reader[1].ToString();
                countryID = (int)reader[2];

                // close the reader
                reader.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);

            }
        }

        // other class methods
        public bool checkCityAndSave(Country country) {
            //next we check if the city entered is already in the database
            if (this.CheckCity(country.id, this.getName()) != 0 && country.id != 0)
            {
                // if it is we assign the id and country id to it
                this.id = this.CheckCity(country.id, this.getName());
                this.setCountryID(country.id);
                return true;
            }
            else
            {
                // double check that country is valid, makes sure that no cities are created with null for the countryID
                if (country.id != 0)
                {
                    // if it is not we generate an id, assign it a corresponding country ID and a createdBy user value
                    this.id = this.generateID("city");
                    this.setCountryID(country.id);
                    createdBy = Login.userName;
                    lastUpdate = DateTime.Now.ToString("YYYY-MM-DD hh:mm:ss");

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
                else {
                    return false;
                }
            }
        }

        public int CheckCity(int id, string name)
        {

            string query = "Select * from city WHERE (countryID = @id and city = @name);";
            try
            {
                MySqlCommand command = new MySqlCommand(query, DBConnection.conn);
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;

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
            string query = "INSERT INTO `city` VALUES" + "(@id, @name, " + "(SELECT countryID FROM country WHERE countryID = @countryID), NOW(), @user, NOW(), @user)";
            try
            {
                MySqlCommand command = new MySqlCommand(query, DBConnection.conn);
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                command.Parameters.Add("@countryID", MySqlDbType.Int32).Value = countryID;
                command.Parameters.Add("@user", MySqlDbType.VarChar).Value = createdBy;
                command.ExecuteNonQuery();

                return "city success";
            }
            catch (MySqlException ex)
            {
                return ex.Message;

            }
        }

        public bool validateInput()
        {
            bool validName;
            bool validCountryID;

            if (String.IsNullOrEmpty(name) || String.IsNullOrWhiteSpace(name))
            {
                id = 0;
                validName = false;
            }
            else
            {
                validName = true;
            }

            if (countryID <= 0)
            {
                validCountryID = false;
            }
            else
            {
                validCountryID = true;
            }

            if (validName && validCountryID)
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
