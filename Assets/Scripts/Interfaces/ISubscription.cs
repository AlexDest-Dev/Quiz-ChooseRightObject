using System;

namespace Interfaces
{
        public interface ISubscription<T> where T : Delegate
        {
                public void Subscribe(T listenerMethod);
                public void Unsubscribe(T listenerMethod);
                public void UnsubscribeAll();
        }
}