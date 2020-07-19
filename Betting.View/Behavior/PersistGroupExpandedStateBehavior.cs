//using Microsoft.Xaml.Behaviors;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Media;

//namespace Betting.View.Behavior
//{
//    /// <summary>
//    /// https://stackoverflow.com/questions/2808777/how-to-save-the-isexpanded-state-in-group-headers-of-a-listview
//    /// </summary>
//    public class PersistGroupExpandedStateBehavior : Behavior<Expander>
//    {
//        #region Static Fields

//        public static readonly DependencyProperty GroupNameProperty = DependencyProperty.Register(
//            "GroupName",
//            typeof(string),
//            typeof(PersistGroupExpandedStateBehavior),
//            new PropertyMetadata(default(string)));

//        private static readonly DependencyProperty ExpandedStateStoreProperty =
//            DependencyProperty.RegisterAttached(
//                "ExpandedStateStore",
//                typeof(IDictionary<string, bool>),
//                typeof(PersistGroupExpandedStateBehavior),
//                new PropertyMetadata(default(IDictionary<string, bool>)));

//        #endregion

//        #region Public Properties

//        public string GroupName
//        {
//            get
//            {
//                return (string)GetValue(GroupNameProperty);
//            }

//            set
//            {
//                SetValue(GroupNameProperty, value);
//            }
//        }

//        #endregion

//        #region Methods

//        protected override void OnAttached()
//        {
//            base.OnAttached();

//            bool? expanded = GetExpandedState();

//            if (expanded != null)
//            {

//                AssociatedObject.IsExpanded = expanded.Value;
//                //this.AssociatedObject.Background = Brushes.Red;
//            }

//            AssociatedObject.Expanded += OnExpanded;
//            AssociatedObject.Collapsed += OnCollapsed;
//        }

//        protected override void OnDetaching()
//        {
//            AssociatedObject.Expanded -= OnExpanded;
//            AssociatedObject.Collapsed -= OnCollapsed;

//            base.OnDetaching();
//        }

//        private ItemsControl FindItemsControl()
//        {
//            DependencyObject current = AssociatedObject;

//            while (current != null && !(current is ItemsControl))
//            {
//                current = VisualTreeHelper.GetParent(current);
//            }

//            if (current == null)
//            {
//                return null;
//            }

//            return current as ItemsControl;
//        }

//        private bool? GetExpandedState()
//        {
//            var dict = GetExpandedStateStore();

//            if (!dict.ContainsKey(GroupName))
//            {
//                return null;
//            }

//            return dict[GroupName];
//        }

//        private IDictionary<string, bool> GetExpandedStateStore()
//        {
//            ItemsControl itemsControl = FindItemsControl();

//            if (itemsControl == null)
//            {
//                throw new Exception(
//                    "Behavior needs to be attached to an Expander that is contained inside an ItemsControl");
//            }

//            var dict = (IDictionary<string, bool>)itemsControl.GetValue(ExpandedStateStoreProperty);

//            if (dict == null)
//            {
//                dict = (ReactiveUI.RxApp.SuspensionHost.AppState as ClientApp2.AppState).ExpandedStates ?? new Dictionary<string, bool>();
//                itemsControl.SetValue(ExpandedStateStoreProperty, dict);
//            }

//            return dict;
//        }

//        private void OnCollapsed(object sender, RoutedEventArgs e)
//        {
//            SetExpanded(false);
//        }

//        private void OnExpanded(object sender, RoutedEventArgs e)
//        {
//            SetExpanded(true);
//        }

//        private void SetExpanded(bool expanded)
//        {
//            var dict = GetExpandedStateStore();

//            dict[GroupName] = expanded;

//            if (ReactiveUI.RxApp.SuspensionHost.AppState is ClientApp2.AppState appState)
//            {
//                appState.ExpandedStates = dict;
//            }
//        }

//        #endregion
//    }
//}
