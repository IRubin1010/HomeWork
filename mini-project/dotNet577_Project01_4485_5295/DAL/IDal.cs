using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;

namespace DAL
{
    public interface IDAL
    {
        // Nanny functions

        /// <summary>
        /// add the nanny to nanny's DB
        /// </summary>
        /// <param name="nanny">the nanny to add to NannyList</param>
        void AddNanny(Nanny nanny);
        /// <summary>
        /// delete nanny from nanny's DB
        /// </summary>
        /// <param name="nanny">the nanny to delete from NannyList</param>
        void DeleteNanny(Nanny nanny);
        /// <summary>
        /// delete nanny from nanny's DB
        /// </summary>
        /// <param name="id">nanny's id of the nanny that want to deletee from NannyList</param>
        void DeleteNanny(int? id);
        /// <summary>
        /// update nanny 
        /// </summary>
        /// <param name="nanny">the new Nanny that replace the old nanny</param>
        void UpdateNanny(Nanny nanny);
        /// <summary>
        /// find nanny
        /// </summary>
        /// <param name="nanny">the nanny that we whant to find</param>
        bool FindNanny(Nanny nanny);
        /// <summary>
        /// find nanny with given ID
        /// </summary>
        /// <param name="id">the nanny's id that we whant to find</param>
        Nanny FindNanny(int? id);
        /// <summary>
        /// update the numabr of nanny's children
        /// </summary>
        /// <param name="nanny">the nanny that we whnt to update her children number</param>
        /// <param name="num">flag, if num = 1 add 1 else sub 1 </param>
        void UpdateNannyChildren(Nanny nanny, int? num);

        // Mother functions

        /// <summary>
        /// add mother to mother's DB 
        /// </summary>
        /// <param name="mother">the mother to add to MotherList</param>
        void AddMother(Mother mother);
        /// <summary>
        /// delete mother from mother's DB
        /// </summary>
        /// <param name="mother">the mother to delete from MotherList</param>
        void DeleteMother(Mother mother);
        /// <summary>
        /// delete mother from mother's DB
        /// </summary>
        /// <param name="id">mother's id of the mother that want to delete from MotherList</param>
        void DeleteMother(int? id);
        /// <summary>
        /// update mother
        /// </summary>
        /// <param name="mother">the new mother that replace the old mother</param>
        void UpdateMother(Mother mother);
        /// <summary>
        /// find mother
        /// </summary>
        /// <param name="mother">the mother that we whant to find</param>
        bool FindMother(Mother mother);
        /// <summary>
        /// find mother with givan ID
        /// </summary>
        /// <param name="id">>the mother's id that we whant to find</param>
        Mother FindMother(int? id);

        // Child functions 

        /// <summary>
        /// add child to child's DB
        /// </summary>
        /// <param name="child">the child to add to ChildList</param>
        void AddChild(Child child);
        /// <summary>
        /// delete child from child's DB
        /// </summary>
        /// <param name="child">the child to delete from ChildList</param>
        void DeleteChild(Child child);
        /// <summary>
        /// delete child from child's DB
        /// </summary>
        /// <param name="id">child's id of the child that want to delete from childList</param>
        void DeleteChild(int? id);
        /// <summary>
        /// update child
        /// </summary>
        /// <param name="child">the new child that replace the old child</param>
        void UpdateChild(Child child);
        /// <summary>
        /// find child
        /// </summary>
        /// <param name="child">the child that we whant to find</param>
        bool FindChild(Child child);
        /// <summary>
        /// find child with given ID
        /// </summary>
        /// <param name="id">the child's id that we whant to find</param>
        Child FindChild(int? id);
        /// <summary>
        /// update if the child has nanny
        /// </summary>
        /// <param name="child">the child that we whant to change if he have a nanny</param>
        /// <param name="change">to what change</param>
        void UpdateHaveNanny(Child child, bool change);

        // Contract functions 

        /// <summary>
        /// add contract to contract's DB
        /// </summary>
        /// <param name="contract">the contract to add to ContractList</param>
        void AddContract(Contract contract);
        /// <summary>
        /// delete contract from contract's DB
        /// </summary>
        /// <param name="contract">the contract to delete from ContractList</param>
        void DeleteContract(Contract contract);
        /// <summary>
        /// delete contract from contract's DB
        /// </summary>
        /// <param name="contractNumber">Contract's number of the contract that want to delete</param>
        void DeleteContract(int? contractNumber);
        /// <summary>
        /// update contract
        /// </summary>
        /// <param name="contract">the new child that replace the old child</param>
        void UpdateContract(Contract contract);
        /// <summary>
        /// find contract
        /// </summary>
        /// <param name="contarct">the contract that we whant to find</param>
        bool FindContract(Contract contract);
        /// <summary>
        /// find contract with given contrat number
        /// </summary>
        /// <param name="contractNumber">the contract's number that we whant to find</param>
        Contract FindContract(int? contractNumber);
        /// <summary>
        /// return the contract number thet  had sigend last
        /// </summary>
        int getContractNumber();

        // list return functions

        /// <summary>
        /// return a list of clone nanny objects
        /// </summary>
        List<Nanny> CloneNannyList();
        /// <summary>
        /// return a list of clone mother objects
        /// </summary>
        List<Mother> CloneMotherList();
        /// <summary>
        /// return a list of clone child objects
        /// </summary>
        List<Child> CloneChildList();
        /// <summary>
        /// return a list of clone contract objects
        /// </summary>
        List<Contract> CloneContractList();

        /// <summary>
        /// return a List of the original nanny objects
        /// </summary>
        List<Nanny> NannyList();
        /// <summary>
        /// return a List of the original mother objects
        /// </summary>
        List<Mother> MotherList();
        /// <summary>
        /// return a List of the original child objects
        /// </summary>
        List<Child> ChildList();
        /// <summary>
        /// return a List of the original contract objects
        /// </summary>
        List<Contract> ContractList();


    }
}
