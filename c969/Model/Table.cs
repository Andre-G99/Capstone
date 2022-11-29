using c969.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c969.Model
{
    public class Table
    {
        //properties all tables in the database have in common
        private int _id;
        private string _createDate;
        private string _createdBy;
        private string _lastUpdate;
        private string _lastUpdatedBy;

        //class properties
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string createDate
        { 
            get { return _createDate; }
            set { _createDate = value; }
        }
        public string createdBy 
        { 
            get { return _createdBy; }
            set { _createdBy = value; }
        }

        public string lastUpdate 
        { 
            get { return _lastUpdate; }
            set { _lastUpdate = value; }
        }

        public string lastUpdatedBy 
        {
            get { return _lastUpdatedBy; }
            set { _lastUpdatedBy = value; }
        }

        //other class methods
        public string saveData(string tableName) {

            string query = "INSERT INTO `@table` VALUES" + "(@ID, @createDate, NOW(), @user, NOW(), @user)";

            try { 
                MySqlCommand command = new MySqlCommand(query, DBConnection.conn);
                command.Parameters.Add("@table", MySqlDbType.String).Value = tableName;
                command.Parameters.Add("@ID", MySqlDbType.Int32).Value = id;
                command.Parameters.Add("@createDate", MySqlDbType.DateTime).Value = createDate;
                command.Parameters.Add("@user", MySqlDbType.VarChar).Value = createdBy;
                command.ExecuteNonQuery();

                return "success";
            }
            catch(MySqlException ex) {
                return ex.Message;

            }
        }

        //id generation
        public int generateID(string table)
        {
            //I'm not using parameters here since the table input is edited programmatically
            string query = "Select * from " + table + " ORDER BY " + table + "ID DESC LIMIT 1;";
            MySqlDataAdapter sda = new MySqlDataAdapter(query, DBConnection.conn);
            DataTable dtbl = new DataTable();

            try
            {
                sda.Fill(dtbl);
                return (int)dtbl.Rows[0][table + "ID"] + 1;
            }

            catch(MySqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return 0;
            }


        }
    }
}
