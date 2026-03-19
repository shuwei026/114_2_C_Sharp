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
            int highscore = sArray[0];
            for (int i = 1; i < sArray.Length; i++)
            {
                if (sArray[i] > highscore)
                {
                    highscore = sArray[i];
                }
            }
            return highscore;

        }

        // The Lowest method accepts an int array argument
        // and returns the lowest value in that array.
        private int Lowest(int[] sArray   )
        {
            int lowscore = sArray[0];
            for (int i = 1; i < sArray.Length; i++)
            {
                if (sArray[i] < lowscore)
                {
                    lowscore = sArray[i];
                }
            }
            return lowscore;

        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            const int SIZE = 5;
            int[] scores = new int[SIZE];
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

                foreach(int val in scores)
                {
                    testScoresListBox.Items.Add(val);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //double average = Average(Scores);
            averageScoreLabel.Text = Average(scores).ToString("n1");
            highScoreLabel.Text = Highest(scores).ToString();
            lowScoreLabel.Text = Lowest(scores).ToString();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
