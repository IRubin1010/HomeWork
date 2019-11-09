using InformationKiosk.PL.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace InformationKiosk.PL.Nevigation
{
    public enum NevigationTargets
    {
        Manage,
    }

    public class NevigatorCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public INevigator Nevigator { get; set; }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter is string)
            {
                if(Enum.TryParse(parameter as string, out NevigationTargets nevigationTarget))
                {
                    var uc = GetControl(nevigationTarget);
                    if (uc != null)
                    {
                        Nevigator?.NevigateTo(uc);
                    }
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public UserControl GetControl(NevigationTargets target)
        {
            UserControl userControl = null;

            switch (target)
            {
                case NevigationTargets.Manage:
                    userControl = new ManageControl();
                    break;
                default:
                    break;
            }
            return userControl;
        }

    }
}
