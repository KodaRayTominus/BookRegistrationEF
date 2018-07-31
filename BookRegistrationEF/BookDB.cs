using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        /**
         * EF will track an object if you pul it
         * out of the database and the do modifications
         * */
        public static void Update(Book b)
        {
            BookContext context = new BookContext();

            //get book from database
            Book originalBook = context.Book.Find(b.ISBN);

            //update any changed properties
            originalBook.Price = b.Price;
            originalBook.Title = b.Title;

            context.SaveChanges();
        }

        //method 2
        public static void UpdateAlt(Book b)
        {
            BookContext context = new BookContext();

            //add book to current context
            context.Book.Add(b);

            //let EF know the book already exsists
            context.Entry(b).State = EntityState.Modified;

            context.SaveChanges();
        }

        public static void Delete(Book b)
        {
            BookContext context = new BookContext();

            context.Book.Add(b);

            context.Entry(b).State = EntityState.Deleted;

            context.SaveChanges();
        }

        //connected scenario where the db context
        //tracks entities in memory
        public static void Delete(string isbn)
        {
            BookContext context = new BookContext();

            //grabbing the entity out of the database to track
            Book bookToDelete = context.Book.Find(isbn);

            //mark the book as deleted from the current context
            context.Book.Remove(bookToDelete);

            //sends delete query to database
            context.SaveChanges();
        }
    }
}
