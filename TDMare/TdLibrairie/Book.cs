namespace TDMare.TdLibrairie;

public class Book:Media
{
    public string Auteur { get; set; }

    public Book(string title, int referenceNumber, int stock, string auteur)
        : base(title, referenceNumber, stock){
        Auteur = auteur;
    }

    public override void AfficherInfos(){
        base.AfficherInfos();
        Console.WriteLine($"Auteur: {Auteur}");
    }
}