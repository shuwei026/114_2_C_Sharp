using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Account_Simulator
{
    public partial class Form1 : Form
    {
        private BankAccount account;

        // 新增欄位：帳戶集合
        private List<BankAccount> accounts = new List<BankAccount>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 不在載入時建立預設帳戶，等按下 CreateAccount 後才建立
            account = null;

            // 顯示初始餘額為 0（帳戶未建立時也顯示 0）
            balanceLabel.Text = (0m).ToString("C");

            // 預設隱藏存款與提款區塊，建立帳戶後才顯示
            depositGroupBox.Visible = false;
            withdrawGroupBox.Visible = false;
        }

        private void createAccountButton_Click(object sender, EventArgs e)
        {
            string ownerName = ownerNameTextBox.Text;
            string accountNumber = accountNumberTextBox.Text;
            decimal openingAmount;

            // Validate the opening amount
            if (!decimal.TryParse(openingAmountTextBox.Text, out openingAmount))
            {
                MessageBox.Show("請輸入有效的開戶金額.");
                return;
            }

            // Create the account
            account = new BankAccount(openingAmount)
            {
                OwnerName = ownerName,
                AccountNumber = accountNumber
            };

            // 把新帳戶加入集合，供 searchAccount 使用
            accounts.Add(account);

            // Update the UI
            balanceLabel.Text = account.Balance.ToString("C");
            depositTextBox.Clear();
            withdrawTextBox.Clear();
            ownerNameTextBox.Clear();
            accountNumberTextBox.Clear();

            // 建立帳戶後顯示存款與提款區塊
            depositGroupBox.Visible = true;
            withdrawGroupBox.Visible = true;
        }

        private BankAccount searchAccount(string accountNumber)
        {
            foreach (BankAccount account in accounts)
            {
                if (account.AccountNumber == accountNumber)
                {
                    return account;
                }
            }

            MessageBox.Show("找不到帳戶.");
            return null;
        }

        private void depositButton_Click(object sender, EventArgs e)
        {
          decimal amount;
            if (decimal.TryParse(depositTextBox.Text, out amount))
            {
                if (account == null)
                {
                    MessageBox.Show("請先建立帳戶.");
                    return;
                }
                account.Deposit(amount);
                balanceLabel.Text = account.Balance.ToString("C");
                depositTextBox.Clear();
            }
            else
            {
                MessageBox.Show("請輸入有效的存款金額.");
            }
            if (account == null)
            {
                MessageBox.Show("請先建立帳戶.");
                return;
            }
            if (decimal.TryParse(depositTextBox.Text, out amount))
            {
                account.Deposit(amount);
                balanceLabel.Text = account.Balance.ToString("C");
                depositTextBox.Clear();
            }
            else
            {
                MessageBox.Show("請輸入有效的存款金額.");
            }
                    }
        private void withdrawButton_Click(object sender, EventArgs e)
        {
            if (account == null)
            {
                MessageBox.Show("請先建立帳戶.");
                return;
            }

            decimal withdrawAmount;
            if (decimal.TryParse(withdrawTextBox.Text, out withdrawAmount))
            {
                // Check if the account has enough balance
                if (account.Balance - withdrawAmount < 0)
                {
                    MessageBox.Show("餘額不足，無法提款.");
                    return;
                }

                account.Withdraw(withdrawAmount);
                balanceLabel.Text = account.Balance.ToString("C");
                withdrawTextBox.Clear();
            }
            else
            {
                MessageBox.Show("請輸入有效的提款金額.");
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }

        private void balanceLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
