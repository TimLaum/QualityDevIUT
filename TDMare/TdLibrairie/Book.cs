namespace TDMare.TdLibrairie;

// Classe représentatn le média Book
public class Book:Media
{
    public string Author { get; set; }

    public Book( string p_title, int p_referenceNumber, int p_stock, string p_author )
        : base(p_title, p_referenceNumber, p_stock){
        Author = p_author;
    }

    public override void DisplayInfo( )
    {
        base.DisplayInfo();
        Console.WriteLine($"Auteur: {Author}");
    }
}