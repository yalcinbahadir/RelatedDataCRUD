using Microsoft.EntityFrameworkCore;
using RelatedData.Data;
using RelatedData.Domein;
using System;
using System.Linq;

namespace RelatedData.UI
{
    class Program
    {
        public static BookDbContext _context = new BookDbContext();
        static void Main(string[] args)
        {
            //AddCategories();
            //AddBooks();
            //AddAuthors();
            //GetAuthors();
            //GetBooks();
            //RemoveOneAuthorFromOneBook();


            Console.ReadLine();
        }

        private static void AddCategories()
        {
            var c1 = new Category() { Name = "Category-A" };
            var c2 = new Category() { Name = "Category-B" };
            var c3 = new Category() { Name = "Category-C" };
            _context.Categories.AddRange(c1, c2, c3);
            var result = _context.SaveChanges() > 0;
            if (result)
            {
                Console.WriteLine("Added Categories");
                var categories = _context.Categories.ToList();
                categories.ForEach(c => Console.WriteLine(c.Name));
            }

        }

        private static void AddBooks()
        {
            var b1 = new Book() { Title = "Book-A", CategoryId = 1 };
            var b2 = new Book() { Title = "Book-B", CategoryId = 2 };
            var b3 = new Book() { Title = "Book-C", CategoryId = 3 };
            _context.Books.AddRange(b1, b2, b3);
            var result = _context.SaveChanges() > 0;
            if (result)
            {
                Console.WriteLine("Added Books");
                var books = _context.Books.Include(b => b.Category).ToList();
                books.ForEach(c => Console.WriteLine($" Title:{c.Title} Category : {c.Category.Name}"));
            }

        }

        private static void AddAuthors()
        {
            var books1 = _context.Books.ToList();
            var a1 = new Author() { Name = "Ali", Books = books1, Contact = new Contact { EmailAddress = "ali@test.com" } };
            var a2 = new Author() { Name = "Tarik", Books = books1, Contact = new Contact { EmailAddress = "tarik@test.com" } };
            var a3 = new Author() { Name = "Bahadir", Books = books1, Contact = new Contact { EmailAddress = "bahadir@test.com" } };

            _context.Authors.AddRange(a1, a2, a3);
            var result = _context.SaveChanges() > 0;
            if (result)
            {
                Console.WriteLine("Added Authors");
                var authors = _context.Authors.Include(b => b.Contact).Include(a => a.Books).ToList();
                authors.ForEach(a => Console.WriteLine($" Name:{a.Name} Email : {a.Contact.EmailAddress} bookcount : {a.Books.Count}"));
            }

        }

        private static void GetAuthors()
        {
            Console.WriteLine(" Authors");
            var authors = _context.Authors.Include(b => b.Contact).Include(a => a.Books).ToList();
            foreach (var a in authors)
            {
                Console.WriteLine($" Name:{a.Name} Email : {a.Contact.EmailAddress} bookcount : {a.Books.Count}");
            }
        }
        private static void GetBooks()
        {
            Console.WriteLine("Books");
            var books = _context.Books.Include(b => b.Authors).ThenInclude(a=>a.Contact).ToList();
            foreach (var b in books)
            {
                Console.WriteLine($" Title:{b.Title}");
                if (b.Authors.Count>0)
                {
                    Console.WriteLine($" Authors:{b.Authors.Count}");
                    Console.WriteLine("........................");
                    foreach (var author in b.Authors)
                    {
                        Console.WriteLine($"Name: {author.Name} Email : {author.Contact.EmailAddress}");
                    }
                }
            }
        }

        private static void RemoveOneAuthorFromOneBook()
        {
            var author = _context.Authors.Find(3);
            var book = _context.Books.Include(b => b.Authors).FirstOrDefault(b=>b.Id==1);

            book.Authors.Remove(author);
            var test = book;
            _context.SaveChanges();

           
        }
    }
}
