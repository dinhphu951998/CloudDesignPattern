using System;
using System.Collections.Generic;
using System.Text;

namespace CircuitBreaker
{
    public interface ICircuitBreaker
    {
        void ExecuteAction(Action action);
    }
}
