using System;
using System.Collections.Generic;
using System.Text;

namespace CircuitBreaker.CircuitBreakerWithStateMachine
{
    public class CircuitBreakerContext : ICircuitBreaker
    {
        private ICircuitBreakerState currentState = new CloseState();

        public void ExecuteAction(Action action)
        {
            try
            {
                currentState = currentState.Handle(action);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
