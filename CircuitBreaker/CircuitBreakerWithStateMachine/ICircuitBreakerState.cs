using System;
using System.Collections.Generic;
using System.Text;

namespace CircuitBreaker.CircuitBreakerWithStateMachine
{
    public interface ICircuitBreakerState
    {
        ICircuitBreakerState Handle(Action action);
    }
}
