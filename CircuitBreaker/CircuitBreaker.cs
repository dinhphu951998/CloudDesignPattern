using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CircuitBreaker
{
    public class CircuitBreaker : ICircuitBreaker
    {
        private readonly ICircuitBreakerStateStore stateStore = CircuitBreakerStateStoreFactory.GetCircuitBreakerStateStore();
        private readonly object halfOpenSyncObject = new object();
        private readonly TimeSpan openToHalfOpenWaitTime = new TimeSpan(1, 0, 0);

        public bool IsClosed { get { return stateStore.IsClose; } }
        public bool IsOpen { get { return !IsClosed; } }

        public void ExecuteAction(Action action)
        {
            if (IsOpen)
            {
                if (stateStore.LastStateChangeDateUTC + openToHalfOpenWaitTime < DateTime.UtcNow) //may check more things here
                {
                    bool lockTaken = false;// limit threads to be executed when breaker is HalfOpen
                    try
                    {
                        Monitor.TryEnter(halfOpenSyncObject, ref lockTaken);
                        if (lockTaken)
                        {
                            stateStore.HalfOpen();
                            action();
                            stateStore.ResetToClose();
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        stateStore.OpenCircuit(ex);
                        throw;
                    }
                    finally
                    {
                        if (lockTaken)
                        {
                            Monitor.Exit(halfOpenSyncObject);
                        }
                    }
                }
                throw new CircuitBreakerOpenException(stateStore.LastException);
            }

            try
            {
                action();
            }
            catch (Exception ex) //ex happens, set to open state
            {
                this.TrackException(ex);
                throw;
            }
        }

        private void TrackException(Exception ex)
        {
            //may check for number of fail before switching to Open
            this.stateStore.OpenCircuit(ex);
        }
    }
}
