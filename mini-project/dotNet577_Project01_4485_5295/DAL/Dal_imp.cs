using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;

namespace DAL
{
    public class Dal_imp :IDal
    {
        public static int ContractNumber = 10000000;

        public bool AddNanny(Nanny nanny)
        {
            if (FindNanny(nanny) == null)
            {
                DataSource.NannyList.Add(nanny);
                return true;
            }
            return false;
        }

        public void DeleteNanny(Nanny nanny)
        {
            DataSource.NannyList.Remove(nanny);
        }

        public void DeleteNanny(int id)
        {
            if (FindNanny(id) != null)
                DeleteNanny(FindNanny(id));

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
            if (FindNanny(nanny) != null)
            {
                //TO DO
            }
        }

        public Nanny FindNanny(Nanny nanny)
        {
            return FindNanny(nanny.ID);
        }

        public Nanny FindNanny(int id)
        {
            foreach (Nanny item in DataSource.NannyList)
            {
                if (item.ID == id)
                    return item;
            }
            return null;
        }

        public bool AddMother(Mother mother)
        {
            if (FindMother(mother) == null)
            {
                DataSource.MotherList.Add(mother);
                return true;
            }
            return false;
        }

        public void DeleteMother(int id)
        {
            if (FindMother(id) != null)
                DataSource.MotherList.Remove(FindMother(id));
        }

        public void DeleteMother(Mother mother)
        {
            if (FindMother(mother) != null)
                DataSource.MotherList.Remove(mother);
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
            if (FindMother(mother) != null)
            {
                //TO DO
            }

        }

        public Mother FindMother(Mother mother)
        {
            return FindMother(mother.ID);
        }

        public Mother FindMother(int id)
        {
            foreach (Mother item in DataSource.MotherList)
            {
                if (item.ID == id)
                    return item;
            }
            return null;
        }

        public bool AddChild(Child child)
        {
            if (FindChild(child) == null)
            {
                DataSource.ChildList.Add(child);
                return true;
            }
            return false;
        }

        public void DeleteChild(Child child)
        {
            if (FindChild(child) != null)
                DataSource.ChildList.Remove(child);
        }

        public void DeleteChild(int id)
        {
            if (FindChild(id) != null)
                DataSource.ChildList.Remove(FindChild(id));
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
            if (FindChild(child) != null)
            {
                //TO DO
            }
        }

        public Child FindChild(Child child)
        {
            return FindChild(child.ID);
        }

        public Child FindChild(int id)
        {
            foreach (Child item in DataSource.ChildList)
            {
                if (item.ID == id)
                    return item;
            }
            return null;
        }

        public bool AddContract(Contract contract)
        {
            if (FindNanny(contract.NannyID) != null && FindMother(contract.MotherID) != null)
            {
                contract.ContractNumber = ContractNumber++;
                DataSource.ContractList.Add(contract);
                return true;
            }
            return false;
        }

        public void DeleteContract(Contract contract)
        {
            if (FindContract(contract) != null)
                DataSource.ContractList.Remove(contract);
        }

        public void DeleteContract(int contractNumber)
        {
            if (FindContract(contractNumber) != null)
                DataSource.ContractList.Remove(FindContract(contractNumber));
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
            if (FindContract(contract) != null)
            {
                //TO DO
            }
        }

        public Contract FindContract(Contract contarct)
        {
            return FindContract(contarct.ContractNumber);
        }

        public Contract FindContract(int contractNumber)
        {
            foreach (Contract contract in DataSource.ContractList)
            {
                if (contract.ContractNumber == contractNumber)
                    return contract;
            }
            return null;
        }

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
