using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MyApp.Utilities
{
    class TxtBox : TextBox
    {
        static TxtBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TxtBox), new FrameworkPropertyMetadata(typeof(TxtBox)));

        }
    }
}
