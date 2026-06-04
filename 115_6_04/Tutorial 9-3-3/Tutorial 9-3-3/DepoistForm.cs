using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tutorial_9_3_3
{
    public partial class DepoistForm : Form
    {
        private List<BankAccount> bankAccounts;
        public DepoistForm()
        {
            InitializeComponent();
        }

        public DepoistForm(List<BankAccount> accounts)
        {
            InitializeComponent();
            bankAccounts = accounts;
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            string acc = txtAccount.Text.Trim();
            decimal amt;
            if (decimal.TryParse(txtAmount.Text.Trim(), out amt))
            {
                if (bankAccounts != null)
                {
                    var account = bankAccounts.FirstOrDefault(b => string.Equals(b.AccountNumber, acc, StringComparison.OrdinalIgnoreCase));
                    if (account != null)
                    {
                        account.Deposit(amt);
                        lstTransactions.Items.Add($"存款 - 帳號: {acc} 金額: {amt} -> 餘額: {account.Balance}");
                        MessageBox.Show("存款成功", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("找不到指定帳號。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // no account list provided, just log the transaction
                    lstTransactions.Items.Add($"存款 - 帳號: {acc} 金額: {amt}");
                }

                txtAccount.Text = string.Empty;
                txtAmount.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("請輸入有效的金額", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
