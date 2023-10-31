using JEZ37S_HFT_2023241.Repository.DataBase;
using System;

namespace JEZ37S_HFT_2023241.Repository
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LibraryDbContext test = new LibraryDbContext();
            foreach (var item in test.Books)
            {
                Console.WriteLine(item.Name + " -- "+ item.Author.Name+" -- "+item.Reservation.MemberName);
                
            }
            Console.ReadLine();
        }
    }
}
