namespace TDMare.TdLibrairie;

public class CD:Media
{
    public string Artist { get; set; }
    
        public CD( string p_title, int p_referenceNumber, int p_stock, string p_artist )
            : base(p_title, p_referenceNumber, p_stock){
            Artist = p_artist;
        }
    
        public override void DisplayInfo( )
        {
            base.DisplayInfo( );
            Console.WriteLine( $"Artiste: {Artist}" );
        }
}