using Betting.View;
using Betting.ViewModel;
using ReactiveUI;
using Splat;
using System.Windows;

namespace Betting.DemoWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Locator.CurrentMutable.Register<IViewFor<ProfitChartViewModel>>(()=> new ProfitChartView());

            MainViewModelViewHost.ViewModel = new ProfitChartViewModel();
        }
    }
}
