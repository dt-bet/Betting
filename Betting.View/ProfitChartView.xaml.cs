using DynamicData.Binding;
using OxyPlot;
using OxyPlot.Series;
using ReactiveUI;
using System;
using System.Collections;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Betting.View
{
    /// <summary>
    /// Interaction logic for ProfitChartView.xaml
    /// </summary>
    public partial class ProfitChartView
    {
        public ProfitChartView()
        {
            InitializeComponent();

            this.WhenActivated(disposable =>
            {
                BalanceIntegerUpDown.ToChanges().InvokeCommand(ViewModel, a => a.Balance).DisposeWith(disposable);
                SigmaIntegerUpDown.ToChanges().InvokeCommand(ViewModel, a => a.Sigma).DisposeWith(disposable);
                FractionIntegerUpDown.ToChanges().InvokeCommand(ViewModel, a => a.Fraction).DisposeWith(disposable);
                WinIntegerUpDown.ToChanges().InvokeCommand(ViewModel, a => a.Win).DisposeWith(disposable);
                ProfitabilityIntegerUpDown.ToChanges().InvokeCommand(ViewModel, a => a.Profitablity).DisposeWith(disposable);
                RunButton.Events().Click.Select(a => runIntegerUpDown.Value).InvokeCommand(ViewModel, a => a.Run).DisposeWith(disposable);
                RunManyButton.Events().Click.Select(a => new object()).InvokeCommand(ViewModel, a => a.RunMany).DisposeWith(disposable);
                RemovePreviousCheckBox.SelectToggleChanges().InvokeCommand(ViewModel, a => a.UsePrevious);

            ViewModel
            .WhenValueChanged(a => a.DataPoints)
                .Where(a => a != null)
                .ObserveOnDispatcher()
                .Select(BuildPlotModel)
                .BindTo(this, a => a.PlotView1.Model);
         
                ViewModel
               .WhenValueChanged(a => a.CurveDataPoints)
                   .Where(a => a != null)
                   .ObserveOnDispatcher()
                   .Select(BuildPlotModel)
                  .BindTo(this, a => a.PlotView2.Model);
            });


        }


        static PlotModel BuildPlotModel(DataPoint[][] list)
        {
            var plotModel = new PlotModel();

            plotModel.Series.Add(Factory.BuildLineDarkSeries(list[0]));

            var rator = list.GetEnumerator();
            {
                rator.MoveNext();
                while (rator.MoveNext())
                {
                    plotModel.Series.Add(Factory.BuildLineLightSeries(rator.Current as IEnumerable));
                }
            }
            return plotModel;
        }

        static PlotModel BuildPlotModel(DataPoint[] dataPoints)
        {
            var plotModel = new PlotModel();
            plotModel.Series.Add(Factory.BuildLineDarkSeries(dataPoints));
            return plotModel;
        }

        static class Factory
        {
            public static LineSeries BuildLineDarkSeries(IEnumerable dataPoints)
            {
                return new LineSeries
                {
                    ItemsSource = dataPoints,
                    StrokeThickness = 1,
                    LineStyle = LineStyle.Dash,
                    MarkerSize = 2,
                    MarkerFill = OxyColors.DarkGray,
                    MarkerType = MarkerType.Circle,
                    Color = OxyColors.Gray
                };
            }

            public static LineSeries BuildLineLightSeries(IEnumerable dataPoints)
            {
                return new LineSeries
                {
                    ItemsSource = dataPoints,
                    LineStyle = LineStyle.Dash,
                    StrokeThickness = 1,
                    MarkerSize = 2,
                    MarkerFill = OxyColors.LightGray,
                    MarkerType = MarkerType.Circle,
                    Color = OxyColors.LightGray
                };
            }
        }

    }
}