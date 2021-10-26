using System;
using System.Collections.Generic;
using System.Text;

namespace CircuitBreaker.CircuitBreakerWithStateMachine
{
    public class HalfOpenState : ICircuitBreakerState
    {
        private CircuitBreakerCounter counter => CircuitBreakerCounter.GetCounter();

        public ICircuitBreakerState Handle(Action action)
        {
            try
            {
                action();
                counter.IncreaseSuccessCounter();
                if (counter.SuccessExceeded())
                {
                    return new CloseState();
                }
            }
            catch (Exception)
            {
                counter.IncreaseFailureCounter();
                return new OpenState();
            }
            return this;
        }
    }
}
