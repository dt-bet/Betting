using Betting.ViewModel;
using ReactiveUI;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Betting.View
{
    /// <summary>
    /// Interaction logic for MainUserControl.xaml
    /// </summary>
    public partial class MainUserControl : ReactiveUserControl<ViewModelsViewModel>
    {

        static MainUserControl()
        {
          
        }

        public MainUserControl()
        {
            InitializeComponent();
            this
              .WhenActivated(
                  disposables =>
                  {
                      (Resources["GroupedSamples"] as CollectionViewSource).Source = ViewModel.Collection;

                      ViewModel.SelectedItem = samplesListBox.SelectedItem;

                      this
                      .OneWayBind(ViewModel,
                      x => x.SelectedItem,
                      x => x.sampleViewModelViewHost.ViewModel,
                      x => ((KeyValuePair<string, KeyValuePair<string, object>>)x).Value.Value)
                      .DisposeWith(disposables);

                 

                      this.samplesListBox.SelectionChanged += SamplesListBox_SelectionChanged;
                  });

        }

        private void SamplesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            (ViewModel).SelectedItem = e.AddedItems.Cast<object>().First();
        }

        private void Button_Home_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
