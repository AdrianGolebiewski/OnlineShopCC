using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace TestDb
{
    public class DeleteProduct
    {
        public void DeleteProductFromDb()
        {
            // Łączenie z bazą danych.
            var cs = "Host=localhost;Username=postgres;Password=ZuRaf20102014;Database=cars";
            using var con = new NpgsqlConnection(cs);
            con.Open();
            using var cmd = new NpgsqlCommand();
            cmd.Connection = con;
            for (; ; )
            {
                // Usuwanie produktu
                Console.WriteLine("NAZWA TABLICY: cars | KOLUMNY: car   model   max_speed   hp  price");
                Console.WriteLine();
                Console.WriteLine("Podaj nazwę kolumny i parametr produktu: ");
                Console.WriteLine();
                string parametry = Console.ReadLine();
                cmd.CommandText = $"DELETE FROM cars WHERE {parametry}";
                cmd.ExecuteNonQuery();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine();
                Console.WriteLine("Produkt został usunięty");
                Console.ResetColor();
                Console.WriteLine();
            }
        }
    }
}
