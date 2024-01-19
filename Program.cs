using System;
using System.ComponentModel.Design;

namespace LibraryCatalogue
{
    public class Book 
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public bool IsCheckedOut { get; set; }

        public Book(int id, string title, string author, string genre, bool isCheckedOut)
        {
            Id = id;
            Author = author;
            Title = title;
            Genre = genre;
            IsCheckedOut = isCheckedOut;
        }

        static Book InputBook(int bookLength)
        {
            Console.WriteLine("Book Title: ");
            string title = Console.ReadLine();
            Console.WriteLine("Book Author: ");
            string author = Console.ReadLine();
            Console.WriteLine("Book Genre: ");
            string genre = Console.ReadLine();
            bool isCheckedOut = false;
            int id = bookLength;
            Book book = new Book(id, title, author, genre, isCheckedOut);
            return book;
        }


        public static void Main()
        {
            List<Book> books = new List<Book>();
            string input;
            
            do
            {
                Console.WriteLine("Welcome to the library system");
                Console.WriteLine("1. Checkout Book 2.Input Book 3.Return Book");
                Console.WriteLine("\t4.View All Books 5.Exit");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Checkout(books);
                        break;
                    case "2":
                        int bookLength = books.Count;
                        Book newBook = InputBook(bookLength);
                        books.Add(newBook);
                        break;
                    case "3":
                        ReturnBook(books);
                        break;
                    case "4":
                        DisplayBooks(books);
                        break;
                    case "5":
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            } while (input != "5");


        }
        static void Checkout(List<Book> books)
        {
            Console.WriteLine("Enter Book Title To Search: ");
            string title = Console.ReadLine();

            Book foundBook = Search(books, title);

            if(foundBook != null)
            {
                Console.WriteLine($"Book Found: \"{foundBook.Title}\" by {foundBook.Author} ");
                if(foundBook.IsCheckedOut == false)
                {
                    Console.WriteLine("This book is available. Would you like to check it out? [y/n]");
                    string choice = Console.ReadLine();
                    if(choice == "y")
                    {
                        Console.WriteLine("Book has been checked out");
                        foundBook.IsCheckedOut = true;
                    }
                    else
                    {
                        return;
                    }

                }
                else
                {
                    Console.WriteLine("Book is currently unavailable");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Book not found");
                Console.WriteLine("Press any key to return to menu.");
                Console.ReadKey();
            }
        }
        static void ReturnBook(List<Book> books)
        {
            Console.WriteLine("Enter Book Title To Return: ");
            string title = Console.ReadLine();

            Book foundBook = Search(books, title);

            if (foundBook != null)
            {
                Console.WriteLine($"Book Found: \"{foundBook.Title}\" by {foundBook.Author} ");
                if (foundBook.IsCheckedOut == true)
                {
                    Console.WriteLine("Thank you for your return!");
                    foundBook.IsCheckedOut= false;
                    Console.WriteLine("Press any key to return to menu.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Error book is not checked out");
                    Console.WriteLine("Press any key to return to menu.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Book not found");
                Console.WriteLine("Press any key to return to menu.");
                Console.ReadKey();
            }
        }
        static Book Search(List<Book> books, string title)
        {
            return books.FirstOrDefault(book => book.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }
        static void DisplayBooks(List<Book> books)
        {

            foreach(var book in books)
            {
                string check = "Checked Out";
                if(book.IsCheckedOut == false)
                {
                    check = "Available";
                }
                Console.WriteLine($"Id: {book.Id}, Title: {book.Title}, Author: {book.Author}, Genre: {book.Genre}, Status: {check}");
            }
        }
       
    }
}