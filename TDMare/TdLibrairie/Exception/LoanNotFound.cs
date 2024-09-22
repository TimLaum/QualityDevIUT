namespace TDMare.TdLibrairie.Exception;
using System;

// Exception qui gère quand un prêt de de média n'a pas été trouvé
public class LoanNotFoundException : Exception
{
    public LoanNotFoundException( string p_message ) : base( p_message ) 
    {
    }
}