using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegistrationEF
{
    static class BookDB
    {
        public static List<Book> GetAllBooks()
        {
            BookContext context = new BookContext();

            List<Book> allBooks =
                            (from b in context.Book
                             select b).ToList();
            return allBooks;
        }

        /// <summary>
        /// adds a book to the database
        /// </summary>
        /// <param name="b">book to be added</param>
        public static void Add(Book b)
        {
            BookContext context = new BookContext();

            context.Book.Add(b);

            context.SaveChanges();
        }
    }
}
