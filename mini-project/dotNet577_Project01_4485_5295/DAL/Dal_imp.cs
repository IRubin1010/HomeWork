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
        public static int? ContractNumber = 10000000;

        // implement for singelton
        static Dal_imp() { }

        static readonly IDAL instance = new Dal_imp();

        public static IDAL Instance { get { return instance; } }

        /* Nanny functions */

        /// <summary>
        /// add nanny to nanny's DB
        /// </summary>
        /// <param name="nanny">the nanny to add to NannyList</param>
        /// <remarks> if find the nanny on the list - 
        /// meeans this nanny already exsist throw exception </remarks>
        public void AddNanny(Nanny nanny)
        {
            if (!FindNanny(nanny))
            {
                NannyList().Add(nanny.Clone());
            }
            else
                throw new DALException(nanny.FullName() + " already exsist", "Add nanny");
        }

        /// <summary>
        /// delete nanny from nanny's DB
        /// </summary>
        /// <param name="nanny">the nanny to delete from NannyList</param>
        /// <remarks> accept nanny and send to DeleteNanny(int? id) function nanny's id </remarks>
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

        /// <summary>
        /// delete nanny from nanny's DB
        /// </summary>
        /// <param name="id">nanny's id of the nanny that want to deletee from NannyList</param>
        /// <remarks> if didn't find to remove, throw exception </remarks>
        public void DeleteNanny(int? id)
        {
            if (!NannyList().Remove(FindNanny(id)))
                throw new DALException("nanny with ID: " + id + " dosn't exsist", "Delete Nanny");
        }

        /// <summary>
        /// update nanny 
        /// </summary>
        /// <remarks></remarks>
        /// <param name="nanny">the new Nanny that replace the old nanny</param>
        /// <remarks>
        /// accept nanny, delete the old nanny and replace it with the new nanny
        /// if didn't find the nanny to delete, or can't add the new nanny throw exception
        /// </remarks>
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

        /// <summary>
        /// find nanny
        /// </summary>
        /// <param name="nanny">the nanny that we whant to find</param>
        /// <remarks>
        /// accept nanny and send to FindNanny(int? id) function with nanny id 
        /// return true if find, else return false
        /// </remarks>
        public bool FindNanny(Nanny nanny)
        {
            return FindNanny(nanny.ID) != null;
        }

        /// <summary>
        /// find nanny with given ID
        /// </summary>
        /// <param name="id">the nanny's id that we whant to find</param>
        /// <remarks>
        /// accept nanny id, return nanny if find, else return null
        /// </remarks>
        public Nanny FindNanny(int? id)
        {
            List<Nanny> list = (from nanny in CloneNannyList()
                                where nanny.ID == id
                                select nanny).ToList();
            if (list.Count == 0) return null;
            return list[0];
        }

        /// <summary>
        /// update the numabr of nanny's children
        /// </summary>
        /// <param name="nanny">the nanny that we whnt to update her children number</param>
        /// <param name="num">flag, if num = 1 add 1 else sub 1 </param>
        /// <remarks>
        /// accept nanny and a number
        /// if number = 1, add 1 to nanny's children
        /// else reduce nanny's children by 1
        /// if didn't find the nanny throw exception
        /// </remarks>
        public void UpdateNannyChildren(Nanny nanny, int? num)
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

        /// <summary>
        /// add mother to mother's DB 
        /// </summary>
        /// <param name="mother">the mother to add to MotherList</param>
        /// <remarks>
        /// if find the mother on the list - this nanny already exsist throw exception
        /// </remarks>
        public void AddMother(Mother mother)
        {
            if (!FindMother(mother))
            {
                MotherList().Add(mother.Clone());
            }
            else
                throw new DALException(mother.FullName() + " already exsist", "Add mother");
        }

        /// <summary>
        /// delete mother from mother's DB
        /// </summary>
        /// <param name="mother">the mother to delete from MotherList</param>
        /// <remarks>
        /// accept mother and send to DeleteMother(int? id) function mother's id 
        /// </remarks>
        public void DeleteMother(Mother mother)
        {
            try
            {
                DeleteMother(mother.ID);
            }
            catch (DALException ex)
            {
                throw new DALException(mother.FullName() + " dosn't exsist", ex.sender);
            }
        }

        /// <summary>
        /// delete mother from mother's DB
        /// </summary>
        /// <param name="id">mother's id of the mother that want to delete from MotherList</param>
        /// <remarks>
        /// if didn't find to remove, throw exception
        /// </remarks>
        public void DeleteMother(int? id)
        {
            if (!MotherList().Remove(FindMother(id)))
                throw new DALException("mohter with ID: " + id + " dosn't exsist", "Delete mother");
        }

        /// <summary>
        /// update mother
        /// </summary>
        /// <param name="mother">the new mother that replace the old mother</param>
        /// <remarks>
        /// accept mother, delete the old mother and replace it with the new mother
        /// if didn't find the mother to delete, or can't add the new mother throw exception
        /// </remarks>
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

        /// <summary>
        /// find mother
        /// </summary>
        /// <param name="mother">the mother that we whant to find</param>
        /// <remarks>
        /// accept momther and send to FindMother(int? id) function with mother id 
        /// return true if find, else return false
        /// </remarks>
        public bool FindMother(Mother mother)
        {
            return FindMother(mother.ID) != null;
        }

        /// <summary>
        /// find mother with givan ID
        /// </summary>
        /// <param name="id">>the mother's id that we whant to find</param>
        /// <remarks>
        /// accept mother id, return mother if find, else return null
        /// </remarks>
        public Mother FindMother(int? id)
        {
            List<Mother> list = (from mother in CloneMotherList()
                                 where mother.ID == id
                                 select mother).ToList();
            if (list.Count == 0) return null;
            return list[0];
        }

        /* Child functions */

        /// <summary>
        /// add child to child's DB
        /// </summary>
        /// <param name="child">the child to add to ChildList</param>
        /// <remarks>
        /// if find the child on the list - this child already exsist throw exception
        /// </remarks>
        public void AddChild(Child child)
        {
            if (!FindChild(child))
            {
                ChildList().Add(child.Clone());
            }
            else
                throw new DALException(child.FirstName + " already exsist", "Add child");
        }

        /// <summary>
        /// delete child from child's DB
        /// </summary>
        /// <param name="child">the child to delete from ChildList</param>
        /// <remarks>
        /// accept child and send to DeleteChild(int? id) function child's id 
        /// </remarks>
        public void DeleteChild(Child child)
        {
            try
            {
                DeleteChild(child.ID);
            }
            catch (DALException ex)
            {
                throw new DALException(child.FirstName + " dosn't exsist", ex.sender);
            }
        }

        /// <summary>
        /// delete child from child's DB
        /// </summary>
        /// <param name="id">child's id of the child that want to delete from childList</param>
        /// <remarks>
        /// if didn't find to remove, throw exception
        /// </remarks>
        public void DeleteChild(int? id)
        {
            if (!ChildList().Remove(FindChild(id)))
                throw new DALException("nanny with ID: " + id + " dosn't exsist", "Delete child");
        }

        /// <summary>
        /// update child
        /// </summary>
        /// <param name="child">the new child that replace the old child</param>
        /// <remarks>
        /// accept child, delete the old child and replace it with the new child
        /// if didn't find the child to delete, or can't add the new child throw exception
        /// </remarks>
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

        /// <summary>
        /// find child
        /// </summary>
        /// <param name="child">the child that we whant to find</param>
        /// <remarks>
        /// accept child and send to FindChild(int? id) function with child id 
        /// return true if find, else return false
        /// </remarks>
        public bool FindChild(Child child)
        {
            return FindChild(child.ID) != null;
        }

        /// <summary>
        /// find child with given ID
        /// </summary>
        /// <param name="id">the child's id that we whant to find</param>
        /// <remarks>
        /// accept child id, return child if find, else return null
        /// </remarks>
        public Child FindChild(int? id)
        {
            List<Child> list = (from child in CloneChildList()
                                where child.ID == id
                                select child).ToList();
            if (list.Count == 0) return null;
            return list[0];
        }

        /// <summary>
        /// update if the child has nanny
        /// </summary>
        /// <param name="child">the child that we whant to change if he have a nanny</param>
        /// <param name="change">to what change</param>
        /// <remarks>
        /// get the child, if find the child change the "have nanny" parameter - according to 'change'
        ///                else throw exception  
        /// </remarks>
        public void UpdateHaveNanny(Child child, bool change)
        {
            Child Child = ChildList().Find(chil => chil.Equals(child));
            if (Child != null)
                Child.HaveNanny = change;
            else
                throw new DALException(child.FirstName + " dosn't exsist", "Update Have Nanny");
        }

        /* contract functions */

        /// <summary>
        /// add contract to contract's DB
        /// </summary>
        /// <param name="contract">the contract to add to ContractList</param>
        /// <remarks>
        /// accept contract, give the contract a number and add to contract list
        /// check that - nanny, mother and child exsist 
        /// check also that there this contract dosn't already exsist
        /// throw exceptions accordingly
        /// </remarks>
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

        /// <summary>
        /// delete contract from contract's DB
        /// </summary>
        /// <param name="contract">the contract to delete from ContractList</param>
        /// <remarks>
        /// accept contract and send to DeleteContract(int? id) function contract's number 
        /// </remarks>
        public void DeleteContract(Contract contract)
        {
            try
            {
                DeleteContract(contract.ContractNumber);
            }
            catch (DALException ex)
            {
                throw new DALException("contract number: " + contract.ContractNumber + " dosn't exsist", ex.sender);
            }
        }

        /// <summary>
        /// delete contract from contract's DB
        /// </summary>
        /// <param name="contractNumber">Contract's number of the contract that want to delete</param>
        /// <remarks>
        /// if didn't find to remove, throw exception
        /// </remarks>
        public void DeleteContract(int? contractNumber)
        {
            if (!ContractList().Remove(FindContract(contractNumber)))
                throw new DALException("contract with contract number: " + contractNumber + " dosn't exsist", "Delete contract");
        }

        /// <summary>
        /// update contract
        /// </summary>
        /// <param name="contract">the new child that replace the old child</param>
        /// <remarks>
        /// accept contract, delete the old contract and replace it with the new contract
        /// if didn't find the contract to delete, or can't add the new contract throw exception
        /// </remarks>
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

        /// <summary>
        /// find contract
        /// </summary>
        /// <param name="contarct">the contract that we whant to find</param>
        /// <remarks>
        /// accept contract and send to FindContract(int? id) function with contract's nunmber 
        /// return true if find, else return false
        /// </remarks>
        public bool FindContract(Contract contarct)
        {
            return FindContract(contarct.ContractNumber) != null;
        }

        /// <summary>
        /// find contract with given contrat number
        /// </summary>
        /// <param name="contractNumber">the contract's number that we whant to find</param>
        /// <remarks>
        /// accept contract id, return contract if find, else return null
        /// </remarks>
        public Contract FindContract(int? contractNumber)
        {
            List<Contract> list = (from contract in CloneContractList()
                                   where contract.ContractNumber == contractNumber
                                   select contract).ToList();
            if (list.Count == 0) return null;
            return list[0];
        }

        /* list return functions */

        /// <summary>
        /// return a List of clone nanny objects
        /// </summary>
        public List<Nanny> CloneNannyList()
        {
            return NannyList().Select(nanny => nanny.Clone()).ToList();
        }

        /// <summary>
        /// return a List of clone mother objects
        /// </summary>
        public List<Mother> CloneMotherList()
        {
            return MotherList().Select(mother => mother.Clone()).ToList();
        }

        /// <summary>
        /// return a List of clone child objects
        /// </summary>
        public List<Child> CloneChildList()
        {
            return ChildList().Select(child => child.Clone()).ToList();
        }

        /// <summary>
        /// return a List of clone contract objects
        /// </summary>
        public List<Contract> CloneContractList()
        {
            return ContractList().Select(contract => contract.Clone()).ToList();
        }

        /// <summary>
        /// return a List of the original nanny objects
        /// </summary>
        public List<Nanny> NannyList()
        {
            return DataSource.NannyList;
        }

        /// <summary>
        /// return a List of the original mother objects
        /// </summary>
        public List<Mother> MotherList()
        {
            return DataSource.MotherList;
        }

        /// <summary>
        /// return a List of the original child objects
        /// </summary>
        public List<Child> ChildList()
        {
            return DataSource.ChildList;
        }

        /// <summary>
        /// return a List of the original contract objects
        /// </summary>
        public List<Contract> ContractList()
        {
            return DataSource.ContractList;
        }
    }
}
