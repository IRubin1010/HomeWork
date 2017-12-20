using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    interface IDal
    {
        bool AddNanny(Nanny nanny);
        void DeleteNanny(Nanny nanny);
        void DeleteNanny(int id);
        void UpdateNanny(int id);
        void UpdateNanny(Nanny nanny);
        Nanny FindNanny(Nanny nanny);
        Nanny FindNanny(int id);

        bool AddMother(Mother mother);
        void DeleteMother(Mother mother);
        void DeleteMother(int id);
        void UpdateMother(int id);
        void UpdateMother(Mother mother);
        Mother FindMother(Mother mother);
        Mother FindMother(int id);

        bool AddChild(Child child);
        void DeleteChild(Child child);
        void DeleteChild(int id);
        void UpdateChild(int id);
        void UpdateChild(Child child);
        Child FindChild(Child child);
        Child FindChild(int id);

        bool AddContract(Contract contract);
        void DeleteContract(Contract contract);
        void DeleteContract(int contractNumber);
        void UpdateContract(int contractNumber);
        void UpdateContract(Contract contract);
        Contract FindContract(Contract contract);
        Contract FindContract(int contractNumber);

        List<Nanny> NannyList();
        List<Mother> MotherList();
        List<Child> ChildList();
        List<Contract> ContractList();
    }
}
