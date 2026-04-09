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
            // 讀取格式為 "學號 分數" 的檔案，每行可能包含空白或製表符作為分隔
            var ids = new List<string>();
            var scoresList = new List<int>();

            try
            {
                using (var reader = File.OpenText("TestScores.txt"))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (string.IsNullOrWhiteSpace(line))
                            continue;

                        var parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        if (parts.Length < 2)
                            continue; // 忽略格式不正確的行

                        var id = parts[0];
                        // 若分數後方還有額外欄位，僅取第二欄作為分數
                        if (int.TryParse(parts[1], out int score))
                        {
                            ids.Add(id);
                            scoresList.Add(score);
                        }
                        // 若解析失敗則跳過該行
                    }
                }

                int[] scores = scoresList.ToArray();

                testScoresListBox.Items.Clear();
                testScoresListBox.Items.Add("學生人數:" + scores.Length);

                // 顯示 "學號 分數"
                for (int i = 0; i < scores.Length; i++)
                {
                    testScoresListBox.Items.Add(ids[i] + " " + scores[i]);
                }

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
