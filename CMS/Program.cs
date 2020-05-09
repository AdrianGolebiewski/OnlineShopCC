using System;
using Dapper;
using Npgsql;

namespace TestDb
{
    class Program
    {
        static void Main(string[] args)
        {
            View menu = new View();
            menu.ShowMenu();
        }
    }
}