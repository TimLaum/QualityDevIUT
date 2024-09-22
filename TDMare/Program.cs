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
/*
        library.BorrowMedia(cd1, "Alice Martin");

        // Recherche de médias
        var searchResults = library.SearchMedia("Les Misérables");
        Console.WriteLine("\nRésultat de la recherche :");
        foreach (var media in searchResults)
        {
            media.DisplayInfo();
        }

        // Affichage des médias empruntés par John Doe
        var borrowedMedia = library.ListMediaBorrowedByUser("John Doe");
        Console.WriteLine("\nMédias empruntés par John Doe :");
        foreach (var media in borrowedMedia)
        {
            media.DisplayInfo();
        }

        // Retour du livre emprunté
        library.ReturnMedia(book1, "John Doe");

        // Affichage des statistiques de la bibliothèque
        library.DisplayStatistics();

        // Ajout d'un autre exemplaire du livre avec l'opérateur +
        library += new Book("Les Misérables", 101, 2, "Victor Hugo");

        // Tentative de retrait de médias avec l'opérateur -
        library -= new Book("Les Misérables", 101, 3, "Victor Hugo");
        library -= new CD("Thriller", 303, 12, "Michael Jackson");  // Va générer une erreur, car il n'y a pas assez d'exemplaires

        // Affichage des statistiques mises à jour après les opérations +
        library.DisplayStatistics();

        library.SaveToFile("bibliotheque.json");
        library1.LoadFromFile("bibliotheque.json");
        library1.DisplayStatistics();
*/
    }
}
