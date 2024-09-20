namespace TDMare.TdLibrairie;

public class DVD:Media
{
    public double Duration { get; set; } // Durée en minutes

    public DVD(string title, int referenceNumber, int stock, double duration)
        : base(title, referenceNumber, stock){
        Duration = duration;
    }

    public override void DisplayInfo(){
        base.DisplayInfo();
        Console.WriteLine($"Durée: {Duration} minutes");
    }
}