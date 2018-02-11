using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PLWPF
{

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App() : base()
        {
            this.Dispatcher.UnhandledException += OnDispatcherUnhandledException;
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //set the globbal culture to hebrew to avoid erros
            CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("he-IL");
            CultureInfo.CurrentUICulture = CultureInfo.CreateSpecificCulture("he-IL");
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture("he-IL");
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.CreateSpecificCulture("he-IL");

        }

        /// <summary>
        /// cath all exception
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnDispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            string errorMessage = string.Format("An unhandled exception occurred: {0}", e.Exception.Message);
            MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            e.Handled = true;
        }
    }
}
