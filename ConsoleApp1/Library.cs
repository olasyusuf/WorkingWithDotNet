public class Library
{
    private List<Book> books;
    private List<Member> members;
    private Dictionary<Member, List<Book>> loanBooks;

    public Library()
    {
        books = new List<Book>();
        members = new List<Member>();
        loanBooks = new Dictionary<Member, List<Book>>();
    }

    public String AddBook(Book book)
    {
        if (book == null)
            return "Invalid book.";

        books.Add(book);
        return "Book added successfully.";
    }

    public List<Book> GetBooks()
    {
        return books;
    }

    public List<Book> GetAvailableBooks()
    {
        return books.Where(b => b.IsAvailable).ToList();
    }

    public Book GetBookByISBN(int isbn) => books.First(book => book.ISBN == isbn && book.IsAvailable);

    public String RemoveBook(Book book)
    {
        if (book == null)
            return "Invalid book.";

        if (!books.Contains(book))
            return "Book not found in library.";

        books.Remove(book);
        return "Book removed successfully.";
    }

    public String AddMember(String name)
    {
        if (name == null)
            return "Please provide a valid name.";

        Member member = new Member(name: name, membershipID: Guid.NewGuid().ToString(), isActive: true);
        members.Add(member);
        return $"Member {member.MembershipID} added successfully.";
    }

    public List<Member> GetMembers()
    {
        return members;
    }

    public Member GetMemberByID(string membershipID) => members.First(m => m.MembershipID == membershipID);

    public String LoanBook(Member member, Book book)
    {
        if (member == null || book == null)
            return "Invalid member or book.";

        if (!books.Contains(book) || !book.IsAvailable)
            return "Book is not available for loan.";

        if (!loanBooks.ContainsKey(member))
            loanBooks[member] = new List<Book>();

        loanBooks[member].Add(book);
        book.IsAvailable = false;
        return "Book loaned successfully.";
    }

    public String ReturnBook(Member member, Book book)
    {
        if (member == null || book == null)
            return "Invalid member or book.";

        if (!loanBooks.ContainsKey(member) || !loanBooks[member].Contains(book))
            return "This book was not loaned to the member.";

        loanBooks[member].Remove(book);
        book.IsAvailable = true;
        return "Book returned successfully.";
    }
}