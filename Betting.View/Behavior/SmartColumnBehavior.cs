using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Controls;

namespace Betfair.View.Behavior
{
    /// <summary>
    /// https://www.codeproject.com/articles/389764/a-smart-behavior-for-datagrid-autogeneratecolumn
    /// </summary>
    public class ColumnHeaderBehavior : Behavior<DataGrid>
    {
        protected override void OnAttached()
        {
            AssociatedObject.AutoGeneratingColumn +=
                new EventHandler<DataGridAutoGeneratingColumnEventArgs>(OnAutoGeneratingColumn);
        }

        protected override void OnDetaching()
        {
            AssociatedObject.AutoGeneratingColumn -=
                new EventHandler<DataGridAutoGeneratingColumnEventArgs>(OnAutoGeneratingColumn);
        }

        protected void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string displayName = GetPropertyDisplayName(e.PropertyDescriptor);
            if (!string.IsNullOrEmpty(displayName))
            {
                e.Column.Header = displayName;
            }
            else
            {
                e.Cancel = true;
            }
        }

        protected static string GetPropertyDisplayName(object descriptor)
        {
            if (descriptor is PropertyDescriptor pd)
            {
                if (pd.Attributes[typeof(DisplayNameAttribute)] is DisplayNameAttribute displayNameAttribute)
                    return displayNameAttribute.DisplayName;
            }
            else
            {
                PropertyInfo pi = descriptor as PropertyInfo;

                return pi?.GetCustomAttributes(typeof(DisplayNameAttribute), true)
                     .OfType<DisplayNameAttribute>()
                     .Where(a => a != DisplayNameAttribute.Default)
                     .SingleOrDefault()?
                     .DisplayName;

            }
            return null;
        }
    }
}
