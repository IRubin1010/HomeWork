using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Child
    {
        //Properties//
        private int? id;
        public int? ID { get { return id; } set { if (value >= 100000000 && value <= 999999999) id = value; else throw new ArgumentException("iligell ID"); } }
        public int? MotherID { get; set; }
        public string FirstName { get; set; }
        public string NameAndID { get { return FirstName + " ID: " + ID; } }
        public DateTime BirthDate { get; set; }
        public int? AgeInMonth { get { if (DateTime.Today.Month - BirthDate.Month == 0) return null; else return (DateTime.Today.Year - BirthDate.Year) * 12 + DateTime.Today.Month - BirthDate.Month; } set { } }
        public bool IsSpecialNeeds { get; set; }
        public string SpecialNeeds { get; set; }
        public bool HaveNanny { get; set; }

        public Child()
        {
            BirthDate = DateTime.Today;
        }

        //override//

        public override string ToString()
        {
            return NameAndID;
        }

        public string Print()
        {
            string needs = "";
            if (IsSpecialNeeds)
                needs += "is special needs: " + IsSpecialNeeds + '\n' + '\t' + SpecialNeeds;
            else
                needs += "is special needs: " + IsSpecialNeeds;
            return "ID: " + ID + '\n' +
                    "mother ID: " + MotherID + '\n' +
                    "name: " + FirstName + '\n' +
                    "birth date: " + BirthDate.ToShortDateString() + '\n' +
                    "age in month: " + AgeInMonth + '\n' +
                    needs + '\n' +
                    "have nanny: " + HaveNanny + '\n';
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Child child = obj as Child;
            if (child == null) return false;
            return this.ID == child.ID;
        }

        /// <summary>
        /// clone child
        /// </summary>
        /// <returns>clone child object</returns>
        public Child Clone()
        {
            return (Child)MemberwiseClone();
        }

    }
}
