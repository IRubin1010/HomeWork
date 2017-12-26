using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    public interface IBL
    {
        void AddNanny(Nanny nanny);
        void DeleteNanny(Nanny nanny);
        void DeleteNanny(int id);
        void UpdateNanny(Nanny nanny);
        bool FindNanny(Nanny nanny);
        Nanny FindNanny(int id);

        void AddMother(Mother mother);
        void DeleteMother(Mother mother);
        void DeleteMother(int id);
        void UpdateMother(Mother mother);
        bool FindMother(Mother mother);
        Mother FindMother(int id);

        void AddChild(Child child);
        void DeleteChild(Child child);
        void DeleteChild(int id);
        void UpdateChild(Child child);
        bool FindChild(Child child);
        Child FindChild(int id);

        void AddContract(Contract contract);
        void DeleteContract(Contract contract);
        void DeleteContract(int contractNumber);
        void UpdateContract(Contract contract);
        bool FindContract(Contract contract);
        Contract FindContract(int contractNumber);

        List<Nanny> CloneNannyList();
        List<Mother> CloneMotherList();
        List<Child> CloneChildList();
        List<Contract> CloneContractList();

        int Distance(string addressA, string addressB);
        List<Nanny> PotentialMatch(Mother mother);
        bool PotentialHoursMatch(Nanny nanny, Mother mother);
        bool PotentialDaysMatch(Nanny nanny, Mother mother);
        List<Nanny> MotherConditions(Mother mother);
        bool IsNannyInKM(Mother mother, Nanny nanny, int Km);
        List<Nanny> NannysInKMWithConditions(Mother mother, int Km);
        List<Nanny> PropertiesMatch(Mother mother, int Km);
        List<Nanny> PartialMatch(Mother mother, int Km);
        List<Child> ChildrenWithNoNanny();
        List<Nanny> ValidVacationsNannys();
        List<Contract> SpesificsContracts(Func<Contract, bool> contractCondition);
        int NumOfSpesificsContracts(Func<Contract, bool> contractCondition);

        //Gouping
        IEnumerable<IGrouping<int, Nanny>> GruopNannyByChildAge(bool descendig, bool ordered = false);
    }
}
