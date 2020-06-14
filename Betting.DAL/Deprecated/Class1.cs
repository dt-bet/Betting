
using Deedle;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Betting.DAL
{
    public static class DataHelper
    {


//        public static Series<DateTime, double> GetData(string fileName, string column = "open")
//        {

//            var frame = Frame.ReadCsv(Path.Combine(PathHelper.GetProjectPath(), "Resources", fileName));
//            string key = frame.ColumnKeys.SingleOrDefault(_ => String.Equals(_, "date", StringComparison.CurrentCultureIgnoreCase));
//            if (key == null)
//                throw new Exception("no date column in data");
//            var frameDate = frame.IndexRows<DateTime>(key).SortRowsByKey();
//            return frameDate.GetColumn<double>(column);

//        }





//        public static IEnumerable<KeyValuePair<string, Series<DateTime, double>>> GetAllDataInResources(string column = "open")
//        {
//            foreach (var x in Directory.EnumerateFiles(Path.Combine(PathHelper.GetProjectPath(), "Resources")))
//            {
//                yield return new KeyValuePair<string, Series<DateTime, double>>(Path.GetFileName(x), GetData(x, column));
//            }


//        }
//        public static IEnumerable<KeyValuePair<string, Series<DateTime, double>>> GetAllDataInResources2(string column = "Open")
//        {
//            string ex = @"\stocknet-dataset-master\price\raw";
//            var solutionPath = PathHelper.GetSolutionPath();

//            foreach (var x in Directory.EnumerateFiles(solutionPath + ex))
//            {
//                yield return new KeyValuePair<string, Series<DateTime, double>>(Path.GetFileNameWithoutExtension(x), GetData(x, column));
//            }
//        }


//        public static IEnumerable<Model.Sector> GetAllDataInResources3()
//        {
//            string ex = @"\stocknet-dataset-master\StockTable.csv";

//            var solution = PathHelper.GetSolutionPath();

//            var dtable = Frame.ReadCsv(solution + ex).ToDataTable(new[] { "" });

//            return from myRow in dtable.AsEnumerable()
//                   group myRow by myRow.Field<string>("Sector") into g
//                   select new Model.Sector
//                   {
//                       Key = g.Key,
//                       Stocks = g.Select(__ =>
//new Model.Stock
//{
//    Key = __.Field<string>("Symbol").Remove(0, 1),
//    Name = __.Field<string>("Company")
//}).ToList()
//                   };





//        }





    }

}