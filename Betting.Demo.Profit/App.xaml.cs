using Betting.View.Profit;
using ReactiveUI;
using Splat;
using System;
using System.Linq;
using System.Windows;
using static Splat.Locator;


namespace Betfair.Demo.ProfitTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly AutoSuspendHelper autoSuspendHelper;

        public App()
        {
            SQLitePCL.Batteries.Init();

            this.autoSuspendHelper = new AutoSuspendHelper(this);

            //Locator.CurrentMutable.RegisterConstant(ObservableLogger.Instance, typeof(ILogger));
            //Locator.CurrentMutable.RegisterConstant(new CombinedLogger(ObservableLogger.Instance, new UtilityLog.ConsoleLogger()), typeof(ILogger));

            //// Initialize the suspension driver after AutoSuspendHelper.
            //RxApp.SuspensionHost.CreateNewAppState = () => new AppState();
            //RxApp.SuspensionHost.SetupDefaultSuspendResume(new Betfair.App.Wpf.Infrastructure.NewtonsoftJsonSuspensionDriver(Common.Constants.AppStatePath));

            // seems stupid, but this forces the RxApp static constructor to run
            // without this, our registrations below might be overwritten by RxUI when it eventually initializes
            RxApp.DefaultExceptionHandler = RxApp.DefaultExceptionHandler;

            RegisterAll();
        }



        void RegisterAll()
        {
            RegisterOther();

            RegisterViews();

            AppDomain currentDomain = AppDomain.CurrentDomain;
            //currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);
        }

        private static void RegisterViews()
        {

        }

        private void RegisterOther()
        {
            var defaultViewLocator = Locator.Current.GetService<IViewLocator>();
            var viewLocator = new ConventionBasedViewLocator(defaultViewLocator);

            // register a custom view locator that uses convention to resolve views based on view model names, but also defers
            // to the default view locator for those samples that require it for demonstration purposes
            CurrentMutable.RegisterConstant<IViewLocator>(viewLocator);

            //RegLazy(() => new DAL.BetScoreRepository(), typeof(IBetScoreRepository));
            //RegLazy<IBetAdjuster>(() => new BetAdjuster(Locator.Current.GetService<IMainConnection>()));
           // RegLazy<INameGetter>(() => new BLL.Service.NameGetter());
        }


        private static void RegLazy<T>(Func<T> func, string contract = null) => CurrentMutable.RegisterLazySingleton(func, contract);

        private static void RegLazy<T>(Lazy<T> func, string contract = null) => CurrentMutable.RegisterLazySingleton(() => func.Value, contract);

    }



    sealed class ConventionBasedViewLocator : IViewLocator
    {
        private readonly IViewLocator deferTo;
        private readonly Lazy<Type[]> types = new Lazy<Type[]>(() => typeof(TestSubChartView).Assembly.GetTypes());

        public ConventionBasedViewLocator(IViewLocator deferTo)
        {
            this.deferTo = deferTo;

        }

        public IViewFor ResolveView<T>(T viewModel, string contract = null) where T : class
        {

            return contract == null && (GetViewType(viewModel.GetType()) is Type viewType) ?
                (IViewFor)Activator.CreateInstance(viewType) :
                this.deferTo.ResolveView(viewModel, contract);


            Type GetViewType(Type viewModelType)
            {
                var viewTypeName = viewModelType.FullName.Replace("ViewModel", "View").Split('.').Last();

                var viewType = types.Value.SingleOrDefault(a => a.Name == viewTypeName);

                if (viewType == null && viewModelType.BaseType != typeof(object))
                {
                    return GetViewType(viewModelType.BaseType);
                }

                return viewType;
            }
        }
    }
}
