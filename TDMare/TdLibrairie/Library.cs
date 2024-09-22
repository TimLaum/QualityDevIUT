namespace TDMare.TdLibrairie;
using System.Text.Json;
using System.Text.Json.Serialization;
using Exception;

// Classe de base représentant la librairie
public class Library
{
    private List<Media> mediaCollection = new List<Media>( );
    private List<Loan> loans = new List<Loan>( );
    

    public void AddMedia( Media p_media )
    {
        mediaCollection.Add( p_media );
        Console.WriteLine( $"Média ajouté : {p_media.Title}" );
    }
    
    
    public List<Media> MediaCollection => mediaCollection;

    public void RemoveMedia( Media p_media )
    {
        mediaCollection.Remove( p_media );
        Console.WriteLine( $"Média retiré : {p_media.Title}" );
    }

    public void BorrowMedia( Media p_media, string p_user )
    {
        try
        {
            // Tentative de décrémenter le stock du média
            if ( p_media.Stock <= 0 )
            {
                // Lever une exception si le stock est épuisé
                throw new OutOfStockException( $"{p_media.Title} n'est pas disponible en stock." );
            } 

            // Si le stock est disponible, on procède à l'emprunt
            p_media.Stock--;
            loans.Add( new Loan( p_media, p_user ) );
            Console.WriteLine( $"{p_user} a emprunté {p_media.Title}" );
        }
        catch ( OutOfStockException ex )
        {
            // Gestion du cas où le média est hors stock
            Console.WriteLine( ex.Message );
        }
    }
    

    public void ReturnMedia( Media p_media, string p_user )
    {
        // Recherche du prêt correspondant dans la liste des prêts
        Loan loan = loans.FirstOrDefault( l => l.BorrowedMedia == p_media && l.User == p_user );

        // Vérification si le prêt existe
        if ( loan == null )
        {
            // Lancer une exception si aucun prêt ne correspond
            throw new LoanNotFoundException( $"{p_user} n'a pas emprunté {p_media.Title}." );
        }

        // Si le prêt est trouvé, on augmente le stock et on supprime le prêt
        p_media.Stock++;
        loans.Remove( loan );
        Console.WriteLine( $"{p_user} a retourné {p_media.Title}" );
    }
        
    

    public List<Media> SearchMedia( string criteria )
    {
        return mediaCollection.Where(m => 
            m.Title.Contains( criteria, StringComparison.OrdinalIgnoreCase ) ||
            ( m is Book book && book.Author.Contains(criteria, StringComparison.OrdinalIgnoreCase ) )
        ).ToList( );
    }

    public List<Media> ListMediaBorrowedByUser( string p_user )
    {
        return loans.Where( l => l.User == p_user )
                    .Select( l => l.BorrowedMedia )
                    .ToList( );
    }

    public void DisplayStatistics( )
    {
        int totalMedia = mediaCollection.Count;
        int totalAvailableCopies = mediaCollection.Sum( m => m.Stock );
        int borrowedMedia = loans.Count();
        
        Console.WriteLine( "Statistiques de la bibliothèque :" );
        Console.WriteLine( $"- Nombre total de médias : {totalMedia}" );
        Console.WriteLine( $"- Nombre total d'exemplaires disponibles : {totalAvailableCopies}" );
        Console.WriteLine( $"- Nombre de médias empruntés : {borrowedMedia}" );
    }

        //Surcharge de l'opérateur + pour ajouter un média dans la librairie
        public static Library operator +( Library library, Media p_media )
    {
        Media existingMedia = library.mediaCollection.FirstOrDefault( m => m.Title == p_media.Title );

        if ( existingMedia != null )
        {
            // Si le média existe déjà, on augmente le stock
            existingMedia.Stock += p_media.Stock;
        }
        else
        {
            // Sinon, on ajoute le média à la collection
            library.mediaCollection.Add( p_media );
        }

        Console.WriteLine( $"Média ajouté : {p_media.Title}, Nombre d'exemplaires : {p_media.Stock}" );
        return library;
    }

    // Surcharge de l'opérateur - pour retirer un média de la librairie
    public static Library operator -( Library library, Media p_media )
    {
        Media existingMedia = library.mediaCollection.FirstOrDefault( m => m.Title == p_media.Title );

        if ( existingMedia != null )
        {
            // Si le stock est suffisant, on retire le nombre d'exemplaires
            if ( existingMedia.Stock >= p_media.Stock )
            {
                existingMedia.Stock -= p_media.Stock;
                Console.WriteLine( $"Média retiré : {p_media.Title}, Nombre d'exemplaires restants : {existingMedia.Stock}" );
            }
            else
            {
                // Gestion d'une exception si le nombre d'exemplaires est insuffisant
                Console.WriteLine( $"Erreur : Pas assez d'exemplaires pour retirer {p_media.Stock} {p_media.Title}. Exemplaires disponibles : {existingMedia.Stock}" );
            }
        }
        else
        {
            Console.WriteLine( $"Erreur : Le média {p_media.Title} n'existe pas dans la bibliothèque." );
        }

        return library;
    }

        // Méthode pour sauvegarder la bibliothèque dans un fichier JSON
    public void SaveToFile( string filePath )
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true, // Pour rendre le fichier JSON lisible
            Converters = { new JsonStringEnumConverter() }, // Si on utilise des enums
            IncludeFields = true // Pour inclure les champs privés
        };

        var json = JsonSerializer.Serialize(mediaCollection, options);
        Console.WriteLine( json );
        File.WriteAllText( filePath, json );
        Console.WriteLine( $"Bibliothèque sauvegardée dans le fichier : {filePath}" );
    }

        public void LoadFromFile( string filePath )
    {
        if ( File.Exists( filePath ) )
        {
            var options = new JsonSerializerOptions
            {
                IncludeFields = true,
                Converters = { new JsonStringEnumConverter( ) }, // Gérer les enums si nécessaires
            };

            var json = File.ReadAllText( filePath );
            mediaCollection = JsonSerializer.Deserialize<List<Media>>( json, options ) ?? new List<Media>();
            Console.WriteLine( $"Bibliothèque chargée depuis le fichier : {filePath}" );
        }
        else
        {
            Console.WriteLine( $"Le fichier {filePath} n'existe pas." );
        }
    }
}
