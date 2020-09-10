using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Windows;

namespace Betting.DemoWpfApp
{
    class MainViewModel
    {
        readonly IEnumerable<DataRow> points;
        IEnumerator<DataRow> pointsEnumerator;

        public MainViewModel()
        {
            var csv = File.ReadAllText("../../../Data/E0H.csv");
            DateTime dtn = DateTime.Now;
            points = Csv.CsvReader.ReadFromText(csv)
                .Select(line =>
                {
                    DateTime dt = dtn + TimeSpan.FromDays(int.Parse(line["index"]));
                    double prc = double.Parse(line["B365H"]);
                    double prd = double.Parse(line["B365D"]);
                    bool rslt = double.Parse(line["UPH"]) > 0;
                    return new DataRow { date = dt, price = prc, prediction = prd, result = rslt };
                });

            pointsEnumerator = points.GetEnumerator();

            Observable.Interval(TimeSpan.FromSeconds(1)).Subscribe(_ =>
            {
                if (pointsEnumerator.MoveNext())
                    Application.Current.Dispatcher.Invoke(() => Points.Add(pointsEnumerator.Current));
            });

        }


        public ICollection<DataRow> Points { get; } = new ObservableCollection<DataRow>();

    }
}