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

        // Used only for event handler (button) that will just activate the save feature
        private void Save_This_Button(object sender, RoutedEventArgs e)
        {
            Save_User_Data();
        }


        // Saving the total user data when used
        private void Save_User_Data()
        {
            // Seralzie the data
            var options = new JsonSerializerOptions { IncludeFields = true };
            string jsonString = JsonSerializer.Serialize(UserDictionary, options);

            // The data as a JSON string may be easily saved to a file
            File.WriteAllText(@"data-files/users.txt", jsonString);
        }


        // Load all the data from the JSON / Text file
        public void Load_User_Data()
        {
            // Seralzie
            var options = new JsonSerializerOptions { IncludeFields = true };
            string jsonStringFromFile = File.ReadAllText(@"data-files/users.txt");

            Dictionary<string, User>? TempUserDictionary = JsonSerializer.Deserialize<Dictionary<string, User>>(jsonStringFromFile, options);

            if (TempUserDictionary != null)
            {
                UserDictionary = TempUserDictionary;
            }

        }

        // Just loads all the data
        public void Load_All_Weapons()
        {

            // Seralzie
            var options = new JsonSerializerOptions { IncludeFields = true };
            string jsonStringFromFile = File.ReadAllText(@"data-files/weapons.txt");

            Dictionary<string, Weapon>? TempAllWeapons = JsonSerializer.Deserialize<Dictionary<string, Weapon>>(jsonStringFromFile, options);

            if (TempAllWeapons != null)
            {
                AllWeapons = TempAllWeapons;
            }
        }


        /*
     // Left Over Weapon Code to actually make the JSON file 


    // Daggers
    AllWeapons.Add("Dagger", new("Daggers", "Dagger", 56, 0, 0, 0, 0, "E", "B", "N/A", "N/A", 0, 0, 0, 0, 45, 10, 30, 30, 26));
    AllWeapons.Add("Ghost Blade", new("Daggers", "Ghost Blade", 110, 0, 0, 0, 0, "E", "N/A", "N/A", "N/A", 0, 0, 0, 0, 45, 10, 30, 30, 26));
    AllWeapons.Add("Bandit's Knife", new("Daggers", "Bandit's Knife", 56, 0, 0, 0, 0, "E", "B", "N/A", "N/A", 0, 0, 0, 0, 45, 10, 30, 30, 26));
    AllWeapons.Add("Parrying Dagger", new("Daggers", "Parrying Dagger", 54, 0, 0, 0, 0, "E", "B", "N/A", "N/A", 0, 0, 0, 0, 45, 10, 30, 30, 26));
    AllWeapons.Add("Priscilla's Dagger", new("Daggers", "Priscilla's Dagger", 80, 0, 0, 0, 0, "A", "N/A", "N/A", "N/A", 0, 0, 0, 0, 45, 10, 30, 30, 26));
    AllWeapons.Add("Dark Silver Tracer", new("Daggers", "Dark Silver Tracer", 75, 0, 0, 0, 0, "E", "S", "N/A", "N/A", 0, 0, 0, 0, 45, 10, 30, 30, 26));

    // Striaght Swords
    AllWeapons.Add("Straight Sword Hilt", new("Striaght Swords", "Straight Sword Hilt", 20, 0, 0, 0, 0, "E", "E", "N/A", "N/A", 0, 0, 0, 0, 20, 5, 15, 15, 10));
    AllWeapons.Add("Broken Straight Sword", new("Striaght Swords", "Broken Straight Sword", 40, 0, 0, 0, 0, "D", "D", "N/A", "N/A", 0, 0, 0, 0, 20, 5, 15, 15, 16));
    AllWeapons.Add("Broadsword", new("Striaght Swords", "Broadsword", 82, 0, 0, 0, 0, "C", "C", "N/A", "N/A", 0, 0, 0, 0, 50, 10, 35, 35, 32));
    AllWeapons.Add("Shortsword", new("Striaght Swords", "Shortsword", 78, 0, 0, 0, 0, "C", "C", "N/A", "N/A", 0, 0, 0, 0, 50, 10, 35, 35, 32));
    AllWeapons.Add("Longsword", new("Striaght Swords", "Longsword", 80, 0, 0, 0, 0, "C", "C", "N/A", "N/A", 0, 0, 0, 0, 50, 10, 35, 35, 32));
    AllWeapons.Add("Barbed Straight Sword", new("Straight Sword", "Barbed Straight Sword", 80, 0, 0, 0, 0, "D", "D", "N/A", "N/A", 0, 0, 0, 0, 50, 10, 35, 35, 32));

    // Great Swords
    AllWeapons.Add("Bastard Sword", new("Greatsword", "Bastard Sword", 105, 0, 0, 0, 0, "C", "C", "N/A", "N/A", 0, 0, 0, 0, 60, 10, 40, 40, 38));
    AllWeapons.Add("Black Knight Sword", new("Greatsword", "Black Knight Sword", 220, 0, 0, 0, 0, "C", "E", "N/A", "N/A", 0, 0, 0, 0, 60, 10, 40, 40, 38));
    AllWeapons.Add("Claymore", new("Greatsword", "Claymore", 103, 0, 0, 0, 0, "C", "C", "N/A", "N/A", 0, 0, 0, 0, 60, 10, 40, 40, 38));
    AllWeapons.Add("Flamberge", new("Greatsword", "Flamberge", 100, 0, 0, 0, 0, "D", "C", "N/A", "N/A", 0, 0, 0, 0, 60, 10, 40, 40, 38));
    AllWeapons.Add("Crystal Greatsword", new("Greatsword", "Crystal Greatsword", 190, 0, 0, 0, 0, "C", "C", "N/A", "N/A", 0, 0, 0, 0, 60, 10, 40, 40, 38));
    AllWeapons.Add("Man-Serpent Greatsword", new("Greatsword", "Man-Serpent Greatsword", 110, 0, 0, 0, 0, "B", "N/A", "N/A", "N/A", 0, 0, 0, 0, 60, 10, 40, 40, 38));
    AllWeapons.Add("Great Lord Greatsword", new("Greatsword", "Great Lord Greatsword", 256, 0, 0, 0, 0, "D", "D", "N/A", "N/A", 0, 0, 0, 0, 60, 10, 40, 40, 26));
    AllWeapons.Add("Moonlight Greatsword", new("Greatsword", "Moonlight Greatsword", 0, 132, 0, 0, 0, "N/A", "N/A", "A", "N/A", 0, 0, 0, 0, 60, 10, 40, 40, 38));

    // Ultra Greatswords
    AllWeapons.Add("Dragon Greatsword", new("Ultra Greatsword", "Dragon Greatsword", 390, 0, 0, 0, 0, "N/A", "N/A", "N/A", "N/A", 0, 0, 0, 0, 60, 10, 40, 40, 38));
    AllWeapons.Add("Greatsword", new("Ulra Greatsword", "Greatsword", 130, 0, 0, 0, 0, "C", "D", "N/A", "N/A", 0, 0, 0, 0, 70, 10, 50, 50, 44));
    AllWeapons.Add("Black Knight Greatsword", new("Ultra Greatsword", "Black Knight Greatsword", 220, 0, 0, 0, 0, "B", "E", "N/A", "N/A", 0, 0, 0, 0, 70, 10, 50, 50, 44));
    AllWeapons.Add("Zweihander", new("Ultra Greatsword", "Zweihander", 130, 0, 0, 0, 0, "C", "D", "N/A", "N/A", 0, 0, 0, 0, 70, 10, 50, 50, 44));
    AllWeapons.Add("Demon Great Machete", new("Ultra Greatsword", "Demon Great Machete", 133, 0, 0, 0, 0, "B", "N/A", "N/A", "N/A", 0, 0, 0, 0, 70, 10, 50, 50, 44));

    // Curved Swords
    AllWeapons.Add("Scimitar", new("Curved Swords", "Scimitar", 80, 0, 0, 0, 0, "E", "B", "N/A", "N/A", 0, 0, 0, 0, 45, 10, 30, 30, 30));
    AllWeapons.Add("Shotel", new("Curved Swords", "Shotel", 82, 0, 0, 0, 100, "E", "C", "N/A", "N/A", 0, 0, 0, 0, 45, 10, 30, 30, 30));
    AllWeapons.Add("Falchion", new("Curved Swords", "Falchion", 82, 0, 0, 0, 100, "E", "B", "N/A", "N/A", 0, 0, 0, 0, 45, 10, 30, 30, 30));
    AllWeapons.Add("Quelaag's Furysword", new("Curved Swords", "Quelaag's Furysword", 60, 0, 170, 0, 0, "E", "B", "N/A", "N/A", 0, 0, 0, 0, 45, 10, 30, 30, 30));
    AllWeapons.Add("Painting Guardian Sword", new("Curved Swords", "Painting Guardian Sword", 76, 0, 0, 0, 100, "E", "A", "N/A", "N/A", 300, 0, 0, 0, 45, 10, 30, 30, 30));
    AllWeapons.Add("Jagged Ghost Blade", new("Curved Swords", "Jagged Ghost Blade", 155, 0, 0, 0, 0, "E", "N/A", "N/A", "N/A", 0, 0, 0, 0, 45, 10, 30, 30, 30));
    AllWeapons.Add("Gold Tracer", new("Curved Swords", "Gold Tracer", 130, 0, 0, 0, 0, "E", "A", "N/A", "N/A", 0, 0, 0, 0, 45, 10, 30, 30, 30));

    // Katanas
    AllWeapons.Add("Uchigatana", new("Katanas", "Uchigatana", 90, 0, 0, 0, 100, "N/A", "B", "N/A", "N/A", 300, 0, 0, 0, 45, 10, 30, 30, 30));
    AllWeapons.Add("Washing Pole", new("Katanas", "Washing Pole", 90, 0, 0, 0, 100, "D", "D", "N/A", "N/A", 300, 0, 0, 0, 45, 10, 30, 30, 30));
    AllWeapons.Add("Iaito", new("Katanas", "Iaito", 88, 0, 0, 0, 100, "N/A", "B", "N/A", "N/A", 300, 0, 0, 0, 45, 10, 30, 30, 30));
    AllWeapons.Add("Chaos Blade", new("Katanas", "Chaos Blade", 144, 0, 0, 0, 100, "N/A", "B", "N/A", "N/A", 300, 0, 0, 0, 45, 10, 30, 30, 30));

    // Curved Greatswords
    AllWeapons.Add("Server", new("Curved Greatsword", "Server", 107, 0, 0, 0, 100, "E", "C", "N/A", "N/A", 0, 0, 0, 0, 60, 10, 40, 40, 36));
    AllWeapons.Add("Murakumo", new("Curved Greatsword", "Murakumo", 113, 0, 0, 0, 100, "E", "B", "N/A", "N/A", 0, 0, 0, 0, 60, 10, 40, 40, 36));
    AllWeapons.Add("Gravelord Sword", new("Curved Greatsword", "Gravelord Sword", 265, 0, 0, 0, 100, "E", "E", "N/A", "N/A", 0, 300, 0, 0, 60, 10, 40, 40, 36));

    // Rapier
    AllWeapons.Add("Rapier", new("Piercing Sword", "Rapier", 73, 0, 0, 0, 110, "D", "C", "N/A", "N/A", 0, 0, 0, 0, 45, 10, 30, 30, 22));
    AllWeapons.Add("Estoc", new("Piercing Sword", "Estoc", 75, 0, 0, 0, 100, "D", "C", "N/A", "N/A", 0, 0, 0, 0, 45, 10, 30, 30, 22));
    AllWeapons.Add("Mail Breaker", new("Piercing Sword", "Mail Breaker", 57, 0, 0, 0, 120, "D", "C", "N/A", "N/A", 0, 0, 0, 0, 45, 10, 30, 30, 22));
    AllWeapons.Add("Ricard's Rapier", new("Piercing Sword", "Ricard's Rapier", 70, 0, 0, 0, 100, "E", "B", "N/A", "N/A", 0, 0, 0, 0, 45, 10, 30, 30, 22));
    AllWeapons.Add("Velka's Rapier", new("Piercing Sword", "Velka's Rapier", 62, 104, 0, 0, 100, "E", "C", "B", "N/A", 0, 0, 0, 110, 45, 10, 30, 30, 22));

    // Axes
    AllWeapons.Add("Hand Axe", new("Axes", "Velka's Rapier", 80, 0, 0, 0, 100, "C", "D", "N/A", "N/A", 0, 0, 0, 0, 55, 10, 40, 40, 36));
    AllWeapons.Add("Gargoyle Tail Axe", new("Axes", "Gargoyle Tail Axe", 93, 0, 0, 0, 100, "D", "C", "N/A", "N/A", 0, 0, 0, 0, 55, 10, 40, 40, 36));
    AllWeapons.Add("Battle Axe", new("Axes", "Battle Axe", 95, 0, 0, 0, 100, "C", "D", "N/A", "N/A", 0, 0, 0, 0, 55, 10, 40, 40, 36));
    AllWeapons.Add("Butcher Knife", new("Axes", "Butcher Knife", 90, 0, 0, 0, 100, "B", "N/A", "N/A", "N/A", 0, 0, 0, 0, 55, 10, 40, 40, 36));
    AllWeapons.Add("Crescent Axe", new("Axes", "Crescent Axe", 115, 115, 0, 0, 100, "D", "D", "N/A", "B", 0, 0, 120, 0, 55, 10, 40, 40, 36));
    AllWeapons.Add("Golem Axe", new("Axes", "Golem Axe", 170, 0, 0, 0, 100, "C", "E", "N/A", "N/A", 0, 0, 0, 0, 55, 10, 40, 40, 36));

    // Great Axes
    AllWeapons.Add("Demon's Greataxe", new("Great Axes", "Demon's Greataxe", 114, 0, 0, 0, 100, "A", "N/A", "N/A", "N/A", 0, 0, 0, 0, 55, 10, 40, 40, 38));
    AllWeapons.Add("Great Axe", new("Great Axes", "GreatAxe", 140, 0, 0, 0, 100, "C", "E", "N/A", "N/A", 0, 0, 0, 0, 55, 10, 40, 40, 38));
    AllWeapons.Add("Dragon King Greataxe", new("Great Axes", "Dragon King Greataxe", 380, 0, 0, 0, 100, "N/A", "N/A", "N/A", "N/A", 0, 0, 0, 0, 55, 10, 40, 40, 38));
    AllWeapons.Add("Black Knight Greataxe", new("Great Azes", "Black Knight Greataxe", 229, 0, 0, 0, 100, "B", "E", "N/A", "N/A", 0, 0, 0, 0, 55, 10, 40, 40, 38));
    AllWeapons.Add("Stone Greataxe", new("Great Axes", "Stone Greataxe", 190, 00, 0, 0, 100, "B", "E", "N/A", "N/A", 0, 0, 0, 0, 55, 10, 40, 40, 38)); 
 */
    }
}
