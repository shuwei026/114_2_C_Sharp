using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Account_Simulator
{
    public partial class Form1 : Form
    {
        // BankAccount field with a $1000 starting balance 
        private BankAccount account = new BankAccount(20000m);


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Display the starting balance.
            balanceLabel.Text = account.Balance.ToString("C");
        }

        private void depositButton_Click(object sender, EventArgs e)
        {
           decimal depositAmount;
            // Validate the input and perform the deposit.
            if (decimal.TryParse(depositTextBox.Text, out depositAmount))
            {
                account.Deposit(depositAmount);
                balanceLabel.Text = account.Balance.ToString("C");
                depositTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Please enter a valid decimal number for the deposit amount.");
            }
        }

        private void withdrawButton_Click(object sender, EventArgs e)
        {
            decimal amount;
            if (decimal.TryParse(withdrawTextBox.Text, out amount))
            {
                account.withdraw(amount);
                balanceLabel.Text = account.Balance.ToString("C");
                withdrawTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Please enter a valid decimal number for the withdrawal amount.");
            }   
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }

        private void depositAmountDescriptionLabel_Click(object sender, EventArgs e)
        {

        }

        private void withdrawAmountDescriptionLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
