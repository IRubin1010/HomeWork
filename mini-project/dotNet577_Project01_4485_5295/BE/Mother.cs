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
            string needNannyDaysAndHours = "";
            for (int i = 0; i < 6; i++)
            {
                switch (i)
                {
                    case 0:
                        needNannyDaysAndHours += "Sunday: ";
                        if (NeedNanny[i] == true)
                            needNannyDaysAndHours += NeedNannyHours[0, i] + " - " + NeedNannyHours[1, i] + '\n' + '\t';
                        else
                            needNannyDaysAndHours += "don't need nanny \n \t";
                        break;
                    case 1:
                        needNannyDaysAndHours += "Monday: ";
                        if (NeedNanny[i] == true)
                            needNannyDaysAndHours += NeedNannyHours[0, i] + " - " + NeedNannyHours[1, i] + '\n' + '\t';
                        else
                            needNannyDaysAndHours += "don't work \n \t";
                        break;
                    case 2:
                        needNannyDaysAndHours += "Tuesday: ";
                        if (NeedNanny[i] == true)
                            needNannyDaysAndHours += NeedNannyHours[0, i] + " - " + NeedNannyHours[1, i] + '\n' + '\t';
                        else
                            needNannyDaysAndHours += "don't work \n \t";
                        break;
                    case 3:
                        needNannyDaysAndHours += "Wednesday: ";
                        if (NeedNanny[i] == true)
                            needNannyDaysAndHours += NeedNannyHours[0, i] + " - " + NeedNannyHours[1, i] + '\n' + '\t';
                        else
                            needNannyDaysAndHours += "don't work \n \t";
                        break;
                    case 4:
                        needNannyDaysAndHours += "Thursday: ";
                        if (NeedNanny[i] == true)
                            needNannyDaysAndHours += NeedNannyHours[0, i] + " - " + NeedNannyHours[1, i] + '\n' + '\t';
                        else
                            needNannyDaysAndHours += "don't work \n \t";
                        break;
                    case 5:
                        needNannyDaysAndHours += "Friday: ";
                        if (NeedNanny[i] == true)
                            needNannyDaysAndHours += NeedNannyHours[0, i] + " - " + NeedNannyHours[1, i];
                        else
                            needNannyDaysAndHours += "don't work";
                        break;
                    default:
                        break;
                }
            }
            return "ID: " + ID + '\n' +
                    "name: " + FirstName + " " + LastName + '\n' +
                    "phon number: 0" + PhoneNumber + '\n' +
                    "address: " + Address + '\n' +
                    "search area for nanny: " + SearchAreaForNanny + '\n' +
                    "want elevator: " + WantElevator + '\n' +
                    "minimum seniority: " + MinSeniority + '\n' +
                    "max floor: " + MaxFloor + '\n' +
                    "day and hours work: \n \t" + needNannyDaysAndHours + '\n' +
                    "remarks: " + Remarks + '\n';
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
            mother.NeedNannyHours = (TimeSpan[,])NeedNannyHours.Clone();
            return mother;
        }

        public string FullName()
        {
            return FirstName + " " + LastName;
        }
    }
}
