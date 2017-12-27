using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Nanny
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public int NannyAge { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public bool Elevator { get; set; }
        public int Floor { get; set; }
        public int Seniority { get; set; }
        public int Children { get; set; }
        public int MaxChildren { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public bool IsHourlyFee { get; set; }
        public int HourlyFee { get; set; }
        public int MonthlyFee { get; set; }
        public bool[] IsWork;
        public TimeSpan[,] WorkHours;
        public bool IsValidVacationDays { get; set; }
        public string Recommendations { get; set; }

        public int HoursValue { get; set; }
        public int DaysValue { get; set; }
        public int SeniorityValue { get; set; }
        public int DistanceValue { get; set; }
        public int ElevatorValue { get; set; }
        public int FloorValue { get; set; }
        public int SumValue { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Nanny nanny = obj as Nanny;
            if (nanny == null) return false;
            return this.ID == nanny.ID;
        }

        public Nanny Clone()
        {
            Nanny nanny = (Nanny)MemberwiseClone();
            nanny.BirthDate = new DateTime(BirthDate.Year,BirthDate.Month,BirthDate.Day);
            for (int i = 0; i < 6; i++)
            {
                nanny.WorkHours[0, i] = new TimeSpan(WorkHours[0, i].Hours, WorkHours[0, i].Minutes, WorkHours[0, i].Seconds);
                nanny.WorkHours[1, i] = new TimeSpan(WorkHours[1, i].Hours, WorkHours[1, i].Minutes, WorkHours[1, i].Seconds);
            }
            return nanny;
        }

        public string FullName()
        {
            return FirstName + " " + LastName;
        }
    }
}
