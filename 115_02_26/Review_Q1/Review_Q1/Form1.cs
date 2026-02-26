using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

        namespace Review_Q1
{
    public partial class Form1 : Form
    {
        // 遊戲選項枚舉
        private enum GameChoice
        {
            Stone,    // 石頭
            Paper,    // 布
            Scissors  // 剪刀
        }

        // 遊戲統計
        private int computerWins = 0;
        private int playerWins = 0;
        private int draws = 0;
        private Random random = new Random();

        // 圖片快取（若有提供影像就使用，否則使用文字 emoji）
        private readonly Dictionary<GameChoice, Image> choiceImages = new Dictionary<GameChoice, Image>(3);

        public Form1()
        {
            InitializeComponent();
            computerPictureBox.Text = "";
            playerPictureBox.Text = "";

            // 嘗試從預設的 Images 資料夾載入圖片（執行檔相對路徑）
            TryLoadDefaultImages();

            // 在視窗關閉時釋放圖片資源
            this.FormClosed += Form1_FormClosed;
        }

        /// <summary>
        /// 玩家選擇石頭
        /// </summary>
        private void stoneButton_Click(object sender, EventArgs e)
        {
            PlayGame(GameChoice.Stone);
        }

        /// <summary>
        /// 玩家選擇布
        /// </summary>
        private void paperButton_Click(object sender, EventArgs e)
        {
            PlayGame(GameChoice.Paper);
        }

        /// <summary>
        /// 玩家選擇剪刀
        /// </summary>
        private void scissorsButton_Click(object sender, EventArgs e)
        {
            PlayGame(GameChoice.Scissors);
        }

        /// <summary>
        /// 執行一局遊戲
        /// </summary>
        private void PlayGame(GameChoice playerChoice)
        {
            // 電腦隨機選擇
            GameChoice computerChoice = (GameChoice)random.Next(0, 3);

            // 顯示雙方選擇的圖片和文字
            DisplayChoices(computerChoice, playerChoice);

            // 判斷勝負
            DetermineWinner(computerChoice, playerChoice);

            // 更新統計顯示
            UpdateStatistics();
        }

        /// <summary>
        /// 顯示雙方的選擇（若有圖片則使用圖片，否則顯示 emoji）
        /// </summary>
        private void DisplayChoices(GameChoice computerChoice, GameChoice playerChoice)
        {
            // 電腦
            if (choiceImages.TryGetValue(computerChoice, out Image compImg) && compImg != null)
            {
                computerPictureBox.Image = compImg;
                computerPictureBox.Text = "";
            }
            else
            {
                computerPictureBox.Image = null;
                switch (computerChoice)
                {
                    case GameChoice.Stone:
                        computerPictureBox.Text = "✊";
                        break;
                    case GameChoice.Paper:
                        computerPictureBox.Text = "✋";
                        break;
                    case GameChoice.Scissors:
                        computerPictureBox.Text = "✌";
                        break;
                }
            }

            // 玩家
            if (choiceImages.TryGetValue(playerChoice, out Image playerImg) && playerImg != null)
            {
                playerPictureBox.Image = playerImg;
                playerPictureBox.Text = "";
            }
            else
            {
                playerPictureBox.Image = null;
                switch (playerChoice)
                {
                    case GameChoice.Stone:
                        playerPictureBox.Text = "✊";
                        break;
                    case GameChoice.Paper:
                        playerPictureBox.Text = "✋";
                        break;
                    case GameChoice.Scissors:
                        playerPictureBox.Text = "✌";
                        break;
                }
            }
        }

        /// <summary>
        /// 判斷勝負並更新分數
        /// </summary>
        private void DetermineWinner(GameChoice computerChoice, GameChoice playerChoice)
        {
            string result = "";

            // 平手判定
            if (computerChoice == playerChoice)
            {
                draws++;
                result = "平手！";
                resultLabel.ForeColor = System.Drawing.Color.Gray;
            }
            // 玩家勝利判定
            else if ((playerChoice == GameChoice.Stone && computerChoice == GameChoice.Scissors) ||
                     (playerChoice == GameChoice.Paper && computerChoice == GameChoice.Stone) ||
                     (playerChoice == GameChoice.Scissors && computerChoice == GameChoice.Paper))
            {
                playerWins++;
                result = "你贏了！";
                resultLabel.ForeColor = System.Drawing.Color.Green;
            }
            // 電腦勝利
            else
            {
                computerWins++;
                result = "電腦贏了！";
                resultLabel.ForeColor = System.Drawing.Color.Red;
            }

            resultLabel.Text = result;
        }

        /// <summary>
        /// 更新統計分數顯示
        /// </summary>
        private void UpdateStatistics()
        {
            computerScoreLabel.Text = $"電腦勝場數：{computerWins}";
            playerScoreLabel.Text = $"玩家勝場數：{playerWins}";
            drawScoreLabel.Text = $"平手次數：{draws}";
        }

        /// <summary>
        /// 結束遊戲
        /// </summary>
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 顯示最終統計結果
            string finalResult = $"遊戲統計結果：\n\n" +
                               $"玩家勝場數：{playerWins}\n" +
                               $"電腦勝場數：{computerWins}\n" +
                               $"平手次數：{draws}\n\n";

            if (playerWins > computerWins)
            {
                finalResult += "恭喜！你贏得了這場遊戲！";
            }
            else if (computerWins > playerWins)
            {
                finalResult += "電腦贏得了這場遊戲，再加油！";
            }
            else
            {
                finalResult += "平手！雙方不相上下。";
            }

            MessageBox.Show(finalResult, "遊戲結束", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        /// <summary>
        /// 嘗試載入預設 Images 資料夾內的圖片（執行檔路徑 + \Images）
        /// 檔名建議：stone.png / paper.png / scissors.png（支援多種副檔名）
        /// </summary>
        private void TryLoadDefaultImages()
        {
            string exeDir = AppDomain.CurrentDomain.BaseDirectory ?? Application.StartupPath;
            string imagesDir = Path.Combine(exeDir, "Images");
            if (Directory.Exists(imagesDir))
            {
                LoadImagesFromFolder(imagesDir);
            }
        }

        /// <summary>
        /// 從指定資料夾載入圖片到快取（會覆蓋原來的對應項）
        /// 支援副檔名：png, jpg, jpeg, bmp, gif
        /// </summary>
        public void LoadImagesFromFolder(string folderPath)
        {
            if (string.IsNullOrEmpty(folderPath) || !Directory.Exists(folderPath))
                return;

            // 為每個 GameChoice 嘗試找到檔名
            foreach (GameChoice choice in Enum.GetValues(typeof(GameChoice)))
            {
                // 合法檔名集合（小寫）
                string baseName = choice switch
                {
                    GameChoice.Stone => "stone",
                    GameChoice.Paper => "paper",
                    GameChoice.Scissors => "scissors",
                    _ => choice.ToString().ToLower()
                };

                // 支援的副檔名
                string[] exts = new[] { ".png", ".jpg", ".jpeg", ".bmp", ".gif" };
                Image loaded = null;

                foreach (var ext in exts)
                {
                    string tryPath = Path.Combine(folderPath, baseName + ext);
                    if (File.Exists(tryPath))
                    {
                        try
                        {
                            // Image.FromFile 會鎖定檔案，為避免影響可改用 Image.FromStream，如果需要我可以改成使用 MemoryStream 複製一份
                            loaded = Image.FromFile(tryPath);
                        }
                        catch
                        {
                            loaded = null;
                        }
                        if (loaded != null)
                            break;
                    }
                }

                // 若找到則先釋放舊的再放新圖
                if (choiceImages.TryGetValue(choice, out Image old) && old != null)
                {
                    try { old.Dispose(); } catch { }
                    choiceImages.Remove(choice);
                }

                if (loaded != null)
                {
                    choiceImages[choice] = loaded;
                }
            }
        }

        /// <summary>
        /// 關閉視窗時釋放載入的圖片資源
        /// </summary>
        private void Form1_FormClosed(object? sender, FormClosedEventArgs e)
        {
            foreach (var kv in choiceImages)
            {
                try { kv.Value?.Dispose(); } catch { }
            }
            choiceImages.Clear();
        }
    }
}
