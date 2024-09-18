namespace TDMare.TdLibrairie;

public class CD:Media
{
    public string Artiste { get; set; }
    
        public CD(string title, int referenceNumber, int stock, string artiste)
            : base(title, referenceNumber, stock){
            Artiste = artiste;
        }
    
        public override void AfficherInfos(){
            base.AfficherInfos();
            Console.WriteLine($"Artiste: {Artiste}");
        }
}