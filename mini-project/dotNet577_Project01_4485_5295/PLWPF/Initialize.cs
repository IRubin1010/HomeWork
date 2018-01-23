using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BL;

namespace PLWPF
{
    public class Initialize
    {

        IBL ibl;
        public Initialize(IBL Bl)
        {
            ibl = Bl;
            NannyInitialize();
            MotherInitialize();
            ChildInitialize();
            ContractInitialize();
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
            ibl.AddMother(MotherTest);

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
            ibl.AddChild(ChildTest);
            ibl.AddChild(a);
            ibl.AddChild(b);
            ibl.AddChild(c);
            ibl.AddChild(d);
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
            ibl.AddContract(TestContract);
            //ibl.AddContract(aa);
            ibl.AddContract(bb);
            //ibl.AddContract(cc);

        }
        public Nanny meirShimon = new Nanny
        {
            ID = 305625295,
            LastName = "shimon",
            FirstName = "meir",
            BirthDate = new DateTime(1991, 7, 16),
            PhoneNumber = 0543453882,
            Address = "Ovadya St 6, Bnei Brak",
            Elevator = true,
            Floor = 0,
            Seniority = 5,
            Children = 0,
            MaxChildren = 10,
            MinAge = 0,
            MaxAge = 6,
            IsHourlyFee = true,
            HourlyFee = 42,
            MonthlyFee = 1000,
            IsWork = new bool[6] { true, true, true, true, true, true },
            WorkHours = new TimeSpan[2][]
            {
                new TimeSpan[6] { new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(9, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0) },
                new TimeSpan[6] { new TimeSpan(13, 30, 0), new TimeSpan(14, 30, 0), new TimeSpan(15, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0) }
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
            PhoneNumber = 0543395033,
            Address = "Yerushalayim St 51, Bnei Brak",
            Elevator = true,
            Floor = 2,
            Seniority = 4,
            Children = 0,
            MaxChildren = 18,
            MinAge = 6,
            MaxAge = 12,
            IsHourlyFee = true,
            HourlyFee = 42,
            MonthlyFee = 1000,
            IsWork = new bool[6] { true, true, false, true, true, true },
            WorkHours = new TimeSpan[2][]
            {
                new TimeSpan[6] { new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0) },
                new TimeSpan[6] { new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0) }
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
            PhoneNumber = 0543453834,
            Address = "Sokolov st 44, Bnei Brak",
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
            WorkHours = new TimeSpan[2][]
            {
                new TimeSpan[6] { new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0) },
                new TimeSpan[6] { new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0) }
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
            PhoneNumber = 0543456372,
            Address = "be'eri St 20, Bnei Brak",
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
            WorkHours = new TimeSpan[2][]
            {
                new TimeSpan[6] { new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0) },
                new TimeSpan[6] { new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0) }
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
            PhoneNumber = 0543451042,
            Address = "chason ish St 43, Bnei Brak",
            Elevator = true,
            Floor = 1,
            Seniority = 8,
            Children = 0,
            MaxChildren = 14,
            MinAge = 12,
            MaxAge = 18,
            IsHourlyFee = false,
            HourlyFee = 42,
            MonthlyFee = 3750,
            IsWork = new bool[6] { true, true, true, true, true, true },
            WorkHours = new TimeSpan[2][]
            {
                new TimeSpan[6] { new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0) },
                new TimeSpan[6] { new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0) }
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
            PhoneNumber = 0543483782,
            Address = "rabi akiva St 69, Bnei Brak",
            Elevator = true,
            Floor = 1,
            Seniority = 6,
            Children = 0,
            MaxChildren = 14,
            MinAge = 0,
            MaxAge = 6,
            IsHourlyFee = true,
            HourlyFee = 40,
            MonthlyFee = 1000,
            IsWork = new bool[6] { true, true, true, true, true, true },
            WorkHours = new TimeSpan[2][]
            {
                new TimeSpan[6] { new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0) },
                new TimeSpan[6] { new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0) }
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
            PhoneNumber = 0543429642,
            Address = "Ha-Rav Desler St 69, Bnei Brak",
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
            WorkHours = new TimeSpan[2][]
            {
                new TimeSpan[6] { new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0) },
                new TimeSpan[6] { new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0) }
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
            WorkHours = new TimeSpan[2][]
            {
                new TimeSpan[6] { new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0) },
                new TimeSpan[6] { new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0) }
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
            PhoneNumber = 0543473882,
            Address = "Rabbi Yehuda HaNassi St 27, Bnei Brak",
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
            WorkHours = new TimeSpan[2][]
            {
                new TimeSpan[6] { new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0) },
                new TimeSpan[6] { new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0) }
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
            PhoneNumber = 0543473834,
            Address = "Nissenboim St 11, Bnei Brak",
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
            WorkHours = new TimeSpan[2][]
            {
                new TimeSpan[6] { new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0) },
                new TimeSpan[6] { new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0) }
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
            Address = "ha-rav mohilever St 8, Bnei Brak",
            SearchAreaForNanny = "Beit Ha-Defus St 21, Jerusalem",
            WantElevator = true,
            MinSeniority = 1,
            MaxFloor = 4,
            NeedNanny = new bool[6] { true, true, true, true, true, true },
            NeedNannyHours = new TimeSpan[2][]
            {
                    new TimeSpan[6] { new TimeSpan(7,30,0), new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) },
                    new TimeSpan[6] { new TimeSpan(16,30,0), new TimeSpan(16, 30, 0) , new TimeSpan(16, 30, 0) , new TimeSpan(16, 30, 0) , new TimeSpan(16, 30, 0) , new TimeSpan(16, 30, 0) }
            },
            Remarks = ""
        };
        public Mother shimshonYeret = new Mother()
        {
            ID = 294894786,
            LastName = "yeret",
            FirstName = "shimshon",
            PhoneNumber = 0504397588,
            Address = "Rabbi Yehuda HaNassi St 49, Bnei Brak",
            SearchAreaForNanny = "",
            WantElevator = true,
            MinSeniority = 4,
            MaxFloor = 2,
            NeedNanny = new bool[6] { false, true, true, true, true, true },
            NeedNannyHours = new TimeSpan[2][]
            {
                new TimeSpan[6] { new TimeSpan(7,30,0), new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) },
                new TimeSpan[6] { new TimeSpan(16,0,0), new TimeSpan(16, 0, 0) , new TimeSpan(16, 0, 0) , new TimeSpan(16, 0, 0) , new TimeSpan(16, 0, 0) , new TimeSpan(16, 0, 0) }
            },
            Remarks = ""
        };
        public Mother mosheYeret = new Mother()
        {
            ID = 294892086,
            LastName = "yeret",
            FirstName = "moshe",
            PhoneNumber = 0504003828,
            Address = "ovadya St 8, Bnei Brak",
            SearchAreaForNanny = "Hannah Szenes St 8, Bnei Brak",
            WantElevator = false,
            MinSeniority = 5,
            MaxFloor = 1,
            NeedNanny = new bool[6] { true, true, true, false, true, true },
            NeedNannyHours = new TimeSpan[2][]
           {
                new TimeSpan[6] { new TimeSpan(7,0,0), new TimeSpan(7, 0,0) , new TimeSpan(7, 0,0) , new TimeSpan(7, 0,0) , new TimeSpan(7, 0,0) , new TimeSpan(7, 0,0) },
                new TimeSpan[6] { new TimeSpan(16,30,0), new TimeSpan(16, 30, 0) , new TimeSpan(16, 30, 0) , new TimeSpan(16, 30, 0) , new TimeSpan(16, 30, 0) , new TimeSpan(16, 30, 0) }
           },
            Remarks = ""
        };
        public Mother natanYeret = new Mother()
        {
            ID = 294909286,
            LastName = "yeret",
            FirstName = "natan",
            PhoneNumber = 0504129888,
            Address = "Hannah Szenes St 8, Bnei Brak",
            SearchAreaForNanny = "Chason Ish St 20, Bnei Brak",
            WantElevator = false,
            MinSeniority = 2,
            MaxFloor = 2,
            NeedNanny = new bool[6] { true, true, true, true, true, true },
            NeedNannyHours = new TimeSpan[2][]
           {
                new TimeSpan[6] { new TimeSpan(8,0,0), new TimeSpan(8,0,0) , new TimeSpan(8,0,0) , new TimeSpan(8,0,0) , new TimeSpan(8,0,0) , new TimeSpan(8,0,0) },
                new TimeSpan[6] { new TimeSpan(16,0,0), new TimeSpan(16,0, 0) , new TimeSpan(16,0, 0) , new TimeSpan(16,0, 0) , new TimeSpan(16,0, 0) , new TimeSpan(16, 30, 0) }
           },
            Remarks = ""
        };
        public Mother simchaYeret = new Mother()
        {
            ID = 294849001,
            LastName = "yeret",
            FirstName = "simcha",
            PhoneNumber = 0504184920,
            Address = "Yerushalayim St 72, Bnei Brak",
            SearchAreaForNanny = "",
            WantElevator = true,
            MinSeniority = 3,
            MaxFloor = 3,
            NeedNanny = new bool[6] { true, true, true, true, false, false },
            NeedNannyHours = new TimeSpan[2][]
           {
                new TimeSpan[6] { new TimeSpan(7,0,0), new TimeSpan(7,0,0) , new TimeSpan(7,0,0) , new TimeSpan(7,0,0) , new TimeSpan(7,0,0) , new TimeSpan(7,0,0) },
                new TimeSpan[6] { new TimeSpan(14,0,0), new TimeSpan(14,0, 0) , new TimeSpan(14,0, 0) , new TimeSpan(14,0, 0) , new TimeSpan(14,0, 0) , new TimeSpan(14,0, 0) }
           },
            Remarks = ""
        };
        public Mother yakovYeret = new Mother()
        {
            ID = 294800286,
            LastName = "yeret",
            FirstName = "yakov",
            PhoneNumber = 0504183827,
            Address = "gottlieb St 4, Bnei Brak",
            SearchAreaForNanny = "",
            WantElevator = false,
            MinSeniority = 5,
            MaxFloor = 4,
            NeedNanny = new bool[6] { true, false, true, true, true, true },
            NeedNannyHours = new TimeSpan[2][]
           {
                new TimeSpan[6] { new TimeSpan(7,30,0), new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) },
                new TimeSpan[6] { new TimeSpan(16,30,0), new TimeSpan(16, 30, 0) , new TimeSpan(16, 30, 0) , new TimeSpan(16, 30, 0) , new TimeSpan(16, 30, 0) , new TimeSpan(16, 30, 0) }
           },
            Remarks = ""
        };
        public Mother hilelYeret = new Mother()
        {
            ID = 294335086,
            LastName = "yeret",
            FirstName = "hilel",
            PhoneNumber = 0504395188,
            Address = "sokolow St 34, Bnei Brak",
            SearchAreaForNanny = "",
            WantElevator = false,
            MinSeniority = 3,
            MaxFloor = 5,
            NeedNanny = new bool[6] { true, true, true, true, true, true },
            NeedNannyHours = new TimeSpan[2][]
           {
                new TimeSpan[6] { new TimeSpan(7,30,0), new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) },
                new TimeSpan[6] { new TimeSpan(17,30,0), new TimeSpan(17, 30, 0) , new TimeSpan(17, 30, 0) , new TimeSpan(17, 30, 0) , new TimeSpan(17, 30, 0) , new TimeSpan(17, 30, 0) }
           },
            Remarks = ""
        };
        public Mother MotherTest = new Mother()
        {
            ID = 294337686,
            LastName = "yeret",
            FirstName = "hilel",
            PhoneNumber = 0504395188,
            Address = "hafes haim St 14, Bnei Brak",
            SearchAreaForNanny = "",
            WantElevator = false,
            MinSeniority = 3,
            MaxFloor = 5,
            NeedNanny = new bool[6] { true, true, true, true, true, true },
            NeedNannyHours = new TimeSpan[2][]
   {
                new TimeSpan[6] { new TimeSpan(7,30,0), new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) },
                new TimeSpan[6] { new TimeSpan(17,30,0), new TimeSpan(17, 30, 0) , new TimeSpan(17, 30, 0) , new TimeSpan(17, 30, 0) , new TimeSpan(17, 30, 0) , new TimeSpan(17, 30, 0) }
   },
            Remarks = ""
        };



        public Child yoni = new Child()
        {
            ID = 397458103,
            MotherID = 294839286,
            FirstName = "yoni",
            BirthDate = new DateTime(2017, 9, 2),
            AgeInMonth = 5,
            IsSpecialNeeds = false,
            SpecialNeeds = "",
            HaveNanny = false
        };
        public Child shimon = new Child()
        {
            ID = 397004103,
            MotherID = 294894786,
            FirstName = "shimon",
            BirthDate = new DateTime(2017, 6, 2),
            AgeInMonth = 7,
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
            BirthDate = new DateTime(2017, 10, 28),
            AgeInMonth = 4,
            IsSpecialNeeds = true,
            SpecialNeeds = "",
            HaveNanny = false
        };
        public Child moti = new Child()
        {
            ID = 594028499,
            MotherID = 294335086,
            FirstName = "moti",
            BirthDate = new DateTime(2017, 9, 2),
            AgeInMonth = 6,
            IsSpecialNeeds = false,
            SpecialNeeds = "",
            HaveNanny = false
        };

        public Child a = new Child()
        {
            ID = 397460103,
            MotherID = 294337686,
            FirstName = "a",
            BirthDate = new DateTime(2016, 12, 2),
            AgeInMonth = 11,
            IsSpecialNeeds = false,
            SpecialNeeds = "",
            HaveNanny = false
        };

        public Child b = new Child()
        {
            ID = 397240103,
            MotherID = 294337686,
            FirstName = "b",
            BirthDate = new DateTime(2017, 1, 2),
            AgeInMonth = 10,
            IsSpecialNeeds = false,
            SpecialNeeds = "",
            HaveNanny = false
        };

        public Child c = new Child()
        {
            ID = 310460103,
            MotherID = 294337686,
            FirstName = "c",
            BirthDate = new DateTime(2016, 11, 2),
            AgeInMonth = 12,
            IsSpecialNeeds = false,
            SpecialNeeds = "",
            HaveNanny = false
        };

        public Child d = new Child()
        {
            ID = 397055103,
            MotherID = 294839286,
            FirstName = "d",
            BirthDate = new DateTime(2016, 8, 2),
            AgeInMonth = 16,
            IsSpecialNeeds = false,
            SpecialNeeds = "",
            HaveNanny = false
        };







        public Child ChildTest = new Child()
        {
            ID = 594028789,
            MotherID = 294335086,
            FirstName = "childtest",
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
            MotherID = 294335086,
            IsMeet = true,
            IsContractSigned = false,
            HourlyFee = 42,
            MonthlyFee = 2500,
            IsPaymentByHour = false,
            BeginTransection = new DateTime(2018, 1, 1),
            EndTransection = new DateTime(2018, 8, 1)
        };
        public Contract aa = new Contract()
        {
            NannyID = 294003857,
            ChildID = 397460103,
            MotherID = 294337686,
            IsMeet = true,
            IsContractSigned = false,
            HourlyFee = 42,
            MonthlyFee = 2500,
            IsPaymentByHour = false,
            BeginTransection = new DateTime(2018, 1, 1),
            EndTransection = new DateTime(2018, 8, 1)
        };
        public Contract bb = new Contract()
        {
            NannyID = 305625275,
            ChildID = 397240103,
            MotherID = 294337686,
            IsMeet = true,
            IsContractSigned = false,
            HourlyFee = 42,
            MonthlyFee = 2500,
            IsPaymentByHour = false,
            BeginTransection = new DateTime(2018, 1, 1),
            EndTransection = new DateTime(2018, 8, 1)
        };
        public Contract cc = new Contract()
        {
            NannyID = 305625275,
            ChildID = 310460103,
            MotherID = 294337686,
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
