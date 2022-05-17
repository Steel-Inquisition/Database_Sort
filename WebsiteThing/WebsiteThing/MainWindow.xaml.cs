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

        // Global Variables
        public Dictionary<string, User> UserDictionary = new();
        public string User_Name = "";
        public Dictionary<string, Weapon> AllWeapons = new();


        // Instanly activates when the window loads in the first time
        public MainWindow()
        {
            InitializeComponent();

            // Load All The Weapons
            Load_All_Weapons();

            // Load User Data
            Load_User_Data();
        }


        // Start user menu when successfully enters account
        public void Set_Up_Menu_For_User()
        {
            // Get welcome text based on the username
            WelcomeUserText.Text = $"Welcome, {UserDictionary[User_Name].user_name}!";

            // Write down all the weapon data without parameters
            WriteAllData();

            // Write down current user favorites
            PrintWishlist();
        }




        // Write all data down with no parameters needed
        public void WriteAllData()
        {
            foreach (KeyValuePair<string, Weapon> kvp in AllWeapons)
            {
                DisplayData.Text += $"{kvp.Key} \n";
            }
        }
    }

    // Users
    public class User
    {

        // User Names
        public string user_name = "";

        // Password to this User
        public string password = "";

        // Backup to this User
        public string backup = "";

        // This User's Favorite Weapons
        public List<Weapon> FavoriteWeapons = new();

        // The User
        public User(string user_name, string password, string backup)
        {
            this.user_name = user_name;
            this.password = password;
            this.backup = backup;
        }

    }


    // Data-Points Stats
    public class Weapon
    {

        // Type of the Weapon
        public string type = "";

        // Name of the Weapon
        public string name = "";

        // Weapon Stats
        public int physical_damage;
        public int magical_damage;
        public int fire_damage;
        public int lightning_damage;
        public int critical;

        // Weapon Parameter
        public string strength_parameter = "";
        public string dexterity_parameter = "";
        public string intelligence_parameter = "";
        public string faith_parameter = "";

        // Weapon cause bleed or poision
        public int bleed;
        public int poision;

        // Divine or Occult
        public int auxiliary_divine_dark_souls;
        public int auxiliary_occult_dark_souls;

        // Defense
        public int physical_defense;
        public int magic_defense;
        public int fire_defense;
        public int lightning_defense;

        // Stability
        public int stability;

        // Only used to create Weapons
        public Weapon(string type, string name, int physical_damage, int magical_damage, int fire_damage, int lightning_damage, int critical, string strength_parameter, string dexterity_parameter, string intelligence_parameter, string faith_parameter, int bleed, int poision, int auxiliary_divine_dark_souls, int auxiliary_occult_dark_souls, int physical_defense, int magic_defense, int fire_defense, int lightning_defense, int stability)
        {
            this.type = type;
            this.name = name;
            this.physical_damage = physical_damage;
            this.magical_damage = magical_damage;
            this.fire_damage = fire_damage;
            this.lightning_damage = lightning_damage;
            this.critical = critical;
            this.strength_parameter = strength_parameter;
            this.dexterity_parameter = dexterity_parameter;
            this.intelligence_parameter = intelligence_parameter;
            this.faith_parameter = faith_parameter;
            this.bleed = bleed;
            this.poision = poision;
            this.auxiliary_divine_dark_souls = auxiliary_divine_dark_souls;
            this.auxiliary_occult_dark_souls = auxiliary_occult_dark_souls;
            this.physical_defense = physical_defense;
            this.magic_defense = magic_defense;
            this.fire_defense = fire_defense;
            this.lightning_defense = lightning_defense;
            this.stability = stability;

        }
    }
}
