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

    public String RemoveBook(Book book)
    {
        if (book == null)
            return "Invalid book.";

        if (!books.Contains(book))
            return "Book not found in library.";

        books.Remove(book);
        return "Book removed successfully.";
    }

    public String AddMember(Member member)
    {
        if (member == null)
            return "Invalid member.";

        members.Add(member);
        return "Member added successfully.";
    }

   
}