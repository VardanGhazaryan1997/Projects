using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineProgram
{
    public  class CashRegister      
    {
        public decimal Change { get { return TotalCoins - SpendedCoins; } }
        public decimal SpendedCoins { get; set; }
        public decimal TotalCoins { get; set; }
        public static bool CheckCoin(double coins)
        {
            Console.SetCursorPosition(30, 13);
            Console.WriteLine("             ");
            bool b = false;
            switch (coins)
            {
                case (50):
                    b = true;
                    break;
                case (100):
                    b = true;
                    break;
                case (200):
                    b = true;
                    break;
                case (500):
                    b = true;
                    break;
            }
            return b;
        }
        
    }
}
