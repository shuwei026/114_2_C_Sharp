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
    public partial class SecondForm : Form
    {
        //private MainForm mainForm;
        private string username;
        public SecondForm(string uname)
        {
            InitializeComponent();
            username = uname;    
        }

        private void SecondForm_Load(object sender, EventArgs e)
        {
            label1.Text = username;
        }
    }
}
