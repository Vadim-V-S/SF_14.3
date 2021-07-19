using System;
using System.Collections.Generic;
using System.Linq;

namespace SF_14._3
{
    class Program
    {
        static void Main(string[] args)
        {
            var phoneBook = new List<Contact>();

            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));


            while (true)
            {
                PrintPage(PagePicker(), phoneBook);
            }
        }


        static int PagePicker()
        {
            Console.Write("Введите страницу:\t");

            int num = 0;
            while (!int.TryParse(Console.ReadLine(), out num))
                Console.Write("Введите корректное число:\t");
            Console.Clear();

            return num -= 1;
        }


        static void PrintPage(int num, List<Contact> phoneBook)
        {
            var SelectedRecords = phoneBook.OrderBy(n => n.Name).
                ThenBy(l => l.LastName).
                Skip(num * 2).Take(2).ToList();

            if (SelectedRecords.Count != 0)
            {
                foreach (var rec in SelectedRecords)
                    Console.WriteLine($"{rec.Name} {rec.LastName} тел: {rec.PhoneNumber}, email: {rec.Email}");
            }
            else Console.WriteLine("Нет данных");
        }
    }
}

