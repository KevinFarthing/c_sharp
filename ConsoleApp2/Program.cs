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
            bool open = true;
            Console.WriteLine("Library Initializing");
            CardCatalog main = new CardCatalog("C:\\Users\\Kevin\\Documents\\c#\\Card Catalog\\Serial\\catalog.xml");
            while (open)
            {
                Console.WriteLine("Input Command:");
                int cmd = int.Parse(Console.ReadLine().ToLower());
                switch (cmd)
                {
                    case 1:
                        main.AddBooks();
                        break;
                    case 2:
                        main.ListBooks();
                        break;
                    case 0:
                        main.Save();
                        open = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid command");
                        break;
                }
            }
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
        static private string _filename { get; set; }
        private List<Book> books;
        public CardCatalog(string fileName)
        {
            _filename = fileName;
            books = ReadFromFile();

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
        static public List<Book> ReadFromFile()
        {
            using (FileStream stream = new FileStream(_filename, FileMode.OpenOrCreate))
            {
                XmlSerializer XML = new XmlSerializer(typeof(List<Book>));
                return (List<Book>)XML.Deserialize(stream);
            }
        }
        public void Save()
        {
            using (FileStream stream = new FileStream(_filename, FileMode.Create))
            {
                XmlSerializer XML = new XmlSerializer(typeof(List<Book>));
                XML.Serialize(stream, books);
            }
            //serialization...
        }

    }
}
