using System;

namespace Legacy.Platform.Core.Exceptions
{
    public class ApplicationException : Exception
    {
        public ApplicationException() : this(String.Empty) { }

        public ApplicationException(string message) : base(message) { }

        public ApplicationException(string message, Exception ex) : base(message, ex) { }
    }
}
