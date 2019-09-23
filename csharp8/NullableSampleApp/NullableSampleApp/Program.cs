using System;

#nullable enable

namespace NullableSampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book();
            book.Title = "Professional C#";
        }

        static void ShowBook(Book book)
        {
            Console.WriteLine($"{book.Title} {book.Publisher.ToUpper()}");
        }
    }
}
