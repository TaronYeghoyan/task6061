using System;

namespace Domain.Exceptions
{
    [Serializable]
    public class BussnessException : Exception
    {
        public BussnessException()
        {
        }

        public BussnessException(string Messege) : base(Messege)
        {
        }

        public BussnessException(string Messerge, Exception InnerException) : base(Messerge, InnerException)
        {
        }
    }
}