using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Mother
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public string SearchAreaForNanny { get; set; }
        public bool WantElevator { get; set; }
        public int MinSeniority { get; set; }
        public int MaxFloor { get; set; }
        public bool[] NeedNanny;
        public TimeSpan[,] NeedNannyHours;
        public string Remarks { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Mother mother = obj as Mother;
            if (mother == null) return false;
            return this.ID == mother.ID;
        }

        public Mother Clone()
        {
            Mother mother = (Mother)MemberwiseClone();
            for (int i = 0; i < 6; i++)
            {
                mother.NeedNannyHours[0, i] = new TimeSpan(NeedNannyHours[0, i].Hours, NeedNannyHours[0, i].Minutes, NeedNannyHours[0, i].Seconds);
                mother.NeedNannyHours[1, i] = new TimeSpan(NeedNannyHours[1, i].Hours, NeedNannyHours[1, i].Minutes, NeedNannyHours[1, i].Seconds);
            }
            return mother;
        }

        public string FullName()
        {
            return FirstName + " " + LastName;
        }
    }
}
