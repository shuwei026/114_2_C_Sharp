using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace 摩斯密碼
{
    public partial class Form1 : Form
    {
        // 簡單的 struct 用來儲存單筆摩斯碼對應
        // 要求：使用 struct 並包含一個 char 與一個 string
        private struct MorseEntry
        {
            public char Character; // 對應的字元（儲存為大寫或空格等）
            public string Code;    // 對應的摩斯碼字串（例如 ".-"）

            public MorseEntry(char c, string code)
            {
                Character = c;
                Code = code;
            }
        }

        // 使用 List<MorseEntry> 儲存整張表（不可使用 Dictionary，符合你的要求）
        private List<MorseEntry> morseTable = new List<MorseEntry>();

        public Form1()
        {
            InitializeComponent();

            // 如果設計器在 ListBox 加了預設項目（例如 listBox1）就清除它
            // 包在 try/catch，以免在設計時控制項尚未建立時發生例外
            try { listBox1.Items.Clear(); } catch { }

            // 綁定事件（載入、按鈕點擊）
            this.Load += Form1_Load;
            this.buttonConvert.Click += ButtonConvert_Click;
            this.buttonClear.Click += ButtonClear_Click;
        }

        // 表單載入事件：載入摩斯碼表並把對照顯示在 listbox
        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            LoadMorseTable();       // 讀取外部檔案建立摩斯碼對照表（使用 StreamReader）
            PopulateMappingListBox(); // 顯示已載入的對照
        }

        // 讀取檔案並建立摩斯碼表（簡單、容易理解的實作）
        //
        // 要點：
        // - 必須使用 File.OpenText() 開啟檔案
        // - 使用 StreamReader 讀取且以 !inputFile.EndOfStream 判斷是否還有資料
        // - 支援 markdown 表格格式（每列有 '|' 分隔）或簡單的 "A .-" 格式
        // - 不把整張表寫死在程式裡，從外部檔案 morse_code_table.md 載入
        private void LoadMorseTable()
        {
            // 清空舊資料（若有）
            morseTable.Clear();

            // 檔案放在執行目錄（通常為 bin\Debug）下
            string filePath = Path.Combine(Application.StartupPath, "morse_code_table.md");
            if (!File.Exists(filePath))
            {
                // 如果找不到檔案就提示使用者（不要丟例外）
                MessageBox.Show("找不到 morse_code_table.md，請放到執行目錄 (bin\\Debug)。", "檔案遺失", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 使用 File.OpenText() 回傳 StreamReader，並以 while (!inputFile.EndOfStream) 逐行讀取
            using (StreamReader inputFile = File.OpenText(filePath))
            {
                while (!inputFile.EndOfStream)
                {
                    // 讀取一行文字
                    string line = inputFile.ReadLine();

                    // 忽略空白行
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    // 去頭尾空白方便判斷
                    line = line.Trim();

                    // 支援以 # 開頭的註解行，跳過
                    if (line.StartsWith("#"))
                        continue;

                    // 如果是 Markdown 格式的表格行（包含 |），則嘗試解析
                    // 範例：| Character | Code | Character | Code | ...
                    if (line.Contains("|"))
                    {
                        // 以 '|' 分割，實際資料通常出現在分割陣列的奇數欄位 (1,3,5,...)
                        string[] cols = line.Split('|');

                        // 從索引 1 開始每 2 個為一組（left: character, right: code）
                        for (int i = 1; i + 1 < cols.Length; i += 2)
                        {
                            string left = CleanCell(cols[i]);     // 清理欄位（去除 ` 或 *）
                            string right = CleanCell(cols[i + 1]); // 清理 code 欄位

                            // 若任一欄為空則略過
                            if (string.IsNullOrWhiteSpace(left) || string.IsNullOrWhiteSpace(right))
                                continue;

                            // 處理常見的文字描述映射為實際字元，例如 "space" -> ' '
                            char keyChar;
                            string low = left.ToLower().Trim();
                            if (low == "space" || low == "*space*")
                                keyChar = ' ';
                            else if (low == "comma")
                                keyChar = ',';
                            else if (low == "period" || low == "dot")
                                keyChar = '.';
                            else if (low == "?")
                                keyChar = '?';
                            else
                                // 否則使用欄位的第一個字元（通常是字母或數字）
                                keyChar = left.Trim()[0];

                            // 統一儲存為大寫，方便查詢時不必考慮大小寫
                            keyChar = char.ToUpperInvariant(keyChar);

                            // 加入表格前檢查是否已存在，避免重複
                            bool exists = false;
                            foreach (var e in morseTable)
                            {
                                if (e.Character == keyChar)
                                {
                                    exists = true;
                                    break;
                                }
                            }
                            if (!exists)
                                morseTable.Add(new MorseEntry(keyChar, right));
                        }

                        // 這一行已處理完，跳下一行
                        continue;
                    }

                    // 若不是 table 行，也支援簡單的兩欄格式，例如：A .-
                    // 以空白或 tab 分割
                    string[] parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length >= 2)
                    {
                        string left = CleanCell(parts[0]);
                        string right = CleanCell(parts[1]);
                        if (!string.IsNullOrEmpty(left) && !string.IsNullOrEmpty(right))
                        {
                            char key = char.ToUpperInvariant(left[0]);

                            // 再次檢查是否已有相同 key，避免重複加入
                            bool exists = false;
                            foreach (var e in morseTable)
                            {
                                if (e.Character == key)
                                {
                                    exists = true;
                                    break;
                                }
                            }
                            if (!exists)
                                morseTable.Add(new MorseEntry(key, right));
                        }
                    }
                } // while (!inputFile.EndOfStream)
            } // using StreamReader

            // 最後可選擇性地依字元排序，讓 list 顯示固定順序，方便檢視
            morseTable.Sort((a, b) => a.Character.CompareTo(b.Character));
        }

        // 小工具：清理欄位內容
        // - 移除前後空白
        // - 若用反引號或星號包住（例如 `-....` 或 *space*），則移除包住字元
        // 這樣可以讓 markdown 表格內的表示形式被正確解析成純文字
        private static string CleanCell(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return string.Empty;

            s = s.Trim();

            // 若以反引號包住就移除首尾反引號
            if (s.StartsWith("`") && s.EndsWith("`") && s.Length >= 2)
                s = s.Substring(1, s.Length - 2).Trim();

            // 若以星號包住就移除首尾星號（例如 *space*）
            if (s.StartsWith("*") && s.EndsWith("*") && s.Length >= 2)
                s = s.Substring(1, s.Length - 2).Trim();

            return s;
        }

        // 把載入的對照表顯示到 listBox（逐字對照清單）
        private void PopulateMappingListBox()
        {
            listBox1.Items.Clear();
            foreach (var e in morseTable)
            {
                // 例如顯示 "A -> .-"
                listBox1.Items.Add($"{e.Character} -> {e.Code}");
            }
        }

        // 取得單一字元的摩斯碼（回傳 string；找不到時回傳 null）
        // 這個方法取代原本 TryGetMorse(bool+out) 的實作，對初學者較容易理解
        private string GetMorse(char ch)
        {
            // 將查詢字元轉成大寫與表中儲存值比較，以達到大小寫不敏感
            char up = char.ToUpperInvariant(ch);
            foreach (var e in morseTable)
            {
                if (e.Character == up)
                    return e.Code; // 找到就回傳對應的摩斯碼字串
            }
            return null; // 找不到回傳 null（呼叫端以此判斷是否支援）
        }

        // 轉換按鈕：把 textBoxInput 的文字轉為摩斯碼，並產生逐字對照顯示在 listBox
        private void ButtonConvert_Click(object sender, EventArgs e)
        {
            // 取得使用者輸入，避免為 null
            string input = textBoxInput.Text ?? string.Empty;

            // StringBuilder 用來組合「完整摩斯密碼」
            StringBuilder full = new StringBuilder();

            // 每次轉換前清空 listBox 顯示
            listBox1.Items.Clear();

            // 逐字處理輸入
            foreach (char ch in input)
            {
                // 處理空白（word separator）
                if (char.IsWhiteSpace(ch))
                {
                    // 使用 / 表示單字之間的分隔（常見表示法）
                    if (full.Length > 0)
                        full.Append(" / ");
                    listBox1.Items.Add("(space) -> /"); // 顯示逐字對照（space）
                    continue;
                }

                // 以 GetMorse 取得對應的摩斯碼字串（若為 null 表示不支援）
                string code = GetMorse(ch);
                if (code != null)
                {
                    // 如果已經有內容，先加入一個空格分隔不同字元的摩斯碼
                    if (full.Length > 0 && full[full.Length - 1] != ' ')
                        full.Append(' ');
                    full.Append(code);
                    // 顯示逐字對照：保留原始輸入字元（不會強制顯示為大寫）
                    listBox1.Items.Add($"{ch} -> {code}");
                }
                else
                {
                    // 若表中沒有此字元，依你的要求保留提示（不要直接忽略）
                    if (full.Length > 0 && full[full.Length - 1] != ' ')
                        full.Append(' ');
                    full.Append("[?]"); // 表示未知或不支援
                    listBox1.Items.Add($"{ch} -> (不支援)");
                }
            }

            // 把完整摩斯碼結果顯示到 textBoxMorse
            textBoxMorse.Text = full.ToString();

            // 若 morseTable 為空，提醒使用者可能載入失敗或檔案格式不對
            if (morseTable.Count == 0)
            {
                MessageBox.Show("摩斯碼表為空，請確認 morse_code_table.md 在執行目錄，且格式正確。", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // 清除按鈕：清空輸入、輸出，並重新顯示已載入的對照表
        private void ButtonClear_Click(object sender, EventArgs e)
        {
            textBoxInput.Clear();
            textBoxMorse.Clear();
            listBox1.Items.Clear();
            PopulateMappingListBox(); // 重新填回對照表，方便使用者檢視
        }
    }
}
