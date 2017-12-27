using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Child
    {
        public int ID { get; set; }
        public int MotherID { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public int AgeInMonth { get; set; }
        public bool IsSpecialNeeds { get; set; }
        public string SpecialNeeds { get; set; }
        public bool HaveNanny { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Child child = obj as Child;
            if (child == null) return false;
            return this.ID == child.ID;
        }

        public Child Clone()
        {
            return (Child)MemberwiseClone();
        }

    }
}
