using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopCMSMySql
{
    public class Login
    {
        public void GetAccess()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Welcome in admin panel");
            Console.ResetColor();
            Console.WriteLine();
            for (; ; )
            {
                Console.Write("Login: ");
                string admin = Console.ReadLine().ToLower();
                if (admin == "radek" | admin == "łukasz" | admin == "adrian")
                {
                    for (; ; )
                    {
                        Console.Write("Password: ");
                        string password = Console.ReadLine();
                        Console.WriteLine();
                        if (password == "admin")
                        {
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Wrong password !");
                            Console.ResetColor();
                            Console.WriteLine();
                            continue;
                        }
                    }
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Access denied !");
                    Console.ResetColor();
                    Console.WriteLine();
                }
            }
        }
    }
}
        
        
      