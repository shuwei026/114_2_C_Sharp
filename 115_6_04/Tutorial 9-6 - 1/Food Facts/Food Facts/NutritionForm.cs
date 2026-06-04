using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Food_Facts
{
    public partial class NutritionForm : Form
    {
        FoodItem foodItem;
        public NutritionForm(FoodItem foodItem)
        {
            InitializeComponent();
            this.foodItem = foodItem;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
        private void NutritionForm_Load(object sender, EventArgs e)
        {
            // Display the nutrition information for the selected food item.
            foodLabel.Text = foodItem.Name;
            caloriesLabel.Text = foodItem.Calories.ToString();
            fatLabel.Text = foodItem.Fat.ToString();
            carbLabel.Text = foodItem.Carb.ToString();
        }
    }
}
