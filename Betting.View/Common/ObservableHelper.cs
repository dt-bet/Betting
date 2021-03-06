﻿using PropertyTools.Wpf;
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

        public static IObservable<int> ToChanges(this IntegerUpDown integerUpDown) => from a in Observable.FromEventPattern<RoutedPropertyChangedEventHandler<object>, RoutedPropertyChangedEventArgs<object>>(a => integerUpDown.ValueChanged += a, a => integerUpDown.ValueChanged -= a)
                                                                                             select (int)a.EventArgs.NewValue;


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




        public static IObservable<T> SelectItemChanges<T>(this ComboBox comboBox)
        {
            var selectionChanged = comboBox.Events().SelectionChanged;

            // If using ComboBoxItems 
            var comboBoxItems = selectionChanged
          .SelectMany(a => a.AddedItems.OfType<ContentControl>())
          .StartWith(comboBox.SelectedItem as ContentControl)
          .Where(a => a != null)
          .Select(a => NewMethod2(a.Content))
            .Where(a => a.Equals(default(T)) == false);

            // If using type directly
            var directItems = selectionChanged
          .SelectMany(a => a.AddedItems.OfType<T>())
          .StartWith(NewMethod(comboBox.SelectedItem))
          .Where(a => a.Equals(default(T)) == false);

            // If using type indirectly
            var indirectItems = selectionChanged
          .SelectMany(a => a.AddedItems.Cast<object>().Select(a => TypeConvert.TryConvert<object, T>(a, out T t2) ? t2 : default))
          .StartWith(NewMethod2(comboBox.SelectedItem))
          .Where(a => a.Equals(default(T)) == false);

            var c = comboBoxItems.Amb(directItems).Amb(indirectItems);

            return c;

            static T NewMethod(object selectedItem)
            {
                return selectedItem is T t ? t : default;
            }

            static T NewMethod2(object selectedItem)
            {
                return TypeConvert.TryConvert(selectedItem, out T t2) ? t2 : default;
            }
        }


        public static IObservable<bool> SelectToggleChanges(this ToggleButton toggleButton, bool defaultValue = false)
        {
            return toggleButton.Events()
                .Checked.Select(a => true).Merge(toggleButton.Events()
                .Unchecked.Select(a => false))
                .StartWith(toggleButton.IsChecked ?? defaultValue);
        }
    }
}





