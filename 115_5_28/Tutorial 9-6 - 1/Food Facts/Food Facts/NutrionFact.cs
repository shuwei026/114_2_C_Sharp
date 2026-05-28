using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Facts
{
    internal class NutrionFact
    {
        private string foodName;
        private int calories;
        private double fat;
        private int carb;

        public NutrionFact()
        {
            foodName = string.Empty;
            calories = 0;
            fat = 0.0;
            carb = 0;
        }

        public string FoodName
        {
            get { return foodName; }
            set { foodName = value; }
        }

        public int Calories
        {
            get { return calories; }
            set { calories = value; }
        }

        public double Fat
        {
            get { return fat; }
            set { fat = value; }
        }

        public int Carb
        {
            get { return carb; }
            set { carb = value; }
        }   
    }
}
