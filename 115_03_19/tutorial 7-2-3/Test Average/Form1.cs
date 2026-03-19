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

namespace Test_Average
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // The Average method accepts an int array argument
        // and returns the Average of the values in the array.
        private double Average(int[] sArray  )
        {
            int total = 0;
            for (int i = 0; i < sArray.Length; i++)
            {
                total += sArray[i];
            }
            return (double)total / sArray.Length;

        }

        // The Highest method accepts an int array argument
        // and returns the highest value in that array.
        private int Highest(int[] sArray )
        {
            int[] scoreCopy = new int[sArray.Length];
            for(int i = 0; i < sArray.Length; i++)
            {
                scoreCopy[i] = sArray[i];
            }
            Array.Sort(sArray);
            Array.Reverse(sArray);
            return sArray[sArray.Length - 1];   

        }

        // The Lowest method accepts an int array argument
        // and returns the lowest value in that array.
        private int Lowest(int[] sArray  )
        {
            int[] scoreCopy = new int[sArray.Length];
            for (int i = 0; i < sArray.Length; i++)
            {
                scoreCopy[i] = sArray[i];
            }   

            Array.Sort(sArray);
            Array.Reverse(sArray);
            return sArray[0];
        }

        // count non-empty lines in the data file
        private int getFileScoreCount()
        {
            if (!File.Exists("TestScores.txt"))
                return 0;

            int count = 0;
            using (var reader = File.OpenText("TestScores.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (!string.IsNullOrWhiteSpace(line))
                        count++;
                }
            }
            return count;
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
             //int size = getFileScoreCount();
            int[] scores = new int[getFileScoreCount()];
            StreamReader inputfile;
            int index = 0;

            try
            {
                inputfile = File.OpenText("TestScores.txt");

                while (!inputfile.EndOfStream && index < scores.Length)
                {
                    scores[index] = int.Parse(inputfile.ReadLine());
                    index++;
                }
                inputfile.Close();
                testScoresListBox.Items.Add("學生人數:" + scores.Length);

                foreach (int val in scores)
                {
                    testScoresListBox.Items.Add(val);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //double average = Average(Scores);
            if (scores.Length == 0)
            {
                averageScoreLabel.Text = "N/A";
                highScoreLabel.Text = "N/A";
                lowScoreLabel.Text = "N/A";
            }
            else
            {
                averageScoreLabel.Text = Average(scores).ToString("n1");
                highScoreLabel.Text = Highest(scores).ToString();
                lowScoreLabel.Text = Lowest(scores).ToString();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
