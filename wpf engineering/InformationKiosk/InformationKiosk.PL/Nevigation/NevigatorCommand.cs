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
        AdminStoreView,
        UserView
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
            if(parameter is NevigationCommandParameters)
            {
                var param = parameter as NevigationCommandParameters;
                if(Enum.TryParse(param.NevigationTarget, out NevigationTargets nevigationTarget))
                {
                    var uc = GetControl(nevigationTarget, param.Parameter);
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

        public UserControl GetControl(NevigationTargets target, object parameter)
        {
            UserControl userControl = null;

            switch (target)
            {
                case NevigationTargets.Manage:
                    userControl = new ManageControl();
                    break;
                case NevigationTargets.AdminStoreView:
                    userControl = new AdminStoreViewControl(parameter);
                    break;
                case NevigationTargets.UserView:
                    userControl = new UserViewControl();
                    break;
                default:
                    break;
            }
            return userControl;
        }

    }
}
