using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly Random _rng = new Random();
        private List<int> _drawNumbers = new List<int>();
        private const int MinNumber = 1;
        private const int MaxNumber = 49;
        private const int RequiredCount = 5;

        public Form1()
        {
            InitializeComponent();
            // 初始隱藏右側比對區（Designer 已設定 Visible=false，這裡可確保）
            labelCompareTitle.Visible = false;
            labelMatchCount.Visible = false;
            labelMatchNumbers.Visible = false;
        }

        private void ButtonGenerate_Click(object? sender, EventArgs e)
        {
            var numbers = GenerateUniqueNumbers(RequiredCount, MinNumber, MaxNumber).OrderBy(n => n).ToList();
            textBoxNum1.Text = numbers.ElementAtOrDefault(0).ToString();
            textBoxNum2.Text = numbers.ElementAtOrDefault(1).ToString();
            textBoxNum3.Text = numbers.ElementAtOrDefault(2).ToString();
            textBoxNum4.Text = numbers.ElementAtOrDefault(3).ToString();
            textBoxNum5.Text = numbers.ElementAtOrDefault(4).ToString();

            UpdateMatchResult(numbers);
        }

        private void ButtonLoadDraw_Click(object? sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog();
            dlg.Filter = "文字檔 (*.txt)|*.txt|所有檔案 (*.*)|*.*";
            dlg.Title = "選擇開獎號碼檔案（每行一個數字，共 5 行）";
            if (dlg.ShowDialog() != DialogResult.OK) return;

            try
            {
                if (!File.Exists(dlg.FileName))
                {
                    MessageBox.Show("所選檔案不存在。", "檔案錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var rawLines = File.ReadAllLines(dlg.FileName);
                var lines = rawLines
                    .Select(l => l.Trim())
                    .Where(l => !string.IsNullOrEmpty(l))
                    .ToArray();

                if (lines.Length != RequiredCount)
                {
                    MessageBox.Show($"檔案需包含 {RequiredCount} 個有效數字（一行一個），但找到 {lines.Length} 行。", "格式錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var parsed = new List<int>();
                for (int i = 0; i < lines.Length; i++)
                {
                    var line = lines[i];
                    if (!int.TryParse(line, out var value))
                    {
                        MessageBox.Show($"第 {i + 1} 行不是有效整數：\"{line}\"。", "格式錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (value < MinNumber || value > MaxNumber)
                    {
                        MessageBox.Show($"第 {i + 1} 行數字超出範圍 ({MinNumber}–{MaxNumber})：{value}。", "數值錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    parsed.Add(value);
                }

                var distinctCount = parsed.Distinct().Count();
                if (distinctCount != RequiredCount)
                {
                    MessageBox.Show("檔案中出現重複號碼，請確認每一行為不同號碼。", "格式錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _drawNumbers = parsed.OrderBy(n => n).ToList();
                RefreshDrawListBox();

                var currentGenerated = GetCurrentGeneratedNumbers();
                if (currentGenerated.Count > 0)
                {
                    UpdateMatchResult(currentGenerated);
                }
                else
                {
                    ResetGeneratedTextBoxColors();
                    // 顯示已載入但尚未產生號碼：顯示比對區但顯示尚未產生訊息
                    UpdateCompareLabelsState(drawLoaded: true, generatedPresent: false, matches: null);
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("無權限讀取該檔案。請檢查檔案權限。", "存取錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show($"讀取檔案時發生 IO 錯誤：{ex.Message}", "IO 錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"讀取或解析檔案時發生未預期的錯誤：{ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonExit_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private List<int> GenerateUniqueNumbers(int count, int minInclusive, int maxInclusive)
        {
            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            int rangeSize = maxInclusive - minInclusive + 1;
            if (rangeSize < count)
            {
                throw new ArgumentException("範圍大小不足以產生指定數量的不重複數字。");
            }

            int[] results = new int[count];
            for (int i = 0; i < count; i++)
            {
                results[i] = -1;
            }

            int filled = 0;
            while (filled < count)
            {
                int candidate = _rng.Next(minInclusive, maxInclusive + 1);
                bool exists = false;

                for (int j = 0; j < filled; j++)
                {
                    if (results[j] == candidate)
                    {
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                {
                    results[filled] = candidate;
                    filled++;
                }
            }

            var list = new List<int>(count);
            for (int i = 0; i < count; i++)
            {
                list.Add(results[i]);
            }

            return list;
        }

        private List<int> GetCurrentGeneratedNumbers()
        {
            var list = new List<int>();
            foreach (var tb in new[] { textBoxNum1, textBoxNum2, textBoxNum3, textBoxNum4, textBoxNum5 })
            {
                if (int.TryParse(tb.Text.Trim(), out var v)) list.Add(v);
            }
            return list;
        }

        private void UpdateMatchResult(IEnumerable<int> generated)
        {
            var generatedList = generated?.ToList() ?? new List<int>();

            if (_drawNumbers == null || _drawNumbers.Count == 0)
            {
                ResetGeneratedTextBoxColors();
                UpdateCompareLabelsState(drawLoaded: false, generatedPresent: generatedList.Count > 0, matches: null);
                return;
            }

            if (generatedList.Count == 0)
            {
                ResetGeneratedTextBoxColors();
                UpdateCompareLabelsState(drawLoaded: true, generatedPresent: false, matches: null);
                return;
            }

            var matches = new List<int>();
            for (int i = 0; i < _drawNumbers.Count; i++)
            {
                int draw = _drawNumbers[i];
                for (int j = 0; j < generatedList.Count; j++)
                {
                    if (generatedList[j] == draw)
                    {
                        bool already = false;
                        for (int k = 0; k < matches.Count; k++)
                        {
                            if (matches[k] == draw) { already = true; break; }
                        }
                        if (!already) matches.Add(draw);
                    }
                }
            }

            // 保留原有獎項判斷（若需要顯示可以額外加入）
            UpdateCompareLabelsState(drawLoaded: true, generatedPresent: true, matches: matches);
            RefreshDrawListBox(matches);
            HighlightGeneratedTextBoxes(matches);
        }

        private void UpdateCompareLabelsState(bool drawLoaded, bool generatedPresent, List<int>? matches)
        {
            if (!drawLoaded)
            {
                // 隱藏整個比對區
                labelCompareTitle.Visible = false;
                labelMatchCount.Visible = false;
                labelMatchNumbers.Visible = false;
                return;
            }

            // 顯示比對區
            labelCompareTitle.Visible = true;
            labelMatchCount.Visible = true;
            labelMatchNumbers.Visible = true;

            labelCompareTitle.Text = "比對結果：";

            if (!generatedPresent)
            {
                labelMatchCount.Text = "尚未產生號碼。";
                labelMatchNumbers.Text = string.Empty;
                return;
            }

            int count = matches?.Count ?? 0;
            labelMatchCount.Text = $"中{count}個號碼";

            if (count == 0)
            {
                labelMatchNumbers.Text = "✖ 沒中獎";
            }
            else
            {
                var ordered = (matches ?? new List<int>()).OrderBy(n => n).ToArray();
                labelMatchNumbers.Text = $"中獎號碼：{string.Join(", ", ordered)}";
            }
        }

        private void RefreshDrawListBox(List<int>? matches = null)
        {
            matches ??= new List<int>();
            listBoxDraw.Items.Clear();
            for (int i = 0; i < _drawNumbers.Count; i++)
            {
                var item = $"第{i + 1}個號碼: {_drawNumbers[i]}";
                bool isMatch = false;
                for (int j = 0; j < matches.Count; j++)
                {
                    if (matches[j] == _drawNumbers[i]) { isMatch = true; break; }
                }
                if (isMatch) item += "  (中)";
                listBoxDraw.Items.Add(item);
            }
        }

        private void HighlightGeneratedTextBoxes(List<int> matches)
        {
            var tbs = new[] { textBoxNum1, textBoxNum2, textBoxNum3, textBoxNum4, textBoxNum5 };
            for (int i = 0; i < tbs.Length; i++)
            {
                var tb = tbs[i];
                if (int.TryParse(tb.Text.Trim(), out var v))
                {
                    bool isMatch = false;
                    for (int j = 0; j < matches.Count; j++)
                    {
                        if (matches[j] == v) { isMatch = true; break; }
                    }

                    tb.BackColor = isMatch ? Color.LightGreen : SystemColors.Window;
                }
                else
                {
                    tb.BackColor = SystemColors.Window;
                }
            }
        }

        private void ResetGeneratedTextBoxColors()
        {
            foreach (var tb in new[] { textBoxNum1, textBoxNum2, textBoxNum3, textBoxNum4, textBoxNum5 })
            {
                tb.BackColor = SystemColors.Window;
            }
        }
    }
}
