using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public enum Days
    { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday };

    public class Mother
    {
        // Properties
        private int? id;
        public int? ID { get { return id; } set { if (value >= 100000000 && value <= 999999999) id = value; else { id = 0; throw new ArgumentException("iligell ID"); } } }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string FullNameAndID { get { return FirstName + " " + LastName + " ID: " + ID; } }
        public int? PhoneNumber { get; set; }
        public string Address { get; set; }
        public string SearchAreaForNanny { get; set; }
        public bool WantElevator { get; set; }
        public int? MinSeniority { get; set; }
        public int? MaxFloor { get; set; }
        public bool[] NeedNanny { get; set; }
        public TimeSpan[][] NeedNannyHours { get; set; }
        public string Remarks { get; set; }

        // constractor
        public Mother()
        {
            NeedNanny = new bool[6] { false, false, false, false, false, false };
            NeedNannyHours = new TimeSpan[2][]
            {
                new TimeSpan[6]{ new TimeSpan(0,0,0), new TimeSpan(0,0,0) , new TimeSpan(0,0,0) , new TimeSpan(0,0,0) , new TimeSpan(0,0,0) , new TimeSpan(0,0,0) },
                new TimeSpan[6]{ new TimeSpan(0,0,0), new TimeSpan(0,0,0) , new TimeSpan(0,0,0) , new TimeSpan(0,0,0) , new TimeSpan(0,0,0) , new TimeSpan(0,0,0) }
            };
        }

        // override
        public override string ToString()
        {
            return FullNameAndID;
        }

        public void Print()
        {
            string needNannyDaysAndHours = "";
            for (int i = 0; i < 6; i++)
            {
                needNannyDaysAndHours += ((Days)i).ToString() + ": ";
                if (NeedNanny[i] == true)
                    needNannyDaysAndHours += NeedNannyHours[0][i] + " - " + NeedNannyHours[1][i] + '\n' + '\t';
                else
                    needNannyDaysAndHours += "don't need nanny \n \t";
            }
            Console.WriteLine("ID: " + ID + '\n' +
                    "name: " + FirstName + " " + LastName + '\n' +
                    "phon number: 0" + PhoneNumber + '\n' +
                    "address: " + Address + '\n' +
                    "search area for nanny: " + SearchAreaForNanny + '\n' +
                    "want elevator: " + WantElevator + '\n' +
                    "minimum seniority: " + MinSeniority + '\n' +
                    "max floor: " + MaxFloor + '\n' +
                    "day and hours work: \n \t" + needNannyDaysAndHours + '\n' +
                    "remarks: " + Remarks + '\n');
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Mother mother = obj as Mother;
            if (mother == null) return false;
            return this.ID == mother.ID;
        }

        /// <summary>
        /// clone mother
        /// </summary>
        /// <returns>clone mother object</returns>
        public Mother Clone()
        {
            Mother mother = (Mother)MemberwiseClone();
            mother.NeedNanny = (bool[])NeedNanny.Clone();
            mother.NeedNannyHours = (TimeSpan[][])NeedNannyHours.Clone();
            return mother;
        }

        public string FullName()
        {
            return FirstName + " " + LastName;
        }

        /// <summary>
        /// explicit converter from BE.mother to DO.mother
        /// </summary>
        public static explicit operator DO.Mother(Mother mother)
        {
            if (mother != null)
            {
                return new DO.Mother
                {
                    ID = mother.ID,
                    LastName = mother.LastName,
                    FirstName = mother.FirstName,
                    PhoneNumber = mother.PhoneNumber,
                    Address = mother.Address,
                    SearchAreaForNanny = mother.SearchAreaForNanny,
                    WantElevator = mother.WantElevator,
                    MinSeniority = mother.MinSeniority,
                    MaxFloor = mother.MaxFloor,
                    NeedNanny = (bool[])mother.NeedNanny.Clone(),
                    NeedNannyHours = (TimeSpan[][])mother.NeedNannyHours.Clone(),
                    Remarks = mother.Remarks
                };
            }
            return null;
        }

        /// <summary>
        /// explicit converter from DO.mother to BE.mother
        /// </summary>
        public static explicit operator Mother(DO.Mother mother)
        {
            if (mother != null)
            {
                return new Mother
                {
                    ID = mother.ID,
                    LastName = mother.LastName,
                    FirstName = mother.FirstName,
                    PhoneNumber = mother.PhoneNumber,
                    Address = mother.Address,
                    SearchAreaForNanny = mother.SearchAreaForNanny,
                    WantElevator = mother.WantElevator,
                    MinSeniority = mother.MinSeniority,
                    MaxFloor = mother.MaxFloor,
                    NeedNanny = (bool[])mother.NeedNanny.Clone(),
                    NeedNannyHours = (TimeSpan[][])mother.NeedNannyHours.Clone(),
                    Remarks = mother.Remarks
                };
            }
            return null;
        }
    }
}
