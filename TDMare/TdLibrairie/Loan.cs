namespace TDMare.TdLibrairie;


public class Loan
{
    public Media BorrowedMedia { get; set; }
    public string User { get; set; }
    public DateTime LoanDate { get; set; }

    // Classe représentant la location de média
    public Loan( Media p_media, string p_user )
    {
        BorrowedMedia = p_media;
        User = p_user;
        LoanDate = DateTime.Now;
    }
}
