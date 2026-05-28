using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MutiFormVarlible
{
    public partial class MainForm : Form
    {
        public string username = "Chuckhu";

        public string Username
        {
            get { return username; }
            
        }   
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SecondForm secondForm = new SecondForm(this);
            secondForm.Show();
        }
    }
}
