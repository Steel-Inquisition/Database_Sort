using System.Collections.Generic;
using System.Windows;

namespace WebsiteThing
{
    public partial class MainWindow : Window
    {
        // Add Weapon Functions
        public void AddWeapon(object sender, RoutedEventArgs e)
        {

            bool found = false;


            // Search through the dictionary by it's key and value
            foreach (KeyValuePair<string, Weapon> kvp in AllWeapons)
            {

                // if this weapon is the same as the inputed weapon the player wants to add
                if (kvp.Key == AddWeaponInput.Text)
                {

                    // add this weapon
                    UserDictionary[User_Name].FavoriteWeapons.Add(kvp.Value);

                    // this is found
                    found = true;

                    break;
                }
            }

            // if found then print out the data otherwise state that something went wrong
            if (found)
            {
                PrintWishlist();
            }
            else
            {
                MessageBox.Show("This Weapon Doesn't Exist or was Spelled Wrong");
            }

        }

        // Remove Weapon Function
        public void RemoveWeapon(object sender, RoutedEventArgs e)
        {

            // Get position of the weapon that the user wants to remove
            int position = FindPosition();

            // If the position is found
            if (position > -1)
            {
                // Remove the weapon at the position found
                UserDictionary[User_Name].FavoriteWeapons.RemoveAt(position);

                // Reprint the wishlist to show the new change
                PrintWishlist();
            }


        }


        // Find the position
        public int FindPosition()
        {


            // Search through the user's favorite weapon list
            for (int i = 0; i < UserDictionary[User_Name].FavoriteWeapons.Count; i++)
            {
                // if this weapon is the same as the inputed weapon the player wants to remove
                if (UserDictionary[User_Name].FavoriteWeapons[i].name == RemoveWeaponInput.Text)
                {
                    // returnn the position of the weapon to remove
                    return i;
                }
            }

            // if found then print out the data otherwise state that something went wrong

            MessageBox.Show("This Weapon Doesn't Exist or was Spelled Wrong");

            return -1;
        }


    }





}
