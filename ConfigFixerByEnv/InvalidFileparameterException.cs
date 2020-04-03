using System;

namespace ConfigFixerByEnv
{
    public class InvalidFileparameterException : Exception
    {
        public InvalidFileparameterException(string message) : base(message)
        {
        }
    }
}
