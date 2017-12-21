using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    interface IBl
    {
        bool AddNanny(Nanny nanny);
        void DeleteNanny(Nanny nanny);
        void DeleteNanny(int id);
        void UpdateNanny(int id);
        void UpdateNanny(Nanny nanny);
        bool FindNanny(Nanny nanny);
        Nanny FindNanny(int id);

        bool AddMother(Mother mother);
        void DeleteMother(Mother mother);
        void DeleteMother(int id);
        void UpdateMother(int id);
        void UpdateMother(Mother mother);
        bool FindMother(Mother mother);
        Mother FindMother(int id);

        bool AddChild(Child child);
        void DeleteChild(Child child);
        void DeleteChild(int id);
        void UpdateChild(int id);
        void UPdateChild(Child child);
        bool FindChild(Child child);
        Child FindChild(int id);

        bool AddContract(Contract contract);
        void DeleteContract(Contract contract);
        void DeleteContract(int contractNumber);
        void UpdateContract(int contractNumber);
        void UpdateContract(Contract contract);
        bool FindContract(Contract contract);
        Contract FindContract(int contractNumber);

        List<Nanny> NannyList();
        List<Mother> MotherList();
        List<Child> ChildList();
        List<Contract> ContractList();

        int Distance(string addressA, string addressB);
        List<Nanny> PotentialMatch(Mother mother);
        bool PotentialHoursMatch(Nanny nanny, Mother mother);
        bool PotentialDaysMatch(Nanny nanny, Mother mother);
        List<Nanny> MotherConditions(Mother mother);
        bool IsNannyInKM(Mother mother, Nanny nanny, int Km);
        List<Nanny> NannysInKM(Mother mother, int Km);
        void PropertiesMatch(Mother mother, int Km);
        List<Nanny> PartialMatch(Mother mother, int Km);
        List<Child> ChildrenWithNoNanny();
        List<Nanny> ValidVacationsNannys();
        List<Contract> SpesificsContracts(Func<Contract, bool> contractCondition);
        int NumOfSpesificsContracts(Func<Contract, bool> contractCondition);
    }
}
