using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;

namespace DAL
{
    public class Dal_imp : IDal
    {
        public static int ContractNumber = 10000000;

        // Nanny
        public bool AddNanny(Nanny nanny)
        {
            if (!FindNanny(nanny))
            {
                NannyList().Add(nanny);
                return true;
            }
            return false;
        }

        public void DeleteNanny(Nanny nanny)
        {
            NannyList().Remove(nanny);
        }

        public void DeleteNanny(int id)
        {
            NannyList().Remove(FindNanny(id));
        }

        public void UpdateNanny(int id)
        {
            Nanny nanny = FindNanny(id);
            if (nanny != null)
            {
                //TO DO
            }
        }

        public void UpdateNanny(Nanny nanny)
        {
            if (FindNanny(nanny))
            {
                //TO DO
            }
        }

        public bool FindNanny(Nanny nanny)
        {
            return FindNanny(nanny.ID) != null;
        }

        public Nanny FindNanny(int id)
        {
            foreach (Nanny item in DataSource.NannyList)
                if (item.ID == id) return item;
            return null;
        }

        // Mother
        public bool AddMother(Mother mother)
        {
            if (!FindMother(mother))
            {
                MotherList().Add(mother);
                return true;
            }
            return false;
        }

        public void DeleteMother(int id)
        {
            if (FindMother(id) != null)
                MotherList().Remove(FindMother(id));
        }

        public void DeleteMother(Mother mother)
        {
            if (FindMother(mother))
                MotherList().Remove(mother);
        }

        public void UpdateMother(int id)
        {
            Mother mother = FindMother(id);
            if (mother != null)
            {
                //TO DO
            }

        }

        public void UpdateMother(Mother mother)
        {
            if (FindMother(mother))
            {
                //TO DO
            }

        }

        public bool FindMother(Mother mother)
        {
            return FindMother(mother.ID) != null;
        }

        public Mother FindMother(int id)
        {
            foreach (Mother item in DataSource.MotherList)
                if (item.ID == id) return item;
            return null;
        }

        // Child
        public bool AddChild(Child child)
        {
            if (!FindChild(child))
            {
                ChildList().Add(child);
                return true;
            }
            return false;
        }

        public void DeleteChild(Child child)
        {
            if (FindChild(child))
                ChildList().Remove(child);
        }

        public void DeleteChild(int id)
        {
            if (FindChild(id) != null)
                ChildList().Remove(FindChild(id));
        }

        public void UpdateChild(int id)
        {
            Child child = FindChild(id);
            if (child != null)
            {
                //TO DO
            }
        }

        public void UpdateChild(Child child)
        {
            if (FindChild(child))
            {
                //TO DO
            }
        }

        public bool FindChild(Child child)
        {
            return FindChild(child.ID) != null;
        }

        public Child FindChild(int id)
        {
            foreach (Child item in DataSource.ChildList)
                if (item.ID == id) return item;
            return null;
        }

        // Contract
        public bool AddContract(Contract contract)
        {
            if (FindNanny(contract.NannyID) != null && FindMother(contract.MotherID) != null)
            {
                contract.ContractNumber = ContractNumber++;
                ContractList().Add(contract);
                return true;
            }
            return false;
        }

        public void DeleteContract(Contract contract)
        {
            if (FindContract(contract))
                ContractList().Remove(contract);
        }

        public void DeleteContract(int contractNumber)
        {
            if (FindContract(contractNumber) != null)
                ContractList().Remove(FindContract(contractNumber));
        }

        public void UpdateContract(int contractNumber)
        {
            Contract contract = FindContract(ContractNumber);
            if (contract != null)
            {
                //TO DO
            }
        }

        public void UpdateContract(Contract contract)
        {
            if (FindContract(contract))
            {
                //TO DO
            }
        }

        public bool FindContract(Contract contarct)
        {
            return FindContract(contarct.ContractNumber) != null;
        }

        public Contract FindContract(int contractNumber)
        {
            foreach (Contract contract in DataSource.ContractList)
                if (contract.ContractNumber == contractNumber)  return contract;
            return null;
        }

        // Lists
        public List<Nanny> NannyList()
        {
            return DataSource.NannyList;
        }

        public List<Mother> MotherList()
        {
            return DataSource.MotherList;
        }

        public List<Child> ChildList()
        {
            return DataSource.ChildList;
        }

        public List<Contract> ContractList()
        {
            return DataSource.ContractList;
        }
    }
}
