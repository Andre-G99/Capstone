using c969.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c969.Model
{
    public class Country : Table
    {
        private string name;

        //getters and setters
        public string getName() { return name; }
        public void setName(string newName) { name = newName; }

        // db getter
        public void getNameDB(int id) {
            string query = "Select * from `country` WHERE countryID = @id;";
            try
            {
                // create and open the reader
                MySqlCommand command = new MySqlCommand(query, DBConnection.conn);
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                MySqlDataReader reader = command.ExecuteReader();
                reader.Read();

                //grab and set the city name and country id
                name = reader[1].ToString();

                // close the reader
                reader.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
            }
        }

        public bool checkCountryAndSave() {
            if (this.findCountry(this.getName()) != 0)
            {
                //if it is we assign its country id to it
                this.id = this.findCountry(this.getName());
                return true;
            }
            else
            {
                // if it is not we generate and id and assign the user who created it to the createdBy property
                this.id = this.generateID("country");
                createdBy = Login.userName;
                lastUpdatedBy = Login.userName;

                //simultaneously add and validate user input
                if (this.validateInput())
                {
                    this.saveData();
                    return true;
                }
                else
                {
                    id = 0;
                    return false;
                }
            }
        }

        public int findCountry(string name)
        {

            string query = "Select * from country WHERE country = @country;";

            try
            {
                MySqlCommand command = new MySqlCommand(query, DBConnection.conn);
                command.Parameters.Add("@country", MySqlDbType.VarChar).Value = name;
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
            string query = "INSERT INTO `country` VALUES" + "(@id, @name, NOW(), @user, NOW(), @user)";
            try
            {
                MySqlCommand command = new MySqlCommand(query, DBConnection.conn);
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                command.Parameters.Add("@user", MySqlDbType.VarChar).Value = createdBy;
                command.ExecuteNonQuery();

                return "country success";
            }
            catch (MySqlException ex)
            {
                return ex.Message;

            }


        }

        public bool validateInput()
        {
            switch (String.IsNullOrEmpty(name) || String.IsNullOrWhiteSpace(name))
            {
                case true:
                    id = 0;
                    return false;
                case false:
                    return true;
                default:
                    return false;
            }

        }
    }

}
