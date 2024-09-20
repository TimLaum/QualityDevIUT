
using TDMare.TdLibrairie;

class Program
{
    static void Main(string[] args)
    {
        Book  livre = new Book("Les Misérables", 101, 5, "Victor Hugo");
        DVD dvd = new DVD("Inception", 202, 3, 148);
        CD cd = new CD("Thriller", 303, 10, "Michael Jackson");

        Media[] medias = { livre, dvd, cd };

        foreach (var media in medias)
        {
            media.AfficherInfos();
            Console.WriteLine();
        }
    }
}
