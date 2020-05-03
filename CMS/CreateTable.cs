using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace TestDb
{
    class CreateTable
    {
        // Metoda do dodawania nowej tablicy
        public string AddNewTable()
        {
            // Łączenie z bazą danych.
            var cs = "Host=localhost;Username=postgres;Password=ZuRaf20102014;Database=cars";
            using var con = new NpgsqlConnection(cs);
            con.Open();
            using var cmd = new NpgsqlCommand();
            cmd.Connection = con;

            // Tworzenie nowej pustej tablicy i usunięcie, jeżeli tablica o takiej nazwie już istnieje.
            Console.Write("Podaj nazwę tablicy: ");
            string newTable = Console.ReadLine();
            string removeTableIfExist = $"DROP TABLE IF EXISTS {newTable}";
            cmd.CommandText = removeTableIfExist;
            cmd.ExecuteNonQuery();

            // Tworzenie struktury tablicy.
            Console.Write("Podaj nazwy i parametry kolumn: ");
            string nameAndTypeOfColumns = Console.ReadLine();
                     
            cmd.CommandText = @$"CREATE TABLE {newTable}(id SERIAL PRIMARY KEY, {nameAndTypeOfColumns})";
            cmd.ExecuteNonQuery();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Nowa tablica została utworzona");
            Console.ResetColor();
            return newTable;
        }
    }
}
