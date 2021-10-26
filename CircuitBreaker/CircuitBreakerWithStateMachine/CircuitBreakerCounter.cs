using System;
using System.Collections.Generic;
using System.Text;

namespace CircuitBreaker.CircuitBreakerWithStateMachine
{
    public class CircuitBreakerCounter
    {
        private int failureCount;

        private int successCounter;

        public const int EXCEED_FAILURE_TIMES = 5;
        public const int EXCEED_SUCCESS_TIMES = 5;

        private CircuitBreakerCounter()
        {

        }

        private static CircuitBreakerCounter counter;

        public static CircuitBreakerCounter GetCounter()
        {

            if (counter == null)
            {
                lock (counter)
                {
                    if (counter == null)
                    {
                        counter = new CircuitBreakerCounter();
                    }
                }
            }
            return counter;
        }


        public void IncreaseFailureCounter()
        {
            this.failureCount++;
        }

        public void IncreaseSuccessCounter()
        {
            this.successCounter++;
        }

        public bool FailureExceeded()
        {
            return failureCount >= EXCEED_FAILURE_TIMES;
        }
        public bool SuccessExceeded()
        {
            return successCounter >= EXCEED_SUCCESS_TIMES;
        }
    }
}
