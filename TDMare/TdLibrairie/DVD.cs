namespace TDMare.TdLibrairie;

// Classe représentant le média DVD
public class DVD:Media
{
    public double Duration { get; set; } // Durée en minutes

    public DVD( string p_title, int p_referenceNumber, int p_stock, double p_duration )
        : base(p_title, p_referenceNumber, p_stock){
        Duration = p_duration;
    }

    public override void DisplayInfo( )
    {
        base.DisplayInfo( );
        Console.WriteLine( $"Durée: {Duration} minutes" );
    }
}