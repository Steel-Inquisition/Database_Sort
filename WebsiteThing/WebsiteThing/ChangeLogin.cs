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
        // Activates when a user has forgotten their password
        // Changes the visibility so you can see the forgot password box
        public void Forgot_Password(object sender, RoutedEventArgs e)
        {
            log_in_box.Visibility = Visibility.Hidden;
            forgot_password_box.Visibility = Visibility.Visible;
        }

        // Making New User Section
        public void Enter_New_User(object sender, RoutedEventArgs e)
        {

            // Get Input
            string this_username = NewUserName.Text;
            string test_new_password = NewPassword.Text;
            string this_backup = BackUp.Text;

            // If the user inputed password matches to each other and the username isn't blank, the password isn't blank, the backup isn't blank, it isn't a copy of another username that already exists, and that the username isn't the same as it's password. If true, then creates a new user. Otherwise this will be false and it will report as such.
            if (test_new_password == CheckNewPassword.Text && this_username != "" && test_new_password != "" && this_backup != "" && !UserDictionary.ContainsKey(this_username) && this_username != test_new_password)
            {
                // Output that it worked
                MessageBox.Show($"Welcome, {this_username}! You have now created an account!");

                // Add this user to the dictionary
                UserDictionary.Add(this_username, new(this_username, test_new_password, this_backup));

                // Save the new Data
                Save_User_Data();

                // Change visibility
                log_in_box.Visibility = Visibility.Visible;
                no_account_box.Visibility = Visibility.Hidden;

            }
            else
            {
                MessageBox.Show("There is some error in making the new user");
            }

        }



        // Checks if the inputed new password is valid
        public void Replace_New_User(object sender, RoutedEventArgs e)
        {

            // If the inputed new user is returned as true, output that the password has changed, otherwise output that something went wrong
            if (Test_New_User())
            {
                MessageBox.Show("This user's password is now changed!");
            }
            else
            {
                MessageBox.Show("This user doesn't exist or you inputed something wrong");
            }
        }

        // Testing if new password is valid
        public bool Test_New_User()
        {

            // Get Input
            string test_username = TestUserName.Text;
            string test_background = TestBackground.Text;

            string test_new_password = TestPassword.Text;

            // If the attempted replacement of a user doesn't exist, return false
            if (!UserDictionary.ContainsKey(test_username))
            {
                return false;
            }

            // if the user entered background isn't the same as the current user trying to be replaced background
            if (test_background != UserDictionary[test_username].backup)
            {
                return false;
            }


            // if the user entered password isn't the same as it's tested new password
            if (test_new_password != TestPasswordAgain.Text)
            {
                return false;
            }

            // Change this user's password to the inputed password
            UserDictionary[test_username].password = test_new_password;

            // Save the New Data
            Save_User_Data();

            // Returns true to output
            return true;
        }

        // This is used to change viisbility and erase textbox to the main user_log_in box mostly
        public void Exit_Box(object sender, RoutedEventArgs e)
        {

            // Erase the textboxes
            erase(no_account_box);
            erase(forgot_password_box);
            erase(log_in_box);

            // Visibility Change
            log_in_box.Visibility = Visibility.Visible;
            no_account_box.Visibility = Visibility.Hidden;
            forgot_password_box.Visibility = Visibility.Hidden;
        }

        // Eras every textbox in this canvas
        public void erase(Canvas erase_this)
        {
            foreach (TextBox textbox in erase_this.Children.OfType<TextBox>())
            {
                textbox.Text = "";
            }
        }
    }
}
