using DynamicData.Binding;
using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Controls;

namespace Betting.View
{
    /// <summary>
    /// Interaction logic for ProfitChartView.xaml
    /// </summary>
    public partial class ProfitChartView : UserControl
    {
        public ProfitChartView()
        {
            InitializeComponent();

            var vm = new Betting.ViewModel.ProfitChartViewModel();
            this.DataContext = vm;
            vm.WhenValueChanged(a => a.DataPoints)
                .Where(a=>a!=null)
                .ObserveOnDispatcher()
                .Subscribe(a =>
            {

                DataPoint[][] list = new DataPoint[3][];

                for (int i = 0; i < 3; i++)
                {
                    list[i] = new DataPoint[a.Length];
                }

                for (int i = 0; i < a.Length; i++)
                {
                    int j = 0;
                    try
                    {

                        using var c = a[i].ToList().GetEnumerator();
                        while (c.MoveNext() && 0 <= j++)
                            list[j - 1][i] = c.Current;
                    }
                    catch(Exception ex)
                    {

                    }
                }



                try
                {
                    var plotModel = new PlotModel();

                    var rator = list.GetEnumerator();
                        var ls = new LineSeries
                        {
                            ItemsSource = list[0],
                            StrokeThickness = 2,
                            LineStyle = LineStyle.Solid,
                            MarkerSize = 4,
                            MarkerFill = OxyColors.DarkGray,
                            MarkerType = MarkerType.Circle,
                            Color = OxyColors.Gray
                        };



                        plotModel.Series.Add(ls);

                    rator.MoveNext();
                    while (rator.MoveNext())
                    {
                        var ls2 = new LineSeries
                        {
                            ItemsSource = rator.Current as System.Collections.IEnumerable,
                            StrokeThickness = 2,
                            LineStyle = LineStyle.Dash,
                           
                          
                            Color = OxyColors.Gainsboro
                        };



                        plotModel.Series.Add(ls2);
                    }
                    PlotView1.Model = plotModel;
                }
                catch (Exception ex)
                {

                }
            });

        }

    }
}
