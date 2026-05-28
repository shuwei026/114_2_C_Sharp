using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiform_Practice
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void displayFormButton_Click(object sender, EventArgs e)
        {
            // Create an instance of the MessageForm class.
            MessageForm myMessageForm = new MessageForm();

            // Display the form.
            //myMessageForm.ShowDialog();
            myMessageForm.Show();

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
