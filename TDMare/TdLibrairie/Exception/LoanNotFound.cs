namespace TDMare.TdLibrairie.Exception;
using System;

public class LoanNotFoundException : Exception
{
    public LoanNotFoundException(string message) : base(message) 
    {
    }
}