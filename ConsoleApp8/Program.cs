using System;
using System.Collections.Generic;
using System.Linq;

#region Part 02
#region Book Class
public class Book
{
    public string ISBN { get; set; }
    public string Title { get; set; }
    public string[] Authors { get; set; }
    public DateTime PublicationDate { get; set; }
    public decimal Price { get; set; }

    public Book(string _ISBN, string _Title, string[] _Authors, DateTime _PublicationDate, decimal _Price)
    {
        ISBN = _ISBN ?? "Unknown";
        Title = _Title ?? "No Title";
        Authors = _Authors ?? new string[] { "Unknown Author" };
        PublicationDate = _PublicationDate;
        Price = _Price;
    }

    public override string ToString()
    {
        return $"ISBN: {ISBN}, Title: {Title}, Authors: {string.Join(", ", Authors)}, Publication Date: {PublicationDate.ToShortDateString()}, Price: {Price:C}";
    }
}
#endregion

#region BookFunctions Class
public static class BookFunctions
{
    public static string GetTitle(Book B) => B?.Title ?? "No Title";
    public static string GetAuthors(Book B) => B?.Authors != null ? string.Join(", ", B.Authors) : "Unknown Authors";
    public static string GetPrice(Book B) => B != null ? B.Price.ToString("C") : "No Price";
}
#endregion
#endregion

#region Part 03
#region LibraryEngine Class
public class LibraryEngine
{
    public delegate string BookFunction(Book B);

    public static void ProcessBooks(List<Book> bList, BookFunction fPtr)
    {
        if (bList == null || fPtr == null) return;

        foreach (Book B in bList)
        {
            Console.WriteLine(fPtr(B));
        }
    }
}
#endregion

#region CustomList Class
public class CustomList<T>
{
    private List<T> items = new List<T>();

    public void Add(T item) => items.Add(item);
    public bool Exists(Predicate<T> match) => items.Exists(match);
    public T? Find(Predicate<T> match) => items.Find(match);
    public List<T> FindAll(Predicate<T> match) => items.FindAll(match);
    public int FindIndex(Predicate<T> match) => items.FindIndex(match);
    public T? FindLast(Predicate<T> match) => items.FindLast(match);
    public int FindLastIndex(Predicate<T> match) => items.FindLastIndex(match);
    public void ForEach(Action<T> action) => items.ForEach(action);
    public bool TrueForAll(Predicate<T> match) => items.TrueForAll(match);
    public List<T> ToList() => items.ToList();
}
#endregion
#endregion

#region Program Entry Point
class Program
{
    static void Main()
    {
        List<Book> books = new List<Book>
        {
            new Book("123-456-789", "C# Programming", new string[] { "John Doe" }, DateTime.Now, 49.99m),
            new Book("987-654-321", "Advanced C#", new string[] { "Jane Smith" }, DateTime.Now, 59.99m)
        };

        Console.WriteLine("Processing Books:");

        LibraryEngine.ProcessBooks(books, BookFunctions.GetTitle);
    }
}
#endregion
