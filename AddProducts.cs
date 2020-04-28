using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace TestDb
{
    public class AddProducts
    {
        public void AddNewProducts()
        {
            // Łączenie z bazą danych.
            var cs = "Host=localhost;Username=postgres;Password=ZuRaf20102014;Database=cars";
            using var con = new NpgsqlConnection(cs);
            con.Open();
            using var cmd = new NpgsqlCommand();
            cmd.Connection = con;
            for (; ; )
            {
                // Dodawanie nowego produktu
                Console.WriteLine("NAZWA TABLICY: cars | KOLUMNY: car   model   max_speed   hp  price");
                Console.WriteLine();
                Console.WriteLine("Podaj parametry produktu: ");
                Console.WriteLine();
                string parametry = Console.ReadLine();
                cmd.CommandText = $"INSERT INTO cars(car, model, max_speed, hp, price) VALUES({parametry})";
                cmd.ExecuteNonQuery();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine();
                Console.WriteLine("Nowy produkt został dodany");
                Console.ResetColor();
                Console.WriteLine();
            }
        }
    }
}
