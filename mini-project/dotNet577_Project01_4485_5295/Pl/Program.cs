using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BL;

namespace Pl
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IBL ibl = FactoryBL.GetBL();
                InitializeNanny init = new InitializeNanny();
                Nanny nanny = init.intialize();
                Console.WriteLine(nanny.FullName());
                ibl.AddNanny(nanny);
                List<Nanny> list = ibl.CloneNannyList();
                list[0].FirstName = "mosh";
                ibl.DeleteNanny(nanny);
                ibl.DeleteNanny(nanny);
                List<Nanny> listB = ibl.CloneNannyList();
                ibl.AddNanny(nanny);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
           

        }
    }

    public class InitializeNanny
    {
        public Nanny intialize() { return nanny; }
        public Nanny nanny = new Nanny
        {
            ID = 305625295,
            LastName = "shimon",
            FirstName = "meir",
            BirthDate = new DateTime(1991, 7, 16),
            NannyAge = 26,
            PhoneNumber = 0543453882,
            Address = "Beit Ha-Defus St 21, Jerusalem",
            Elevator = true,
            Floor = 0,
            Seniority = 5,
            Children = 0,
            MaxChildren = 18,
            MinAge = 0,
            MaxAge = 6,
            IsHourlyFee = true,
            HourlyFee = 42,
            MonthlyFee = 1000,
            IsWork = new bool[6] { true, true, true, true, true, true },
            WorkHours = new TimeSpan[2, 6]
            {
                { new TimeSpan(7,30,0), new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) },
                { new TimeSpan(16,0,0), new TimeSpan(16, 0, 0) , new TimeSpan(16, 0, 0) , new TimeSpan(16, 0, 0) , new TimeSpan(16, 0, 0) , new TimeSpan(16, 0, 0) }
            },
            IsValidVacationDays = true,
            Recommendations = "",
      };
    }
}

