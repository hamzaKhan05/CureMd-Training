using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library("Lahore-Library", 1, new Librarian("Arshad", 28, 1995, 5583));

            // book instances
            NonFictionBook book1 = new NonFictionBook("Abdullah", "Hashim Nadeem", 1, "Philosophy");
            NonFictionBook book2 = new NonFictionBook("Humsafar", "Farhat Ishtiaq", 2, "Romance");
            NonFictionBook book3 = new NonFictionBook("Raja Gidh", "Bano Apa", 3, "Philosophy");
            NonFictionBook book4 = new NonFictionBook("Ak Din", "Bano Apa", 4, "History");
            FictionBook book5 = new FictionBook("Frankenstein", "Mary Shelley", 5, "frame-story");


            //  books to be added into the library
            library.AddBook(book1);
            library.AddBook(book2);
            library.AddBook(book3);
            library.AddBook(book4);
            library.AddBook(book5);


            //  books in the library to be viewed
            Console.WriteLine("All Books in the library are:");
            library.ViewBooks();
            Console.WriteLine("-----------------------------------");

            //  book from the library to be removed
            library.RemoveBook(2);

            //  books in the library after removal to be viewed
            Console.WriteLine("All Books in the library after removal are:");
            library.ViewBooks();
            Console.WriteLine("-----------------------------------");

            // Searching for a book by  Its Name
            Console.WriteLine("Search for a book by name/title 'Raja Gidh':");
            library.SearchBook("Raja Gidh");
            Console.WriteLine("-----------------------------------");

            // Issuing a book to a user named Hamza with age and ID as his DOB
            Person user = new Person("Hamza", 22, 2002); //instance of person class 
            library.Librarian.IssueBook(book1, user);
            library.Librarian.IssueBook(book3, user);

            //  issued books list displayed
            Console.WriteLine("Issued books:");
            library.ListIssuedBooks();
            Console.WriteLine("-----------------------------------");

            // Returning a book to the library and removing it from issued books list
            library.Librarian.ReturnBook(book1, user);

            //  issued books after return being displayed
            Console.WriteLine("Issued books after return:");
            library.ListIssuedBooks();
            Console.WriteLine("-----------------------------------");

            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();
        }
    }

    abstract class Book // Abstract parent class for Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int BookID { get; set; }

        protected Book(string title, string author, int bookID)
        {
            Title = title;
            Author = author;
            BookID = bookID;
        }

        public abstract void DisplayInfo(); // Abstract function for displaying book information which will overrided in childs classes of fiction and non-fiction
    }

    class FictionBook : Book // child class for FictionBook
    {
        public string Genre { get; set; }

        public FictionBook(string title, string author, int bookID, string genre)
            : base(title, author, bookID)
        {
            Genre = genre;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Book ID: {BookID}, Title: {Title}, Author: {Author}, Genre: {Genre}");
        }
    }

    class NonFictionBook : Book // child class for NonFictionBook
    {
        public string Subject { get; set; }

        public NonFictionBook(string title, string author, int bookID, string subject)
            : base(title, author, bookID)
        {
            Subject = subject;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Book ID: {BookID}, Title: {Title}, Author: {Author}, Subject: {Subject}");
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int PersonID { get; set; }

        public Person(string name, int age, int personID)
        {
            Name = name;
            Age = age;
            PersonID = personID;
        }
    }

    class Librarian : Person // Librarian class inherits from Person
    {
        public int EmployeeID { get; set; }
        private List<Tuple<Book, Person>> IssuedBooks { get; set; }

        public Librarian(string name, int age, int personID, int employeeID) : base(name, age, personID)
        {
            EmployeeID = employeeID;
            IssuedBooks = new List<Tuple<Book, Person>>();
        }

        public void IssueBook(Book book, Person user)
        {
            IssuedBooks.Add(new Tuple<Book, Person>(book, user));
            Console.WriteLine($"Book: '{book.Title}' issued to {user.Name}!");
        }

        public void ReturnBook(Book book, Person user)
        {
            // iterates and gives the record of the first book that fulfills the condition and stores it in issuedBook that if the book returned was in the issuedBooks list before or not
            var issuedBook = IssuedBooks.FirstOrDefault(Findbook => Findbook.Item1.BookID == book.BookID && Findbook.Item2.PersonID == user.PersonID);
            if (issuedBook != null) // if book was issued to that user 
            {
                IssuedBooks.Remove(issuedBook);
                Console.WriteLine($"Book: '{book.Title}' returned by {user.Name}!");
            }
            else // if book was not issued to that user or book was not issued at all
            {
                Console.WriteLine($"Book: '{book.Title}' wasn't issued to {user.Name}!");
            }
        }

        public void ListIssuedBooks()
        {
            if (IssuedBooks.Count > 0)
            {
                foreach (var issuedBook in IssuedBooks)
                {
                    Console.WriteLine($"Book-ID: {issuedBook.Item1.BookID}, Title: {issuedBook.Item1.Title}, Issued to: {issuedBook.Item2.Name}");
                }
            }
            else
            {
                Console.WriteLine("No books are currently being issued to a user!");
            }
        }
    }

    class Library
    {
        public string LibraryName { get; set; }
        public int LibraryID { get; set; }
        private List<Book> Books { get; set; }
        public Librarian Librarian { get; set; }

        public Library(string libraryName, int libraryID, Librarian librarian)
        {
            LibraryName = libraryName;
            LibraryID = libraryID;
            Books = new List<Book>();
            Librarian = librarian;
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
            Console.WriteLine($"Book '{book.Title}' added to the library.");
        }

        public void RemoveBook(int bookID)
        {
            Book bookToRemove = Books.Find(book => book.BookID == bookID);
            if (bookToRemove != null)
            {
                Books.Remove(bookToRemove);
                Console.WriteLine($"Book named: '{bookToRemove.Title}' removed from the library.");
            }
            else
            {
                Console.WriteLine($"Book with ID {bookID} not found in the library.");
            }
        }

        public void ViewBooks()
        {
            if (Books.Count > 0)
            {
                foreach (Book book in Books)
                {
                    book.DisplayInfo();
                }
            }
            else
            {
                Console.WriteLine("No books in the library.");
            }
        }

        public void SearchBook(string title)
        {
            Book book = Books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (book != null)
            {
                book.DisplayInfo();
            }
            else
            {
                Console.WriteLine($"Book with title '{title}' not found in the library.");
            }
        }

        public void ListIssuedBooks()
        {
            Librarian.ListIssuedBooks();
        }
    }
}