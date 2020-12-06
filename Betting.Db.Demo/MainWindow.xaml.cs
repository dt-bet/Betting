using System.Windows;

namespace Betting.Db.Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataGrid1.ItemsSource = Betting.Faker.Factory.FakerOdd.Generate(100);
            DataGrid2.ItemsSource = Betting.Faker.Factory.FakerStrategy.Generate(7);
            DataGrid2.ItemsSource = Betting.Faker.Factory.FakerStrategy.Generate(7);
        }
    }
}
