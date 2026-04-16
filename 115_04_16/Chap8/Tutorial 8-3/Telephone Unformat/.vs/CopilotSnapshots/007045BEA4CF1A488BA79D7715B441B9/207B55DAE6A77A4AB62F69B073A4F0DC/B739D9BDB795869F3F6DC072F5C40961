using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telephone_Unformat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // The IsValidFormat method accepts a string argument
        // and determines whether it is properly formatted as
        // a US telephone number in the following manner:
        // (XX) XXXX-XXXX
        // If the argument is properly formatted, the method
        // returns true, otherwise false.
        private bool IsValidFormat(string str)
        {
           if (str.Length != 14) 
            {
                return false;
            }
            if (str[0] != '(' || str[4] != ')' || str[9] != '-')
            {
                return false;
            }
            for (int i = 1; i <= 2; i++)
            {
                if (!char.IsDigit(str[i]))
                {
                    return false;
                }
            }
            for (int i = 5; i <= 8; i++)
            {
                if (!char.IsDigit(str[i]))
                {
                    return false;
                }
            }
            for (int i = 10; i <= 13; i++)
            {
                if (!char.IsDigit(str[i]))
                {
                    return false;
                }
            }
            return true;
        }

        // The unformat method accepts a string, by reference,
        // assumed to contain a telephone number formatted in
        // this manner: (XX) XXXX-XXXX.
        // The method unformats the string by removing the
        // parentheses and the hyphen.
        private void Unformat(ref string str)
        {
            //str = str.Substring(1, 2) + str.Substring(5, 4) + str.Substring(10, 4);
            str = str.Remove(0, 1); // Remove the first character '('
            str = str.Remove(2, 1); // Remove the second character ')'
            str = str.Remove(6, 1); // Remove the seventh character '-'
        }

        private void unformatButton_Click(object sender, EventArgs e)
        {
            string input = numberTextBox.Text;
            if (IsValidFormat(input))
            {
                Unformat(ref input);
                numberTextBox.Text = input;
            }
            else
            {
                MessageBox.Show("Invalid format. Please enter a number in the format (XXX)XXX-XXXX.");
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
