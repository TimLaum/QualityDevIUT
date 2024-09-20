namespace TDMare.TdLibrairie;

public class Book:Media
{
    public string Author { get; set; }

    public Book(string title, int referenceNumber, int stock, string author)
        : base(title, referenceNumber, stock){
        Author = author;
    }

    public override void DisplayInfo(){
        base.DisplayInfo();
        Console.WriteLine($"Auteur: {Author}");
    }
}