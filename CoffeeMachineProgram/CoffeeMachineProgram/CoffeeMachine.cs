using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachineProgram
{
    public class CoffeeMachine
    {
        CashRegister cashRegister;
        StorePart storePart;
        DataEntities db;
        List<CoffeeType> coffees;
        public CoffeeMachine()
        {
            db = new DataEntities();
            storePart = new StorePart();
            cashRegister = new CashRegister();
            coffees = db.CoffeeTypes.ToList();
        }
        public bool CheckCoffeesNum(int coffeeNum)
        {
            switch (coffeeNum)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;
                case 9:
                    break;
                case 10:
                    break;
                default:
                    return false;
            }
            return true;
        }
        public CoffeeType GetCoffee(int coffeeNum)
        {
            if (CheckCoffeesNum(coffeeNum))
            {
                return coffees[coffeeNum - 1];
            }
            return null;
        }
        public bool ChoosCoffee()
        {
            bool b = false;
            do
            {
                b = false;
                int numCoffee = 0;
                WriteInPosition(new string(' ', 68), 0, 18, true, true);
                WriteInPosition(new string(' ', 68), 0, 19, true, true);
                WriteInPosition(new string(' ', 68), 0, 20, true, true);
                WriteInPosition(new string(' ',20), 50,16, true, true);

                Console.SetCursorPosition(50, 16);
                int.TryParse(Console.ReadLine(), out numCoffee);
                if (CheckCoffeesNum(numCoffee))
                {
                    CoffeeType coffee = GetCoffee(numCoffee);
                    if (storePart.ResourceTrack(coffee, false))
                    {
                        if (cashRegister.TotalCoins >= coffee.Price)
                        {
                            cashRegister.TotalCoins -= coffee.Price;
                            storePart.ResourceTrack(coffee);
                            WriteInPosition("Total coins is " + cashRegister.TotalCoins, 28, 10, false);
                            WriteInPosition("Your " + coffee.Name + " is ready", 25, 18, false);
                            WriteInPosition("Press 0 for getting your change", 22, 19, false);
                            WriteInPosition("or press any key for choosing coffee again ", 16, 20, false);

                            if (Console.ReadKey().Key == ConsoleKey.D0)
                            {
                                WriteInPosition("Your change is " + (double)cashRegister.Change, 28, 22, false);
                                return true;
                            }
                            else
                            {
                                b = true;
                            }
                        }
                        else
                        {
                            WriteInPosition("you don’t have enough money in your balance for thet Coffee", 7, 18, true);
                            WriteInPosition("press any key  for choosing another coffee", 15, 19, false);
                            WriteInPosition("or press enter for adding coins", 15, 20, false);

                            if (Console.ReadKey().Key == ConsoleKey.Enter)
                            {
                                return false;
                            }
                            b = true;
                        }
                    }
                    else
                    {
                        WriteInPosition("Sorry but in coffee machine not enough resources for preparing that coffee", 5, 18, true);
                        WriteInPosition("press enter for choosing another coffee", 16, 19, false);
                        if (Console.ReadKey().Key == ConsoleKey.Enter)
                        {
                            b = true;
                        }
                    }
                }
                else
                {
                    WriteInPosition(@"Wrong number ...Press enter", 24, 18, true);
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        b = true;
                    }
                }

            } while (b);
            return true;
        }
        public void ThrowCoins()
        {
            do
            {
                WriteInPosition(new string(' ', 68), 0, 18, true, true);
                WriteInPosition(new string(' ', 68), 0, 19, true, true);
                WriteInPosition(new string(' ', 68), 0, 20, true, true);
                WriteInPosition(new string(' ', 68), 0, 13, true, true);
                int coins = 0;
                bool isNull = false;
                try
                {
                    Console.SetCursorPosition(55, 12);
                    Console.WriteLine(new string(' ', 20));
                    Console.SetCursorPosition(55, 12);
                    coins = int.Parse(Console.ReadLine());
                }
                catch (ArgumentNullException)
                {
                    isNull = true;
                }
                catch (Exception)
                {
                    isNull = false;
                }
                if (CashRegister.CheckCoin(coins))
                {
                    this.cashRegister.TotalCoins += coins;
                }
                else
                {
                    if (isNull)
                    {
                        WriteInPosition("Wrong coin retry", 28, 13, true);
                    }
                    else
                    {
                        WriteInPosition("Throw coin", 28, 13, true);
                    }
                }
                WriteInPosition("Total coins is " + cashRegister.TotalCoins, 28, 10, false);
            } while (Console.ReadKey().Key == ConsoleKey.Enter);
        }
        public static void WriteInPosition(string s, int x, int y, bool red, bool clear = false)
        {
            Console.SetCursorPosition(x, y);
            if (!clear)
            {
                if (red)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(s);
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(s);
                }
            }
            else
            {
                Console.WriteLine(new string(' ', s.Length));
            }
        }
        public void DisplayCoffeeTypes()
        {
            Console.WindowWidth = 68;
            Console.SetBufferSize(80, 30);
            int i = 0;
            Console.WriteLine(new string('*', 68));
            foreach (CoffeeType coffee in coffees)
            {
                Console.Write("|" + coffee.Id + " " + coffee.Name + "\t" + coffee.Price + "\t");
                i++;
                if (i % 3 == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine(new string('*', 68));
                }
            }
            Console.WriteLine();
            Console.WriteLine(new string('*', 68));
        }
    }
}
