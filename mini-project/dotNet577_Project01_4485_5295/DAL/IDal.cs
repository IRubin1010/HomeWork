using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public interface IDAL
    {
        // Nanny
        void AddNanny(Nanny nanny);
        void DeleteNanny(Nanny nanny);
        void DeleteNanny(int id);
        void UpdateNanny(Nanny nanny);
        bool FindNanny(Nanny nanny);
        Nanny FindNanny(int id);
        void UpdateNannyChildren(Nanny nanny, int num);

        // Mother
        void AddMother(Mother mother);
        void DeleteMother(Mother mother);
        void DeleteMother(int id);
        void UpdateMother(Mother mother);
        bool FindMother(Mother mother);
        Mother FindMother(int id);

        // Child
        void AddChild(Child child);
        void DeleteChild(Child child);
        void DeleteChild(int id);
        void UpdateChild(Child child);
        bool FindChild(Child child);
        Child FindChild(int id);
        void UpdateHaveNanny(Child child, bool change);

        // Contract
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

        List<Nanny> NannyList();
        List<Mother> MotherList();
        List<Child> ChildList();
        List<Contract> ContractList();


    }
}
