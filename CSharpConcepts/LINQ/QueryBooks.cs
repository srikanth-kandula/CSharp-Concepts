using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpConcepts
{
    class Linq
    {        
        public Linq()
        {
            var books = new BookRepository().GetBooks();

            //LINQ Query Operators - same as using Extension methods defined below
            var _selectedBookTitles = from b in books
                                      where b.price < 40
                                      orderby b.price
                                      select b.title;

            //LINQ Extension Methods
            var selectedBookTitles = books
                                    .Where(b => b.price < 40) //returns books with price < 40
                                    .OrderBy(b => b.price) //orders books by their price
                                    .Select(b => b.title); //returns title for each book
                                    
            foreach (string title in selectedBookTitles)
            {
                Console.WriteLine($"{title}");
            }

            var chosenBooks = books
                                .Skip(2).Take(3);
            foreach(Book book in chosenBooks)
            {
                Console.WriteLine($"{book.title} - {book.price}");
            }
        }
    }

    class Book
    {
        public string title;
        public float price;
    }
    class BookRepository
    {
        public IEnumerable<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book() {title = "b_frist book", price = 10.09f },
                new Book() {title = "a_second book", price = 20 },
                new Book() {title = "e_third book", price = 30 },
                new Book() {title = "e_third book", price = 40 },
                new Book() {title = "c_fifth book", price = 50 }
            };
        }
    }
}
