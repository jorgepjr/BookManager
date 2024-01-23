namespace Domain;
public class Book
{
    public Book(string code, string title, string author, string year, string genre, string publisher)
    {
        Code = code;
        Title = title;
        Author = author;
        Year = year;
        Genre = genre;
        Publisher = publisher;
        Active = true;
    }

    public Guid Id { get; private set; }
    public string Code { get; private set; }
    public string Title { get; private set; }
    public string Author { get; private set; }
    public string Year { get; private set; }
    public string Genre { get; private set; }
    public string Publisher { get; private set; }
    public bool Active { get; private set; }
}
