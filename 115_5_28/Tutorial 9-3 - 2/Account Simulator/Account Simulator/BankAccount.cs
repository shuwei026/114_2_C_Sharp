using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Account_Simulator
{
    class BankAccount
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

        public string AccountNumber { get; internal set; }
        public string OwnerName { get; internal set; }

        public void Deposit(decimal amount)
        {
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
            }

            else
            {
                MessageBox.Show("Deposit amount must be positive.");
            }

        }

        public void Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
            }
            else if (amount <= 0)
            {
                MessageBox.Show("Withdraw amount must be positive.");
            }
            else
            {
                MessageBox.Show("Insufficient funds for this withdrawal.");
            }
        }
    }
}
       
