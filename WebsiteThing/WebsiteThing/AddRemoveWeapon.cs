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
        // Add Weapon Functions
        private void AddWeapon(object sender, RoutedEventArgs e)
        {

            bool found = false;

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
        private void RemoveWeapon(object sender, RoutedEventArgs e)
        {

            bool found = false;

            foreach (KeyValuePair<string, Weapon> kvp in AllWeapons)
            {

                // if this weapon is the same as the inputed weapon the player wants to remove
                if (kvp.Key == RemoveWeaponInput.Text)
                {
                    UserDictionary[User_Name].FavoriteWeapons.Remove(kvp.Value);

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

        // Print all the members of the wishlist
        private void PrintWishlist()
        {
            DisplayFavorites.Text = "";

            // Get the player's favorite weapon and display them
            foreach (Weapon this_weapon in UserDictionary[User_Name].FavoriteWeapons)
            {
                DisplayFavorites.Text += $"{this_weapon.name} \n";
            }
        }
    }

}
