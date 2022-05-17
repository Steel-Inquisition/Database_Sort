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

        // This function is used to search with parameters
        private void Search_Through_Data(object sender, RoutedEventArgs e)
        {

            // Devoid the base text
            DisplayData.Text = "";

            // Search through the dictionary using a foreach
            foreach (KeyValuePair<string, Weapon> kvp in AllWeapons)
            {

                // Check all weapon values
                if (CheckWeaponValues(kvp.Value))
                {
                    DisplayData.Text += $"{kvp.Key} \n";
                }

            }


        }

        // From Search_Through_Data is the function that checks a weapon and it's stats
        // It checks if the weapon interfers with any of the parameters. If it interfers with any of the parameters, adds 1 to the IsValid
        // I originally wanted to make it so that you can sort and see everything, the weapons that are most valid (closest to zero) at the front and the least (farthest away from zero) at the back. But I decided that would be far too annoying to actually program
        // 
        public bool CheckWeaponValues(Weapon TestingWeapon)
        {

            // Test Name and Type

            // Set up validity of weapon
            int IsValid = 0;

            // Test Name
            IsValid += CheckThisWord(SearchName.IsChecked, UserEnterName.Text, TestingWeapon.name);

            // Test Type
            IsValid += CheckThisWord(SearchType.IsChecked, UserEnterType.Text, TestingWeapon.type);



            // Test Stats

            // Test physical damage of weapon if checked
            IsValid += IsThisSearchValid(SearchPhysical.IsChecked, UserEnterPhysMin.Text, UserEnterPhysMax.Text, TestingWeapon.physical_damage);

            // Test magical damage of weapon if checked
            IsValid += IsThisSearchValid(SearchMagical.IsChecked, UserEnterMagMin.Text, UserEnterMagMax.Text, TestingWeapon.magical_damage);

            // Test fire damage of weapon if checked
            IsValid += IsThisSearchValid(SearchFire.IsChecked, UserEnterFireMin.Text, UserEnterFireMin.Text, TestingWeapon.fire_damage);

            // Test lighining damage of weapon if checked 
            IsValid += IsThisSearchValid(SearchLightning.IsChecked, UserEnterLightMin.Text, UserEnterLightMax.Text, TestingWeapon.lightning_damage);

            // Test critical of weapon if checked
            IsValid += IsThisSearchValid(SearchCritical.IsChecked, UserEnterCrticalMin.Text, UserEnterCrticalMax.Text, TestingWeapon.critical);

            // Test bleed of weapon if checked
            IsValid += IsThisSearchValid(SearchBlood.IsChecked, UserEnterBloodMin.Text, UserEnterBloodMax.Text, TestingWeapon.bleed);

            // Test poision of weapon if checked
            IsValid += IsThisSearchValid(SearchPoision.IsChecked, UserEnterPoisionMin.Text, UserEnterPoisionMax.Text, TestingWeapon.poision);

            // Test auxiliary divine dark souls if checked
            IsValid += IsThisSearchValid(SearchDivine.IsChecked, UserEnterDivineMin.Text, UserEnterDivineMax.Text, TestingWeapon.auxiliary_divine_dark_souls);

            // Test auxiliary occult dark souls if checked
            IsValid += IsThisSearchValid(SearchOccult.IsChecked, UserEnterOccultMin.Text, UserEnterOccultMax.Text, TestingWeapon.auxiliary_occult_dark_souls);

            // Test physical defense if checked
            IsValid += IsThisSearchValid(SearchPhysDef.IsChecked, UserEnterPhysDefMin.Text, UserEnterPhysDefMax.Text, TestingWeapon.physical_defense);

            // Test magical defense if checked
            IsValid += IsThisSearchValid(SearchMagDef.IsChecked, UserEnterMagDefMin.Text, UserEnterMagDefMax.Text, TestingWeapon.magic_defense);

            // Test fire defense if checked
            IsValid += IsThisSearchValid(SearchFireDef.IsChecked, UserEnterFireDefMin.Text, UserEnterFireDefMax.Text, TestingWeapon.fire_defense);

            // Test lightning defense if checked
            IsValid += IsThisSearchValid(SearchLightDef.IsChecked, UserEnterLightDefMin.Text, UserEnterLightDefMax.Text, TestingWeapon.lightning_defense);

            // Test stability if checked
            IsValid += IsThisSearchValid(SearchStability.IsChecked, UserEnterStabilityMin.Text, UserEnterStabilityMax.Text, TestingWeapon.stability);


            // Test Parameters

            // Test strength parameter
            IsValid += CheckThisWord(SearchStrengthParameter.IsChecked, UserEnterStrPara.Text, TestingWeapon.strength_parameter);

            // Test dexterity parameter
            IsValid += CheckThisWord(SearchDexterityParameter.IsChecked, UserEnterDexPara.Text, TestingWeapon.dexterity_parameter);

            // Test intelligence parameter
            IsValid += CheckThisWord(SearchIntelligenceParameter.IsChecked, UserEnterIntPara.Text, TestingWeapon.intelligence_parameter);

            // Test faith parameter
            IsValid += CheckThisWord(SearchFaithParameter.IsChecked, UserEnterFaiPara.Text, TestingWeapon.faith_parameter);

            // If IsValid unchanged then this weapon meets it's requirements and will be returned as valid. If it doesn't, then it will be returned as false
            if (IsValid == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        // Check if a stat sort us valid
        public int IsThisSearchValid(bool? ThisBoxIsChecked, string min, string max, int this_data)
        {

            // Is the box checked beside this value activated?
            if ((bool)ThisBoxIsChecked)
            {

                // If so, check the user entered min value and compare it to the max value
                if (CheckMinVsMax(min, max, this_data))
                {

                    // if it is inbetween the min and max, then return true
                    return 0;
                }
                else
                {

                    // otherwise it does not fit in the parameters and thus shouldn't counted
                    return 1;
                }
            }


            return 0;
        }


        // Checking a number is inbetween a min and a max
        public bool CheckMinVsMax(string min, string max, int this_data)
        {

            // If this data is above the min and bellow the max, return true, otherwise this is false
            if (this_data > Convert.ToInt32(min) && this_data < Convert.ToInt32(max))
            {
                return true;

            }
            else
            {

                return false;

            }


        }

        // Checking if a word is equal to what it wants to be
        public int CheckThisWord(bool? ThisBoxIsChecked, string key, string password)
        {

            // If this is checked
            if ((bool)ThisBoxIsChecked)
            {

                // If the key equals to the password, return true (0), otherwise return as false (1)
                if (key == password)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }

            }

            return 0;
        }
    }
}
