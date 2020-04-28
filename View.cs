using System;
using System.Collections.Generic;
using System.Text;

namespace TestDb
{
    public class View
    {
        /*
        Metoda do pobierania nazwy użytkownika, hasła i
        do wyświetlania menu. Te motody można rozdzielić
        na oddzielne klasy.
        */

        CreateTable createTable = new CreateTable();
        ProductsList productsList = new ProductsList();
        AddProducts addProducts = new AddProducts();
        DeleteProduct deleteProduct = new DeleteProduct();

        public void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Witaj w panelu administracyjnym");
            Console.ResetColor();
            Console.WriteLine();
            for (; ; )
            {
                Console.Write("Podaj nazwę użytkownika: ");
                string admin = Console.ReadLine().ToLower();
                if (admin == "radek" | admin == "łukasz" | admin == "adrian")
                {
                    for (; ; )
                    {
                        Console.Write("Podaj hasło: ");
                        string haslo = Console.ReadLine();
                        Console.WriteLine();
                        if (haslo != "test")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Podałeś nieporawne hasło !");
                            Console.ResetColor();
                            Console.WriteLine();
                            continue;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("MENU: ");
                            Console.ResetColor();
                            Console.WriteLine();
                            string menu = "1. Lista produktów\n2. Dodaj produkt\n3. Usuń produkt\n4. Aktualizuj produkt\n5. Dodaj nową tablicę";
                            Console.WriteLine(menu);
                            Console.WriteLine();
                            Console.Write("Wybierz opcję: ");
                            int opcja = int.Parse(Console.ReadLine());
                            Console.WriteLine();
                            if (opcja == 1)
                            {
                                productsList.ShowProducts();
                                break;
                            }
                            if (opcja == 2)
                            {
                                addProducts.AddNewProducts();
                                break;
                            }
                            if (opcja == 3)
                            {
                                deleteProduct.DeleteProductFromDb();
                                break;
                            }
                            if (opcja == 5)
                            {
                                createTable.AddNewTable();
                                break;
                            }
                        }

                    }
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine("Nie posiadasz uprawnień administratora !");
                    Console.ResetColor();
                    Console.WriteLine();
                }

            }
        }
    }
}
