namespace TDMare.TdLibrairie;
using System.Text.Json;
using System.Text.Json.Serialization;
using Exception;

public class Library
{
    private List<Media> mediaCollection = new List<Media>();
    private List<Loan> loans = new List<Loan>();

    public void AddMedia(Media media)
    {
        mediaCollection.Add(media);
        Console.WriteLine($"Média ajouté : {media.Title}");
    }

    public List<Media> MediaCollection => mediaCollection;

    public void RemoveMedia(Media media)
    {
        mediaCollection.Remove(media);
        Console.WriteLine($"Média retiré : {media.Title}");
    }

    public void BorrowMedia(Media media, string user)
    {
        try
        {
            // Tentative de décrémenter le stock du média
            if (media.Stock <= 0)
            {
                // Lever une exception si le stock est épuisé
                throw new OutOfStockException($"{media.Title} n'est pas disponible en stock.");
            } 

            // Si le stock est disponible, on procède à l'emprunt
            media.Stock--;
            loans.Add(new Loan(media, user));
            Console.WriteLine($"{user} a emprunté {media.Title}");
        }
        catch (OutOfStockException ex)
        {
            // Gestion du cas où le média est hors stock
            Console.WriteLine(ex.Message);
        }
    }
    

    public void ReturnMedia(Media media, string user)
    {
        Loan loan = loans.FirstOrDefault(l => l.BorrowedMedia == media && l.User == user);
        if (loan != null)
        {
            media.Stock++;
            loans.Remove(loan);
            Console.WriteLine($"{user} a retourné {media.Title}");
        }
        else
        {
            Console.WriteLine($"{user} n'a pas emprunté {media.Title}");
        }
        
    }

    public List<Media> SearchMedia(string criteria)
    {
        return mediaCollection.Where(m => 
            m.Title.Contains(criteria, StringComparison.OrdinalIgnoreCase) ||
            (m is Book book && book.Author.Contains(criteria, StringComparison.OrdinalIgnoreCase))
        ).ToList();
    }

    public List<Media> ListMediaBorrowedByUser(string user)
    {
        return loans.Where(l => l.User == user)
                    .Select(l => l.BorrowedMedia)
                    .ToList();
    }

    public void DisplayStatistics()
    {
        int totalMedia = mediaCollection.Count;
        int totalAvailableCopies = mediaCollection.Sum(m => m.Stock);
        int borrowedMedia = loans.Count();
        
        Console.WriteLine("Statistiques de la bibliothèque :");
        Console.WriteLine($"- Nombre total de médias : {totalMedia}");
        Console.WriteLine($"- Nombre total d'exemplaires disponibles : {totalAvailableCopies}");
        Console.WriteLine($"- Nombre de médias empruntés : {borrowedMedia}");
    }

        public static Library operator +(Library library, Media media)
    {
        Media existingMedia = library.mediaCollection.FirstOrDefault(m => m.Title == media.Title);

        if (existingMedia != null)
        {
            // Si le média existe déjà, on augmente le stock
            existingMedia.Stock += media.Stock;
        }
        else
        {
            // Sinon, on ajoute le média à la collection
            library.mediaCollection.Add(media);
        }

        Console.WriteLine($"Média ajouté : {media.Title}, Nombre d'exemplaires : {media.Stock}");
        return library;
    }

    // Surcharge de l'opérateur -
    public static Library operator -(Library library, Media media)
    {
        Media existingMedia = library.mediaCollection.FirstOrDefault(m => m.Title == media.Title);

        if (existingMedia != null)
        {
            // Si le stock est suffisant, on retire le nombre d'exemplaires
            if (existingMedia.Stock >= media.Stock)
            {
                existingMedia.Stock -= media.Stock;
                Console.WriteLine($"Média retiré : {media.Title}, Nombre d'exemplaires restants : {existingMedia.Stock}");
            }
            else
            {
                // Gestion d'une exception si le nombre d'exemplaires est insuffisant
                Console.WriteLine($"Erreur : Pas assez d'exemplaires pour retirer {media.Stock} {media.Title}. Exemplaires disponibles : {existingMedia.Stock}");
            }
        }
        else
        {
            Console.WriteLine($"Erreur : Le média {media.Title} n'existe pas dans la bibliothèque.");
        }

        return library;
    }

        // Méthode pour sauvegarder la bibliothèque dans un fichier JSON
    public void SaveToFile(string filePath)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true, // Pour rendre le fichier JSON lisible
            Converters = { new JsonStringEnumConverter() }, // Si on utilise des enums
            IncludeFields = true // Pour inclure les champs privés
        };

        var json = JsonSerializer.Serialize(mediaCollection, options);
        Console.WriteLine(json);
        File.WriteAllText(filePath, json);
        Console.WriteLine($"Bibliothèque sauvegardée dans le fichier : {filePath}");
    }

        public void LoadFromFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            var options = new JsonSerializerOptions
            {
                IncludeFields = true,
                Converters = { new JsonStringEnumConverter() }, // Gérer les enums si nécessaires
            };

            var json = File.ReadAllText(filePath);
            mediaCollection = JsonSerializer.Deserialize<List<Media>>(json, options) ?? new List<Media>();
            Console.WriteLine($"Bibliothèque chargée depuis le fichier : {filePath}");
        }
        else
        {
            Console.WriteLine($"Le fichier {filePath} n'existe pas.");
        }
    }
}
