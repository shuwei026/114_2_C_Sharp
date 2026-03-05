using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace review_q3
{
    public partial class Form1 : Form
    {
        private Random _rand = new Random();
        private List<int> _myNumbers = new List<int>();
        private List<int> _winningNumbers = new List<int>();

        public Form1()
        {
            InitializeComponent();
            ResetDisplay();
        }

        private void ResetDisplay()
        {
            lblNum1.Text = "";
            lblNum2.Text = "";
            lblNum3.Text = "";
            lblNum4.Text = "";
            lblNum5.Text = "";

            lstWinning.Items.Clear();
            lblResultCount.Text = "中0個號碼";
            lblMatchNumbers.Text = "沒中獎";
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            _myNumbers = GenerateUniqueNumbers(5, 1, 49);
            lblNum1.Text = _myNumbers[0].ToString();
            lblNum2.Text = _myNumbers[1].ToString();
            lblNum3.Text = _myNumbers[2].ToString();
            lblNum4.Text = _myNumbers[3].ToString();
            lblNum5.Text = _myNumbers[4].ToString();

            // After generating, if winning numbers already loaded compare
            if (_winningNumbers.Count > 0)
            {
                CompareNumbers();
            }
        }

        private List<int> GenerateUniqueNumbers(int count, int min, int max)
        {
            var set = new HashSet<int>();
            while (set.Count < count)
            {
                set.Add(_rand.Next(min, max + 1));
            }
            var list = set.ToList();
            list.Sort();
            return list;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            // Load winning numbers from a text file. Expect numbers separated by non-digits.
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Text Files|*.txt|All Files|*.*";
                ofd.Title = "選擇開獎號碼檔案";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var text = System.IO.File.ReadAllText(ofd.FileName);
                        var nums = Regex.Matches(text, "\\d+")
                            .Cast<Match>()
                            .Select(m => int.Parse(m.Value))
                            .ToList();

                        _winningNumbers = nums.Distinct().OrderBy(n => n).ToList();
                        lstWinning.Items.Clear();
                        for (int i = 0; i < _winningNumbers.Count; i++)
                        {
                            lstWinning.Items.Add($"第{(i + 1)}個號碼: {_winningNumbers[i]}");
                        }

                        if (_myNumbers.Count > 0)
                        {
                            CompareNumbers();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("讀取檔案失敗: " + ex.Message);
                    }
                }
            }
        }

        private void CompareNumbers()
        {
            var matches = _myNumbers.Intersect(_winningNumbers).OrderBy(n => n).ToList();
            lblResultCount.Text = $"中{matches.Count}個號碼";
            if (matches.Count == 0)
            {
                lblMatchNumbers.Text = "沒中獎";
            }
            else
            {
                lblMatchNumbers.Text = "中獎號碼: " + string.Join(", ", matches);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
