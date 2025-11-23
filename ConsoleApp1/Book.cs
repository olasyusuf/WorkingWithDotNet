public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int ISBN { get; }
    public int YearPublished { get; set; }
    public bool IsAvailable { get; set; }

    public Book(int isbn, string title, string author, int yearPublished, bool isAvailable)
    {
        ISBN = isbn;
        Title = title;
        Author = author;
        YearPublished = yearPublished;
        IsAvailable = isAvailable;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"{Title} by {Author}, published in {YearPublished}");
    }
}