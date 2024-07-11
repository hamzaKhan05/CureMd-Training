using System;
using System.Collections.Generic;

namespace LibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library("City Library", 1);

            // Create some book instances
            Book book1 = new Book("The Great Gatsby", "F. Scott Fitzgerald", 1);
            Book book2 = new Book("1984", "George Orwell", 2);
            Book book3 = new Book("To Kill a Mockingbird", "Harper Lee", 3);

            // Add books to the library
            library.AddBook(book1);
            library.AddBook(book2);
            library.AddBook(book3);

            // View books in the library
            Console.WriteLine("Books in the library:");
            library.ViewBooks();

            // Remove a book from the library
            library.RemoveBook(2);

            // View books in the library after removal
            Console.WriteLine("Books in the library after removal:");
            library.ViewBooks();
        }
    }

    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int BookID { get; set; }

        public Book(string title, string author, int bookID)
        {
            Title = title;
            Author = author;
            BookID = bookID;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Book ID: {BookID}, Title: {Title}, Author: {Author}");
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

    class Library
    {
        public string LibraryName { get; set; }
        public int LibraryID { get; set; }
        private List<Book> Books { get; set; }

        public Library(string libraryName, int libraryID)
        {
            LibraryName = libraryName;
            LibraryID = libraryID;
            Books = new List<Book>();
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
                Console.WriteLine($"Book '{bookToRemove.Title}' removed from the library.");
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
    }
}
