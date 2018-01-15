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
        public int? ID { get; set; }
        public int? MotherID { get; set; }
        public string FirstName { get; set; }
        public string NameAndID { get { return FirstName + " ID: " + ID; } }
        public DateTime BirthDate { get; set; }
        public int? AgeInMonth { get; set; }
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
