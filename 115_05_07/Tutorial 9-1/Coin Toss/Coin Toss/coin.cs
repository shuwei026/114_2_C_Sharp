using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coin_Toss
{
    class coin
    {
        private string sideUp;
        public coin()
        {
           sideUp = "Heads";
        }
        
        public void toss()
        {
            Random rand = new Random();
            int result = rand.Next(2);
            if (result == 0)
                sideUp = "Heads";
            else
                sideUp = "Tails";
        }

        public string getSideUp()
        {
            return sideUp;
        }   
    }
}
