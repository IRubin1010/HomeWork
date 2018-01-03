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
        // nanny punctions

        /// <summary>
        /// add Nanny to nanny's DB
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
        void DeleteNanny(int id);
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
        Nanny FindNanny(int id);
        /// <summary>
        /// update the numabr of nanny's children
        /// </summary>
        /// <param name="nanny">the nanny that we whnt to update her children number</param>
        /// <param name="num">flag, if num = 1 add 1 else sub 1 </param>
        void UpdateNannyChildren(Nanny nanny, int num);

        // mother functions 

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
        void DeleteMother(int id);
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
        Mother FindMother(int id);

        // child functions

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
        void DeleteChild(int id);
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
        Child FindChild(int id);
        /// <summary>
        /// update if the child has nanny
        /// </summary>
        /// <param name="child">the child that we whant to change if he have a nanny</param>
        /// <param name="change">to what change</param>
        void UpdateHaveNanny(Child child, bool change);

        // contract functions 

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
        void DeleteContract(int contractNumber);
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
        Contract FindContract(int contractNumber);
        /// <summary>
        /// clculate the payment for a contract
        /// </summary>
        /// <param name="contract">the contract to calculate the payment for</param>
        void CalculatePayment(Contract contract);

        // list return functions

        /// <summary>
        /// return a List of clone nanny objects
        /// </summary>
        List<Nanny> CloneNannyList();
        /// <summary>
        /// return a List of clone mother objects
        /// </summary>
        List<Mother> CloneMotherList();
        /// <summary>
        /// return a List of clone child objects
        /// </summary>
        List<Child> CloneChildList();
        /// <summary>
        /// return a List of clone contract objects
        /// </summary>
        List<Contract> CloneContractList();


        /// <summary>
        /// calculate the distance between 2 address
        /// </summary>
        /// <param name="addressA">the address to calculate from</param>
        /// <param name="addressB">the address to calculate to</param>
        int Distance(string addressA, string addressB);
        /// <summary>
        /// return a list of nanny who work at the same days and hours as the mother need
        /// </summary>
        /// <param name="mother">the mother to check match for a nanny</param>
        List<Nanny> PotentialMatch(Mother mother);
        /// <summary>
        /// return true if the nanny's hours match to the mother's hours
        /// </summary>
        /// <param name="nanny">the nanny to check the hours</param>
        /// <param name="mother">the mother to check the hours</param>
        bool PotentialHoursMatch(Nanny nanny, Mother mother);
        /// <summary>
        /// return true if the nanny's days match to the mother's days
        /// </summary>
        /// <param name="nanny">the nanny to check the days</param>
        /// <param name="mother">the mother to check the days</param>
        bool PotentialDaysMatch(Nanny nanny, Mother mother);
        /// <summary>
        /// return a list of nannys who match perfectly to the mother, 
        /// considering hours, days, elevator, seniority and floor match.
        /// </summary>
        /// <param name="mother">the mother to get a match</param>
        List<Nanny> MotherConditions(Mother mother);
        /// <summary>
        /// return true if a nanny is within the Km range of the mother
        /// </summary>
        /// <param name="mother">mother to chack range of Km</param>
        /// <param name="nanny">nanny to chack if is in the range of Km</param>
        /// <param name="Km">the range of Km to check</param>
        bool IsNannyInKM(Mother mother, Nanny nanny, int Km);
        /// <summary>
        /// return a list of nannys who match perfectly to the mother, 
        /// considering range of Km too
        /// </summary>
        /// <param name="mother">the mother to get a match</param>
        /// <param name="Km">the range of Km to check</param>
        List<Nanny> NannysInKMWithConditions(Mother mother, int Km);
        /// <summary>
        /// return a list of nannys with a value, so that the value is 
        /// according tne mother needs
        /// <para>the more the mother's needs match more, the value is higher</para>
        /// </summary>
        /// <param name="mother">the mother to check match</param>
        /// <param name="Km">the range of Km</param>
        List<Nanny> PropertiesMatch(Mother mother, int Km);
        /// <summary>
        /// retrun list of the best 5 match of nanny hwo match the mother
        /// </summary>
        /// <param name="mother">mothe to check the match</param>
        List<Nanny> PartialMatch(Mother mother/*, int Km*/);
        /// <summary>
        /// return a list of children who don't has nanny
        /// </summary>
        List<Child> ChildrenWithNoNanny();
        /// <summary>
        /// return a list of all nannys who thier vacations days are valid
        /// </summary>
        /// <returns></returns>
        List<Nanny> ValidVacationsNannys();
        /// <summary>
        /// return a list of contracts filter by conditions
        /// </summary>
        /// <param name="contractCondition">boolean func that chack some conditions</param>
        List<Contract> SpesificsContracts(Func<Contract, bool> contractCondition);
        /// <summary>
        /// return the number of contracts that meet certain conditions 
        /// </summary>
        /// <param name="contractCondition">boolean func that chack some conditions</param>
        int NumOfSpesificsContracts(Func<Contract, bool> contractCondition);

        //Gouping
        IEnumerable<IGrouping<int, Nanny>> GruopNannyByChildAge(bool orderByMaxAge, bool ordered = false);
        IEnumerable<IGrouping<int, Contract>> GroupContractByDistance(bool order);
<<<<<<< HEAD

=======
        int DistanceBetweenNannyAndMother(Contract contract);
>>>>>>> master
    }
}
