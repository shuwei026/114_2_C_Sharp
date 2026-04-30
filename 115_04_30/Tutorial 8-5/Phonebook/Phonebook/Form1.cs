using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Phonebook
{
    struct PhoneBookEntry
    {
        public string name;
        public string phone;
    }

    public partial class Form1 : Form
    {
        // Field to hold a list of PhoneBookEntry objects.
        private List<PhoneBookEntry> phoneList = new List<PhoneBookEntry>();
        
        

        public Form1()
        {
            InitializeComponent();
        }

        // The ReadFile method reads the contents of the
        // PhoneList.txt file and stores it as PhoneBookEntry
        // objects in the phoneList.
        private void ReadFile()
        {
            try
            {
                StreamReader inputFile;
                string line;
                char[] delim= { ',' };
                PhoneBookEntry entry = new PhoneBookEntry();
                // Open the file for reading.
                using (inputFile = File.OpenText("PhoneList.txt"))
                {
                    // Read the first line from the file.
                    line = inputFile.ReadLine();
                    // Continue processing until the end of the file is reached.
                    while (!inputFile.EndOfStream)
                    {
                        // Split the line into name and phone number.
                        string[] tokens = line.Split(delim);
                        if (tokens.Length == 2)
                        {
                            entry.name = tokens[0].Trim();
                            entry.phone = tokens[1].Trim();
                            phoneList.Add(entry);
                        }
                        // Read the next line from the file.
                        line = inputFile.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading file: " + ex.Message);
            }
        }

        // The DisplayNames method displays the list of names
        // in the namesListBox control.
        private void DisplayNames()
        {
            foreach (PhoneBookEntry entry in phoneList)
            {
                nameListBox.Items.Add(entry.name);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReadFile();
            DisplayNames();
        }

        private void nameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = nameListBox.SelectedIndex;
            if (index != -1)
            {
               // string phone = phoneList[index].phone;
               phoneLabel.Text = phoneList[index].phone;
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
