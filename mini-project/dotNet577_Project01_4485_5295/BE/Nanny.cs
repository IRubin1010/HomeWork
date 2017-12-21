using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Nanny
    {
        public int ID { get; }
        public string LastName { get; }
        public string FirstName { get; }
        public DateTime BirthDate { get; }
        public int NannyAge { get; }
        public int PhoneNumber { get; }
        public string Address { get; }
        public bool Elevator { get; }
        public int Floor { get; }
        public int Seniority { get; }
        public int Children { get; set; }
        public int MaxChildren { get; }
        public int MinAge { get; }
        public int MaxAge { get; }
        public bool IsHourlyFee { get; }
        public int HourlyFee { get; }
        public int MonthlyFee { get; }
        public bool[] IsWork;
        public TimeSpan[,] WorkHours = new TimeSpan[2, 6];
        public bool IsValidVacationDays { get; }
        public string Recommendations { get; }

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

        public Nanny(int id, int age, string address, bool elevator,int floor)
        {
            ID = id;
            NannyAge = age;
            Address = address;
            Elevator = elevator;
            Floor = floor;
        }
    }
}
