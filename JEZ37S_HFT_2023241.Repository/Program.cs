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
                Console.WriteLine(item.Name + ": "+item.Category.Category_Name+"\n\tIrta: "
                    + item.Author.Name + "\n\tKibérelte: " + item.Reservation.MemberName+ "\n\tBérelési szám: "+item.Reservation.Id+"\n");

            }
            Console.ReadLine();
        }
    }
}
