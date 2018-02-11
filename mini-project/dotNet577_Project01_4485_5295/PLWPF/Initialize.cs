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
            //NannyInitialize();
            //MotherInitialize();
            //ChildInitialize();
            //ContractInitialize();
        }
        void NannyInitialize()
        {
            ibl.AddNanny(Michal_Shtern);
            ibl.AddNanny(Meirav_Levy);
            ibl.AddNanny(Sara_Kopolovitsh);
            ibl.AddNanny(Ayala_Zehavi);
            ibl.AddNanny(Moria_Schneider);
            ibl.AddNanny(Malki_Fishman);
            ibl.AddNanny(Elisheva_Shaked);
            ibl.AddNanny(Yafi_Shtain);
            ibl.AddNanny(Adi_Shushan);
            ibl.AddNanny(Chavi_Horen);
            ibl.AddNanny(BatSheva_Choen);
            ibl.AddNanny(Avigail_Kuk);
            ibl.AddNanny(Miriam_Harel);
            ibl.AddNanny(Pnina_Kush);
            ibl.AddNanny(Hadasa_Weiss);
            ibl.AddNanny(Yafit_Shtain);
            ibl.AddNanny(Diti_Farkash);
            ibl.AddNanny(Batya_Adler);
            ibl.AddNanny(lea_Gans);
            ibl.AddNanny(Tamar_Grinblat);
            ibl.AddNanny(Yael_Adler);
        }
        void MotherInitialize()
        {
            ibl.AddMother(Bracha_Polak);
            ibl.AddMother(Oshrat_Levi);
            ibl.AddMother(Ayelt_Shaked);
            ibl.AddMother(Gilat_Benet);
            ibl.AddMother(Esti_Kopshitz);
            ibl.AddMother(Tovi_Shachak);
            ibl.AddMother(Sheindi_Lider);
            ibl.AddMother(Beili_Yudkevitz);
            ibl.AddMother(Mina_Berkovitz);
            ibl.AddMother(Shani_Hovav);
        }
        void ChildInitialize()
        {
            ibl.AddChild(yoni);
            ibl.AddChild(nadav);
            ibl.AddChild(roni);
            ibl.AddChild(moty);
            ibl.AddChild(eti);
            ibl.AddChild(aviad);
            ibl.AddChild(miri);
            ibl.AddChild(david);
            ibl.AddChild(yael);
            ibl.AddChild(naama);
            ibl.AddChild(hila);
            ibl.AddChild(michal);
            ibl.AddChild(reut);
            ibl.AddChild(dodo);
            ibl.AddChild(maten);
            ibl.AddChild(moishi);
            ibl.AddChild(meir);
            ibl.AddChild(yakov);

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

        public Nanny Malki_Fishman = new Nanny
        {
            ID = 305625695,
            LastName = "Fishman",
            FirstName = "Malki",
            BirthDate = new DateTime(1987, 5, 19),
            PhoneNumber = 0543483782,
            Address = "rabi akiva St 69, Bnei Brak",
            Elevator = false,
            Floor = 2,
            Seniority = 6,
            Children = 0,
            MaxChildren = 4,
            MinAge = 0,
            MaxAge = 6,
            IsHourlyFee = true,
            HourlyFee = 15,
            MonthlyFee = 1000,
            IsWork = new bool[6] { true, true, true, true, true, true },
            WorkHours = new TimeSpan[2][]
           {
                new TimeSpan[6] { new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(07, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0) },
                new TimeSpan[6] { new TimeSpan(16, 00, 0), new TimeSpan(16, 00, 0), new TimeSpan(16, 00, 0), new TimeSpan(16, 00, 0), new TimeSpan(16, 00, 0), new TimeSpan(12, 00, 0) }
           },
            IsValidVacationDays = false,
            Recommendations = "",
        };
        public Nanny Yafit_Shtain = new Nanny
        {
            ID = 305265695,
            LastName = "Shtain",
            FirstName = "Yafit",
            BirthDate = new DateTime(1987, 5, 19),
            PhoneNumber = 0543483782,
            Address = "הרב דסלר 5, בני ברק, Israel",
            Elevator = false,
            Floor = 2,
            Seniority = 6,
            Children = 0,
            MaxChildren = 4,
            MinAge = 0,
            MaxAge = 6,
            IsHourlyFee = true,
            HourlyFee = 15,
            MonthlyFee = 1000,
            IsWork = new bool[6] { true, true, true, true, true, true },
            WorkHours = new TimeSpan[2][]
           {
                new TimeSpan[6] { new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(07, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0) },
                new TimeSpan[6] { new TimeSpan(16, 00, 0), new TimeSpan(16, 00, 0), new TimeSpan(16, 00, 0), new TimeSpan(16, 00, 0), new TimeSpan(16, 00, 0), new TimeSpan(12, 00, 0) }
           },
            IsValidVacationDays = false,
            Recommendations = "",
        };
        public Nanny Tamar_Grinblat = new Nanny
        {
            ID = 204265695,
            LastName = "Grinblat",
            FirstName = "Tamar",
            BirthDate = new DateTime(1987, 5, 19),
            PhoneNumber = 0543483782,
            Address = "אהרונוביץ' 33, בני ברק, Israel",
            Elevator = false,
            Floor = 2,
            Seniority = 6,
            Children = 0,
            MaxChildren = 4,
            MinAge = 0,
            MaxAge = 6,
            IsHourlyFee = true,
            HourlyFee = 15,
            MonthlyFee = 1000,
            IsWork = new bool[6] { true, true, true, true, true, true },
            WorkHours = new TimeSpan[2][]
          {
                new TimeSpan[6] { new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(07, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0) },
                new TimeSpan[6] { new TimeSpan(16, 00, 0), new TimeSpan(16, 00, 0), new TimeSpan(16, 00, 0), new TimeSpan(16, 00, 0), new TimeSpan(16, 00, 0), new TimeSpan(12, 00, 0) }
          },
            IsValidVacationDays = false,
            Recommendations = "",
        };
        public Nanny Ayala_Zehavi = new Nanny
        {
            ID = 303368978,
            LastName = "Zehavi",
            FirstName = "Ayala",
            BirthDate = new DateTime(1994, 12, 9),
            PhoneNumber = 0543456372,
            Address = "be'eri St 20, Bnei Brak",
            Elevator = false,
            Floor = 4,
            Seniority = 5,
            Children = 0,
            MaxChildren = 10,
            MinAge = 0,
            MaxAge = 6,
            IsHourlyFee = false,
            HourlyFee = 12,
            MonthlyFee = 2000,
            IsWork = new bool[6] { true, true, true, true, true, true },
            WorkHours = new TimeSpan[2][]
            {
                new TimeSpan[6] { new TimeSpan(8, 00, 0), new TimeSpan(8, 00, 0), new TimeSpan(8, 00, 0), new TimeSpan(8, 00, 0), new TimeSpan(8, 00, 0), new TimeSpan(8, 00, 0) },
                new TimeSpan[6] { new TimeSpan(17, 00, 0), new TimeSpan(17, 00, 0), new TimeSpan(17, 00, 0), new TimeSpan(17, 00, 0), new TimeSpan(17, 00, 0), new TimeSpan(13, 00, 0) }
            },
            IsValidVacationDays = false,
            Recommendations = "",
        };
        public Nanny Chavi_Horen = new Nanny
        {
            ID = 305695295,
            LastName = "Horen",
            FirstName = "Chavi",
            BirthDate = new DateTime(1991, 3, 7),
            PhoneNumber = 0543473834,
            Address = "Nissenboim St 11, Bnei Brak",
            Elevator = true,
            Floor = 1,
            Seniority = 7,
            Children = 0,
            MaxChildren = 7,
            MinAge = 0,
            MaxAge = 6,
            IsHourlyFee = false,
            HourlyFee = 42,
            MonthlyFee = 4000,
            IsWork = new bool[6] { true, true, true, true, true, true },
            WorkHours = new TimeSpan[2][]
           {
                new TimeSpan[6] { new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0) },
                new TimeSpan[6] { new TimeSpan(13, 30, 0), new TimeSpan(13, 30, 0), new TimeSpan(13, 30, 0), new TimeSpan(13, 30, 0), new TimeSpan(13, 30, 0), new TimeSpan(13, 30, 0) }
           },
            IsValidVacationDays = false,
            Recommendations = "",
        };
        public Nanny Avigail_Kuk = new Nanny
        {
            ID = 305825295,
            LastName = "Kuk",
            FirstName = "Avigail",
            BirthDate = new DateTime(1991, 3, 7),
            PhoneNumber = 0543473834,
            Address = "רבי עקיבא 54, בני ברק, Israel",
            Elevator = true,
            Floor = 1,
            Seniority = 7,
            Children = 0,
            MaxChildren = 7,
            MinAge = 0,
            MaxAge = 6,
            IsHourlyFee = false,
            HourlyFee = 42,
            MonthlyFee = 4000,
            IsWork = new bool[6] { true, true, true, true, true, false },
            WorkHours = new TimeSpan[2][]
          {
                new TimeSpan[6] { new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(00, 00, 0) },
                new TimeSpan[6] { new TimeSpan(13, 30, 0), new TimeSpan(13, 30, 0), new TimeSpan(13, 30, 0), new TimeSpan(13, 30, 0), new TimeSpan(13, 30, 0), new TimeSpan(00, 00, 0) }
          },
            IsValidVacationDays = false,
            Recommendations = "",
        };
        public Nanny Diti_Farkash = new Nanny
        {
            ID = 294753857,
            LastName = "Farkash",
            FirstName = "Diti",
            BirthDate = new DateTime(1991, 11, 4),
            PhoneNumber = 0543395033,
            Address = "חבקוק 4, בני ברק, Israel",
            Elevator = true,
            Floor = 2,
            Seniority = 7,
            Children = 0,
            MaxChildren = 7,
            MinAge = 6,
            MaxAge = 12,
            IsHourlyFee = true,
            HourlyFee = 12,
            MonthlyFee = 1000,
            IsWork = new bool[6] { true, true, true, true, true, false },
            WorkHours = new TimeSpan[2][]
            {
                new TimeSpan[6] { new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0) },
                new TimeSpan[6] { new TimeSpan(16, 30, 0), new TimeSpan(16, 30, 0), new TimeSpan(16, 30, 0), new TimeSpan(16, 30, 0), new TimeSpan(16, 30, 0), new TimeSpan(13, 30, 0) }
            },
            IsValidVacationDays = true,
            Recommendations = "Clean and tidy place, amazing attitude for children strongly recommends. riky shimon",
        };
        public Nanny Meirav_Levy = new Nanny
        {
            ID = 294003857,
            LastName = "Levi",
            FirstName = "Meirav",
            BirthDate = new DateTime(1991, 11, 4),
            PhoneNumber = 0543395033,
            Address = "Yerushalayim St 51, Bnei Brak",
            Elevator = true,
            Floor = 2,
            Seniority = 7,
            Children = 0,
            MaxChildren = 7,
            MinAge = 6,
            MaxAge = 12,
            IsHourlyFee = true,
            HourlyFee = 12,
            MonthlyFee = 1000,
            IsWork = new bool[6] { true, true, true, true, true, false },
            WorkHours = new TimeSpan[2][]
            {
                new TimeSpan[6] { new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0) },
                new TimeSpan[6] { new TimeSpan(13, 30, 0), new TimeSpan(13, 30, 0), new TimeSpan(13, 30, 0), new TimeSpan(13, 30, 0), new TimeSpan(13, 30, 0), new TimeSpan(13, 30, 0) }
            },
            IsValidVacationDays = true,
            Recommendations = "Clean and tidy place, amazing attitude for children strongly recommends. riky shimon",
        };
        public Nanny Mehira_Shulman = new Nanny
        {
            ID = 294003857,
            LastName = "Levi",
            FirstName = "Meirav",
            BirthDate = new DateTime(1991, 11, 4),
            PhoneNumber = 0543395033,
            Address = "נחמיה 7, בני ברק, Israel",
            Elevator = true,
            Floor = 2,
            Seniority = 7,
            Children = 0,
            MaxChildren = 7,
            MinAge = 6,
            MaxAge = 12,
            IsHourlyFee = true,
            HourlyFee = 12,
            MonthlyFee = 1250,
            IsWork = new bool[6] { true, true, true, true, true, true },
            WorkHours = new TimeSpan[2][]
            {
                new TimeSpan[6] { new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0) },
                new TimeSpan[6] { new TimeSpan(13, 30, 0), new TimeSpan(13, 30, 0), new TimeSpan(13, 30, 0), new TimeSpan(13, 30, 0), new TimeSpan(13, 30, 0), new TimeSpan(13, 00, 0) }
            },
            IsValidVacationDays = true,
            Recommendations = "Clean and tidy place, amazing attitude for children strongly recommends. riky shimon",
        };
        public Nanny Michal_Shtern = new Nanny
        {
            ID = 305625295,
            LastName = "Stern",
            FirstName = "Michal",
            BirthDate = new DateTime(1982, 7, 16),
            PhoneNumber = 0543972654,
            Address = "הר סיני 12, בני ברק, Israel",
            Elevator = true,
            Seniority = 10,
            Children = 0,
            MaxChildren = 5,
            MinAge = 6,
            MaxAge = 12,
            IsHourlyFee = true,
            HourlyFee = 10,
            MonthlyFee = 1300,
            IsWork = new bool[6] { true, true, true, true, true, true },
            WorkHours = new TimeSpan[2][]
           {
                new TimeSpan[6] { new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(07, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0) },
                new TimeSpan[6] { new TimeSpan(16, 00, 0), new TimeSpan(16, 00, 0), new TimeSpan(16, 00, 0), new TimeSpan(16, 00, 0), new TimeSpan(16, 00, 0), new TimeSpan(12, 00, 0) }
           },
            IsValidVacationDays = true,
            Recommendations = "",
        };
        public Nanny Miriam_Harel = new Nanny
        {
            ID = 305623395,
            LastName = "Harel",
            FirstName = "Miriam",
            BirthDate = new DateTime(1982, 7, 16),
            PhoneNumber = 0543972654,
            Address = "Ovadya St 6, Bnei Brak",
            Elevator = true,
            Seniority = 10,
            Children = 0,
            MaxChildren = 5,
            MinAge = 6,
            MaxAge = 12,
            IsHourlyFee = true,
            HourlyFee = 10,
            MonthlyFee = 1300,
            IsWork = new bool[6] { true, true, true, true, true, true },
            WorkHours = new TimeSpan[2][]
          {
                new TimeSpan[6] { new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(07, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0) },
                new TimeSpan[6] { new TimeSpan(17, 00, 0), new TimeSpan(17, 00, 0), new TimeSpan(17, 00, 0), new TimeSpan(17, 00, 0), new TimeSpan(17, 00, 0), new TimeSpan(13, 00, 0) }
          },
            IsValidVacationDays = true,
            Recommendations = "",
        };
        public Nanny Sara_Kopolovitsh = new Nanny
        {
            ID = 305629275,
            LastName = "Kopolovitsh",
            FirstName = "Sara",
            BirthDate = new DateTime(1998, 8, 12),
            PhoneNumber = 0543453834,
            Address = "Sokolov st 44, Bnei Brak",
            Elevator = false,
            Floor = 0,
            Seniority = 2,
            Children = 0,
            MaxChildren = 10,
            MinAge = 12,
            MaxAge = 18,
            IsHourlyFee = true,
            HourlyFee = 9,
            MonthlyFee = 2000,
            IsWork = new bool[6] { true, true, true, true, true, true },
            WorkHours = new TimeSpan[2][]
            {
                new TimeSpan[6] { new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0) },
                new TimeSpan[6] { new TimeSpan(16, 00, 0), new TimeSpan(16, 00, 0), new TimeSpan(16, 00, 0), new TimeSpan(16, 00, 0), new TimeSpan(16, 00, 0), new TimeSpan(13, 00, 0) }
            },
            IsValidVacationDays = true,
            Recommendations = "",
        };
        public Nanny Yael_Adler = new Nanny
        {
            ID = 206292758,
            LastName = "Adler",
            FirstName = "Yael",
            BirthDate = new DateTime(1998, 8, 12),
            PhoneNumber = 0543453834,
            Address = "חנקין 5, בני ברק, Israel",
            Elevator = false,
            Floor = 0,
            Seniority = 2,
            Children = 0,
            MaxChildren = 10,
            MinAge = 12,
            MaxAge = 18,
            IsHourlyFee = true,
            HourlyFee = 9,
            MonthlyFee = 2000,
            IsWork = new bool[6] { true, true, true, true, true, true },
            WorkHours = new TimeSpan[2][]
           {
                new TimeSpan[6] { new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0) },
                new TimeSpan[6] { new TimeSpan(16, 00, 0), new TimeSpan(16, 00, 0), new TimeSpan(16, 00, 0), new TimeSpan(16, 00, 0), new TimeSpan(16, 00, 0), new TimeSpan(13, 00, 0) }
           },
            IsValidVacationDays = true,
            Recommendations = "",
        };
        public Nanny Batya_Adler = new Nanny
        {
            ID = 305637975,
            LastName = "Adler",
            FirstName = "Batya",
            BirthDate = new DateTime(1998, 8, 12),
            PhoneNumber = 0543453834,
            Address = "הבנים 9, בני ברק, Israel",
            Elevator = false,
            Floor = 0,
            Seniority = 2,
            Children = 0,
            MaxChildren = 10,
            MinAge = 12,
            MaxAge = 18,
            IsHourlyFee = true,
            HourlyFee = 9,
            MonthlyFee = 2000,
            IsWork = new bool[6] { true, true, true, true, true, true },
            WorkHours = new TimeSpan[2][]
            {
                new TimeSpan[6] { new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0) },
                new TimeSpan[6] { new TimeSpan(16, 00, 0), new TimeSpan(16, 00, 0), new TimeSpan(16, 00, 0), new TimeSpan(16, 00, 0), new TimeSpan(16, 00, 0), new TimeSpan(13, 00, 0) }
            },
            IsValidVacationDays = true,
            Recommendations = "",
        };
        public Nanny Moria_Schneider = new Nanny
        {
            ID = 305649295,
            LastName = "Schneider",
            FirstName = "Moria",
            BirthDate = new DateTime(1980, 2, 23),
            PhoneNumber = 0543451042,
            Address = "chason ish St 43, Bnei Brak",
            Elevator = true,
            Floor = 1,
            Seniority = 8,
            Children = 0,
            MaxChildren = 8,
            MinAge = 12,
            MaxAge = 18,
            IsHourlyFee = false,
            HourlyFee = 7,
            MonthlyFee = 1350,
            IsWork = new bool[6] { true, true, true, true, true, true },
            WorkHours = new TimeSpan[2][]
            {
                new TimeSpan[6] { new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0) },
                new TimeSpan[6] { new TimeSpan(16, 00, 0), new TimeSpan(16, 00, 0), new TimeSpan(13, 00, 0), new TimeSpan(16, 00, 0), new TimeSpan(16, 00, 0), new TimeSpan(12, 30, 0) }
            },
            IsValidVacationDays = true,
            Recommendations = "",
        };
        public Nanny BatSheva_Choen = new Nanny
        {
            ID = 305625275,
            LastName = "Choen",
            FirstName = "BatSheva",
            BirthDate = new DateTime(1998, 8, 12),
            PhoneNumber = 0543453834,
            Address = "החלוצים 17, בני ברק, Israel",
            Elevator = false,
            Floor = 0,
            Seniority = 2,
            Children = 0,
            MaxChildren = 10,
            MinAge = 12,
            MaxAge = 18,
            IsHourlyFee = true,
            HourlyFee = 9,
            MonthlyFee = 2200,
            IsWork = new bool[6] { true, true, true, true, true, true },
            WorkHours = new TimeSpan[2][]
            {
                new TimeSpan[6] { new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0) },
                new TimeSpan[6] { new TimeSpan(18, 00, 0), new TimeSpan(18, 00, 0), new TimeSpan(18, 00, 0), new TimeSpan(18, 00, 0), new TimeSpan(18, 00, 0), new TimeSpan(13, 00, 0) }
            },
            IsValidVacationDays = true,
            Recommendations = "",
        };
        public Nanny Pnina_Kush = new Nanny
        {
            ID = 305625175,
            LastName = "Kush",
            FirstName = "Pnina",
            BirthDate = new DateTime(1998, 8, 12),
            PhoneNumber = 0543453834,
            Address = "בן פתחיה 17, בני ברק, Israel",
            Elevator = false,
            Floor = 0,
            Seniority = 2,
            Children = 0,
            MaxChildren = 10,
            MinAge = 12,
            MaxAge = 18,
            IsHourlyFee = true,
            HourlyFee = 9,
            MonthlyFee = 2200,
            IsWork = new bool[6] { true, true, true, true, true, true },
            WorkHours = new TimeSpan[2][]
            {
                new TimeSpan[6] { new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0) },
                new TimeSpan[6] { new TimeSpan(13, 00, 0), new TimeSpan(13, 00, 0), new TimeSpan(13, 00, 0), new TimeSpan(13, 00, 0), new TimeSpan(13, 00, 0), new TimeSpan(13, 00, 0) }
            },
            IsValidVacationDays = true,
            Recommendations = "",
        };
        public Nanny Hadasa_Weiss = new Nanny
        {
            ID = 307825175,
            LastName = "Weiss",
            FirstName = "Hadasa",
            BirthDate = new DateTime(1998, 8, 12),
            PhoneNumber = 0543453834,
            Address = "מנחם 3, בני ברק, Israel",
            Elevator = false,
            Floor = 0,
            Seniority = 2,
            Children = 0,
            MaxChildren = 10,
            MinAge = 12,
            MaxAge = 18,
            IsHourlyFee = true,
            HourlyFee = 9,
            MonthlyFee = 2200,
            IsWork = new bool[6] { true, true, false, true, true, true },
            WorkHours = new TimeSpan[2][]
            {
                new TimeSpan[6] { new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0), new TimeSpan(7, 00, 0) },
                new TimeSpan[6] { new TimeSpan(13, 00, 0), new TimeSpan(13, 00, 0), new TimeSpan(13, 00, 0), new TimeSpan(13, 00, 0), new TimeSpan(13, 00, 0), new TimeSpan(13, 00, 0) }
            },
            IsValidVacationDays = true,
            Recommendations = "",
        };
        public Nanny Elisheva_Shaked = new Nanny
        {
            ID = 305216295,
            LastName = "Shaked",
            FirstName = "Elisheva",
            BirthDate = new DateTime(2000, 4, 2),
            PhoneNumber = 0543429642,
            Address = "Ha-Rav Desler St 69, Bnei Brak",
            Elevator = false,
            Floor = 4,
            Seniority = 0,
            Children = 0,
            MaxChildren = 6,
            MinAge = 18,
            MaxAge = 24,
            IsHourlyFee = false,
            HourlyFee = 42,
            MonthlyFee = 2500,
            IsWork = new bool[6] { true, true, false, true, true, false },
            WorkHours = new TimeSpan[2][]
            {
                new TimeSpan[6] { new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0) },
                new TimeSpan[6] { new TimeSpan(13, 30, 0), new TimeSpan(13, 30, 0), new TimeSpan(13, 30, 0), new TimeSpan(13, 30, 0), new TimeSpan(13, 30, 0), new TimeSpan(13, 30, 0) }
            },
            IsValidVacationDays = true,
            Recommendations = "",
        };
        public Nanny Yafi_Shtain = new Nanny
        {
            ID = 355625295,
            LastName = "Shtain",
            FirstName = "Yafi",
            BirthDate = new DateTime(1997, 3, 22),
            PhoneNumber = 0543448382,
            Address = "יהושע בן נון 4, בני ברק, Israel",
            Elevator = false,
            Floor = 3,
            Seniority = 4,
            Children = 0,
            MaxChildren = 6,
            MinAge = 18,
            MaxAge = 24,
            IsHourlyFee = true,
            HourlyFee = 10,
            MonthlyFee = 1100,
            IsWork = new bool[6] { true, true, true, true, true, true },
            WorkHours = new TimeSpan[2][]
            {
                new TimeSpan[6] { new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0) },
                new TimeSpan[6] { new TimeSpan(14, 00, 0), new TimeSpan(14, 00, 0), new TimeSpan(14, 00, 0), new TimeSpan(14, 00, 0), new TimeSpan(14, 00, 0), new TimeSpan(14, 00, 0) }
            },
            IsValidVacationDays = false,
            Recommendations = "",
        };
        public Nanny Adi_Shushan = new Nanny
        {
            ID = 303964295,
            LastName = "Shushan",
            FirstName = "Adi",
            BirthDate = new DateTime(1995, 3, 7),
            PhoneNumber = 0543473882,
            Address = "Rabbi Yehuda HaNassi St 27, Bnei Brak",
            Elevator = true,
            Floor = 5,
            Seniority = 8,
            Children = 0,
            MaxChildren = 8,
            MinAge = 18,
            MaxAge = 24,
            IsHourlyFee = false,
            HourlyFee = 9,
            MonthlyFee = 4000,
            IsWork = new bool[6] { true, true, true, true, true, true },
            WorkHours = new TimeSpan[2][]
            {
                new TimeSpan[6] { new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(10, 00, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0) },
                new TimeSpan[6] { new TimeSpan(16, 30, 0), new TimeSpan(13, 30, 0), new TimeSpan(16, 30, 0), new TimeSpan(16, 30, 0), new TimeSpan(16, 30, 0), new TimeSpan(12, 30, 0) }
            },
            IsValidVacationDays = false,
            Recommendations = "",
        };
        public Nanny lea_Gans = new Nanny
        {
            ID = 209964295,
            LastName = "lea_Gans",
            FirstName = "lea",
            BirthDate = new DateTime(1995, 3, 7),
            PhoneNumber = 0543473882,
            Address = "Rabbi Yehuda HaNassi St 27, Bnei Brak",
            Elevator = false,
            Floor = 2,
            Seniority = 8,
            Children = 0,
            MaxChildren = 8,
            MinAge = 18,
            MaxAge = 24,
            IsHourlyFee = false,
            HourlyFee = 9,
            MonthlyFee = 4000,
            IsWork = new bool[6] { true, true, true, true, true, true },
            WorkHours = new TimeSpan[2][]
           {
                new TimeSpan[6] { new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(10, 00, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0), new TimeSpan(7, 30, 0) },
                new TimeSpan[6] { new TimeSpan(16, 30, 0), new TimeSpan(13, 30, 0), new TimeSpan(16, 30, 0), new TimeSpan(16, 30, 0), new TimeSpan(16, 30, 0), new TimeSpan(12, 30, 0) }
           },
            IsValidVacationDays = false,
            Recommendations = "",
        };

        public Mother Bracha_Polak = new Mother()
        {
            ID = 294839286,
            LastName = "Polak",
            FirstName = "Bracha",
            PhoneNumber = 0504182088,
            Address = "ha-rav mohilever St 8, Bnei Brak",
            SearchAreaForNanny = "",
            WantElevator = true,
            MinSeniority = 2,
            MaxFloor = 3,
            NeedNanny = new bool[6] { true, true, true, true, true, true },
            NeedNannyHours = new TimeSpan[2][]
            {
                    new TimeSpan[6] { new TimeSpan(7,30,0), new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) },
                    new TimeSpan[6] { new TimeSpan(16,00,0), new TimeSpan(16, 00, 0) , new TimeSpan(16, 00, 0) , new TimeSpan(16, 00, 0) , new TimeSpan(16, 00, 0) , new TimeSpan(12, 00, 0) }
            },
            Remarks = ""
        };
        public Mother Oshrat_Levi = new Mother()
        {
            ID = 294894786,
            LastName = "Levi",
            FirstName = "Oshrat",
            PhoneNumber = 0504397588,
            Address = "בן גוריון 41, בני ברק, Israel",
            SearchAreaForNanny = "",
            WantElevator = true,
            MinSeniority = 5,
            MaxFloor = 7,
            NeedNanny = new bool[6] { false, true, true, true, true, true },
            NeedNannyHours = new TimeSpan[2][]
            {
                new TimeSpan[6] { new TimeSpan(00,00,0), new TimeSpan(7, 00,0) , new TimeSpan(7, 00,0) , new TimeSpan(7, 00,0) , new TimeSpan(7, 00,0) , new TimeSpan(08, 00,0) },
                new TimeSpan[6] { new TimeSpan(00,0,0), new TimeSpan(13, 0, 0) , new TimeSpan(13, 0, 0) , new TimeSpan(13, 0, 0) , new TimeSpan(13, 0, 0) , new TimeSpan(12, 0, 0) }
            },
            Remarks = ""
        };
        public Mother Ayelt_Shaked = new Mother()
        {
            ID = 294892086,
            LastName = "Shaked",
            FirstName = "Ayelt",
            PhoneNumber = 0504003828,
            Address = "ovadya St 8, Bnei Brak",
            SearchAreaForNanny = "Hannah Szenes St 8, Bnei Brak",
            WantElevator = false,
            MinSeniority = 4,
            MaxFloor = 2,
            NeedNanny = new bool[6] { true, true, false, false, true, true },
            NeedNannyHours = new TimeSpan[2][]
            {
                new TimeSpan[6] { new TimeSpan(8,0,0), new TimeSpan(8, 0,0) , new TimeSpan(00, 00,00) , new TimeSpan(00, 00,00) , new TimeSpan(8, 0,0) , new TimeSpan(8, 0,0) },
                new TimeSpan[6] { new TimeSpan(16,00,0), new TimeSpan(16, 30, 0) , new TimeSpan(00, 00, 0) , new TimeSpan(00, 00, 00) , new TimeSpan(16, 30, 0) , new TimeSpan(16, 30, 0) }
            },
            Remarks = ""
        };
        public Mother Gilat_Benet = new Mother()
        {
            ID = 294909286,
            LastName = "Benet",
            FirstName = "Gilat",
            PhoneNumber = 0504129888,
            Address = "Hannah Szenes St 8, Bnei Brak",
            SearchAreaForNanny = "Chason Ish St 20, Bnei Brak",
            WantElevator = false,
            MinSeniority = 2,
            MaxFloor = 2,
            NeedNanny = new bool[6] { true, true, true, true, true, false },
            NeedNannyHours = new TimeSpan[2][]
            {
                new TimeSpan[6] { new TimeSpan(8,0,0), new TimeSpan(8,0,0) , new TimeSpan(8,0,0) , new TimeSpan(8,0,0) , new TimeSpan(8,0,0) , new TimeSpan(00,00,00) },
                new TimeSpan[6] { new TimeSpan(16,0,0), new TimeSpan(16,0, 0) , new TimeSpan(13,0, 0) , new TimeSpan(16,0, 0) , new TimeSpan(16,0, 0) , new TimeSpan(00, 00, 00) }
            },
            Remarks = ""
        };
        public Mother Esti_Kopshitz = new Mother()
        {
            ID = 294849001,
            LastName = "yeret",
            FirstName = "simcha",
            PhoneNumber = 0504184920,
            Address = "Yerushalayim St 72, Bnei Brak",
            SearchAreaForNanny = "",
            WantElevator = true,
            MinSeniority = 8,
            MaxFloor = 3,
            NeedNanny = new bool[6] { true, true, true, true, false, false },
            NeedNannyHours = new TimeSpan[2][]
            {
                new TimeSpan[6] { new TimeSpan(7,0,0), new TimeSpan(7,0,0) , new TimeSpan(7,0,0) , new TimeSpan(7,0,0) , new TimeSpan(00,0,0) , new TimeSpan(00,0,0) },
                new TimeSpan[6] { new TimeSpan(14,0,0), new TimeSpan(14,0, 0) , new TimeSpan(14,0, 0) , new TimeSpan(14,0, 0) , new TimeSpan(00,0, 0) , new TimeSpan(00,0, 0) }
            },
            Remarks = ""
        };
        public Mother Tovi_Shachak = new Mother()
        {
            ID = 294800286,
            LastName = "Shachak",
            FirstName = "Tovi",
            PhoneNumber = 0504183827,
            Address = "הירדן 15, בני ברק, Israel",
            SearchAreaForNanny = "",
            WantElevator = false,
            MinSeniority = 5,
            MaxFloor = 4,
            NeedNanny = new bool[6] { true, true, true, true, true, true },
            NeedNannyHours = new TimeSpan[2][]
            {
                new TimeSpan[6] { new TimeSpan(8,00,0), new TimeSpan(8, 30,0) , new TimeSpan(09, 00,0) , new TimeSpan(7, 00,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) },
                new TimeSpan[6] { new TimeSpan(16,00,0), new TimeSpan(16, 30, 0) , new TimeSpan(13, 00, 0) , new TimeSpan(13, 30, 0) , new TimeSpan(16, 00, 0) , new TimeSpan(12, 30, 0) }
            },
            Remarks = ""
        };
        public Mother Sheindi_Lider = new Mother()
        {
            ID = 294335086,
            LastName = "Lider",
            FirstName = "Sheindi",
            PhoneNumber = 0504395188,
            Address = "sokolow St 34, Bnei Brak",
            SearchAreaForNanny = "הרב שר 3, בני ברק, Israel",
            WantElevator = false,
            MinSeniority = 3,
            MaxFloor = 5,
            NeedNanny = new bool[6] { false, true, true, true, true, true },
            NeedNannyHours = new TimeSpan[2][]
            {
                new TimeSpan[6] { new TimeSpan(00,00,00), new TimeSpan(13, 00,0) , new TimeSpan(13, 00,00) , new TimeSpan(13, 00,0) , new TimeSpan(13, 00,0) , new TimeSpan(7, 30,0) },
                new TimeSpan[6] { new TimeSpan(00,00,00), new TimeSpan(16, 00, 0) , new TimeSpan(16, 00, 0) , new TimeSpan(16, 00, 0) , new TimeSpan(16, 00, 0) , new TimeSpan(12, 00, 0) }
            },
            Remarks = ""
        };
        public Mother Beili_Yudkevitz = new Mother()
        {
            ID = 294337686,
            LastName = "Yudkevitz",
            FirstName = "Beili",
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
        public Mother Mina_Berkovitz = new Mother()
        {
            ID = 294337676,
            LastName = "Berkovitz",
            FirstName = "Mina",
            PhoneNumber = 0504395188,
            Address = "הרב ריינס 17, בני ברק, Israel",
            SearchAreaForNanny = "",
            WantElevator = false,
            MinSeniority = 3,
            MaxFloor = 5,
            NeedNanny = new bool[6] { true, true, true, true, true, true },
            NeedNannyHours = new TimeSpan[2][]
            {
                new TimeSpan[6] { new TimeSpan(7,30,0), new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) , new TimeSpan(7, 30,0) },
                new TimeSpan[6] { new TimeSpan(13,30,0), new TimeSpan(13, 30, 0) , new TimeSpan(13, 30, 0) , new TimeSpan(13, 30, 0) , new TimeSpan(13, 30, 0) , new TimeSpan(12, 00, 0) }
            },
            Remarks = ""
        };
        public Mother Shani_Hovav = new Mother()
        {
            ID = 294355686,
            LastName = "Hovav",
            FirstName = "Shani",
            PhoneNumber = 0504395188,
            Address = "hafes haim St 14, Bnei Brak",
            SearchAreaForNanny = "רבן גמליאל 9, בני ברק, Israel",
            WantElevator = false,
            MinSeniority = 6,
            MaxFloor = 2,
            NeedNanny = new bool[6] { true, false, true, true, true, false },
            NeedNannyHours = new TimeSpan[2][]
             {
                new TimeSpan[6] { new TimeSpan(7,30,0), new TimeSpan(00, 00,0) , new TimeSpan(7, 30,0) , new TimeSpan(8, 00,0) , new TimeSpan(7, 00,0) , new TimeSpan(7, 30,0) },
                new TimeSpan[6] { new TimeSpan(13,30,0), new TimeSpan(00, 00, 0) , new TimeSpan(16, 00, 0) , new TimeSpan(17, 00, 0) , new TimeSpan(16, 00, 0) , new TimeSpan(12, 30, 0) }
             },
            Remarks = ""
        };

        public Child yoni = new Child()
        {
            ID = 397458103,
            MotherID = 294839286,
            FirstName = "yoni",
            BirthDate = new DateTime(2017, 7, 2),
            AgeInMonth = 7,
            IsSpecialNeeds = false,
            SpecialNeeds = "",
            HaveNanny = false
        };
        public Child nadav = new Child()
        {
            ID = 397004103,
            MotherID = 294839286,
            FirstName = "nadav",
            BirthDate = new DateTime(2017, 6, 2),
            AgeInMonth = 7,
            IsSpecialNeeds = false,
            SpecialNeeds = "",
            HaveNanny = false
        };
        public Child roni = new Child()
        {
            ID = 392940383,
            MotherID = 294894786,
            FirstName = "roni",
            BirthDate = new DateTime(2017, 5, 2),
            AgeInMonth = 8,
            IsSpecialNeeds = true,
            SpecialNeeds = "",
            HaveNanny = false
        };
        public Child aviad = new Child()
        {
            ID = 397449028,
            MotherID = 294894786,
            FirstName = "aviad",
            BirthDate = new DateTime(2017, 3, 15),
            AgeInMonth = 9,
            IsSpecialNeeds = true,
            SpecialNeeds = "",
            HaveNanny = false
        };
        public Child moty = new Child()
        {
            ID = 493029984,
            MotherID = 294892086,
            FirstName = "moty",
            BirthDate = new DateTime(2016, 9, 7),
            AgeInMonth = 15,
            IsSpecialNeeds = false,
            SpecialNeeds = "",
            HaveNanny = false
        };
        public Child eti = new Child()
        {
            ID = 294083104,
            MotherID = 294892086,
            FirstName = "eti",
            BirthDate = new DateTime(2017, 7, 28),
            AgeInMonth = 7,
            IsSpecialNeeds = true,
            SpecialNeeds = "",
            HaveNanny = false
        };
        public Child miri = new Child()
        {
            ID = 594028499,
            MotherID = 294909286,
            FirstName = "miri",
            BirthDate = new DateTime(2017, 5, 2),
            AgeInMonth = 7,
            IsSpecialNeeds = false,
            SpecialNeeds = "",
            HaveNanny = false
        };

        public Child david = new Child()
        {
            ID = 397460103,
            MotherID = 294909286,
            FirstName = "david",
            BirthDate = new DateTime(2016, 12, 2),
            AgeInMonth = 11,
            IsSpecialNeeds = false,
            SpecialNeeds = "",
            HaveNanny = false
        };
        public Child moishi = new Child()
        {
            ID = 303460103,
            MotherID = 294800286,
            FirstName = "david",
            BirthDate = new DateTime(2016, 1, 2),
            AgeInMonth = 11,
            IsSpecialNeeds = false,
            SpecialNeeds = "",
            HaveNanny = false
        };
        public Child yael = new Child()
        {
            ID = 397240103,
            MotherID = 294909286,
            FirstName = "yael",
            BirthDate = new DateTime(2017, 5, 2),
            AgeInMonth = 10,
            IsSpecialNeeds = false,
            SpecialNeeds = "",
            HaveNanny = false
        };
        public Child meir= new Child()
        {
            ID = 306240103,
            MotherID = 294800286,
            FirstName = "yael",
            BirthDate = new DateTime(2017, 5, 2),
            AgeInMonth = 10,
            IsSpecialNeeds = false,
            SpecialNeeds = "",
            HaveNanny = false
        };
        public Child naama = new Child()
        {
            ID = 310460103,
            MotherID = 294849001,
            FirstName = "naama",
            BirthDate = new DateTime(2016, 11, 2),
            AgeInMonth = 12,
            IsSpecialNeeds = false,
            SpecialNeeds = "",
            HaveNanny = false
        };
        public Child dodo = new Child()
        {
            ID = 310462203,
            MotherID = 294335086,
            FirstName = "dodo",
            BirthDate = new DateTime(2016, 05, 2),
            AgeInMonth = 12,
            IsSpecialNeeds = false,
            SpecialNeeds = "",
            HaveNanny = false
        };
        public Child yakov = new Child()
        {
            ID = 300462203,
            MotherID = 294337686,
            FirstName = "dodo",
            BirthDate = new DateTime(2016, 9, 2),
            AgeInMonth = 12,
            IsSpecialNeeds = true,
            SpecialNeeds = "Celiac patient",
            HaveNanny = false
        };
        public Child maten = new Child()
        {
            ID = 310457103,
            MotherID = 294335086,
            FirstName = "maten",
            BirthDate = new DateTime(2017 ,11, 2),
            AgeInMonth = 12,
            IsSpecialNeeds = true,
            SpecialNeeds = "Allergic to milk",
            HaveNanny = false
        };

        public Child hila = new Child()
        {
            ID = 397055103,
            MotherID = 294337676,
            FirstName = "hila",
            BirthDate = new DateTime(2016, 8, 2),
            AgeInMonth = 16,
            IsSpecialNeeds = false,
            SpecialNeeds = "",
            HaveNanny = false
        };

        public Child michal = new Child()
        {
            ID = 397054103,
            MotherID = 294337676,
            FirstName = "michal",
            BirthDate = new DateTime(2016, 9, 2),
            AgeInMonth = 16,
            IsSpecialNeeds = false,
            SpecialNeeds = "",
            HaveNanny = false
        };

        public Child reut = new Child()
        {
            ID = 313260103,
            MotherID = 294355686,
            FirstName = "reut",
            BirthDate = new DateTime(2017, 11, 2),
            AgeInMonth = 12,
            IsSpecialNeeds = false,
            SpecialNeeds = "",
            HaveNanny = false
        };
        public Child mosh = new Child()
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
