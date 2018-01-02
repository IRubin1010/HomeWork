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

        // add Nanny
        // if nany age is under 18 throw exception 
        // cal dal.addNanny 
        public void AddNanny(Nanny nanny)
        {
            if (nanny.NannyAge < 18)
                throw new BLException(nanny.FullName() + " age is under 18", "add nanny");
            try
            {
                dal.AddNanny(nanny.Clone());
            }
            catch (DALException)
            {
                throw;
            }
        }

        // delete nanny
        // accept nanny and cal dal.DeleteNanny(Nanny nanny)
        public void DeleteNanny(Nanny nanny)
        {
            try
            {
                DeleteNanny(nanny.ID);
            }
            catch (DALException)
            {

                throw;
            }
        }

        // delete nanny
        // accept id and cal dal.DeleteNanny(int id)
        public void DeleteNanny(int id)
        {
            try
            {
                foreach (Contract contract in CloneContractList().Reverse<Contract>())
                {
                    if (contract.NannyID == id)
                    {
                        DeleteContract(contract);
                    }
                }
                dal.DeleteNanny(id);
            }
            catch (DALException)
            {
                throw;
            }
        }

        // update nanny
        // accept nanny and cal dal.UpdateNanny 
        public void UpdateNanny(Nanny nanny)
        {
            try
            {
                dal.UpdateNanny(nanny.Clone());
            }
            catch (DALException ex)
            {
                throw new BLException(ex.Message, ex.sender);
            }
        }

        // find nanny
        // accept nanny and cal dal.FindNanny(Nanny nanny)
        // retrun true if find, else return false
        public bool FindNanny(Nanny nanny)
        {
            return dal.FindNanny(nanny.Clone());
        }

        // find nanny
        // accept nanny and cal dal.FindNanny(int id)
        // retrun nanny if find, else return null
        public Nanny FindNanny(int id)
        {
            Nanny nanny = dal.FindNanny(id);
            return nanny == null ? null : nanny.Clone();
        }

        // update the numabr of nanny's children
        // cal dal.UpdateNannyChildren to update
        public void UpdateNannyChildren(Nanny nanny, int num)
        {
            try
            {
                dal.UpdateNannyChildren(nanny, num);
            }
            catch (DALException)
            {
                throw;
            }
        }

        /* mother functions */

        // add mother
        // call dal.addmother
        public void AddMother(Mother mother)
        {
            try
            {
                dal.AddMother(mother.Clone());
            }
            catch (DALException ex)
            {
                throw new BLException(ex.Message, ex.sender);
            }
        }

        // delete mother
        // accept mother and cal dal.DeleteMother(Mother mother)
        public void DeleteMother(Mother mother)
        {
            try
            {
                DeleteMother(mother.ID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // delete mother
        // accept id and cal dal.DeleteMother(int id)
        public void DeleteMother(int id)
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
            catch (DALException)
            {
                throw;
            }
        }

        // update mother
        // accept mother and cal dal.UpdateMother
        public void UpdateMother(Mother mother)
        {
            try
            {
                dal.UpdateMother(mother.Clone());
            }
            catch (DALException ex)
            {
                throw new BLException(ex.Message, ex.sender);
            }
        }

        // find mother
        // accept mother and cal dal.FindMother(Mother mother)
        // retrun true if find, else return false
        public bool FindMother(Mother mother)
        {
            return dal.FindMother(mother.Clone());
        }

        // find mother
        // accept mother and cal dal.FindMother(int id)
        // retrun mother if find, else return null
        public Mother FindMother(int id)
        {
            Mother mother = dal.FindMother(id);
            return mother == null ? null : mother.Clone();
        }

        /* child functions */

        // add Child
        // call dal.AddChild
        public void AddChild(Child child)
        {
            try
            {
                dal.AddChild(child.Clone());
            }
            catch (DALException ex)
            {
                throw new BLException(ex.Message, ex.sender);
            }
        }

        // delete child
        // accept child and cal dal.DeleteMother(Child child)
        public void DeleteChild(Child child)
        {
            try
            {
                DeleteChild(child.ID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // delete child
        // accept id and cal dal.DeleteChild(int id)
        public void DeleteChild(int id)
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
            catch (Exception)
            {
                throw;
            }
        }

        // update child
        // accept child and cal dal.UpdateChild
        public void UpdateChild(Child child)
        {
            try
            {
                dal.UpdateChild(child.Clone());
            }
            catch (DALException ex)
            {
                throw new BLException(ex.Message, ex.sender);
            }
        }

        // find child
        // accept child and cal dal.FindChild(Child child)
        // retrun true if find, else return false
        public bool FindChild(Child child)
        {
            return dal.FindChild(child.Clone());
        }

        // find child
        // accept child and cal dal.FindChild(int id)
        // retrun child if find, else return null
        public Child FindChild(int id)
        {
            Child child = dal.FindChild(id);
            return child == null ? null : child.Clone();
        }

        // update if the child has nanny
        // cal dal.UpdateHaveNanny to update
        public void UpdateHaveNanny(Child child, bool change)
        {
            try
            {
                dal.UpdateHaveNanny(child, change);
            }
            catch (DALException)
            {
                throw;
            }
        }

        /* contract functions */

        // add contract
        // accept contract, update number of nanny's children, that the child has nanny,
        // the final payment and cal dal.AddContract to add the contract
        // check that - nanny, mother and child exsist 
        // check also that there this contract dosn't already exsist
        // throw exceptions accordingly
        public void AddContract(Contract contract)
        {
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
            if (child.HaveNanny == true)
                throw new BLException(child.FirstName + " already has a nanny ", "add contrsct");
            // if nanny has more then his max childre throw exception
            if (nanny.Children >= nanny.MaxChildren)
                throw new BLException(nanny.FullName() + " already has " + nanny.MaxChildren + " children", "Add contract");
            // calculate the final payment
            CalculatePayment(contract);
            try
            {
                // update number of nanny's children and that the child has nanny
                UpdateNannyChildren(nanny, 1);
                UpdateHaveNanny(child, true);
                dal.AddContract(contract.Clone());
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

        // delete contract
        // accept contract and cal dal.DeleteContract(Contract contract)
        public void DeleteContract(Contract contract)
        {
            DeleteContract(contract.ContractNumber);
        }

        // delete contract
        // accept contractNumber and cal dal.DeleteContract(int contractNumber)
        public void DeleteContract(int contractNumber)
        {
            Contract contract = FindContract(contractNumber);
            if (contract != null)
            {
                try
                {
                    dal.UpdateNannyChildren(dal.FindNanny(contract.NannyID), -1);
                    dal.UpdateHaveNanny(dal.FindChild(contract.ChildID), false);
                    dal.DeleteContract(contractNumber);
                }
                catch (DALException ex)
                {
                    if (ex.sender == "Update Have Nanny")
                        UpdateNannyChildren(dal.FindNanny(contract.NannyID), 1);
                    if (ex.sender == "Delete contract")
                        UpdateNannyChildren(dal.FindNanny(contract.NannyID), 1); UpdateHaveNanny(dal.FindChild(contract.ChildID), true);
                    throw;
                }
            }
        }

        // update contract
        // accept contract, calculate the final payment again (in case  there
        // was a change in the payment configuration) and cal dal.UpdateContract
        public void UpdateContract(Contract contract)
        {
            try
            {
                CalculatePayment(contract);
                dal.UpdateContract(contract.Clone());
            }
            catch (DALException ex)
            {
                throw new BLException(ex.Message, ex.sender);
            }
        }

        // find contract
        // accept contract and cal dal.FindContract(Contract contract)
        // retrun true if find, else return false
        public bool FindContract(Contract contract)
        {
            return dal.FindContract(contract.Clone());
        }

        // find contract
        // accept contractNumber and cal dal.FindChild(int contractNumber)
        // retrun contract if find, else return null
        public Contract FindContract(int contractNumber)
        {
            Contract contract = dal.FindContract(contractNumber);
            return contract == null ? null : contract.Clone();
        }

        // clculate payment
        // calculate the payment according to the children the mother have 
        // at this nanny, and according to pay per hour or week
        public void CalculatePayment(Contract contract)
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
                contract.FinalPayment = contract.MonthlyFee * discount;
            // if hourly fee
            else
            {
                double hoursPerWeek = 0;
                // calculate the actual hours 
                for (int i = 0; i < 6; i++)
                {
                    if (mother.NeedNannyHours[1, i] <= nanny.WorkHours[1, i])
                        hoursPerWeek += mother.NeedNannyHours[1, i].TotalHours;
                    else
                        hoursPerWeek += nanny.WorkHours[1, i].TotalHours;
                    if (mother.NeedNannyHours[0, i] <= nanny.WorkHours[0, i])
                        hoursPerWeek -= nanny.WorkHours[0, i].TotalHours;
                    else
                        hoursPerWeek -= mother.NeedNannyHours[0, i].TotalHours;
                }
                contract.FinalPayment = hoursPerWeek * discount * contract.HourlyFee;
            }
        }

        /* list return functions */

        // return a list of clone nanny objects
        public List<Nanny> CloneNannyList()
        {
            return dal.CloneNannyList().Select(nanny => nanny.Clone()).ToList();
        }

        // return a list of clone mother objects
        public List<Mother> CloneMotherList()
        {
            return dal.CloneMotherList().Select(mother => mother.Clone()).ToList();
        }

        // return a list of clone child objects
        public List<Child> CloneChildList()
        {
            return dal.CloneChildList().Select(child => child.Clone()).ToList();
        }

        // return a list of clone contract objects
        public List<Contract> CloneContractList()
        {
            return dal.CloneContractList().Select(contract => contract.Clone()).ToList();
        }


        // distance
        // calculate the distance between 2 address
        public int Distance(string addressA, string addressB)
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

        // Potential match
        // return a list of nanny who work at the same days and hours as the mother need
        public List<Nanny> PotentialMatch(Mother mother)
        {
            return CloneNannyList().Where(nanny => PotentialHoursMatch(nanny, mother)
                && PotentialDaysMatch(nanny, mother)).ToList();
        }


        public bool PotentialHoursMatch(Nanny nanny, Mother mother)
        {
            for (int i = 0; i < 6; i++)
            {
                if (nanny.IsWork[i])
                    if (mother.NeedNannyHours[0, i] < nanny.WorkHours[0, i] || mother.NeedNannyHours[1, i] > nanny.WorkHours[1, i])
                        return false;
            }
            return true;
        }

        public bool PotentialDaysMatch(Nanny nanny, Mother mother)
        {
            for (int i = 0; i < nanny.IsWork.Length; i++)
            {
                if (nanny.IsWork[i] == false && mother.NeedNanny[i] == true)
                    return false;
            }
            return true;
        }

        public List<Nanny> MotherConditions(Mother mother)
        {
            List<Nanny> nannyList = PotentialMatch(mother);
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

        public bool IsNannyInKM(Mother mother, Nanny nanny, int Km)
        {
            string address = mother.SearchAreaForNanny != null ? mother.SearchAreaForNanny : mother.Address;
            if (Distance(address, nanny.Address) > Km)
                return false;
            return true;
        }

        public List<Nanny> NannysInKMWithConditions(Mother mother, int Km)
        {
            return MotherConditions(mother).Where(nanny => IsNannyInKM(mother, nanny, Km)).ToList();
        }

        public List<Nanny> PropertiesMatch(Mother mother, int Km)
        {
            List<Nanny> nannyList = CloneNannyList();
            foreach (Nanny nanny in nannyList)
            {
                nanny.HoursValue = PotentialHoursMatch(nanny, mother) == true ? 6 : 0;
                nanny.DaysValue = PotentialDaysMatch(nanny, mother) == true ? 5 : 0;
                nanny.SeniorityValue = mother.MinSeniority <= nanny.Seniority ? 4 : 0;
                // nanny.DistanceValue = IsNannyInKM(mother, nanny, Km) == true ? 3 : 0;
                nanny.ElevatorValue = !(mother.WantElevator == true && nanny.Elevator == false) ? 2 : 0;
                nanny.FloorValue = mother.MaxFloor >= nanny.Floor ? 1 : 0;
                nanny.SumValue = nanny.HoursValue + nanny.DaysValue + nanny.SeniorityValue +
                    nanny.DistanceValue + nanny.ElevatorValue + nanny.FloorValue;
            }
            return nannyList;
        }

        public List<Nanny> PartialMatch(Mother mother/*, int Km*/)
        {
            return PropertiesMatch(mother, 5).OrderByDescending(nanny => nanny.SumValue)
                .Take(5).ToList();
        }

        public List<Child> ChildrenWithNoNanny()
        {
            return CloneChildList().Where(child => child.HaveNanny == false).ToList();
        }

        public List<Nanny> ValidVacationsNannys()
        {
            return CloneNannyList().Where(nanny => nanny.IsValidVacationDays == true).ToList();
        }

        public List<Contract> SpesificsContracts(Func<Contract, bool> contractCondition)
        {
            return CloneContractList().Where(contract => contractCondition(contract) == true).ToList();
        }

        public int NumOfSpesificsContracts(Func<Contract, bool> contractCondition)
        {
            return CloneContractList().Where(contract => contractCondition(contract) == true).ToList().Count;
        }

        public IEnumerable<IGrouping<int, Nanny>> GruopNannyByChildAge(bool descendig, bool order)
        {
            IEnumerable<IGrouping<int, Nanny>> group;
            if (order)
                if (descendig)
                    group = CloneNannyList().OrderByDescending(nanny => nanny.MaxAge).ThenBy(nanny => nanny.LastName).GroupBy(nanny => nanny.MaxAge);
                else
                    group = CloneNannyList().OrderBy(nanny => nanny.MaxAge).ThenBy(nanny => nanny.LastName).GroupBy(nanny => nanny.MaxAge);
            else
                if (descendig)
                group = CloneNannyList().OrderByDescending(nanny => nanny.MaxAge).GroupBy(nanny => nanny.MaxAge);
            else
                group = CloneNannyList().OrderBy(nanny => nanny.MaxAge).GroupBy(nanny => nanny.MaxAge);
            return group;
        }

        public int DistanceBetweenNannyAndMother(Contract contract)
        {
            Mother mother = FindMother(contract.MotherID);
            string address = mother.SearchAreaForNanny != null ? mother.SearchAreaForNanny : mother.Address;
            int distance = Distance(address, FindNanny(contract.NannyID).Address) / 5;
            if (distance == 0)
                return 5;
            return (distance + 1) * 5;
        }
        public IEnumerable<IGrouping<int, Contract>> GroupContractByDistance(bool order)
        {
            IEnumerable<IGrouping<int, Contract>> group;
            if (order)
                group = CloneContractList().OrderBy(contract => contract.ContractNumber).GroupBy(contract => DistanceBetweenNannyAndMother(contract));
            else
                group = CloneContractList().GroupBy(contract => DistanceBetweenNannyAndMother(contract));
            return group;
        }
    }
}
