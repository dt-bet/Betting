using System;
using System.Collections.Generic;
using System.Text;

namespace Betting
{

    internal class Unsubscriber<T> : IDisposable
    {
        private ICollection<IObserver<T>> _observers;
        private IObserver<T> _observer;

        public Unsubscriber(ICollection<IObserver<T>> observers, IObserver<T> observer)
        {
            this._observers = observers;
            this._observer = observer;
        }

        public void Dispose()
        {
            if (_observer != null && _observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }
}
