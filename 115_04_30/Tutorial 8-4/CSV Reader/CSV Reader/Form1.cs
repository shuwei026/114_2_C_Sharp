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

namespace CSV_Reader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader inputfile;
                char[] delim = { ',' };

                using (inputfile = File.OpenText("Grades.csv"))
                {
                    string line;
                    while (!inputfile.EndOfStream)
                    {
                        line = inputfile.ReadLine();
                        string[] fields = line.Split(delim);
                        // Expected format: class, studentID, name, score1, score2, score3, score4, score5
                        if (fields.Length == 8)
                        {
                            int total = 0;
                            int scoreCount = 5;
                            bool parseError = false;
                            for (int i = 3; i < 8; i++)
                            {
                                int s;
                                if (!int.TryParse(fields[i], out s))
                                {
                                    parseError = true;
                                    break;
                                }
                                total += s;
                            }

                            if (parseError)
                            {
                                MessageBox.Show("Invalid score value in line: " + line);
                                continue;
                            }

                            double average = (double)total / scoreCount;
                            // Output format: class studentID name average
                            string output = $"{fields[0]} {fields[1]} {fields[2]} {average:F2}";
                            averagesListBox.Items.Add(output);

                        }
                        else
                        {
                            MessageBox.Show("Invalid line format: " + line);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while reading the file: " + ex.Message);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
