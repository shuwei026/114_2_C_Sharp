using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Color_Spectrum
{
    enum Spectrum 
    { 
        Red =10, Orange = 20, Yellow = 30, Green = 40,
        Blue = 50, Indigo = 60, Violet = 70
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // The DisplayColor method displays the
        // name of a color.
        private void DisplayColor(Spectrum color)
        {
            colorLabel.Text = ((int)color).ToString()+": "+color.ToString();
        }

        private void redLabel_Click(object sender, EventArgs e)
        {
            DisplayColor(Spectrum.Red);
        }

        private void orangeLabel_Click(object sender, EventArgs e)
        {
            DisplayColor(Spectrum.Orange);
        }

        private void yellowLabel_Click(object sender, EventArgs e)
        {
            DisplayColor(Spectrum.Yellow);
        }

        private void greenLabel_Click(object sender, EventArgs e)
        {
            DisplayColor(Spectrum.Green);
        }

        private void blueLabel_Click(object sender, EventArgs e)
        {
            DisplayColor(Spectrum.Blue);
        }

        private void indigoLabel_Click(object sender, EventArgs e)
        {
            DisplayColor(Spectrum.Indigo);
        }

        private void violetLabel_Click(object sender, EventArgs e)
        {
            DisplayColor(Spectrum.Violet);
        }
    }
}
