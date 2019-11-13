using InformationKiosk.BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace InformationKiosk.PL.Nevigation
{
    public class NevigationCommandParameters : DependencyObject
    {
        public static readonly DependencyProperty ParameterProperty = DependencyProperty.Register("Parameter", typeof(object), typeof(NevigationCommandParameters), new FrameworkPropertyMetadata(null));

        public object Parameter
        {
            get
            {
                return (object)GetValue(ParameterProperty);
            }
            set {
                SetValue(ParameterProperty, value); }
        }
        public string NevigationTarget { get; set; }

    }
}
