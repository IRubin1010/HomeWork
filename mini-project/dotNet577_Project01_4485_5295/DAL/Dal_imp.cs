﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;

namespace DAL
{
    sealed class Dal_imp : IDAL
    {
        public static int ContractNumber = 10000000;

        static Dal_imp() { }

        static readonly IDAL instance = new Dal_imp();

        public static IDAL Instance { get { return instance; } }

        // Nanny
        public void AddNanny(Nanny nanny)
        {
            if (!FindNanny(nanny))
            {
                NannyList().Add(nanny.Clone());
            }
            else
                throw new DALException(nanny.FullName() + " already exsist", "Add nanny");
        }

        public void DeleteNanny(Nanny nanny)
        {
            try
            {
                DeleteNanny(nanny.ID);
            }
            catch (DALException ex)
            {
                throw new DALException(nanny.FullName() + " dosn't exsist", ex.sender);
            }
        }

        public void DeleteNanny(int id)
        {
            if (!NannyList().Remove(FindNanny(id)))
                throw new DALException("nanny with ID: " + id + " dosn't exsist", "Delete Nanny");
        }

        public void UpdateNanny(Nanny nanny)
        {
            if (FindNanny(nanny))
            {
                // CHECK IF CAN'T ADD BUT ALREADY REMOVED
                DeleteNanny(nanny);
                try
                {
                    AddNanny(nanny);
                }
                catch (DALException)
                {
                    throw new DALException("can't update " + nanny.FullName() + "details", "update nanny");
                }
            }
            else
                throw new DALException(nanny.FullName() + " dosn't exsist", "update nanny");
        }

        public bool FindNanny(Nanny nanny)
        {
            return FindNanny(nanny.ID) != null;
        }

        public Nanny FindNanny(int id)
        {
            return CloneNannyList().Find(nanny => nanny.ID == id);
        }

        public void UpdateNannyChildren(Nanny nanny, int num)
        {
            if (FindNanny(nanny))
            {
                if (num == 1)
                    NannyList().Find(nan => nan.Equals(nanny)).Children++;
                else
                    NannyList().Find(nan => nan.Equals(nanny)).Children--;
            }
            else
                throw new DALException(nanny.FullName() + " dosn't exsist", "AddNannyChildren");
        }

        // Mother
        public void AddMother(Mother mother)
        {
            if (!FindMother(mother))
            {
                MotherList().Add(mother.Clone());
            }
            else
                throw new DALException(mother.FullName() + " already exsist", "Add mother");
        }

        public void DeleteMother(Mother mother)
        {
            try
            {
                DeleteMother(mother.ID);
            }
            catch (DALException ex)
            {
                throw new DALException(mother.FullName() + " " + ex.Message, ex.sender);
            }
        }

        public void DeleteMother(int id)
        {
            if (!MotherList().Remove(FindMother(id)))
                throw new DALException("dosn't exsist", "Delete Nanny");
        }

        public void UpdateMother(Mother mother)
        {
            if (FindMother(mother))
            {
                // CHECK IF CAN'T ADD BUT ALREADY REMOVED
                DeleteMother(mother);
                try
                {
                    AddMother(mother);
                }
                catch (DALException)
                {
                    throw new DALException("can't update " + mother.FullName(), "update mother");
                }
            }
            else
                throw new DALException(mother.FullName() + " dosn't exsist", "update mother");
        }

        public bool FindMother(Mother mother)
        {
            return FindMother(mother.ID) != null;
        }

        public Mother FindMother(int id)
        {
            return CloneMotherList().Find(moth => moth.ID == id);
        }

        // Child
        public void AddChild(Child child)
        {
            if (!FindChild(child))
            {
                ChildList().Add(child.Clone());
            }
            else
                throw new DALException(child.FirstName + " already exsist", "Add child");
        }

        public void DeleteChild(Child child)
        {
            try
            {
                DeleteChild(child.ID);
            }
            catch (DALException ex)
            {
                throw new DALException(child.FirstName + " " + ex.Message, ex.sender);
            }
        }

        public void DeleteChild(int id)
        {
            if (!ChildList().Remove(FindChild(id)))
                throw new DALException("dosn't exsist", "Delete Nanny");
        }

        public void UpdateChild(Child child)
        {
            if (FindChild(child))
            {
                // CHECK IF CAN'T ADD BUT ALREADY REMOVED
                DeleteChild(child);
                try
                {
                    AddChild(child);
                }
                catch (Exception)
                {
                    throw new DALException("can't update " + child.FirstName, "update child");
                }
            }
            else
                throw new DALException(child.FirstName + " dosn't exsist", "update child");
        }

        public bool FindChild(Child child)
        {
            return FindChild(child.ID) != null;
        }

        public Child FindChild(int id)
        {
            return CloneChildList().Find(chil => chil.ID == id);
        }

        public void UpdateHaveNanny(Child child, bool change)
        {
            Child Child = ChildList().Find(chil => chil.Equals(child));
            if (Child != null)
                Child.HaveNanny = change;
            else
                throw new DALException(child.FirstName + " dosn't exsist", "Update Have Nanny");
        }

        // Contract
        public void AddContract(Contract contract)
        {
            Nanny nanny = FindNanny(contract.NannyID);
            Mother mother = FindMother(contract.MotherID);
            Child child = FindChild(contract.ChildID);
            if (nanny != null)
                if (mother != null)
                    if (child != null)
                        if (FindContract(contract.ContractNumber) == null)
                        {
                            if (contract.ContractNumber == 0)
                                contract.ContractNumber = ContractNumber++;
                            contract.IsContractSigned = true;
                            ContractList().Add(contract.Clone());
                        }
                        else throw new DALException(child.FirstName + " dosn't exsist", "Add contract");
                    else throw new DALException("this contract number already exsist", "Add contract");
                else throw new DALException(mother.FullName() + " dosn't exsist", "Add contract");
            else throw new DALException(nanny.FullName() + " dosn't exsist", "Add contract");
        }

        public void DeleteContract(Contract contract)
        {
            try
            {
                DeleteContract(contract.ContractNumber);
            }
            catch (DALException ex)
            {
                throw new DALException("contract number: " + contract.ContractNumber + " " + ex.Message, ex.sender);
            }
        }

        public void DeleteContract(int contractNumber)
        {
            if (!ContractList().Remove(FindContract(contractNumber)))
                throw new DALException("dosn't exsist", "Delete Nanny");
        }

        public void UpdateContract(Contract contract)
        {
            if (FindContract(contract))
            {
                // CHECK IF CAN'T ADD BUT ALREADY REMOVED
                DeleteContract(contract);
                try
                {
                    AddContract(contract);
                }
                catch (Exception)
                {
                    throw new DALException("can't update contract", "update contract");
                }
            }
            else
                throw new DALException("contract number: " + contract.ContractNumber + " dosn't exsist", "update contract");
        }

        public bool FindContract(Contract contarct)
        {
            return FindContract(contarct.ContractNumber) != null;
        }

        public Contract FindContract(int contractNumber)
        {
            return CloneContractList().Find(contract => contract.ContractNumber == contractNumber);
        }

        // Lists
        public List<Nanny> CloneNannyList()
        {
            return NannyList().Select(nanny => nanny.Clone()).ToList();
        }

        public List<Mother> CloneMotherList()
        {
            return MotherList().Select(mother => mother.Clone()).ToList();
        }

        public List<Child> CloneChildList()
        {
            return ChildList().Select(child => child.Clone()).ToList();
        }

        public List<Contract> CloneContractList()
        {
            return ContractList().Select(contract => contract.Clone()).ToList();
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
