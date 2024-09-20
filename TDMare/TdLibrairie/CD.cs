namespace TDMare.TdLibrairie;

public class CD:Media
{
    public string Artist { get; set; }
    
        public CD(string title, int referenceNumber, int stock, string artist)
            : base(title, referenceNumber, stock){
            Artist = artist;
        }
    
        public override void DisplayInfo(){
            base.DisplayInfo();
            Console.WriteLine($"Artiste: {Artist}");
        }
}