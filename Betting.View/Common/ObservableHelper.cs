using PropertyTools.Wpf;
using System;
using System.Linq;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Xceed.Wpf.Toolkit;

namespace Betting.View
{
    public static class ObservableHelper
    {
        public static IObservable<DateTime> ToChanges(this DateTimeUpDown dateTimeUpDown) => from a in Observable.FromEventPattern<RoutedPropertyChangedEventHandler<object>, RoutedPropertyChangedEventArgs<object>>(a => dateTimeUpDown.ValueChanged += a, a => dateTimeUpDown.ValueChanged -= a)
                                                                                             select (DateTime)a.EventArgs.NewValue;


        public static IObservable<object> ToChanges(this Selector selector) =>
            from change in (from a in Observable.FromEventPattern<SelectionChangedEventHandler, SelectionChangedEventArgs>(a => selector.SelectionChanged += a, a => selector.SelectionChanged -= a)
             select a.EventArgs.AddedItems.Cast<object>().SingleOrDefault())
            .StartWith(selector.SelectedItem)
            where change != null
            select change;

        public static IObservable<RoutedEventArgs> ToClicks(this Button selector) => from x in Observable.FromEventPattern<RoutedEventHandler, RoutedEventArgs>(a => selector.Click += a, a => selector.Click -= a)
                                                                                     select x.EventArgs;


        public static IObservable<bool?> ToChanges(this ToggleButton toggleButton)
        {
            return (from a in (from a in SelectChecked()
                               select a).Merge(from a in SelectUnchecked()
                                               select a)
                    select a.IsChecked)
                    .StartWith(toggleButton.IsChecked)
                    .DistinctUntilChanged();

            IObservable<ToggleButton> SelectChecked() => from es in Observable.FromEventPattern<RoutedEventHandler, RoutedEventArgs>(a => toggleButton.Checked += a, a => toggleButton.Checked -= a)
                                                         select es.Sender as ToggleButton;

            IObservable<ToggleButton> SelectUnchecked() => from es in Observable.FromEventPattern<RoutedEventHandler, RoutedEventArgs>(a => toggleButton.Unchecked += a, a => toggleButton.Unchecked -= a)
                                                           select es.Sender as ToggleButton;
        }


        public static IObservable<(double h, double v)> ToDeltas(this Thumb thumb) => from es in Observable.FromEventPattern<DragDeltaEventHandler, DragDeltaEventArgs>(a => thumb.DragDelta += a, a => thumb.DragDelta -= a)
                                                                                      select (es.EventArgs.HorizontalChange, es.EventArgs.VerticalChange);

   

    }
}


