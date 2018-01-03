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
                Initialize init = new Initialize();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }

    public class Initialize
    {
        IBL ibl = FactoryBL.GetBL();
        public Initialize()
        {
            NannyInitialize();
            MotherInitialize();
            ChildInitialize();
            ContractInitialize();

            //ibl.AddNanny(test);
            //Console.WriteLine(ibl.FindNanny(meirShimon.ID));
            //ibl.DeleteNanny(meirShimon);
            //Console.WriteLine(ibl.FindNanny(meirShimon));
            //ibl.DeleteNanny(meirShimon);
            //Nanny upnanny = ibl.FindNanny(davidShimon.ID);
            //Console.WriteLine(upnanny);
            //upnanny.MaxChildren = 5;
            //upnanny.ID = 123456789;
            //ibl.UpdateNanny(upnanny);
            //Console.WriteLine(ibl.FindNanny(davidShimon.ID
            //Console.WriteLine(ibl.FindNanny(meirShimon.ID));
            //ibl.UpdateNannyChildren(meirShimon, 0);
            //Console.WriteLine(ibl.FindNanny(meirShimon.ID));

            //ibl.AddMother(MotherTest);
            //Console.WriteLine(ibl.FindMother(MotherTest));
            //ibl.DeleteMother(MotherTest);
            //Console.WriteLine(ibl.FindMother(MotherTest));
            //ibl.DeleteMother(MotherTest);
            //Mother upMother = ibl.FindMother(shimshonYeret.ID);
            //Console.WriteLine(ibl.FindMother(shimshonYeret.ID));
            //upMother.NeedNanny[2] = false;
            //upMother.NeedNannyHours[0, 2] = new TimeSpan(12, 0, 0);
            //ibl.DeleteMother(upMother);
            //ibl.UpdateMother(upMother);
            //Console.WriteLine(ibl.FindMother(shimshonYeret.ID));

            //ibl.AddChild(ChildTest);
            //Console.WriteLine(ibl.FindChild(ChildTest.ID));
            ////ibl.DeleteChild(ChildTest);
            ////Console.WriteLine(ibl.FindChild(ChildTest));
            //Child UpChild = ibl.FindChild(ChildTest.ID);
            //UpChild.AgeInMonth = 50;
            ////ibl.DeleteChild(UpChild);
            //ibl.UpdateChild(UpChild);
            //Console.WriteLine(ibl.FindChild(ChildTest.ID));
            //ibl.UpdateHaveNanny(UpChild, true);
            //Console.WriteLine(ibl.FindChild(ChildTest.ID));

            //ibl.AddContract(TestContract);
            //Console.WriteLine(TestContract);
            //Contract Upocontract = ibl.FindContract(10000005);
            //Upocontract.IsPaymentByHour = true;
            //Upocontract.HourlyFee = 40;
            //ibl.UpdateContract(Upocontract);
            //Console.WriteLine(ibl.FindContract( 10000005));
            //Console.WriteLine(ibl.FindNanny(305625295));
            //Console.WriteLine(ibl.FindMother(294335086));
            //ibl.DeleteContract(10000005);
            //Console.WriteLine(ibl.FindContract(TestContract)); 
            //foreach (Contract item in ibl.CloneContractList())
            //    Console.WriteLine(item);
            //List<Child> list = ibl.ChildrenWithNoNanny();
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine(shimshonYeret);
            //List<Nanny> list1 = ibl.PartialMatch(shimshonYeret);
            //Console.WriteLine(list1.Count);
            //foreach (var item in list1)
            //{
            //    Console.WriteLine(item);
            //    Console.WriteLine("===");
            //    Console.WriteLine(item.HoursValue);
            //    Console.WriteLine(item.DaysValue);
            //    Console.WriteLine(item.SeniorityValue);
            //    Console.WriteLine(item.ElevatorValue);
            //    Console.WriteLine(item.FloorValue);
            //}
            //Console.WriteLine("=================================================");
            //List<Contract> list = ibl.SpesificsContracts(contract => contract.IsPaymentByHour);
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}
            //int i = ibl.NumOfSpesificsContracts(contract => contract.IsPaymentByHour == true);
            //Console.WriteLine(i);

            var test = ibl.GruopNannyByChildAge(true, false);
            foreach (var item in test)
            {
                Console.WriteLine(item.Key);
                foreach (var g in item)
                {
                    Console.WriteLine(g);
                }
            }
        }
        void NannyInitialize()
        {
            ibl.AddNanny(meirShimon);
            ibl.AddNanny(morShimon);
            ibl.AddNanny(davidShimon);
            ibl.AddNanny(yosiShimon);
            ibl.AddNanny(aviShimon);
            ibl.AddNanny(yudiShimon);
            ibl.AddNanny(ahronShimon);
            ibl.AddNanny(ariShimon);
            ibl.AddNanny(chaimShimon);
        }
        void MotherInitialize()
        {
            ibl.AddMother(itzikYeret);
            ibl.AddMother(shimshonYeret);
            ibl.AddMother(mosheYeret);
            ibl.AddMother(natanYeret);
            ibl.AddMother(simchaYeret);
            ibl.AddMother(yakovYeret);
            ibl.AddMother(hilelYeret);
        }
        void ChildInitialize()
        {
            ibl.AddChild(yoni);
            ibl.AddChild(shimon);
            ibl.AddChild(roni);
            ibl.AddChild(aviad);
            ibl.AddChild(ronen);
            ibl.AddChild(eran);
            ibl.AddChild(moti);
        }
        void ContractInitialize()
        {
            ibl.AddContract(contract1);
            ibl.AddContract(contract2);
            ibl.AddContract(contract3);
            //ibl.AddContract(contract4);
            ibl.AddContract(contract5);
            ibl.AddContract(contract6);
            //ibl.AddContract(contract7);
        }
        public Nanny meirShimon = new Nanny
        {
            ID = 305625295,
            LastName = "shimon",
            FirstName = "meir",
            BirthDate = new DateTime(1991, 7, 16),
            NannyAge = 26,
            PhoneNumber = 0543453882,
            Address = "Ovadya Street 6, Bnei Brak",
            Elevator = true,
            Floor = 0,
            Seniority = 5,
            Children = 3,
            MaxChildren = 10,
            MinAge = 0,
            MaxAge = 6,
            IsHourlyFee = true,
            HourlyFee = 42,
            MonthlyFee = 1000,
            IsWork = new bool[6] { true, true, true, true, true, true },
            WorkHours = new TimeSpan[2, 6]
           {
                { new TimeSpan(7,30,0), new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) },
                { new TimeSpan(15,0,0), new TimeSpan(16, 0, 0) , new TimeSpan(16, 0, 0) , new TimeSpan(16, 0, 0) , new TimeSpan(16, 0, 0) , new TimeSpan(16, 0, 0) }
           },
            IsValidVacationDays = true,
            Recommendations = "",
        };
        public Nanny morShimon = new Nanny
        {
            ID = 294003857,
            LastName = "shimon",
            FirstName = "mor",
            BirthDate = new DateTime(1990, 11, 4),
            NannyAge = 27,
            PhoneNumber = 0543395033,
            Address = "Yerushalayim street 51, Bnei Brak",
            Elevator = true,
            Floor = 2,
            Seniority = 4,
            Children = 0,
            MaxChildren = 18,
            MinAge = 0,
            MaxAge = 6,
            IsHourlyFee = true,
            HourlyFee = 42,
            MonthlyFee = 1000,
            IsWork = new bool[6] { true, true, false, true, true, true },
            WorkHours = new TimeSpan[2, 6]
           {
                { new TimeSpan(7,30,0), new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) },
                { new TimeSpan(16,0,0), new TimeSpan(16, 0, 0) , new TimeSpan(16, 0, 0) , new TimeSpan(16, 0, 0) , new TimeSpan(16, 0, 0) , new TimeSpan(16, 0, 0) }
           },
            IsValidVacationDays = true,
            Recommendations = "",
        };
        public Nanny davidShimon = new Nanny
        {
            ID = 305625275,
            LastName = "shimon",
            FirstName = "david",
            BirthDate = new DateTime(1993, 8, 12),
            NannyAge = 24,
            PhoneNumber = 0543453834,
            Address = "hebron street 7, Bnei Brak",
            Elevator = true,
            Floor = 4,
            Seniority = 3,
            Children = 0,
            MaxChildren = 182,
            MinAge = 6,
            MaxAge = 12,
            IsHourlyFee = true,
            HourlyFee = 42,
            MonthlyFee = 1000,
            IsWork = new bool[6] { false, false, true, true, true, true },
            WorkHours = new TimeSpan[2, 6]
           {
                { new TimeSpan(7,0,0), new TimeSpan(7,0,0) , new TimeSpan(7,0,0) , new TimeSpan(7,0,0) , new TimeSpan(7,0,0) , new TimeSpan(7,0,0) },
                { new TimeSpan(16,0,0), new TimeSpan(16, 0, 0) , new TimeSpan(16, 0, 0) , new TimeSpan(16, 0, 0) , new TimeSpan(16, 0, 0) , new TimeSpan(16, 0, 0) }
           },
            IsValidVacationDays = true,
            Recommendations = "",
        };
        public Nanny yosiShimon = new Nanny
        {
            ID = 303368978,
            LastName = "shimon",
            FirstName = "yosi",
            BirthDate = new DateTime(1994, 12, 9),
            NannyAge = 23,
            PhoneNumber = 0543456372,
            Address = "be'eri street 20, Bnei Brak",
            Elevator = false,
            Floor = 2,
            Seniority = 2,
            Children = 0,
            MaxChildren = 10,
            MinAge = 0,
            MaxAge = 6,
            IsHourlyFee = false,
            HourlyFee = 42,
            MonthlyFee = 3000,
            IsWork = new bool[6] { true, true, true, true, true, true },
            WorkHours = new TimeSpan[2, 6]
           {
                { new TimeSpan(8,0,0), new TimeSpan(8,0,0) , new TimeSpan(8,0,0) , new TimeSpan(8,0,0) , new TimeSpan(8,0,0) , new TimeSpan(8,0,0) },
                { new TimeSpan(16,0,0), new TimeSpan(16, 0, 0) , new TimeSpan(16, 0, 0) , new TimeSpan(16, 0, 0) , new TimeSpan(16, 0, 0) , new TimeSpan(16, 0, 0) }
           },
            IsValidVacationDays = false,
            Recommendations = "",
        };
        public Nanny aviShimon = new Nanny
        {
            ID = 305649295,
            LastName = "shimon",
            FirstName = "avi",
            BirthDate = new DateTime(1990, 2, 23),
            NannyAge = 27,
            PhoneNumber = 0543451042,
            Address = "chason ish street 43, Bnei Brak",
            Elevator = true,
            Floor = 3,
            Seniority = 8,
            Children = 0,
            MaxChildren = 14,
            MinAge = 12,
            MaxAge = 18,
            IsHourlyFee = false,
            HourlyFee = 42,
            MonthlyFee = 3750,
            IsWork = new bool[6] { true, true, true, false, true, true },
            WorkHours = new TimeSpan[2, 6]
           {
                { new TimeSpan(7,30,0), new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) },
                { new TimeSpan(15,0,0), new TimeSpan(15, 0, 0) , new TimeSpan(15, 0, 0) , new TimeSpan(15, 0, 0) , new TimeSpan(15, 0, 0) , new TimeSpan(15, 0, 0) }
           },
            IsValidVacationDays = true,
            Recommendations = "",
        };
        public Nanny yudiShimon = new Nanny
        {
            ID = 305625695,
            LastName = "shimon",
            FirstName = "yudi",
            BirthDate = new DateTime(1987, 5, 19),
            NannyAge = 30,
            PhoneNumber = 0543483782,
            Address = "rabi akiva street 69, Bnei Brak",
            Elevator = false,
            Floor = 1,
            Seniority = 1,
            Children = 0,
            MaxChildren = 14,
            MinAge = 0,
            MaxAge = 6,
            IsHourlyFee = true,
            HourlyFee = 40,
            MonthlyFee = 1000,
            IsWork = new bool[6] { true, true, true, true, true, true },
            WorkHours = new TimeSpan[2, 6]
           {
                { new TimeSpan(7,30,0), new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) },
                { new TimeSpan(17,0,0), new TimeSpan(17, 0, 0) , new TimeSpan(17, 0, 0) , new TimeSpan(17, 0, 0) , new TimeSpan(17, 0, 0) , new TimeSpan(17, 0, 0) }
           },
            IsValidVacationDays = false,
            Recommendations = "",
        };
        public Nanny ahronShimon = new Nanny
        {
            ID = 305216295,
            LastName = "shimon",
            FirstName = "ahron",
            BirthDate = new DateTime(2000, 4, 2),
            NannyAge = 18,
            PhoneNumber = 0543429642,
            Address = "Ha-Rav Desler Street 69, Bnei Brak",
            Elevator = true,
            Floor = 4,
            Seniority = 0,
            Children = 0,
            MaxChildren = 6,
            MinAge = 12,
            MaxAge = 18,
            IsHourlyFee = false,
            HourlyFee = 42,
            MonthlyFee = 2500,
            IsWork = new bool[6] { true, true, true, true, true, true },
            WorkHours = new TimeSpan[2, 6]
           {
                { new TimeSpan(8,0,0), new TimeSpan(8,0,0) , new TimeSpan(8,0,0) , new TimeSpan(8,0,0) , new TimeSpan(8,0,0) , new TimeSpan(8,0,0) },
                { new TimeSpan(13,0,0), new TimeSpan(13, 0, 0) , new TimeSpan(13, 0, 0) , new TimeSpan(13, 0, 0) , new TimeSpan(13, 0, 0) , new TimeSpan(13, 0, 0) }
           },
            IsValidVacationDays = true,
            Recommendations = "",
        };
        public Nanny ariShimon = new Nanny
        {
            ID = 355625295,
            LastName = "shimon",
            FirstName = "ari",
            BirthDate = new DateTime(1991, 3, 22),
            NannyAge = 26,
            PhoneNumber = 0543448382,
            Address = "Beit Ha-Defus St 21, Jerusalem",
            Elevator = false,
            Floor = 3,
            Seniority = 4,
            Children = 0,
            MaxChildren = 11,
            MinAge = 18,
            MaxAge = 24,
            IsHourlyFee = true,
            HourlyFee = 35,
            MonthlyFee = 1000,
            IsWork = new bool[6] { true, true, true, true, true, false },
            WorkHours = new TimeSpan[2, 6]
           {
                { new TimeSpan(7,30,0), new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) },
                { new TimeSpan(15,30,0), new TimeSpan(15, 30, 0) , new TimeSpan(15, 30, 0) , new TimeSpan(15, 30, 0) , new TimeSpan(15, 30, 0) , new TimeSpan(15, 30, 0) }
           },
            IsValidVacationDays = false,
            Recommendations = "",
        };
        public Nanny chaimShimon = new Nanny
        {
            ID = 303964295,
            LastName = "shimon",
            FirstName = "chaim",
            BirthDate = new DateTime(1995, 3, 7),
            NannyAge = 22,
            PhoneNumber = 0543473882,
            Address = "Rabbi Yehuda HaNassi Street 27, Bnei Brak",
            Elevator = false,
            Floor = 3,
            Seniority = 4,
            Children = 0,
            MaxChildren = 18,
            MinAge = 0,
            MaxAge = 6,
            IsHourlyFee = false,
            HourlyFee = 42,
            MonthlyFee = 4000,
            IsWork = new bool[6] { true, true, true, true, true, true },
            WorkHours = new TimeSpan[2, 6]
           {
                { new TimeSpan(7,30,0), new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) },
                { new TimeSpan(16,30,0), new TimeSpan(16, 30, 0) , new TimeSpan(16, 30, 0) , new TimeSpan(16, 30, 0) , new TimeSpan(16, 30, 0) , new TimeSpan(16, 30, 0) }
           },
            IsValidVacationDays = false,
            Recommendations = "",
        };
        public Nanny test = new Nanny
        {
            ID = 305695295,
            LastName = "shimon",
            FirstName = "chai",
            BirthDate = new DateTime(1995, 3, 7),
            NannyAge = 22,
            PhoneNumber = 0543473834,
            Address = "Nissenboim Street 11, Bnei Brak",
            Elevator = false,
            Floor = 3,
            Seniority = 4,
            Children = 0,
            MaxChildren = 18,
            MinAge = 0,
            MaxAge = 6,
            IsHourlyFee = false,
            HourlyFee = 42,
            MonthlyFee = 4000,
            IsWork = new bool[6] { true, true, true, true, true, true },
            WorkHours = new TimeSpan[2, 6]
           {
                { new TimeSpan(7,30,0), new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) },
                { new TimeSpan(16,30,0), new TimeSpan(16, 30, 0) , new TimeSpan(16, 30, 0) , new TimeSpan(16, 30, 0) , new TimeSpan(16, 30, 0) , new TimeSpan(16, 30, 0) }
           },
            IsValidVacationDays = false,
            Recommendations = "",
        };

        public Mother itzikYeret = new Mother()
        {
            ID = 294839286,
            LastName = "yeret",
            FirstName = "itzik",
            PhoneNumber = 0504182088,
            Address = "ha-rav mohilever Street 8, Bnei Brak",
            SearchAreaForNanny = "Beit Ha-Defus St 21, Jerusalem",
            WantElevator = true,
            MinSeniority = 3,
            MaxFloor = 4,
            NeedNanny = new bool[6] { true, true, true, true, true, true },
            NeedNannyHours = new TimeSpan[2, 6]
            {
                    { new TimeSpan(7,30,0), new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) },
                    { new TimeSpan(16,30,0), new TimeSpan(16, 30, 0) , new TimeSpan(16, 30, 0) , new TimeSpan(16, 30, 0) , new TimeSpan(16, 30, 0) , new TimeSpan(16, 30, 0) }
            },
            Remarks = ""
        };
        public Mother shimshonYeret = new Mother()
        {
            ID = 294894786,
            LastName = "yeret",
            FirstName = "shimshon",
            PhoneNumber = 0504397588,
            Address = "Rabbi Yehuda HaNassi Street 49, Bnei Brak",
            SearchAreaForNanny = "",
            WantElevator = true,
            MinSeniority = 4,
            MaxFloor = 2,
            NeedNanny = new bool[6] { false, true, true, true, true, true },
            NeedNannyHours = new TimeSpan[2, 6]
            {
                { new TimeSpan(7,30,0), new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) },
                { new TimeSpan(16,0,0), new TimeSpan(16, 0, 0) , new TimeSpan(16, 0, 0) , new TimeSpan(16, 0, 0) , new TimeSpan(16, 0, 0) , new TimeSpan(16, 0, 0) }
            },
            Remarks = ""
        };
        public Mother mosheYeret = new Mother()
        {
            ID = 294892086,
            LastName = "yeret",
            FirstName = "moshe",
            PhoneNumber = 0504003828,
            Address = "ovadya Street 8, Bnei Brak",
            SearchAreaForNanny = "Hannah Szenes Street 8, Bnei Brak",
            WantElevator = false,
            MinSeniority = 5,
            MaxFloor = 1,
            NeedNanny = new bool[6] { true, true, true, false, true, true },
            NeedNannyHours = new TimeSpan[2, 6]
           {
                { new TimeSpan(7,0,0), new TimeSpan(7, 0,0) , new TimeSpan(7, 0,0) , new TimeSpan(7, 0,0) , new TimeSpan(7, 0,0) , new TimeSpan(7, 0,0) },
                { new TimeSpan(16,30,0), new TimeSpan(16, 30, 0) , new TimeSpan(16, 30, 0) , new TimeSpan(16, 30, 0) , new TimeSpan(16, 30, 0) , new TimeSpan(16, 30, 0) }
           },
            Remarks = ""
        };
        public Mother natanYeret = new Mother()
        {
            ID = 294909286,
            LastName = "yeret",
            FirstName = "natan",
            PhoneNumber = 0504129888,
            Address = "Hannah Szenes Street 8, Bnei Brak",
            SearchAreaForNanny = "Chason Ish Street 20, Bnei Brak",
            WantElevator = false,
            MinSeniority = 2,
            MaxFloor = 2,
            NeedNanny = new bool[6] { true, true, true, true, true, true },
            NeedNannyHours = new TimeSpan[2, 6]
           {
                { new TimeSpan(8,0,0), new TimeSpan(8,0,0) , new TimeSpan(8,0,0) , new TimeSpan(8,0,0) , new TimeSpan(8,0,0) , new TimeSpan(8,0,0) },
                { new TimeSpan(16,0,0), new TimeSpan(16,0, 0) , new TimeSpan(16,0, 0) , new TimeSpan(16,0, 0) , new TimeSpan(16,0, 0) , new TimeSpan(16, 30, 0) }
           },
            Remarks = ""
        };
        public Mother simchaYeret = new Mother()
        {
            ID = 294849001,
            LastName = "yeret",
            FirstName = "simcha",
            PhoneNumber = 0504184920,
            Address = "Yerushalayim Street 72, Bnei Brak",
            SearchAreaForNanny = "",
            WantElevator = true,
            MinSeniority = 3,
            MaxFloor = 3,
            NeedNanny = new bool[6] { true, true, true, true, false, false },
            NeedNannyHours = new TimeSpan[2, 6]
           {
                { new TimeSpan(7,0,0), new TimeSpan(7,0,0) , new TimeSpan(7,0,0) , new TimeSpan(7,0,0) , new TimeSpan(7,0,0) , new TimeSpan(7,0,0) },
                { new TimeSpan(14,0,0), new TimeSpan(14,0, 0) , new TimeSpan(14,0, 0) , new TimeSpan(14,0, 0) , new TimeSpan(14,0, 0) , new TimeSpan(14,0, 0) }
           },
            Remarks = ""
        };
        public Mother yakovYeret = new Mother()
        {
            ID = 294800286,
            LastName = "yeret",
            FirstName = "yakov",
            PhoneNumber = 0504183827,
            Address = "gottlieb Street 4, Bnei Brak",
            SearchAreaForNanny = "",
            WantElevator = false,
            MinSeniority = 5,
            MaxFloor = 4,
            NeedNanny = new bool[6] { true, false, true, true, true, true },
            NeedNannyHours = new TimeSpan[2, 6]
           {
                { new TimeSpan(7,30,0), new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) },
                { new TimeSpan(16,30,0), new TimeSpan(16, 30, 0) , new TimeSpan(16, 30, 0) , new TimeSpan(16, 30, 0) , new TimeSpan(16, 30, 0) , new TimeSpan(16, 30, 0) }
           },
            Remarks = ""
        };
        public Mother hilelYeret = new Mother()
        {
            ID = 294335086,
            LastName = "yeret",
            FirstName = "hilel",
            PhoneNumber = 0504395188,
            Address = "sokolow Street 34, Bnei Brak",
            SearchAreaForNanny = "",
            WantElevator = false,
            MinSeniority = 3,
            MaxFloor = 5,
            NeedNanny = new bool[6] { true, true, true, true, true, true },
            NeedNannyHours = new TimeSpan[2, 6]
           {
                { new TimeSpan(7,30,0), new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) },
                { new TimeSpan(17,30,0), new TimeSpan(17, 30, 0) , new TimeSpan(17, 30, 0) , new TimeSpan(17, 30, 0) , new TimeSpan(17, 30, 0) , new TimeSpan(17, 30, 0) }
           },
            Remarks = ""
        };
        public Mother MotherTest = new Mother()
        {
            ID = 294337686,
            LastName = "yeret",
            FirstName = "hilel",
            PhoneNumber = 0504395188,
            Address = "hafes haim Street 14, Bnei Brak",
            SearchAreaForNanny = "",
            WantElevator = false,
            MinSeniority = 3,
            MaxFloor = 5,
            NeedNanny = new bool[6] { true, true, true, true, true, true },
            NeedNannyHours = new TimeSpan[2, 6]
   {
                { new TimeSpan(7,30,0), new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) },
                { new TimeSpan(17,30,0), new TimeSpan(17, 30, 0) , new TimeSpan(17, 30, 0) , new TimeSpan(17, 30, 0) , new TimeSpan(17, 30, 0) , new TimeSpan(17, 30, 0) }
   },
            Remarks = ""
        };



        public Child yoni = new Child()
        {
            ID = 397458103,
            MotherID = 294839286,
            FirstName = "yoni",
            BirthDate = new DateTime(2016, 8, 2),
            AgeInMonth = 16,
            IsSpecialNeeds = false,
            SpecialNeeds = "",
            HaveNanny = false
        };
        public Child shimon = new Child()
        {
            ID = 397004103,
            MotherID = 294894786,
            FirstName = "shimon",
            BirthDate = new DateTime(2016, 12, 2),
            AgeInMonth = 12,
            IsSpecialNeeds = false,
            SpecialNeeds = "",
            HaveNanny = false
        };
        public Child roni = new Child()
        {
            ID = 392940383,
            MotherID = 294892086,
            FirstName = "roni",
            BirthDate = new DateTime(2017, 8, 2),
            AgeInMonth = 4,
            IsSpecialNeeds = true,
            SpecialNeeds = "",
            HaveNanny = false
        };
        public Child aviad = new Child()
        {
            ID = 397449028,
            MotherID = 294909286,
            FirstName = "aviad",
            BirthDate = new DateTime(2017, 3, 15),
            AgeInMonth = 9,
            IsSpecialNeeds = true,
            SpecialNeeds = "",
            HaveNanny = false
        };
        public Child ronen = new Child()
        {
            ID = 493029984,
            MotherID = 294849001,
            FirstName = "ronen",
            BirthDate = new DateTime(2016, 9, 7),
            AgeInMonth = 15,
            IsSpecialNeeds = false,
            SpecialNeeds = "",
            HaveNanny = false
        };
        public Child eran = new Child()
        {
            ID = 294083104,
            MotherID = 294800286,
            FirstName = "eran",
            BirthDate = new DateTime(2016, 12, 28),
            AgeInMonth = 12,
            IsSpecialNeeds = true,
            SpecialNeeds = "",
            HaveNanny = false
        };
        public Child moti = new Child()
        {
            ID = 594028499,
            MotherID = 294335086,
            FirstName = "moti",
            BirthDate = new DateTime(2017, 2, 2),
            AgeInMonth = 10,
            IsSpecialNeeds = false,
            SpecialNeeds = "",
            HaveNanny = false
        };
        public Child ChildTest = new Child()
        {
            ID = 594028789,
            MotherID = 294335086,
            FirstName = "moti",
            BirthDate = new DateTime(2017, 2, 2),
            AgeInMonth = 10,
            IsSpecialNeeds = false,
            SpecialNeeds = "",
            HaveNanny = false
        };

        public Contract contract1 = new Contract()
        {
            NannyID = 305625295,
            ChildID = 397458103,
            MotherID = 294839286,
            IsMeet = true,
            IsContractSigned = false,
            HourlyFee = 42,
            MonthlyFee = 1000,
            IsPaymentByHour = true,
            BeginTransection = new DateTime(2018, 1, 1),
            EndTransection = new DateTime(2018, 7, 1)
        };
        public Contract contract2 = new Contract()
        {
            NannyID = 294003857,
            ChildID = 397004103,
            MotherID = 294894786,
            IsMeet = false,
            IsContractSigned = false,
            HourlyFee = 42,
            MonthlyFee = 1000,
            IsPaymentByHour = true,
            BeginTransection = new DateTime(2017, 12, 1),
            EndTransection = new DateTime(2018, 12, 1)
        };
        public Contract contract3 = new Contract()
        {
            NannyID = 305625295,
            ChildID = 392940383,
            MotherID = 294892086,
            IsMeet = true,
            IsContractSigned = false,
            HourlyFee = 42,
            MonthlyFee = 1000,
            IsPaymentByHour = true,
            BeginTransection = new DateTime(2018, 1, 1),
            EndTransection = new DateTime(2019, 1, 1)
        };
        public Contract contract4 = new Contract()
        {
            NannyID = 305625297,
            ChildID = 397449028,
            MotherID = 294909286,
            IsMeet = true,
            IsContractSigned = false,
            HourlyFee = 42,
            MonthlyFee = 3000,
            IsPaymentByHour = false,
            BeginTransection = new DateTime(2018, 1, 1),
            EndTransection = new DateTime(2018, 7, 1)
        };
        public Contract contract5 = new Contract()
        {
            NannyID = 305649295,
            ChildID = 493029984,
            MotherID = 294849001,
            IsMeet = true,
            IsContractSigned = false,
            HourlyFee = 42,
            MonthlyFee = 3750,
            IsPaymentByHour = false,
            BeginTransection = new DateTime(2018, 2, 1),
            EndTransection = new DateTime(2018, 4, 1)
        };
        public Contract contract6 = new Contract()
        {
            NannyID = 305625295,
            ChildID = 294083104,
            MotherID = 294800286,
            IsMeet = false,
            IsContractSigned = false,
            HourlyFee = 40,
            MonthlyFee = 1000,
            IsPaymentByHour = true,
            BeginTransection = new DateTime(2018, 1, 1),
            EndTransection = new DateTime(2019, 1, 1)
        };
        public Contract contract7 = new Contract()
        {
            NannyID = 305916295,
            ChildID = 594028499,
            MotherID = 294335086,
            IsMeet = true,
            IsContractSigned = false,
            HourlyFee = 42,
            MonthlyFee = 2500,
            IsPaymentByHour = false,
            BeginTransection = new DateTime(2018, 1, 1),
            EndTransection = new DateTime(2018, 8, 1)
        };
        public Contract TestContract = new Contract()
        {
            NannyID = 305625295,
            ChildID = 594028499,
            MotherID = 294839286,
            IsMeet = true,
            IsContractSigned = false,
            HourlyFee = 42,
            MonthlyFee = 2500,
            IsPaymentByHour = false,
            BeginTransection = new DateTime(2018, 1, 1),
            EndTransection = new DateTime(2018, 8, 1)
        };


    }
}

