using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Child
    {
        public int ID { get; }
        public int MotherID { get; }
        public string FirstName { get; }
        public string BirthDate { get; }
        public int AgeInMonth { get; }
        public bool IsSpecialNeeds { get; }
        public string SpecialNeeds { get; }
        public bool HaveNanny { get; }
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

        public Child(int id) { ID = id; }
    }
}
