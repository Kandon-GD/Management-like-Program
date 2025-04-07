using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MyApp.Utilities
{
    class Bttn : RadioButton
    {
        static Bttn()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Bttn), new FrameworkPropertyMetadata(typeof(Bttn)));
        }
    }
}
