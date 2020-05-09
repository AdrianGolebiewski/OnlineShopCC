using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace TestDb
{
    public class ProductsList
    {
        
        public void ShowProducts()
        {
            // Łączenie z bazą danych.
            var cs = "Host=localhost;Username=postgres;Password=ZuRaf20102014;Database=cars";
            using var con = new NpgsqlConnection(cs);
            con.Open();

            // Wyświetlanie zawartości tablicy.
            for (; ; )
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("MENU");
     
                Console.ResetColor();
                string pomoc = "1. Wyświetl całą tablicę - SELECT * FROM nazwa_tablicy\n2. Wyświetl określone kolumny - SELECT nazwa_kolumny FROM nazwa_tablicy" +
                               "\n3. Sortowanie po określonej kolumnie - SELECT * FROM nazwa_tablicy ORDER BY nazwa_kolumny ASC/DESC" +
                               "\n4. Filtrowanie - SELECT * FROM nazwa_tablicy WHERE nazwa_kolumn(y) = 'warunek'" +
                               "\n5. Limit wyświetlania - SELECT * FROM nazwa_tablicy LIMIT ilość_wierszy";
                Console.WriteLine();
                Console.WriteLine("NAZWA TABLICY: cars | KOLUMNY: car   model   max_speed   hp  price");
                Console.WriteLine();
                Console.WriteLine(pomoc);
                Console.WriteLine();
                Console.WriteLine("Wpisz opcję: ");
                Console.WriteLine();
                string opcja = Console.ReadLine();
                string sql = $"{opcja}";
                using var cmd = new NpgsqlCommand(sql, con);

                using NpgsqlDataReader rdr = cmd.ExecuteReader();
                Console.WriteLine($"{rdr.GetName(0),-4} {rdr.GetName(1),-10} {rdr.GetName(2),10} {rdr.GetName(3),10} {rdr.GetName(4),10} {rdr.GetName(5),10}");
                while (rdr.Read())
                {
                    Console.WriteLine($"{rdr.GetInt32(0),-4} {rdr.GetString(1),-10} {rdr.GetString(2),10} {rdr.GetInt32(3),10} {rdr.GetInt32(4),10} {rdr.GetDouble(5),10}");
                }
                Console.WriteLine();
            }
        }
    }
}
