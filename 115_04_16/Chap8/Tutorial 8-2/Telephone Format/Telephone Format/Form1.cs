using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telephone_Format
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // IsValidNumber 方法接受一個字串參數
        // 若該字串僅包含 10 個數字字元則回傳 true，否則回傳 false
        private bool IsValidNumber(string str)
        {
            if (str.Length != 10)
            {
                return false;
            }

            foreach (char c in str)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }

        // TelephoneFormat 方法接受一個字串參考參數
        // 將該字串格式化為電話號碼的顯示格式（例如 (12) 3456-7890）
        private void TelephoneFormat(ref string str)
        {
            //string part1 = str.Substring(0, 2); // 取前兩個字元
            //string part2 = str.Substring(2, 4); // 取接下來四個字元
            //string part3 = str.Substring(6, 4); // 取最後四個字元
           // str = $"({part1}) {part2}-{part3}";

            str = str.Insert(0, "("); // 在字串開頭插入左括號
            str = str.Insert(3, ") "); // 在第三個位置插入右括號和空格
            str = str.Insert(9, "-"); // 在第九個位置插入連字號
        }

        private void formatButton_Click(object sender, EventArgs e)
        {
            // 當使用者按下「格式化」按鈕時觸發的事件處理程序
            // 步驟：
            // 1. 取得輸入並移除前後空白
            // 2. 去除所有非數字字元（例如空格、連字號、括號），以提高容錯性
            // 3. 驗證是否為 10 位數字，若否則顯示錯誤訊息
            // 4. 呼叫 TelephoneFormat 將字串格式化，並將結果顯示回輸入欄位

            // 取得使用者輸入並 trim
            string input = numberTextBox.Text.Trim();

            // 移除所有非數字字元，讓使用者可以輸入含格式的字串也能被接受
            string digits = new string(input.Where(char.IsDigit).ToArray());

            // 檢查是否為有效的 10 位數字
            if (!IsValidNumber(digits))
            {
                // 使用繁體中文提示使用者輸入錯誤
                MessageBox.Show("請輸入 10 位數字，例如 0912345678。", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // 將焦點回到輸入框並選取全部文字，方便重新輸入
                numberTextBox.Focus();
                numberTextBox.SelectAll();
                return;
            }

            // 格式化並回寫到輸入欄位
            TelephoneFormat(ref digits);
            numberTextBox.Text = digits;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
