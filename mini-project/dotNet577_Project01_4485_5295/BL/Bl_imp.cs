using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using GoogleMapsApi;
using GoogleMapsApi.Entities.Directions.Request;
using GoogleMapsApi.Entities.Directions.Response;
using System.Threading;

namespace BL
{
    class Bl_imp : IBL
    {
        IDAL dal;
        // get dal object
        public Bl_imp()
        {
            dal = FactoryDAL.GetIDAL();
        }

        /* Nanny functions */

        /// <summary>
        /// add Nanny to nanny's DB
        /// </summary>
        /// <param name="nanny">the nanny to add to NannyList</param>
        /// <remarks>
        /// if nany age is under 18 throw exception 
        /// cal dal.addNanny 
        /// </remarks>
        public void AddNanny(Nanny nanny)
        {
            try
            {
                string message = NannyValidations(nanny);
                if (message != null) throw new BLException(message, "AddNanny");
                dal.AddNanny((DO.Nanny)nanny);
            }
            catch (DALException ex)
            {
                throw new BLException(ex.Message, ex.sender);
            }
        }
        public enum days { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday };
        public string NannyValidations(Nanny nanny)
        {
            string message = null;
            if (!nanny.ID.HasValue) message += "id can't be empty\n";
            if (string.IsNullOrEmpty(nanny.FirstName)) message += "First name can't be empty\n";
            if (string.IsNullOrEmpty(nanny.LastName)) message += "Last name can't be empty\n";
            if (nanny.NannyAge < 0 || nanny.NannyAge == null) message += "Invalid birth date";
            if (nanny.NannyAge < 18 && nanny.NannyAge > 0) message += "age is under 18\n";
            if (string.IsNullOrEmpty(nanny.Address)) message += "Adsress can't be empty\n";
            if (!nanny.PhoneNumber.HasValue) message += "PhoneNumber can't be empty\n";
            if (nanny.MaxAge < nanny.MinAge) message += "The maximum age can not be greater than the minimum age\n";
            for (int i = 0; i < 6; i++)
                if (nanny.WorkHours[0][i] > nanny.WorkHours[1][i])
                    message += "start time can't be later then end time at day " + ((days)i).ToString() + "\n";
            return message;
        }
        /// <summary>
        /// delete nanny from nanny's DB
        /// </summary>
        /// <param name="nanny">the nanny to delete from NannyList</param>
        /// <remarks>
        /// accept nanny and send to DeleteNanny(int?? id) function nanny's id
        /// </remarks> 
        public void DeleteNanny(Nanny nanny)
        {
            if (nanny != null)
            {
                try
                {
                    DeleteNanny(nanny.ID);
                }
                catch (BLException)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// delete nanny from nanny's DB
        /// </summary>
        /// <param name="id">nanny's id of the nanny that want to deletee from NannyList</param>
        /// <remarks>
        /// accept id and cal dal.DeleteNanny(int?? id)
        /// before delteting the nanny go over all his contracts and delete them 
        /// </remarks>
        public void DeleteNanny(int? id)
        {
            try
            {
                foreach (Contract contract in CloneContractList().Reverse<Contract>())
                {
                    if (contract.NannyID == id)
                    {
                        DeleteContract(contract.ContractNumber);
                    }
                }
                dal.DeleteNanny(id);
            }
            catch (BLException)
            {
                throw;
            }
            catch (DALException ex)
            {
                throw new BLException(ex.Message, ex.sender);
            }
        }

        /// <summary>
        /// update nanny 
        /// </summary>
        /// <param name="nanny">the new Nanny that replace the old nanny</param>
        /// <remarks>
        /// accept nanny and cal dal.UpdateNanny 
        /// </remarks>
        public void UpdateNanny(Nanny nanny)
        {
            if (nanny != null)
            {
                try
                {
                    string message = NannyValidations(nanny);
                    if (message != null) throw new BLException(message, "UpdateNanny");
                    dal.UpdateNanny((DO.Nanny)nanny);
                }
                catch (DALException ex)
                {
                    throw new BLException(ex.Message, ex.sender);
                }
            }
        }

        /// <summary>
        /// find nanny
        /// </summary>
        /// <param name="nanny">the nanny that we whant to find</param>
        /// <remarks>
        /// accept nanny and cal dal.FindNanny(Nanny nanny)
        /// retrun true if find, else return false
        /// </remarks>
        public bool FindNanny(Nanny nanny)
        {
            if (nanny != null)
                return dal.FindNanny((DO.Nanny)nanny);
            else return false;
        }

        /// <summary>
        /// find nanny with given ID
        /// </summary>
        /// <param name="id">the nanny's id that we whant to find</param>
        /// <remarks>
        /// accept nanny and cal dal.FindNanny(int?? id)
        /// retrun nanny if find, else return null
        /// </remarks>
        public Nanny FindNanny(int? id)
        {
            Nanny nanny = (Nanny)dal.FindNanny(id);
            return nanny == null ? null : nanny.Clone();
        }

        /// <summary>
        /// update the numabr of nanny's children
        /// </summary>
        /// <param name="nanny">the nanny that we whnt to update her children number</param>
        /// <param name="num">flag, if num = 1 add 1 else sub 1 </param>
        /// <remarks>
        /// cal dal.UpdateNannyChildren to update
        /// </remarks>
        public void UpdateNannyChildren(Nanny nanny, int? num)
        {
            if (nanny != null)
            {
                try
                {
                    dal.UpdateNannyChildren((DO.Nanny)nanny, num);
                }
                catch (DALException ex)
                {
                    throw new BLException(ex.Message, ex.sender);
                }
            }
        }

        /* mother functions */

        public string MotherValidations(Mother mother)
        {
            string message = null;
            if (!mother.ID.HasValue) message += "id can't be empty\n";
            if (string.IsNullOrEmpty(mother.FirstName)) message += "First name can't be empty\n";
            if (string.IsNullOrEmpty(mother.LastName)) message += "Last name can't be empty\n";
            if (string.IsNullOrEmpty(mother.Address)) message += "Adsress can't be empty\n";
            if (!mother.PhoneNumber.HasValue) message += "PhoneNumber can't be empty\n";
            for (int i = 0; i < 6; i++)
                if (mother.NeedNannyHours[0][i] > mother.NeedNannyHours[1][i])
                    message += "start time can't be later then end time at day " + ((days)i).ToString() + "\n";
            return message;
        }

        /// <summary>
        /// add mother to mother's DB 
        /// </summary>
        /// <param name="mother">the mother to add to MotherList</param>
        /// <remarks>
        /// call dal.addmother
        /// </remarks>
        public void AddMother(Mother mother)
        {
            if (mother != null)
            {
                try
                {
                    string message = MotherValidations(mother);
                    if (message != null) throw new BLException(message, "AddMother");
                    dal.AddMother((DO.Mother)mother);
                }
                catch (DALException ex)
                {
                    throw new BLException(ex.Message, ex.sender);
                }
            }
        }

        /// <summary>
        /// delete mother from mother's DB
        /// </summary>
        /// <param name="mother">the mother to delete from MotherList</param>
        /// <remarks>
        /// accept mother and send to DeleteMother(int?? id) function mother's id 
        /// </remarks>
        public void DeleteMother(Mother mother)
        {
            if (mother != null)
            {
                try
                {
                    DeleteMother(mother.ID);
                }
                catch (BLException)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// delete mother from mother's DB
        /// </summary>
        /// <param name="id">mother's id of the mother that want to delete from MotherList</param>
        /// <remarks>
        /// accept id and cal dal.DeleteMother(int?? id)
        /// before delteting the mother go over all his children 
        /// and delete them (this delete also all conected contracts)
        /// </remarks>
        public void DeleteMother(int? id)
        {
            try
            {
                foreach (Child child in CloneChildList().Reverse<Child>())
                {
                    if (child.MotherID == id)
                        DeleteChild(child);
                }
                dal.DeleteMother(id);
            }
            catch (BLException)
            {
                throw;
            }
            catch (DALException ex)
            {
                throw new BLException(ex.Message, ex.sender);
            }
        }

        /// <summary>
        /// update mother
        /// </summary>
        /// <param name="mother">the new mother that replace the old mother</param>
        /// <remarks>
        /// accept mother and cal dal.UpdateMother
        /// </remarks>
        public void UpdateMother(Mother mother)
        {
            if (mother != null)
            {
                try
                {
                    string message = MotherValidations(mother);
                    if (message != null) throw new BLException(message, "UpdateMother");
                    dal.UpdateMother((DO.Mother)mother);
                }
                catch (DALException ex)
                {
                    throw new BLException(ex.Message, ex.sender);
                }
            }
        }

        /// <summary>
        /// find mother
        /// </summary>
        /// <param name="mother">the mother that we whant to find</param>
        /// <remarks>
        /// accept mother and cal dal.FindMother(Mother mother)
        /// retrun true if find, else return false
        /// </remarks>
        public bool FindMother(Mother mother)
        {
            if (mother != null)
                return dal.FindMother((DO.Mother)mother);
            else return false;
        }

        /// <summary>
        /// find mother with givan ID
        /// </summary>
        /// <param name="id">>the mother's id that we whant to find</param>
        /// <remarks>
        /// accept mother and cal dal.FindMother(int?? id)
        /// retrun mother if find, else return null
        /// </remarks>
        public Mother FindMother(int? id)
        {
            Mother mother = (Mother)dal.FindMother(id);
            return mother == null ? null : mother.Clone();
        }

        /* child functions */

        public string ChildValidations(Child child)
        {
            string message = null;
            if (!child.ID.HasValue) message += "id can't be empty\n";
            if (!child.MotherID.HasValue) message += "mother id can't be empty\n";
            if (string.IsNullOrEmpty(child.FirstName)) message += "First name can't be empty\n";
            if (child.AgeInMonth < 0 || child.AgeInMonth == null) message += "Invalid birth date\n";
            return message;
        }

        /// <summary>
        /// add child to child's DB
        /// </summary>
        /// <param name="child">the child to add to ChildList</param>
        /// <remarks>
        /// call dal.AddChild
        /// </remarks>
        public void AddChild(Child child)
        {
            if (child != null)
            {
                try
                {
                    string message = ChildValidations(child);
                    if (message != null) throw new BLException(message, "AddChild");
                    if (FindMother(child.MotherID) == null)
                        throw new BLException("mother with ID: " + child.MotherID + " dosn't exsist", "Add Child");
                    dal.AddChild((DO.Child)child);
                }
                catch (DALException ex)
                {
                    throw new BLException(ex.Message, ex.sender);
                }
            }
        }

        /// <summary>
        /// delete child from child's DB
        /// </summary>
        /// <param name="child">the child to delete from ChildList</param>
        /// <remarks>
        /// accept child and send to DeleteMother(int?? id) function child's id
        /// </remarks>
        public void DeleteChild(Child child)
        {
            if (child != null)
            {
                try
                {
                    DeleteChild(child.ID);
                }
                catch (BLException)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// delete child from child's DB
        /// </summary>
        /// <param name="id">child's id of the child that want to delete from childList</param>
        /// <remarks>
        /// accept id and cal dal.DeleteChild(int?? id)
        /// befpre deleting the child delete the his contract
        /// </remarks>
        public void DeleteChild(int? id)
        {
            try
            {
                foreach (Contract contract in CloneContractList().Reverse<Contract>())
                {
                    if (contract.ChildID == id)
                        DeleteContract(contract);
                }
                dal.DeleteChild(id);
            }
            catch (BLException)
            {
                throw;
            }
            catch (DALException ex)
            {
                throw new BLException(ex.Message, ex.sender);
            }
        }

        /// <summary>
        /// update child
        /// </summary>
        /// <param name="child">the new child that replace the old child</param>
        /// <remarks>
        /// accept child and cal dal.UpdateChild
        /// </remarks>
        public void UpdateChild(Child child)
        {
            if (child != null)
            {
                try
                {
                    string message = ChildValidations(child);
                    if (message != null) throw new BLException(message, "UpdateChild");
                    dal.UpdateChild((DO.Child)child);
                }
                catch (DALException ex)
                {
                    throw new BLException(ex.Message, ex.sender);

                }
            }
        }

        /// <summary>
        /// find child
        /// </summary>
        /// <param name="child">the child that we whant to find</param>
        /// <remarks>
        /// accept child and cal dal.FindChild(Child child)
        /// retrun true if find, else return false
        /// </remarks>
        public bool FindChild(Child child)
        {
            if (child != null)
                return dal.FindChild((DO.Child)child);
            else return false;
        }

        /// <summary>
        /// find child with given ID
        /// </summary>
        /// <param name="id">the child's id that we whant to find</param>
        /// <remarks>
        /// accept child and cal dal.FindChild(int?? id)
        /// retrun child if find, else return null
        /// </remarks>
        public Child FindChild(int? id)
        {
            Child child = (Child)dal.FindChild(id);
            return child == null ? null : child.Clone();
        }

        /// <summary>
        /// update if the child has nanny
        /// </summary>
        /// <param name="child">the child that we whant to change if he have a nanny</param>
        /// <param name="change">to what change</param>
        /// <remarks>
        /// cal dal.UpdateHaveNanny to update 
        /// </remarks>
        public void UpdateHaveNanny(Child child, bool change)
        {
            if (child != null)
            {
                try
                {
                    dal.UpdateHaveNanny((DO.Child)child, change);
                }
                catch (DALException ex)
                {
                    throw new BLException(ex.Message, ex.sender);
                }
            }
        }

        /* contract functions */
        public string ContractValidations(Contract contract)
        {
            string message = null;
            if (!contract.MotherID.HasValue) message += " mother id can't be empty\n";
            if (!contract.ChildID.HasValue) message += "child id can't be empty\n";
            if (!contract.NannyID.HasValue) message += "nanny id can't be empty\n";
            if (contract.EndTransection < contract.BeginTransection) message += "Contract end date can not be earlier than start date\n";
            return message;
        }

        /// <summary>
        /// add contract to contract's DB
        /// </summary>
        /// <param name="contract">the contract to add to ContractList</param>
        /// <remarks>
        /// accept contract, update number of nanny's children, that the child has nanny,
        /// the final payment and cal dal.AddContract to add the contract
        /// check that - nanny, mother and child exsist 
        /// check also that there this contract dosn't already exsist
        /// throw exceptions accordingly
        /// </remarks>
        public void AddContract(Contract contract)
        {
            if (contract != null)
            {
                string message = ContractValidations(contract);
                if (message != null) throw new BLException(message, "AddContract");
                Mother mother = FindMother(contract.MotherID);
                Nanny nanny = FindNanny(contract.NannyID);
                Child child = FindChild(contract.ChildID);
                if (mother == null)
                    throw new BLException("mother with ID: " + contract.MotherID + " dosn't exsist", "add contract");
                if (nanny == null)
                    throw new BLException("nanny with ID: " + contract.NannyID + " dosn't exsist", "add contract");
                if (child == null)
                    throw new BLException("child with ID: " + contract.ChildID + " dosn't exsist", "add contract");
                // if child age is under 3 month throw exception
                if (child.AgeInMonth < 3)
                    throw new BLException(child.FirstName + " is under 3 month", "add contrsct");
                if (IsChildInNannyAge(nanny, child.ID) == false)
                    throw new BLException(child.FirstName + " is not on nanny's age range", "add contrsct");
                if (child.HaveNanny == true)
                    throw new BLException(child.FirstName + " already has a nanny ", "add contrsct");
                // if nanny has more then his max childre throw exception
                if (nanny.Children >= nanny.MaxChildren)
                    throw new BLException(nanny.FullName() + " already has " + nanny.MaxChildren + " children", "Add contract");
                try
                {
                    // calculate the final payment
                    CalculatePayment(contract);
                    // update number of nanny's children and that the child has nanny
                    UpdateNannyChildren(nanny, 1);
                    UpdateHaveNanny(child, true);
                    dal.AddContract((DO.Contract)contract);
                }
                catch (BLException ex)
                {
                    // if fail at UpdateHaveNanny need to reduce back nanny children
                    if (ex.sender == "Update Have Nanny")
                        UpdateNannyChildren(nanny, -1);
                    throw;
                }
                catch (DALException ex)
                {
                    // if fail at UpdateHaveNanny need to reduce back nanny children,
                    // and if fail at AddContract need to reduce back nanny children
                    // and change back the have nanny feild of child.
                    if (ex.sender == "Update Have Nanny")
                        UpdateNannyChildren(nanny, -1);
                    if (ex.sender == "Add contract")
                        UpdateNannyChildren(nanny, -1); UpdateHaveNanny(child, false);
                    throw new BLException(ex.Message, ex.sender);
                }
            }
        }

        /// <summary>
        /// delete contract from contract's DB
        /// </summary>
        /// <param name="contract">the contract to delete from ContractList</param>
        /// <remarks>
        /// accept contract and send to DeleteContract(int?? contractNumber) function contract's contractNumber
        /// </remarks>
        public void DeleteContract(Contract contract)
        {
            if (contract != null)
            {
                try
                {
                    DeleteContract(contract.ContractNumber);
                }
                catch (BLException)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// delete contract from contract's DB
        /// </summary>
        /// <param name="contractNumber">Contract's number of the contract that want to delete</param>
        /// <remarks>
        /// accept contractNumber and cal dal.DeleteContract(int?? contractNumber)
        /// before deleting update number of nanny's children, and the child has nanny
        /// </remarks>
        public void DeleteContract(int? contractNumber)
        {
            Contract contract = FindContract(contractNumber);
            if (contract != null)
            {
                try
                {
                    // update number of nanny's children and that the child has nanny
                    UpdateNannyChildren((Nanny)dal.FindNanny(contract.NannyID), -1);
                    UpdateHaveNanny((Child)dal.FindChild(contract.ChildID), false);
                    dal.DeleteContract(contractNumber);
                }
                catch (BLException ex)
                {
                    // if fail at UpdateHaveNanny need to reduce back nanny children
                    if (ex.sender == "Update Have Nanny")
                        UpdateNannyChildren(FindNanny(contract.NannyID), 1);
                    throw;
                }
                catch (DALException ex)
                {
                    // if fail at UpdateHaveNanny need to increase back nanny children,
                    // and if fail at AddContract need to increase back nanny children
                    // and change back the have nanny feild of child.
                    if (ex.sender == "Update Have Nanny")
                        UpdateNannyChildren(FindNanny(contract.NannyID), 1);
                    if (ex.sender == "Delete contract")
                        UpdateNannyChildren(FindNanny(contract.NannyID), 1); UpdateHaveNanny(FindChild(contract.ChildID), true);
                    throw new BLException(ex.Message, ex.sender);
                }
            }
        }

        /// <summary>
        /// update contract
        /// </summary>
        /// <param name="contract">the new child that replace the old child</param>
        /// <remarks>
        /// accept contract, calculate the final payment again (in case  there
        /// was a change in the payment configuration) and cal dal.UpdateContract
        /// </remarks>
        public void UpdateContract(Contract contract)
        {
            if (contract != null)
            {
                try
                {
                    string message = ContractValidations(contract);
                    if (message != null) throw new BLException(message, "updateContract");
                    CalculatePayment(contract);
                    dal.UpdateContract((DO.Contract)contract);
                }
                catch (DALException ex)
                {
                    throw new BLException(ex.Message, ex.sender);
                }
                catch (BLException)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// find contract
        /// </summary>
        /// <param name="contarct">the contract that we whant to find</param>
        /// <remarks>
        /// accept contract and cal dal.FindContract(Contract contract)
        /// retrun true if find, else return false
        /// </remarks>
        public bool FindContract(Contract contract)
        {
            if (contract != null)
                return dal.FindContract((DO.Contract)contract);
            else return false;
        }

        /// <summary>
        /// find contract with given contrat number
        /// </summary>
        /// <param name="contractNumber">the contract's number that we whant to find</param>
        /// <remarks>
        /// accept contractNumber and cal dal.FindChild(int?? contractNumber)
        /// retrun contract if find, else return null
        /// </remarks>
        public Contract FindContract(int? contractNumber)
        {
            Contract contract = (Contract)dal.FindContract(contractNumber);
            return contract == null ? null : contract.Clone();
        }

        /// <summary>
        /// clculate the payment for a contract
        /// </summary>
        /// <param name="contract">the contract to calculate the payment for</param>
        /// <remarks>
        /// calculate the payment according to the children the mother have 
        /// at this nanny, and according to pay per hour or week
        /// </remarks>
        public void CalculatePayment(Contract contract)
        {
            if (contract != null)
            {
                // check that the mother, nanny and child exsist
                Mother mother = FindMother(contract.MotherID);
                Nanny nanny = FindNanny(contract.NannyID);
                Child child = FindChild(contract.ChildID);
                if (mother == null)
                    throw new BLException("mother with ID: " + contract.MotherID + " dosn't exsist", "add contract");
                if (nanny == null)
                    throw new BLException("nanny with ID: " + contract.NannyID + " dosn't exsist", "add contract");
                if (child == null)
                    throw new BLException("child with ID: " + contract.ChildID + " dosn't exsist", "add contract");
                double discount = 1.0;
                foreach (Contract item in CloneContractList())
                {
                    // (check the contract number becouse, update contract calculate the payment 
                    // again and the previous contract still exsist, this couse that the calculation of the 
                    // discount consider at list one child which is in common with the nanny and the mother)
                    if (item.MotherID == contract.MotherID && item.NannyID == contract.NannyID
                        && item.ContractNumber != contract.ContractNumber)
                        discount -= 0.02;
                }
                // if monthly fee
                if (contract.IsPaymentByHour == false)
                {
                    if (contract.MonthlyFee == null)
                        throw new BLException("No monthly payment set", "CalculatePayment");
                    contract.FinalPayment = (int)contract.MonthlyFee * discount;
                }
                // if hourly fee
                else
                {
                    if (contract.HourlyFee == null)
                        throw new BLException("No monthly payment set", "CalculatePayment");
                    double hoursPerWeek = 0;
                    // calculate the actual hours 
                    for (int i = 0; i < 6; i++)
                    {
                        if (mother.NeedNanny[i] == true && nanny.IsWork[i] == true)
                        {
                            if (mother.NeedNannyHours[1][i] >= nanny.WorkHours[0][i]
                                && nanny.WorkHours[1][i] >= mother.NeedNannyHours[0][i])
                            {
                                if (mother.NeedNannyHours[1][i] <= nanny.WorkHours[1][i])
                                    hoursPerWeek += mother.NeedNannyHours[1][i].TotalHours;
                                else
                                    hoursPerWeek += nanny.WorkHours[1][i].TotalHours;
                                if (mother.NeedNannyHours[0][i] <= nanny.WorkHours[0][i])
                                    hoursPerWeek -= nanny.WorkHours[0][i].TotalHours;
                                else
                                    hoursPerWeek -= mother.NeedNannyHours[0][i].TotalHours;
                            }
                        }
                    }
                    contract.FinalPayment = hoursPerWeek * discount * (int)contract.HourlyFee * 4;
                }
            }
        }

        /* list return functions */

        /// <summary>
        /// return a List of clone nanny objects
        /// </summary>
        public List<Nanny> CloneNannyList()
        {
            return dal.CloneNannyList().Select(nanny => (Nanny)nanny).ToList();
        }

        /// <summary>
        /// return a List of clone mother objects
        /// </summary>
        public List<Mother> CloneMotherList()
        {
            return dal.CloneMotherList().Select(mother => (Mother)mother).ToList();
        }

        /// <summary>
        /// return a List of clone child objects
        /// </summary>
        public List<Child> CloneChildList()
        {
            return dal.CloneChildList().Select(child => (Child)child).ToList();
        }

        /// <summary>
        /// return a List of clone contract objects
        /// </summary>
        public List<Contract> CloneContractList()
        {
            return dal.CloneContractList().Select(contract => (Contract)contract).ToList();
        }

        /// <summary>
        /// calculate the distance between 2 address
        /// </summary>
        /// <param name="addressA">the address to calculate from</param>
        /// <param name="addressB">the address to calculate to</param>
        public int? Distance(string addressA, string addressB)
        {
            var drivingDirectionRequest = new DirectionsRequest
            {
                TravelMode = TravelMode.Walking,
                Origin = addressA,
                Destination = addressB,
            };
            DirectionsResponse drivingDirections = GoogleMaps.Directions.Query(drivingDirectionRequest);
            Route route = drivingDirections.Routes.First();
            Leg leg = route.Legs.First();
            return leg.Distance.Value;
        }

        /// <summary>
        /// return a list of nanny who work at the same days and hours as the mother need,
        /// check also that the child is whitin nanny age range
        /// </summary>
        /// <param name="mother">the mother to check match for a nanny</param>
        /// <param name="id">child id</param>
        public List<Nanny> PotentialMatch(Mother mother, int? id)
        {
            if (mother != null)
                return CloneNannyList().Where(nanny => PotentialHoursMatch(nanny, mother)
                    && PotentialDaysMatch(nanny, mother) && IsChildInNannyAge(nanny, id)).ToList();
            else return new List<Nanny>();
        }

        /// <summary>
        /// return true if the nanny's hours match to the mother's hours
        /// </summary>
        /// <param name="nanny">the nanny to check the hours</param>
        /// <param name="mother">the mother to check the hours</param>
        public bool PotentialHoursMatch(Nanny nanny, Mother mother)
        {
            if (mother != null && nanny != null)
            {
                // go over nanny and mother hours and check the match
                for (int i = 0; i < 6; i++)
                {
                    if ((bool)nanny.IsWork[i])
                        if (mother.NeedNannyHours[0][i] < nanny.WorkHours[0][i] || mother.NeedNannyHours[1][i] > nanny.WorkHours[1][i])
                            return false;
                }
                return true;
            }
            else return false;
        }

        /// <summary>
        /// return true if the nanny's days match to the mother's days
        /// </summary>
        /// <param name="nanny">the nanny to check the days</param>
        /// <param name="mother">the mother to check the days</param>
        public bool PotentialDaysMatch(Nanny nanny, Mother mother)
        {
            if (nanny != null && mother != null)
            {
                // go over nanny and mother days and check the match
                for (int i = 0; i < nanny.IsWork.Length; i++)
                {
                    if (nanny.IsWork[i] == false && mother.NeedNanny[i] == true)
                        return false;
                }
                return true;
            }
            else return false;
        }

        /// <summary>
        /// checks if a child is in nanny range of age
        /// </summary>
        /// <param name="nanny">nanny to check</param>
        /// <param name="id">child id to check</param>
        public bool IsChildInNannyAge(Nanny nanny, int? id)
        {
            if (nanny != null)
            {
                Child child = FindChild(id);
                if (child == null) return false;
                if (child.AgeInMonth < nanny.MinAge || child.AgeInMonth > nanny.MaxAge)
                    return false;
                return true;
            }
            else return false;
        }

        /// <summary>
        /// return a list of nannys who match perfectly to the mother, 
        /// considering hours, days, elevator, seniority and floor match.
        /// </summary>
        /// <param name="mother">the mother to get a match</param>
        /// <param name="id">child id</param>
        public List<Nanny> MotherConditions(Mother mother, int? id)
        {
            if (mother != null)
            {
                // get a list of nannys who thier days and hours match
                List<Nanny> nannyList = PotentialMatch(mother, id);
                // check the elevator, seniority and floor
                foreach (Nanny nanny in nannyList.Reverse<Nanny>())
                {
                    if ((mother.WantElevator == true && nanny.Elevator == false) || (mother.MinSeniority > nanny.Seniority) ||
                        (mother.MaxFloor < nanny.Floor))
                    {
                        nannyList.Remove(nanny);
                    }
                }
                return nannyList;
            }
            else return new List<Nanny>();
        }

        /// <summary>
        /// return true if a nanny is within the Km range of the mother
        /// </summary>
        /// <param name="mother">mother to chack range of Km</param>
        /// <param name="nanny">nanny to chack if is in the range of Km</param>
        /// <param name="Km">the range of Km to check</param>
        public bool IsNannyInKM(Mother mother, Nanny nanny, int? Km)
        {
            if (nanny != null && mother != null)
            {
                string address = mother.SearchAreaForNanny != "" ? mother.SearchAreaForNanny : mother.Address;
                if (Distance(address, nanny.Address) > Km * 1000)
                    return false;
                return true;
            }
            else return false;
        }

        /// <summary>
        /// return a list of nannys who match perfectly to the mother, 
        /// considering range of Km too
        /// </summary>
        /// <param name="mother">the mother to get a match</param>
        /// <param name="Km">the range of Km to check</param>
        /// <param name="id">child id</param>
        public List<Nanny> NannysInKMWithConditions(Mother mother, int? Km, int? id)
        {
            if (mother != null)
                return CloneNannyList().Where(nanny => IsNannyInKM(mother, nanny, Km)).ToList();
            else return new List<Nanny>();
        }

        /// <summary>
        /// return a list of nannys with a value, so that the value is 
        /// according tne mother needs
        /// <para>the more the mother's needs match more, the value is higher</para>
        /// </summary>
        /// <param name="mother">mother to check match</param>
        /// <param name="Km">the range of Km</param>
        /// <param name="id">child id</param>
        public List<Nanny> PropertiesMatch(Mother mother, int? Km, int? id)
        {
            if (mother != null)
            {
                // give value for each mother's need
                // if the nanny match this need give it a value 
                // else give 0
                // than sum the values 
                // the highest value means it is the best match
                List<Nanny> nannyList = CloneNannyList();
                foreach (Nanny nanny in nannyList.Reverse<Nanny>())
                {
                    if (IsChildInNannyAge(nanny, id) == false)
                    {
                        nannyList.Remove(nanny); continue;
                    }
                    nanny.HoursValue = PotentialHoursMatch(nanny, mother) == true ? 6 : 0;
                    nanny.DaysValue = PotentialDaysMatch(nanny, mother) == true ? 5 : 0;
                    nanny.SeniorityValue = mother.MinSeniority <= nanny.Seniority ? 4 : 0;
                    nanny.DistanceValue = IsNannyInKM(mother, nanny, Km) == true ? 3 : 0;
                    nanny.ElevatorValue = !(mother.WantElevator == true && nanny.Elevator == false) ? 2 : 0;
                    nanny.FloorValue = mother.MaxFloor >= nanny.Floor ? 1 : 0;
                    nanny.SumValue = nanny.HoursValue + nanny.DaysValue + nanny.SeniorityValue +
                        nanny.DistanceValue + nanny.ElevatorValue + nanny.FloorValue;
                }
                return nannyList;
            }
            else return new List<Nanny>();
        }

        /// <summary>
        /// retrun list of the best 5 match of nanny hwo match the mother
        /// </summary>
        /// <param name="mother">mothe to check the match</param>
        /// /// <param name="id">child id</param>
        public List<Nanny> PartialMatch(Mother mother, int? Km, int? id)
        {
            if (mother != null)
                return PropertiesMatch(mother, Km, id).OrderByDescending(nanny => nanny.SumValue)
                    .Take(5).ToList();
            else return new List<Nanny>();
        }

        /// <summary>
        /// return a list of children who don't has nanny
        /// </summary>
        public List<Child> ChildrenWithNoNanny()
        {
            return CloneChildList().Where(child => child.HaveNanny == false).ToList();
        }

        /// <summary>
        /// return a list of all nannys who thier vacations days are valid
        /// </summary>
        /// <returns></returns>
        public List<Nanny> ValidVacationsNannys()
        {
            return CloneNannyList().Where(nanny => nanny.IsValidVacationDays == true).ToList();
        }

        /// <summary>
        /// return a list of contracts filter by conditions
        /// </summary>
        /// <param name="contractCondition">boolean func that chack some conditions</param>
        public List<Contract> SpesificsContracts(Func<Contract, bool> contractCondition)
        {
            return CloneContractList().Where(contract => contractCondition(contract) == true).ToList();
        }

        /// <summary>
        /// return the number of contracts that meet certain conditions 
        /// </summary>
        /// <param name="contractCondition">boolean func that chack some conditions</param>
        public int? NumOfSpesificsContracts(Func<Contract, bool> contractCondition)
        {
            return SpesificsContracts(contractCondition).Count;
        }

        /// <summary>
        /// return a list of all mother's children
        /// </summary>
        /// <param name="mother">mother to get his children</param>
        public List<Child> MotherChildren(Mother mother)
        {
            if (mother != null)
                return CloneChildList().Where(child => child.MotherID == mother.ID).ToList();
            else return new List<Child>();
        }

        /// <summary>
        /// chaeck if a child is cared for by a nanny
        /// </summary>
        /// <param name="nanny">nanny to check</param>
        /// <param name="child">child to check</param>
        public bool IsChildByNanny(Nanny nanny, Child child)
        {
            if (nanny != null && child != null)
            {
                foreach (Contract contract in CloneContractList())
                {
                    if (contract.NannyID == nanny.ID && contract.ChildID == child.ID)
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// return a list of all children cared for by a nanny
        /// </summary>
        /// <param name="nanny">nanny to check</param>
        public List<Child> NannyChildren(Nanny nanny)
        {
            if (nanny != null)
                return CloneChildList().Where(child => IsChildByNanny(nanny, child)).ToList();
            else return new List<Child>();
        }

        /// <summary>
        /// return a list of all nanny's contracts
        /// </summary>
        /// <param name="nanny">nanny to check for</param>
        public List<Contract> NannyContracts(Nanny nanny)
        {
            if (nanny != null)
            {
                return (from contract in CloneContractList()
                        where contract.NannyID == nanny.ID
                        select contract).ToList();
            }
            else return new List<Contract>();
        }

        /// <summary>
        /// return a list of nanny hwo have less then "num" children
        /// </summary>
        /// <param name="num">number of children</param>
        public List<Nanny> NannyWitheChildrenLessThen(int? num)
        {
            return CloneNannyList().Where(nanny => nanny.Children <= num).ToList();
        }

        /// <summary>
        /// rrturn group of nannys group by the children age
        /// </summary>
        /// <param name="orderByMaxAge">if to order by max age</param>
        /// <param name="order">if to order at all</param>
        public IEnumerable<IGrouping<int?, Nanny>> GruopNannyByChildAge(bool orderByMaxAge, bool order)
        {
            IEnumerable<IGrouping<int?, Nanny>> group;
            if (order)
            {
                group = from nanny in CloneNannyList()
                        group nanny by (orderByMaxAge ? nanny.MaxAge : nanny.MinAge) into g
                        orderby g.Key
                        select g;
            }
            else
            {
                group = from nanny in CloneNannyList()
                        group nanny by (orderByMaxAge ? nanny.MaxAge : nanny.MinAge);
            }
            return group;
        }

        /// <summary>
        /// calculate the distance between a mother and nanny
        /// </summary>
        /// <param name="contract">contract to calculate the distance</param>
        public int? DistanceBetweenNannyAndMother(Contract contract)
        {
            if (contract != null)
            {
                Mother mother = FindMother(contract.MotherID);
                string address = mother.SearchAreaForNanny != "" ? mother.SearchAreaForNanny : mother.Address;
                // the distance function returns meter that's why they divide by 1000
                int? distance = Distance(address, FindNanny(contract.NannyID).Address) / 1000;
                if (distance == 0)
                    return 1;
                return (distance + 1);
            }
            return -1;
        }

        /// <summary>
        /// return a group of contract group by the distance between nanny and mother
        /// </summary>
        /// <param name="order">if to order</param>
        public IEnumerable<IGrouping<int?, Contract>> GroupContractByDistance(bool order)
        {
            IEnumerable<IGrouping<int?, Contract>> group;
            if (order)
                group = from contract in CloneContractList()
                        group contract by DistanceBetweenNannyAndMother(contract) into g
                        orderby g.Key
                        select g;
            else
                group = from contract in CloneContractList()
                        group contract by DistanceBetweenNannyAndMother(contract);
            return group.ToList();
        }


    }
}
