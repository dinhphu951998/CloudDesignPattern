using System;
using System.Collections.Generic;
using System.Text;

namespace CircuitBreaker
{
    public interface ICircuitBreakerStateStore
    {
        CircuitBreakerStateEnum State { get; }
        Exception LastException { get; }
        DateTime LastStateChangeDateUTC { get; }
        void OpenCircuit(Exception ex); //set to Open state
        void ResetToClose(); //to close
        void HalfOpen(); //to prepare for half open
        bool IsClose { get; }
    }
}
