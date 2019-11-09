using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace InformationKiosk.PL.Nevigation
{
    public interface INevigator
    {
        void NevigateTo(UserControl control);
    }
}
