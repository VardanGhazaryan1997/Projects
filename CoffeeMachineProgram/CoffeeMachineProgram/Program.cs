using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace CoffeeMachineProgram
{
    class Program
    {
        static CoffeeMachine machine = new CoffeeMachine();
        static void Main(string[] args)
        {
            machine.DisplayCoffeeTypes();
            Console.SetCursorPosition(25, 12);
            Console.Write("Enter Coins <50,100,200,500>");
            Console.SetCursorPosition(25, 16);
            Console.WriteLine("enter number of coffee");
            Thread thread = new Thread(new ThreadStart(WaitToKey));
            thread.Start();
        }
        public static void WaitToKey()
        {
            int x = 12; int y = 21;
            Console.SetCursorPosition(y, x);
            Console.Write("->");
            while (true)
            {
                ConsoleKeyInfo info = Console.ReadKey();
                switch (info.Key)
                {
                    case (ConsoleKey.UpArrow):
                        Console.SetCursorPosition(y, x);
                        Console.Write("  ");
                        x = 12;
                        break;
                    case (ConsoleKey.DownArrow):
                        Console.SetCursorPosition(y, x);
                        Console.Write("  ");
                        x = 16;
                        break;
                    case (ConsoleKey.Enter):
                        if (x == 12)
                            machine.ThrowCoins();
                        if (x == 16)
                        {
                            if (machine.ChoosCoffee())
                            {
                                return;
                            }
                            else {
                                Console.SetCursorPosition(y, x);
                                Console.Write("  ");
                                x = 12;
                                machine.ThrowCoins();
                            }
                        }                       
                        break;
                    default:
                        Console.SetCursorPosition(y + 2, x);
                        Console.Write(" ");
                        break;
                }
                Console.SetCursorPosition(y, x);
                Console.Write("->");
            }
        }
    }
}
