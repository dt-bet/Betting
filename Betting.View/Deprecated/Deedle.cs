//using Deedle;
//using OxyPlot;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reactive.Linq;
//using System.Reactive.Subjects;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;

//namespace Betting.View
//{
//    public class DeedleControl:Control
//    {



//        public string Path
//        {
//            get { return (string)GetValue(PathProperty); }
//            set { SetValue(PathProperty, value); }
//        }

//        public static readonly DependencyProperty PathProperty = DependencyProperty.Register("Path", typeof(string), typeof(DeedleControl), new PropertyMetadata(null,Changed));

//        public string Value
//        {
//            get { return (string)GetValue(ValueProperty); }
//            set { SetValue(ValueProperty, value); }
//        }


//        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(string), typeof(DeedleControl), new PropertyMetadata(null, Changed));


//        public string Date
//        {
//            get { return (string)GetValue(DateProperty); }
//            set { SetValue(DateProperty, value); }
//        }

      
//        public static readonly DependencyProperty DateProperty = DependencyProperty.Register("Date", typeof(string), typeof(DeedleControl), new PropertyMetadata(null, Changed));


//        Dictionary<string, Subject<object>> dict = typeof(DeedleControl).GetDependencyProperties().ToDictionary(_ => _.Name.Substring(0, _.Name.Length - 8), _ => new Subject<object>());


//        private static void Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
//        {
//            (d as DeedleControl).dict[e.Property.Name].OnNext(e.NewValue);
//        }


//        static DeedleControl()
//        {
//            DefaultStyleKeyProperty.OverrideMetadata(typeof(DeedleControl), new FrameworkPropertyMetadata(typeof(DeedleControl)));
//        }



//        //public PlotModel PlotModel
//        //{
//        //    get { return (PlotModel)GetValue(PlotModelProperty); }
//        //    set { SetValue(PlotModelProperty, value); }
//        //}

//        // Using a DependencyProperty as the backing store for PlotModel.  This enables animation, styling, binding, etc...
//        public static readonly DependencyProperty PlotModelProperty =
//            DependencyProperty.Register("PlotModel", typeof(PlotModel), typeof(DeedleControl), new PropertyMetadata(null));



//        public DeedleControl()
//        {


//            var xx = dict[nameof(Path)]
//        .CombineLatest(
//        dict[nameof(Date)],
//        dict[nameof(Value)],
//        (path, date, value) => new { path, date, value })
//        .Subscribe(_ =>
//        {
//            Task.Run(() =>  GetPlotModel(GetData((string)_.path, (string)_.value))).ContinueWith(_ =>
//            {
//                this.Dispatcher.InvokeAsync(() => this.SetValue(PlotModelProperty, _), System.Windows.Threading.DispatcherPriority.Background);
//            });
//        });
//        }


//        public static Series<DateTime, double> GetData(string filePath, string column = "open")
//        {

//            var frame = Deedle.Frame.ReadCsv(filePath);
//            string key = frame.ColumnKeys.SingleOrDefault(_ => String.Equals(_, "date", StringComparison.CurrentCultureIgnoreCase));
//            if (key == null)
//                throw new Exception("no date column in data");
//            var frameDate = frame.IndexRows<DateTime>(key).SortRowsByKey();
//            return frameDate.GetColumn<double>(column);

//        }

//        public static PlotModel GetPlotModel(Series<DateTime,double> series)
//        {
//            var model = new PlotModel() {Title= "LineSeries", LegendSymbolLength = 24 };
//            var s1 = new OxyPlot.Series.LineSeries()
//            {
//                Color = OxyColors.SkyBlue,
//                MarkerType = MarkerType.Circle,
//                MarkerSize = 6,
//                MarkerStroke = OxyColors.White,
//                MarkerFill = OxyColors.SkyBlue,
//                MarkerStrokeThickness = 1.5
//            };
//            model.Series.Add(s1);
//            //
//            foreach (var s in series.Observations)
//            {
//                s1.Points.Add(new DataPoint((s.Key-default(DateTime)).TotalHours,s.Value));
//            }
//            return model;
//        }
//    }
//}
