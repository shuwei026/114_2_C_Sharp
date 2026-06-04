using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tutorial_9_3_3
{
    public class BankAccount
    {
        private decimal balance;

        public BankAccount(decimal initialBalance)
        {
            balance = initialBalance;
        }

        public decimal Balance
        {
            get { return balance; }
        }

        public string AccountNumber { get; set; }
        public string OwnerName { get; set; }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                balance += amount;
            }
            else
            {
                MessageBox.Show("Deposit amount must be positive.");
            }
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                MessageBox.Show("Withdraw amount must be positive.");
            }
            else if (amount > balance)
            {
                MessageBox.Show("Insufficient funds for this withdrawal.");
            }
            else
            {
                balance -= amount;
            }
        }
    }
}
