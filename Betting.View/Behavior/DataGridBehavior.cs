using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Betting.View
{
    /// <summary>
    /// Using this behavior on a dataGRid will ensure to display only columns with "Browsable Attributes"
    /// Eric Ouellet
    /// </summary>
    public static class DataGridBehavior
    {
        public static readonly DependencyProperty UseBrowsableAttributeOnColumnProperty =
            DependencyProperty.RegisterAttached("UseBrowsableAttributeOnColumn",
            typeof(bool),
            typeof(DataGridBehavior),
            new UIPropertyMetadata(false, UseBrowsableAttributeOnColumnChanged));

        public static bool GetUseBrowsableAttributeOnColumn(DependencyObject obj)
        {
            return (bool)obj.GetValue(UseBrowsableAttributeOnColumnProperty);
        }

        public static void SetUseBrowsableAttributeOnColumn(DependencyObject obj, bool val)
        {
            obj.SetValue(UseBrowsableAttributeOnColumnProperty, val);
        }

        private static void UseBrowsableAttributeOnColumnChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (obj is DataGrid dataGrid)
            {
                if ((bool)e.NewValue)
                {
                    dataGrid.AutoGeneratingColumn += DataGridOnAutoGeneratingColumn;
                }
                else
                {
                    dataGrid.AutoGeneratingColumn -= DataGridOnAutoGeneratingColumn;
                }
            }
        }

        private static void DataGridOnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyDescriptor is PropertyDescriptor propDesc)
            {
                foreach (Attribute att in propDesc.Attributes)
                {
                    if (att is BrowsableAttribute browsableAttribute)
                    {
                        if (!browsableAttribute.Browsable)
                        {
                            e.Cancel = true;
                        }
                    }

                    // As proposed by "dba" stackoverflow user on webpage: 
                    // https://stackoverflow.com/questions/4000132/is-there-a-way-to-hide-a-specific-column-in-a-datagrid-when-autogeneratecolumns
                    // I added few next lines:
                    if (att is DisplayNameAttribute displayName)
                    {
                        e.Column.Header = displayName.DisplayName;
                    }
                }
            }
        }
    }
}

