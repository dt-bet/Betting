using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Betting.View
{

    //[ValueConversion(typeof(bool), typeof(string))]
    //public class CompleteConverter : IValueConverter
    //{
    //    // This converter changes the value of a Tasks Complete status from true/false to a string value of
    //    // "Complete"/"Active" for use in the row group header.
    //    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        bool complete = (bool)value;
    //        if (complete)
    //            return "Complete";
    //        else
    //            return "Active";
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        string strComplete = (string)value;
    //        if (strComplete == "Complete")
    //            return true;
    //        else
    //            return false;
    //    }
    //}


    //[ValueConversion(typeof(bool), typeof(string))]
    //public class GroupConverter : IValueConverter
    //{
    //    // This converter changes the value of a Tasks Complete status from true/false to a string value of
    //    // "Complete"/"Active" for use in the row group header.
    //    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        var objects = ((IEnumerable)((dynamic)value).Items)
    //            .Cast<object>();

    //        var property = objects.First().GetType().GetProperties().Single(a => a.Name.Equals(parameter));

    //        var xx = objects
    //             .Select(a => double.Parse(property.GetValue(a).ToString()))
    //             .Sum();
    //        return xx;
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        string strComplete = (string)value;
    //        if (strComplete == "Complete")
    //            return true;
    //        else
    //            return false;
    //    }
    //}
}
