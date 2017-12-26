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

        public Bl_imp()
        {
            dal = FactoryDAL.GetIDAL();
        }

        // Nanny
        public void AddNanny(Nanny nanny)
        {
            if (nanny.NannyAge < 18)
                throw new BLException(nanny.FullName() + " age is under 18", "add nanny");
            try
            {
                dal.AddNanny(nanny.Clone());
            }
            catch (DALException ex)
            {
                // CHECK IF CAN ONLY THROW
                throw;/*new BLException(ex.Message, ex.sender);*/
            }
        }

        public void DeleteNanny(Nanny nanny)
        {
            dal.DeleteNanny(nanny.Clone());
        }

        public void DeleteNanny(int id)
        {
            dal.DeleteNanny(id);
        }

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

        public bool FindNanny(Nanny nanny)
        {
            return dal.FindNanny(nanny.Clone());
        }

        public Nanny FindNanny(int id)
        {
            return dal.FindNanny(id).Clone();
        }

        // Mother
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

        public void DeleteMother(Mother mother)
        {
            dal.DeleteMother(mother.Clone());
        }

        public void DeleteMother(int id)
        {
            dal.DeleteMother(id);
        }

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

        public bool FindMother(Mother mother)
        {
            return dal.FindMother(mother.Clone());
        }

        public Mother FindMother(int id)
        {
            return dal.FindMother(id).Clone();
        }

        // Child
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

        public void DeleteChild(Child child)
        {
            dal.DeleteChild(child.Clone());
        }

        public void DeleteChild(int id)
        {
            dal.DeleteChild(id);
        }

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

        public bool FindChild(Child child)
        {
            return dal.FindChild(child.Clone());
        }

        public Child FindChild(int id)
        {
            return dal.FindChild(id).Clone();
        }

        // Contracts
        public void AddContract(Contract contract)
        {
            Mother mother = FindMother(contract.MotherID);
            Nanny nanny = FindNanny(contract.NannyID);
            Child child = FindChild(contract.ChildID);
            if (mother == null || nanny == null || child == null)
                throw new BLException(mother.FullName() + " or " + nanny.FullName() + " or " + child.FirstName + " dosn't exsist", "add contract");
            if (child.AgeInMonth < 3)
                throw new BLException(child.FirstName + " is under 3 month", "add contrsct");
            if (nanny.Children >= nanny.MaxChildren)
                throw new BLException(nanny.FullName() + "already has " + nanny.MaxChildren + " children", "Add contract");
            double discount = 1.0;
            foreach (Contract item in CloneContractList())
            {
                if (item.MotherID == contract.MotherID && item.NannyID == contract.NannyID)
                    discount -= 0.02;
            }
            if (contract.IsPaymentByHour == false)
                contract.FinalPayment = nanny.MonthlyFee * discount;
            else
            {
                double hoursPerWeek = 0;
                for (int i = 0; i < 6; i++)
                {
                    hoursPerWeek += mother.NeedNannyHours[1, i].TotalHours - mother.NeedNannyHours[0, i].TotalHours;
                }
                contract.FinalPayment = hoursPerWeek * discount;
            }
            nanny.Children++;
            try
            {
                dal.AddContract(contract.Clone());
            }
            catch (DALException ex)
            {
                throw new BLException(ex.Message, ex.sender);
            }
        }

        public void DeleteContract(Contract contract)
        {
            dal.DeleteContract(contract.Clone());
        }

        public void DeleteContract(int contractNumber)
        {
            dal.DeleteContract(contractNumber);
        }

        public void UpdateContract(Contract contract)
        {
            try
            {
                dal.UpdateContract(contract.Clone());
            }
            catch (DALException ex)
            {
                throw new BLException(ex.Message, ex.sender);
            }
        }

        public bool FindContract(Contract contract)
        {
            return dal.FindContract(contract.Clone());
        }

        public Contract FindContract(int contractNumber)
        {
            return dal.FindContract(contractNumber).Clone();
        }

        // Lists
        public List<Nanny> CloneNannyList()
        {
            return dal.NannyList().Select(nanny => nanny.Clone()).ToList();
        }

        public List<Mother> CloneMotherList()
        {
            return dal.MotherList().Select(mother => mother.Clone()).ToList();
        }

        public List<Child> CloneChildList()
        {
            return dal.ChildList().Select(child => child.Clone()).ToList();
        }

        public List<Contract> CloneContractList()
        {
            return dal.ContractList().Select(contract => contract.Clone()).ToList();
        }


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

        public List<Nanny> PotentialMatch(Mother mother)
        {
            return CloneNannyList().Where(nanny => PotentialHoursMatch(nanny, mother)
                && PotentialDaysMatch(nanny, mother)).ToList();
        }

        public bool PotentialHoursMatch(Nanny nanny, Mother mother)
        {
            for (int i = 0; i < 6; i++)
            {
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
            foreach (Nanny nanny in nannyList)
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
                nanny.SeniorityValue = mother.MinSeniority < nanny.Seniority ? 4 : 0;
                nanny.DistanceValue = IsNannyInKM(mother, nanny, Km) == true ? 3 : 0;
                nanny.ElevatorValue = !(mother.WantElevator == true && nanny.Elevator == false) ? 2 : 0;
                nanny.FloorValue = mother.MaxFloor < nanny.Floor ? 1 : 0;
                nanny.SumValue = nanny.HoursValue + nanny.DaysValue + nanny.SeniorityValue +
                    nanny.DistanceValue + nanny.ElevatorValue + nanny.FloorValue;
            }
            return nannyList;
        }

        public List<Nanny> PartialMatch(Mother mother, int Km)
        {
            return PropertiesMatch(mother, Km).OrderByDescending(nanny => nanny.SumValue)
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
