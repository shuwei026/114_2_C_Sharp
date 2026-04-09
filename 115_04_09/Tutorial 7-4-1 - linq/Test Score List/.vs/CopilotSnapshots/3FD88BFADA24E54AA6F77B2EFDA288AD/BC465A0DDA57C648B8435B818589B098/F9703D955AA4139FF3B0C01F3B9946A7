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

namespace Test_Score_List
{
    public partial class Form1 : Form
    {
        // 類別層級儲存目前載入的成績清單，讓搜尋與其他方法能共用
        private List<int> scoresList;
        // 新增：對應的學號清單，與 scoresList 同步索引
        private List<string> studentIds;

        public Form1()
        {
            InitializeComponent();
        }

        

       

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            double averageScore;    // To hold the average score
            int numAboveAverage;    // Number of above average scores
            int numBelowAverage;    // Number of below average scores

            // 建立並儲存到類別層級的 List，以便其他事件（如搜尋）可以存取
            scoresList = new List<int>();
            studentIds = new List<string>();

            // Read the scores from the file into the List.
            ReadScores(scoresList, studentIds);

            // Display the scores.
            DisplayScores(scoresList, studentIds);

            // Display the average score.
            averageScore = Average(scoresList);
            averageLabel.Text = averageScore.ToString("n1");

            // Display the number of above average scores.
            numAboveAverage = AboveAverage(scoresList, averageScore);
            aboveAverageLabel.Text = numAboveAverage.ToString();

            // Display the number of below average scores.
            numBelowAverage = BelowAverage(scoresList);
            belowAverageLabel.Text = numBelowAverage.ToString();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }

        // 新增：搜尋按鈕事件處理方法
        // 功能：解析使用者在 `searchTextBox` 輸入的整數分數，於已載入的 `scoresList` 中搜尋
        // 若找到第一個符合的項目，則在 `searchResultLabel` 顯示該項目的位置（從 1 開始）
        // 若解析失敗或找不到，則顯示「分數不存在」。
        private void searchButton_Click(object sender, EventArgs e)
        {
            // 嘗試解析使用者輸入
            if (!int.TryParse(searchTextBox.Text.Trim(), out int searchscore))
            {
                searchResultLabel.Text = "分數不存在";
                return;
            }

            // 確認已載入分數清單
            if (scoresList == null || scoresList.Count == 0)
            {
                searchResultLabel.Text = "分數不存在";
                return;
            }

            // 使用 List 的 IndexOf 取得第一個符合的索引（若無則回傳 -1）
            int index = scoresList.IndexOf(searchscore);
            if (index >= 0)
            {
                // 顯示位置（從 1 開始）及對應學號與分數
                searchResultLabel.Text = "位置：" + (index + 1).ToString();
            }
            else
            {
                searchResultLabel.Text = "分數不存在";
            }
        }

        // 以下為新增的方法，以修正原本缺少的方法所造成的編譯錯誤。

        /// <summary>
        /// 讀取成績檔案並將整數分數加入到傳入的 List 中。
        /// 檔案格式每行為："學號 空白 分數"（例如：A114221055 54）
        /// 預設檔名為 "scores.txt"，位於應用程式啟動目錄。
        /// 若檔案不存在或解析失敗，會顯示提示訊息，但不會拋出例外到呼叫端。
        /// </summary>
        /// <param name="scoresList">用來儲存讀取到的分數的 List</param>
        /// <param name="studentIds">用來儲存讀取到的學號的 List（與 scoresList 同步索引）</param>
        private void ReadScores(List<int> scoresList, List<string> studentIds)
        {
            if (scoresList == null || studentIds == null) return;

            string path = Path.Combine(Application.StartupPath, "TestScores.txt");
            if (!File.Exists(path))
            {
                // 檔案不存在，通知使用者並結束讀取動作
                MessageBox.Show("找不到成績檔案：" + path + "\n請將 TestScores.txt 放在應用程式目錄中。", "檔案不存在", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string[] lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    // 以空白分隔，第一個欄位當作學號，最後一個欄位當作分數（可容忍中間有多個空白）
                    var parts = line.Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length < 2) continue; // 格式不符，略過

                    string id = parts[0];
                    string scoreToken = parts[parts.Length - 1];
                    if (int.TryParse(scoreToken, out int value))
                    {
                        studentIds.Add(id);
                        scoresList.Add(value);
                    }
                    // 無法解析的行會被略過，不影響其他資料
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("讀取檔案時發生錯誤：" + ex.Message, "讀取錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 顯示分數於 ListBox（每行一個分數），格式為："學號 分數"。
        /// </summary>
        /// <param name="scoresList">要顯示的分數清單</param>
        /// <param name="studentIds">對應的學號清單</param>
        private void DisplayScores(List<int> scoresList, List<string> studentIds)
        {
            testScoresListBox.Items.Clear();
            if (scoresList == null || studentIds == null) return;

            int count = Math.Min(scoresList.Count, studentIds.Count);
            for (int i = 0; i < count; i++)
            {
                testScoresListBox.Items.Add(studentIds[i] + " " + scoresList[i].ToString());
            }
        }

        /// <summary>
        /// 計算分數平均值，若清單為空回傳 0。
        /// </summary>
        /// <param name="scoresList">分數清單</param>
        /// <returns>平均分數（double）</returns>
        private double Average(List<int> scoresList)
        {
            if (scoresList == null || scoresList.Count == 0) return 0.0;
            return scoresList.Average();
        }

        /// <summary>
        /// 計算高於指定平均分數的分數數量。
        /// </summary>
        /// <param name="scoresList">分數清單</param>
        /// <param name="averageScore">平均分數</param>
        /// <returns>高於平均的項目數量</returns>
        private int AboveAverage(List<int> scoresList, double averageScore)
        {
            if (scoresList == null || scoresList.Count == 0) return 0;
            return scoresList.Count(s => s > averageScore);
        }

        /// <summary>
        /// 計算低於平均分數的分數數量（內部會自行計算平均）。
        /// </summary>
        /// <param name="scoresList">分數清單</param>
        /// <returns>低於平均的項目數量</returns>
        private int BelowAverage(List<int> scoresList)
        {
            if (scoresList == null || scoresList.Count == 0) return 0;
            double avg = Average(scoresList);
            return scoresList.Count(s => s < avg);
        }
    }
}
