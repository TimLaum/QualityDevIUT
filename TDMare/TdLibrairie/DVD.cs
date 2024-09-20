namespace TDMare.TdLibrairie;

public class DVD:Media
{
    public double Duree { get; set; } // Durée en minutes

    public DVD(string title, int referenceNumber, int stock, double duree)
        : base(title, referenceNumber, stock){
        Duree = duree;
    }

    public override void AfficherInfos(){
        base.AfficherInfos();
        Console.WriteLine($"Durée: {Duree} minutes");
    }
}