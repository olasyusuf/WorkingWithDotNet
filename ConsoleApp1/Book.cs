public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int ISBN { get; }
    public int YearPublished { get; set; }
    public bool IsAvailable { get; set; }

    public Book(string title, string author, int isbn, int yearPublished, bool isAvailable)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        YearPublished = yearPublished;
        IsAvailable = isAvailable;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"{Title} by {Author}, published in {YearPublished}");
    }
}