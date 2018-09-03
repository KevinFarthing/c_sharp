using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace ConsoleApp2
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            Console.ReadLine();
        }
    }

    [Serializable()]
    public class Book
    {
        //maybe don't need privates
        private string title;  // the genre field
        public string Title    // the Genre property
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        private string author;  // the genre field
        public string Author    // the Genre property
        {
            get
            {
                return author;
            }
            set
            {
                author = value;
            }
        }
        private string isbn;
        public string ISBN    // the Name property
        {
            get
            {
                return isbn;
            }
            set
            {
                isbn = value;
            }
        }

        //public Book()//not used in current format
        //{
        //
        //}

        public void Print()
        {

            Console.WriteLine("####");
            Console.WriteLine("Title = '{0}'", Title);
            Console.WriteLine("Author = '{0}'", Author);
            Console.WriteLine("PageCount = '{0}'", ISBN);
            Console.WriteLine("####");
        }
    }
    public class CardCatalog
    {
        private string _filename { get; set; }
        private List<Book> books = new List<Book>();
        public CardCatalog(string fileName)
        {
            //serialization
            //read filename
        }
        public void ListBooks()
        {
            foreach (var book in books)
            {
                book.Print();
            }
        }
        public void AddBooks()
        {
            //use while loops
            Console.WriteLine("Book Title:");
            string title = Console.ReadLine();
            Console.WriteLine("Book Author:");
            string author = Console.ReadLine();
            Console.WriteLine("Book ISBN:");
            string isbn = Console.ReadLine();

            books.Add(new Book()
            {
                Title = title,
                Author = author,
                ISBN=isbn
            });
        }
        public void Save(string filename)
        {
            using (FileStream stream = new FileStream(filename, FileMode.Create))
            {
                XmlSerializer XML = new XmlSerializer(typeof(List<Book>));
                XML.Serialize(stream, books);
            }
            //serialization...
        }

    }
}
