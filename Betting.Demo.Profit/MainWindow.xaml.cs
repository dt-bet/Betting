using Betting.ViewModel;
using System.Windows;

namespace Betfair.Demo.ProfitTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static MainWindow()
        {

        }

        public MainWindow()
        {
            InitializeComponent();
            this.sampleViewModelViewHost.ViewModel = new ViewModelsViewModel("Betfair.ViewModel.ProfitTest");

        }

        private void StackPanel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
