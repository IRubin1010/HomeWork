using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5778_03_4485_5295
{
    class PrinterEventArgs : EventArgs
    {
        public bool Critical { get; }
        public string Error { get; }
        public string PrinterName { get; }
        private DateTime time = DateTime.Now;
        public DateTime Time
        {
            get { return time; }
        }
        // constractor
        public PrinterEventArgs(bool criti, string err,string name)
        {
            Critical = criti;
            Error = err;
            PrinterName = name;
        }
    }
}
