using System;
using System.Collections.Generic;
using System.Text;

namespace CircuitBreaker
{
    public enum CircuitBreakerStateEnum
    {
        Open,
        HalfOpen,
        Close
    }
}
