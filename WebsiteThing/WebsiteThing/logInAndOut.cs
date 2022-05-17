using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace WebsiteThing
{
    public partial class MainWindow : Window
    {

        // Main Log In Section. This checks if the user input is equal to any of the keys in the total user names registered to the system
        public void Log_In(object sender, RoutedEventArgs e)
        {

            // Test Input Function. Will return "" if the input is not considered right.
            User_Name = TestUserNameLogIn();

            if (User_Name != "")
            {
                MessageBox.Show("you are in!");
                Set_Up_Menu_For_User();
                MenuForUser.Visibility = Visibility.Visible;
                log_in_box.Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("you are not in!");
            }
        }


        public string TestUserNameLogIn()
        {
            // Get the input
            string test_username = UsernameEnter.Text;
            string test_password = PasswordEnter.Text;

            // Tests if the total users contain the username and if not returns false ("")
            if (!UserDictionary.ContainsKey(test_username))
            {
                return "";
            }

            // Tests if this user contains the correct password to the inputed data and if not returns false ("")
            if (UserDictionary[test_username].password != test_password)
            {
                return "";

            }

            // if this is correct it will return true (the username that was inputed)
            // Since User_Name is a global variable this confirms it's usage
            return test_username;

        }

        // Activates when making a new account
        // Changes the visibility so you can see the make a new account box
        public void New_Account(object sender, RoutedEventArgs e)
        {
            log_in_box.Visibility = Visibility.Hidden;
            no_account_box.Visibility = Visibility.Visible;
        }

        // When logging out of an account
        public void Log_Out(object sender, RoutedEventArgs e)
        {

            // Return Menu to visible and Main Log-In Box visible
            MenuForUser.Visibility = Visibility.Hidden;
            log_in_box.Visibility = Visibility.Visible;

            // All Checkboxes Are Unchecked 
            foreach (CheckBox check in MenuForUser.Children.OfType<CheckBox>())
            {
                check.IsChecked = false;
            }

            // Textboxes are returned to "E", "None", "", or "0" depending on the type of Textbox
            foreach (TextBox textbox in MenuForUser.Children.OfType<TextBox>())
            {
                if ((string)textbox.Tag == "Parameter")
                {
                    textbox.Text = "E";
                }
                else if ((string)textbox.Tag == "Type")
                {
                    textbox.Text = "None";
                }
                else if ((string)textbox.Tag == "Weapon")
                {
                    textbox.Text = "";
                }
                else
                {
                    textbox.Text = "0";
                }
            }

            // Change Input to ""
            UsernameEnter.Text = "";
            PasswordEnter.Text = "";
        }
    }

}
