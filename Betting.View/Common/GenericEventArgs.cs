using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Betting.View
{
    public delegate void RoutedEventHandler<T>(object sender, RoutedEventArgs<T> e);

    public class RoutedEventArgs<T> : System.Windows.RoutedEventArgs
    {
        public T Arg { get; }

        public RoutedEventArgs(T t, RoutedEvent routedEvent) : base(routedEvent) => Arg = t;
    }
}
