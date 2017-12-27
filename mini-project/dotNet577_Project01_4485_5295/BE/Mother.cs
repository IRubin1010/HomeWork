﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Mother
    {
        public int ID { get; }
        public string LastName { get; }
        public string FirstName { get; }
        public int PhoneNumber { get; }
        public string Address { get; }
        public string SearchAreaForNanny { get; }
        public bool WantElevator { get; }
        public int MinSeniority { get; }
        public int MaxFloor { get; }
        public bool[] NeedNanny;
        public TimeSpan[,] NeedNannyHours = new TimeSpan[2, 6];
        public string Remarks { get; }

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