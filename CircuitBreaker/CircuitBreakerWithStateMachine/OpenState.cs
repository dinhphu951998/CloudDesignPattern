using System;
using System.Collections.Generic;
using System.Text;

namespace CircuitBreaker.CircuitBreakerWithStateMachine
{
    public class OpenState : ICircuitBreakerState
    {
        private readonly DateTime initTime = DateTime.UtcNow;
        private readonly TimeSpan waitingTime = TimeSpan.FromMinutes(30);

        public ICircuitBreakerState Handle(Action action)
        {
            if(initTime + waitingTime < DateTime.UtcNow)
            {
                return new HalfOpenState().Handle(action);
            }
            throw new CircuitBreakerOpenException();
        }
    }
}
