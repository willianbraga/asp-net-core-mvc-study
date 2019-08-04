using System;


namespace VendasMVC.Services.Exceptions
{
    public class IntegrityException : ApplicationException
    {
        public IntegrityException (string message) : base(message)
        { 
        }
    }
}
