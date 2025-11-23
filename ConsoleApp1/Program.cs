// Console.WriteLine("Hello, My first C# Program!");
using System.Diagnostics;

class Program
{
    static Library library = new Library();

    static void AddSampleBooks()
    {
        // Sample usage
        Book book1 = new Book(title: "The Great Gatsby", author: "F. Scott Fitzgerald", isbn: 123456789, isAvailable: true, yearPublished: 1925);
        Book book2 = new Book(title: "1984", author: "George Orwell", isbn: 987654321, isAvailable: true, yearPublished: 1949);

        library.AddBook(book1);
        library.AddBook(book2);
    }

    static void DisplayBooks()
    {
        var books = library.GetBooks();
        Console.WriteLine("Books in Library:");
        foreach (var book in books)
        {
            book.DisplayInfo();
        }
    }
    static void InitializeLibrary()
    {
        AddSampleBooks();
    }

    static void CreateMember()
    {
        Console.Write("Enter member name: ");
        string name = Console.ReadLine() ?? string.Empty;
        Console.WriteLine(library.AddMember(name) ?? "\nError adding member.");
    }

    
    static void ProcessBorrowBook()
    {
        Console.WriteLine("Enter member ID:");
        string memberId = Console.ReadLine() ?? string.Empty;

        Member member = library.GetMemberByID(memberId);

        if (member == null)
        {
            Console.WriteLine("Member not found.");
            return;
        }
        
        DisplayBooks();
        Console.WriteLine("Enter book ISBN:");
        int bookIsbn = int.TryParse(Console.ReadLine(), out bookIsbn) ? bookIsbn : 0;

        Book book = library.GetBookByISBN(bookIsbn);

        if (book == null)
        {
            Console.WriteLine("Book not found.");
            return;
        }

        Console.WriteLine(library.LoanBook(member, book) ?? "Error borrowing book.");
    }

    static void ProcessReturnBook()
    {
        Console.WriteLine("Enter member ID:");
        string memberId = Console.ReadLine() ?? string.Empty;

        Member member = library.GetMemberByID(memberId);

        if (member == null)
        {
            Console.WriteLine("Member not found.");
            return;
        }

        Console.WriteLine("Enter book ISBN:");
        int bookIsbn = int.TryParse(Console.ReadLine(), out bookIsbn) ? bookIsbn : 0;

        Book book = library.GetBookByISBN(bookIsbn);

        if (book == null)
        {
            Console.WriteLine("Book not found.");
            return;
        }

        Console.WriteLine(library.ReturnBook(member, book) ?? "Error returning book.");
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Bolajoko's Library Management System");
        InitializeLibrary();
        
        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create Membership Account");
            Console.WriteLine("2. Borrow Book");
            Console.WriteLine("3. Return Books");
            Console.WriteLine("9. Exit");
            Console.Write("Choose an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    CreateMember();
                    break;
                case "2":
                    ProcessBorrowBook();
                    break;
                case "3":
                    ProcessReturnBook();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Environment.Exit(0); 
                    break;
            }
        }
    }
}



  