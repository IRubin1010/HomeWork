﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Nanny
    {
        // Properties
        private int? id;
        public int? ID { get { return id; } set { if (value >= 100000000 && value <= 999999999) id = value; else { id = 0; throw new ArgumentException("iligell ID"); } } }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string FullNameAndID { get { return FirstName + " " + LastName + " ID: " + ID; } }
        public DateTime BirthDate { get; set; }
        public int? NannyAge { get { if (DateTime.Today.Year - BirthDate.Year == 0) return 0; else return DateTime.Today.Year - BirthDate.Year; } set { } }
        public int? PhoneNumber { get; set; }
        public string Address { get; set; }
        public bool Elevator { get; set; }
        public int? Floor { get; set; }
        public int? Seniority { get; set; }
        public int? Children { get; set; }
        public int? MaxChildren { get; set; }
        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }
        public bool IsHourlyFee { get; set; }
        public int? HourlyFee { get; set; }
        public int? MonthlyFee { get; set; }
        public bool[] IsWork { get; set; }
        public TimeSpan[][] WorkHours { get; set; }
        public bool IsValidVacationDays { get; set; }
        public string Recommendations { get; set; }

        public int? HoursValue { get; set; }
        public int? DaysValue { get; set; }
        public int? SeniorityValue { get; set; }
        public int? DistanceValue { get; set; }
        public int? ElevatorValue { get; set; }
        public int? FloorValue { get; set; }
        public int? SumValue { get; set; }

        // constractor
        public Nanny()
        {
            BirthDate = DateTime.Now.AddYears(-18);
            IsWork = new bool[6] { false, false, false, false, false, false };
            WorkHours = new TimeSpan[2][]
            {
                new TimeSpan[6]{ new TimeSpan(0, 0, 0) , new TimeSpan(0,0,0) , new TimeSpan(0,0,0) , new TimeSpan(0,0,0) , new TimeSpan(0,0,0) , new TimeSpan(0,0,0) },
                new TimeSpan[6]{ new TimeSpan(0,0,0), new TimeSpan(0,0,0) , new TimeSpan(0,0,0) , new TimeSpan(0,0,0) , new TimeSpan(0,0,0) , new TimeSpan(0,0,0) }
            };
        }

        //override
        public override string ToString()
        {
            return FullNameAndID;
        }

        public void Print()
        {
            string dayWorkHors = "";
            for (int i = 0; i < 6; i++)
            {

                dayWorkHors += ((Days)i).ToString() + ": ";
                if (IsWork[i] == true)
                    dayWorkHors += WorkHours[0][i] + " - " + WorkHours[1][i] + '\n' + '\t';
                else
                    dayWorkHors += "don't work \n \t";

            }
            Console.WriteLine("ID: " + ID + '\n' +
                    "name: " + FirstName + " " + LastName + '\n' +
                    "birth date: " + BirthDate.ToShortDateString() + '\n' +
                    "age: " + NannyAge + '\n' +
                    "phon number: 0" + PhoneNumber + '\n' +
                    "address: " + Address + '\n' +
                    "elevator: " + Elevator + '\n' +
                    "floor: " + Floor + '\n' +
                    "seniority: " + Seniority + '\n' +
                    "children: " + Children + '\n' +
                    "max children: " + MaxChildren + '\n' +
                    "min age: " + MinAge + '\n' +
                    "max age: " + MaxAge + '\n' +
                    "is hourly fee: " + IsHourlyFee + '\n' +
                    "hourly fee: " + HourlyFee + '\n' +
                    "monthly fee: " + MonthlyFee + '\n' +
                    "day and hours work: \n \t" + dayWorkHors +
                    "valid vacation days: " + IsValidVacationDays + '\n' +
                    "recomendations: " + Recommendations + '\n');
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Nanny nanny = obj as Nanny;
            if (nanny == null) return false;
            return ID == nanny.ID;
        }


        /// <summary>
        /// clone nanny
        /// </summary>
        /// <returns>clone nanny object</returns>
        public Nanny Clone()
        {
            Nanny nanny = (Nanny)MemberwiseClone();
            nanny.IsWork = (bool[])IsWork.Clone();
            nanny.WorkHours = (TimeSpan[][])WorkHours.Clone();
            return nanny;
        }

        public string FullName()
        {
            return FirstName + " " + LastName;
        }

        /// <summary>
        /// explicit converter from BE.nanny to DO.nanny
        /// </summary>
        public static explicit operator DO.Nanny(Nanny nanny)
        {
            if (nanny != null)
            {
                return new DO.Nanny
                {
                    ID = nanny.ID,
                    LastName = nanny.LastName,
                    FirstName = nanny.FirstName,
                    BirthDate = nanny.BirthDate,
                    NannyAge = nanny.NannyAge,
                    PhoneNumber = nanny.PhoneNumber,
                    Address = nanny.Address,
                    Elevator = nanny.Elevator,
                    Floor = nanny.Floor,
                    Seniority = nanny.Seniority,
                    Children = nanny.Children,
                    MaxChildren = nanny.MaxChildren,
                    MinAge = nanny.MinAge,
                    MaxAge = nanny.MaxAge,
                    IsHourlyFee = nanny.IsHourlyFee,
                    HourlyFee = nanny.HourlyFee,
                    MonthlyFee = nanny.MonthlyFee,
                    IsWork = (bool[])nanny.IsWork.Clone(),
                    WorkHours = (TimeSpan[][])nanny.WorkHours.Clone(),
                    IsValidVacationDays = nanny.IsValidVacationDays,
                    Recommendations = nanny.Recommendations
                };
            }
            return null;
        }

        /// <summary>
        /// explicit converter DO.nanny from to  BE.nanny
        /// </summary>
        public static explicit operator Nanny(DO.Nanny nanny)
        {
            if (nanny != null)
            {
                return new Nanny
                {
                    ID = nanny.ID,
                    LastName = nanny.LastName,
                    FirstName = nanny.FirstName,
                    BirthDate = nanny.BirthDate,
                    NannyAge = nanny.NannyAge,
                    PhoneNumber = nanny.PhoneNumber,
                    Address = nanny.Address,
                    Elevator = nanny.Elevator,
                    Floor = nanny.Floor,
                    Seniority = nanny.Seniority,
                    Children = nanny.Children,
                    MaxChildren = nanny.MaxChildren,
                    MinAge = nanny.MinAge,
                    MaxAge = nanny.MaxAge,
                    IsHourlyFee = nanny.IsHourlyFee,
                    HourlyFee = nanny.HourlyFee,
                    MonthlyFee = nanny.MonthlyFee,
                    IsWork = (bool[])nanny.IsWork.Clone(),
                    WorkHours = (TimeSpan[][])nanny.WorkHours.Clone(),
                    IsValidVacationDays = nanny.IsValidVacationDays,
                    Recommendations = nanny.Recommendations
                };
            }
            return null;
        }
    }
}
