using CircuitBreaker.CircuitBreakerWithStateMachine;
using System;

namespace CircuitBreaker
{
    class Program
    {
        static void Main(string[] args)
        {
            var breaker = new CircuitBreakerContext();
            try
            {
                breaker.ExecuteAction(() =>
                {

                });
            }
            catch (CircuitBreakerOpenException ex)
            {
                Console.WriteLine(ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
