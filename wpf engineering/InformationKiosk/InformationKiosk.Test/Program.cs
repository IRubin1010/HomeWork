using InformationKiosk.BL;
using InformationKiosk.DataProtocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationKiosk.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var admiService = new AdministratorService();
            admiService.AddAdministrator("Meir", "Shimon", "M@M", "1234").ConfigureAwait(false).GetAwaiter().GetResult();
        }
    }
}
