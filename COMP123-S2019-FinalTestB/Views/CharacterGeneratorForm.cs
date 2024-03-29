﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
// For TextReader and TextWriter
using System.IO;

/*
 * STUDENT NAME: Koolait Roa
 * STUDENT ID: 301034220
 * DESCRIPTION: This is the Character Generator  Form - the main form of the application
 */

namespace COMP123_S2019_FinalTestB.Views
{
    public partial class CharacterGeneratorForm : MasterForm
    {
        public List<string> FirstNameList = new List<string>();
        public List<string> LastNameList = new List<string>();

        // Random object that would generate a random number
        public Random random = new Random();

        public CharacterGeneratorForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This is the event handler for the BackButton Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, EventArgs e)
        {
            if(MainTabControl.SelectedIndex != 0)
            {
                MainTabControl.SelectedIndex--;
            }
        }

        /// <summary>
        /// This is the event handler for the NextButton Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextButton_Click(object sender, EventArgs e)
        {
            if(MainTabControl.SelectedIndex < MainTabControl.TabPages.Count - 1)
            {
                MainTabControl.SelectedIndex++;
            }
        }

        /// <summary>
        /// This method  loads the entire firstNames.txt and lastNames.txt file into FirstNameList and LastNameList lists
        /// </summary>
        public void LoadNames()
        {
            // textreader object to store the files
            TextReader firstNamesFile = new StreamReader(@"..\..\Data\firstNames.txt");
            TextReader lastNamesFile = new StreamReader(@"..\..\Data\lastNames.txt");

            // reads a line of characters from the text reader object
            string line = firstNamesFile.ReadLine();
            // loop that would read every line of the file and add each to the list
            while (line != null)
            {
                FirstNameList.Add(line);
                line = firstNamesFile.ReadLine();
            }
            FirstNameList.Add(line);
            firstNamesFile.Close();


            line = lastNamesFile.ReadLine();
            while (line != null)
            {
                LastNameList.Add(line);
                line = lastNamesFile.ReadLine();
            }
            LastNameList.Add(line);
            lastNamesFile.Close();
        }

        /// <summary>
        ///  Method that will randomly pick First Names and Last Names from 
        ///  the FirstNameList and LastNameList controls and set the 
        ///  FirstNameDataLabel and LastNameDataLabel with these values 
        /// </summary>
        public void GenerateNames()
        {
            // gets the number of elements contained in the List
            int listCount = FirstNameList.Count;
            FirstNameDataLabel.Text = FirstNameList[random.Next(0, (listCount - 1))];
            
            listCount = LastNameList.Count;
            string lname = LastNameList[random.Next(0, (listCount - 1))];
            LastNameDataLabel.Text = lname;
        }

        /// <summary>
        /// Call the LoadNames method and call the GenerateNames method upon Form load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CharacterGeneratorForm_Load(object sender, EventArgs e)
        {
            LoadNames();
            GenerateNames();
        }

        /// <summary>
        /// Click Event that calls the GenerateNames method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateNameButton_Click(object sender, EventArgs e)
        {
            GenerateNames();

            // set the value of the FirstName and LastName property of the Program.character object 
            // to the value of text property of the FirstNameDataLabel and LastNameLabel control 
            Program.character.FirstName = FirstNameLabel.Text;
            Program.character.LastName = LastNameLabel.Text;
        }

        /// <summary>
        /// Method that generate random numbers ranging from 3 to 18 for each Ability 
        /// (Strength, Dexterity, Constitution, Intelligence, Wisdom and Charisma)
        /// </summary>
        private void GenerateAbilities()
        {
            Program.character.Strength = $"{random.Next(1, 15)}";
            Program.character.Dexterity = $"{random.Next(1, 15)}";
            Program.character.Constitution = $"{random.Next(1, 15)}";
            Program.character.Intelligence = $"{random.Next(1, 15)}";
            Program.character.Wisdom = $"{random.Next(1, 15)}";
            Program.character.Charisma = $"{random.Next(1, 15)}";
        }

        /// <summary>
        ///  Click event that invokes GenerateAbilities() and and display generated values in the appropriate Label controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateAbilitiesButton_Click(object sender, EventArgs e)
        {
            GenerateAbilities();
            StrengthDataLabel.Text = Program.character.Strength;
            DexterityDataLabel.Text = Program.character.Dexterity;
            ConstitutionDataLabel.Text = Program.character.Constitution;
            IntelligenceDataLabel.Text = Program.character.Intelligence;
            WisdomDataLabel.Text = Program.character.Wisdom;
            CharismaDataLabel.Text = Program.character.Charisma;
        }
    }
}
