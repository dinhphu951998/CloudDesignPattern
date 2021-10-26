using System;
using System.Collections.Generic;
using System.Text;

namespace CircuitBreaker.CircuitBreakerWithStateMachine
{
    public class CloseState : ICircuitBreakerState
    {
        private CircuitBreakerCounter counter => CircuitBreakerCounter.GetCounter();

        public ICircuitBreakerState Handle(Action action)
        {
            try
            {
                action();
            }
            catch (Exception)
            {
                counter.IncreaseFailureCounter();
                if (counter.FailureExceeded())
                {
                    return new OpenState();
                }
                
            }
            return this;
        }
    }
}
