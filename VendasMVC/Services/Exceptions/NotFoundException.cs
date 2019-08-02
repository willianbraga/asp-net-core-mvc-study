using System;

namespace VendasMVC.Services.Exceptions
{
    public class NotFoundException :ApplicationException
    {
        public NotFoundException (string message) : base (message)
        {

        }
    }
}
