namespace TDMare.TdLibrairie;

public class Media
{
    public string Title { get; set; }
    public int ReferenceNumber { get; set; }
    public int Stock { get; set; }

    public Media(string title, int referenceNumber, int stock){
        Title = title;  
        ReferenceNumber = referenceNumber;
        Stock = stock;
    }
    
    public virtual void DisplayInfo() {
        Console.WriteLine($"Titre: {Title}");
        Console.WriteLine($"Numéro de référence: {ReferenceNumber}");
        Console.WriteLine($"Nombre d'exemplaires disponibles: {Stock}");
    }
}