using System;
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

        // implement for singelton
        static Dal_imp() { }

        static readonly IDAL instance = new Dal_imp();

        public static IDAL Instance { get { return instance; } }

        /* Nanny functions */

        // add nanny
        // if find the nanny on the list - this nanny already exsist throw exception
        public void AddNanny(Nanny nanny)
        {
            if (!FindNanny(nanny))
            {
                NannyList().Add(nanny.Clone());
            }
            else
                throw new DALException(nanny.FullName() + " already exsist", "Add nanny");
        }

        // delete nanny
        // accept nanny and send to DeleteNanny(int id) function nanny's id 
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

        // delete nanny
        // if didn't find to remove, throw exception
        public void DeleteNanny(int id)
        {
            if (!NannyList().Remove(FindNanny(id)))
                throw new DALException("nanny with ID: " + id + " dosn't exsist", "Delete Nanny");
        }

        // update nanny
        // accept nanny, delete the old nanny and replace it with the new nanny
        // if didn't find the nannyto delete, or can't add the new nanny throw exception
        public void UpdateNanny(Nanny nanny)
        {
            if (FindNanny(nanny))
            {
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

        // find nanny
        // accept nanny and send to FindNanny(int id) function with nanny id 
        // return true if find, else return false
        public bool FindNanny(Nanny nanny)
        {
            return FindNanny(nanny.ID) != null;
        }

        // find nanny
        // accept nanny id, return nanny if find, else return null
        public Nanny FindNanny(int id)
        {
            return CloneNannyList().Find(nanny => nanny.ID == id);
        }

        // update the numabr of nanny's children
        // accept nanny and a number
        // if number = 1, add 1 to nanny's children
        // else reduce nanny's children by 1
        // if didn't find the nanny throw exception
        public void UpdateNannyChildren(Nanny nanny, int num)
        {
            if (FindNanny(nanny))
            {
                if (num == 1)
                    // add 1
                    NannyList().Find(nan => nan.Equals(nanny)).Children++;
                else
                    //reduce by 1
                    NannyList().Find(nan => nan.Equals(nanny)).Children--;
            }
            else
                throw new DALException(nanny.FullName() + " dosn't exsist", "AddNannyChildren");
        }

        /* mother functions */

        // add mother
        // if find the mother on the list - this nanny already exsist throw exception
        public void AddMother(Mother mother)
        {
            if (!FindMother(mother))
            {
                MotherList().Add(mother.Clone());
            }
            else
                throw new DALException(mother.FullName() + " already exsist", "Add mother");
        }

        // delete mother
        // accept mother and send to DeleteMother(int id) function mother's id 
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

        // delete mother
        // if didn't find to remove, throw exception
        public void DeleteMother(int id)
        {
            if (!MotherList().Remove(FindMother(id)))
                throw new DALException("dosn't exsist", "Delete Nanny");
        }

        // update mother
        // accept mother, delete the old mother and replace it with the new mother
        // if didn't find the mother to delete, or can't add the new mother throw exception
        public void UpdateMother(Mother mother)
        {
            if (FindMother(mother))
            {
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

        // find mother
        // accept momther and send to FindMother(int id) function with mother id 
        // return true if find, else return false
        public bool FindMother(Mother mother)
        {
            return FindMother(mother.ID) != null;
        }

        // find mother
        // accept mother id, return mother if find, else return null
        public Mother FindMother(int id)
        {
            return CloneMotherList().Find(moth => moth.ID == id);
        }

        /* Child functions */

        // add child
        // if find the child on the list - this child already exsist throw exception
        public void AddChild(Child child)
        {
            if (!FindChild(child))
            {
                ChildList().Add(child.Clone());
            }
            else
                throw new DALException(child.FirstName + " already exsist", "Add child");
        }

        // delete child
        // accept child and send to DeleteChild(int id) function child's id 
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

        // delete child
        // if didn't find to remove, throw exception
        public void DeleteChild(int id)
        {
            if (!ChildList().Remove(FindChild(id)))
                throw new DALException("dosn't exsist", "Delete Nanny");
        }

        // update child
        // accept child, delete the old child and replace it with the new child
        // if didn't find the child to delete, or can't add the new child throw exception
        public void UpdateChild(Child child)
        {
            if (FindChild(child))
            {
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

        // find child
        // accept child and send to FindChild(int id) function with child id 
        // return true if find, else return false
        public bool FindChild(Child child)
        {
            return FindChild(child.ID) != null;
        }

        // find child
        // accept child id, return child if find, else return null
        public Child FindChild(int id)
        {
            return CloneChildList().Find(chil => chil.ID == id);
        }

        // update if the child has nanny
        // accept child and bool parameter - of what to change
        // get the child, if find the child change the "have nanny" parameter - according to 'change'
        //                else throw exception  
        public void UpdateHaveNanny(Child child, bool change)
        {
            Child Child = ChildList().Find(chil => chil.Equals(child));
            if (Child != null)
                Child.HaveNanny = change;
            else
                throw new DALException(child.FirstName + " dosn't exsist", "Update Have Nanny");
        }

        /* contract functions */

        // add contract
        // accept contract, give the contract a number and add to contract list
        // check that - nanny, mother and child exsist 
        // check also that there this contract dosn't already exsist
        // throw exceptions accordingly
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
                            // if the contract number equals 0, give a new contract number
                            // if contract number is not 0 - means this is an update contract,
                            // don't give a new contract number
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

        // delete contract
        // accept contract and send to DeleteContract(int id) function contract's number 
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

        // delete contract
        // if didn't find to remove, throw exception
        public void DeleteContract(int contractNumber)
        {
            if (!ContractList().Remove(FindContract(contractNumber)))
                throw new DALException("dosn't exsist", "Delete Nanny");
        }

        // update contract
        // accept contract, delete the old contract and replace it with the new contract
        // if didn't find the contract to delete, or can't add the new contract throw exception
        public void UpdateContract(Contract contract)
        {
            if (FindContract(contract))
            {
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

        // find contract
        // accept contract and send to FindContract(int id) function with contract's nunmber 
        // return true if find, else return false
        public bool FindContract(Contract contarct)
        {
            return FindContract(contarct.ContractNumber) != null;
        }

        // find contract
        // accept contract id, return contract if find, else return null
        public Contract FindContract(int contractNumber)
        {
            return CloneContractList().Find(contract => contract.ContractNumber == contractNumber);
        }

        /* list return functions */ 
        
        // return a list of clone nanny objects
        public List<Nanny> CloneNannyList()
        {
            return NannyList().Select(nanny => nanny.Clone()).ToList();
        }

        // return a list of clone mother objects
        public List<Mother> CloneMotherList()
        {
            return MotherList().Select(mother => mother.Clone()).ToList();
        }

        // return a list of clone child objects
        public List<Child> CloneChildList()
        {
            return ChildList().Select(child => child.Clone()).ToList();
        }

        // return a list of clone contract objects
        public List<Contract> CloneContractList()
        {
            return ContractList().Select(contract => contract.Clone()).ToList();
        }

        // return a List of the original nanny objects
        public List<Nanny> NannyList()
        {
            return DataSource.NannyList;
        }

        // return a List of the original mother objects
        public List<Mother> MotherList()
        {
            return DataSource.MotherList;
        }

        // return a List of the original child objects
        public List<Child> ChildList()
        {
            return DataSource.ChildList;
        }

        // return a List of the original contract objects
        public List<Contract> ContractList()
        {
            return DataSource.ContractList;
        }
    }
}
