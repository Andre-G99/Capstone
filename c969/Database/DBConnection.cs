using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BC = BCrypt.Net.BCrypt;

namespace c969.Database
{
    class DBConnection
    {

        public static MySqlConnection conn { get; set; }
        public const int SIZE = 32;

        public static void startConnection()
        {
            //open the connection
            try
            {
                //get the conncetion string
                string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
                conn = new MySqlConnection(constr);
                conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void closeConnection()
        {
            //close the connection
            try
            {
                if (conn != null)
                {
                    conn.Close();
                }
                conn = null;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public static bool findLinkedAppointments(int customerID)
        {
            string query = "Select * from appointment WHERE customerID = @customerID;";
            MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
            cmd.Parameters.Add("@customerID", MySqlDbType.Int32).Value = customerID;

            MySqlDataAdapter sda = new MySqlDataAdapter();
            sda.SelectCommand = cmd;
            DataTable dtbl = new DataTable();
            try
            {
                sda.Fill(dtbl);
                if (dtbl.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private static string GetRandomSalt()
        {
            return BC.GenerateSalt(12);
        }

        public static string HashPassword(string password)
        {
            return BC.HashPassword(password, GetRandomSalt());
        }

        public static bool ValidatePassword(string password, string correctHash)
        {
            return BC.Verify(password, correctHash);
        }
    }
}
