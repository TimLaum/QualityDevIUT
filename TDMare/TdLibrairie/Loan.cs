namespace TDMare.TdLibrairie;


public class Loan
{
    public Media BorrowedMedia { get; set; }
    public string User { get; set; }
    public DateTime LoanDate { get; set; }

    public Loan(Media media, string user)
    {
        BorrowedMedia = media;
        User = user;
        LoanDate = DateTime.Now;
    }
}
