namespace TDMare.TdLibrairie.Exception;
using System;
public class OutOfStockException : Exception

{
    public OutOfStockException(string message) : base(message)
    {
        
    }
}