using c969.Database;
using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using c969.View;

namespace c969
{
    public partial class Login : Form
    {
        //error messagess
        String englishErrorMessage = "The username and password did not match.";
        String spanishErrorMessage = "El nombre de usuario y la contraseña no coinciden.";
        String err = "";
        
        public static string userName;

        //file creation variables
        public static string currentDirectory = Environment.CurrentDirectory;

        //path should be located in the solution folder inside the "bin" folder as "logins.txt"
        public static string path = Directory.GetParent(currentDirectory) + "/logins.txt";

        public Login()
        {
            InitializeComponent();
            CheckCurrentCulture();
            passwordBox.UseSystemPasswordChar = true;
        }

        private string CheckCurrentCulture()
        {
            if (RegionInfo.CurrentRegion.EnglishName == "Mexico")
            {
                renderInSpanish();
                return "spanish";
            }
            else { 
                err = englishErrorMessage;
                return "english";
            }
        }

        private void renderInSpanish() {
            usernameLabel.Text = "Nombre De Usuario";
            loginButton.Text = "Iniciar";
            passwordLabel.Text = "Contraseña";
            languageLabel.Text = "Idioma: Español (México)";
            err = spanishErrorMessage;
        }

        private void validateLoginBoxes(string lang) {

            if (string.IsNullOrWhiteSpace(passwordBox.Text) || string.IsNullOrEmpty(passwordBox.Text) || string.IsNullOrEmpty(userNameBox.Text) || string.IsNullOrWhiteSpace(userNameBox.Text))
            {

                if (lang == "spanish")
                {
                    err = "El nombre de usuario o la contraseña no pueden estar en blanco.";
                }
                else {

                    err = "Neither the username nor password can be blank.";
                }
                
            }
            else {

                if (lang == "spanish")
                {
                    err = spanishErrorMessage;
                }
                else {

                    err = englishErrorMessage;
                
                }

            }

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            userName = userNameBox.Text;

            string query = "Select password from user Where userName = @user";
            MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
            cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = userNameBox.Text.Trim();
            string hashword = DBConnection.HashPassword(cmd.ExecuteScalar().ToString());
            try
            {
                if (DBConnection.ValidatePassword(passwordBox.Text.Trim(), hashword)) 
                {
                    // check to see if "logins.txt" already exists
                    if (!File.Exists(path))
                    {
                        // If it doesn't, create a file to write to.
                        using (StreamWriter sw = File.CreateText(path))
                        {
                            sw.WriteLine(userName + " logged in at: " + DateTime.Now);
                        }
                    }
                    else {
                        // Else, append to the existing file.
                        using (StreamWriter sw = File.AppendText(path)) {
                            sw.WriteLine(userName + " logged in at: " + DateTime.Now);
                        }    
                    }

                    this.Hide();
                    Form mainScreen = new MainScreen();
                    MainScreen.firstLoad = true;
                    mainScreen.ShowDialog();
                }
                else
                {
                    validateLoginBoxes(CheckCurrentCulture());
                    MessageBox.Show(err);
                }
            }
            catch (MySqlException ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
     