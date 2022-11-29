using c969.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c969.Model
{
    class User : Table
    {
        private int userID;
        private string username;

        //getters and setters
        public int getUserID() { return userID; }
        public string getUsername() { return username; }

        public void setUserID(int id) { userID = id; }
        public void setUsername(string name) { username = name; }

        //db getter
        public static List<string> getUsers() {

            // create list of users
            List<string> userList = new List<string>();

            string query = "SELECT userName FROM user";

            MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                userList.Add(reader[0].ToString());
            }
            reader.Close();
            return userList;
        }

        public static int findUserID(string username) {
            string query = "Select userID from `user` WHERE userName = @username;";
            DBConnection.closeConnection();
            try
            {
                DBConnection.startConnection();
                MySqlCommand command = new MySqlCommand(query, DBConnection.conn);
                command.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;

                int idFound = Convert.ToInt32(command.ExecuteScalar());
                return idFound;
            }
            catch (MySqlException ex) {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public static string findUserName(int id)
        {
            string query = "Select userName from `user` WHERE userID = @id;";

            try
            {

                MySqlCommand command = new MySqlCommand(query, DBConnection.conn);
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                string userFound = command.ExecuteScalar().ToString();
                return userFound;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
