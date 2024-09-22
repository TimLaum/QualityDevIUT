using TDMare.TdLibrairie;

class Program
{
    static void Main(string[] args)
    {

        Library library = new Library();
        Library library1 = new Library();


        Book book1 = new Book("Les Misérables", 101, 1, "Victor Hugo");
        DVD dvd1 = new DVD("Inception", 202, 3, 148);
        CD cd1 = new CD("Thriller", 303, 10, "Michael Jackson");

        // Ajout des médias à la bibliothèque avec les méthodes classiques
        library.AddMedia(book1);
        library.AddMedia(dvd1);
        library.AddMedia(cd1);
        
        // Emprunt de médias
        try
        {
            library.BorrowMedia(book1, "Michael Jackson");
            library.BorrowMedia(book1, "Michael Jackson");
            library.BorrowMedia(dvd1, "Michael Jackson");
            library.BorrowMedia(cd1, "Patrick Bruel");
            library.BorrowMedia(cd1, "Zinédine Zidane");
        }
        catch (NullReferenceException e)
        {
            // Gestion du cas où le livre vaut null
            Console.WriteLine("Erreur : Un argument est null. Détails : " + e.Message);
        }
        catch (InvalidOperationException e)
        {
            // Gestion du cas où le livre est déjà emprunté ou une autre opération invalide
            Console.WriteLine("Erreur : Le livre est déjà emprunté ou une opération invalide a été tentée. Détails : " + e.Message);
        }
        catch (ArgumentException e)
        {
            // Gestion du cas où le nom de l'emprunteur est invalide (vide ou incorrect)
            Console.WriteLine("Erreur : Le nom de l'emprunteur est invalide. Détails : " + e.Message);
        }
        catch (Exception e)
        {
            // Gestion de toutes les autres exceptions non spécifiques
            Console.WriteLine("Une erreur inattendue est survenue. Détails : " + e.Message);
        }
        
        
        // Retour de média
        try
        {
            library.ReturnMedia(book1, "Michael Jackson");
            library.ReturnMedia(cd1, "Zinédine Zidane");
        }
        catch (NullReferenceException e)
        {
            // Gestion du cas où le média vaut null
            Console.WriteLine("Erreur : Un argument est null. Détails : " + e.Message);
        }
        catch (ArgumentException e)
        {
            // Gestion du cas où le nom de l'emprunteur est invalide (vide ou incorrect)
            Console.WriteLine("Erreur : Le nom de l'emprunteur est invalide. Détails : " + e.Message);
        }
        catch (Exception e)
        {
            // Gestion de toutes les autres exceptions non spécifiques
            Console.WriteLine("Une erreur inattendue est survenue. Détails : " + e.Message);
        }
        
        
        // Q5.3) Affichage de chaque média 
        Console.WriteLine("\n\nMédias dans la bibliothèque");
        foreach (var media in library.MediaCollection)
        {
            Console.WriteLine(' ');
            media.DisplayInfo();
        }
        
        library.SaveToFile("bibliotheque.json");
        library.LoadFromFile("bibliotheque.json");
        library.DisplayStatistics();

    }
}
