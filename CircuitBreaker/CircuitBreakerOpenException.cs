using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CircuitBreaker
{
    public class CircuitBreakerOpenException : Exception
    {
        public CircuitBreakerOpenException()
        {
        }

        public CircuitBreakerOpenException(string message) : base(message)
        {
        }

        public CircuitBreakerOpenException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CircuitBreakerOpenException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        public CircuitBreakerOpenException(Exception innerException) : base(innerException.Message, innerException)
        {
        }
    }
}
