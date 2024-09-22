namespace TDMare.TdLibrairie.Exception;
using System;

// Exception qui gère quand il n'y a plus de stock de media
public class OutOfStockException : Exception

{
    public OutOfStockException( string p_message ) : base( p_message )
    {
        
    }
}