﻿using System;
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
    public class Bl_imp : IBl
    {
        Dal_imp dal = new Dal_imp();

        // Nanny
        public bool AddNanny(Nanny nanny)
        {
            if (nanny.NannyAge < 18)
                return false;
            return dal.AddNanny(nanny);
        }

        public void DeleteNanny(Nanny nanny)
        {
            dal.DeleteNanny(nanny);
        }

        public void DeleteNanny(int id)
        {
            dal.DeleteNanny(id);
        }

        public void UpdateNanny(int id)
        {
            dal.UpdateNanny(id);
        }

        public void UpdateNanny(Nanny nanny)
        {
            dal.UpdateNanny(nanny);
        }

        public bool FindNanny(Nanny nanny)
        {
            return dal.FindNanny(nanny);
        }

        public Nanny FindNanny(int id)
        {
            return dal.FindNanny(id);
        }

        // Mother
        public bool AddMother(Mother mother)
        {
            return dal.AddMother(mother);
        }

        public void DeleteMother(Mother mother)
        {
            dal.DeleteMother(mother);
        }

        public void DeleteMother(int id)
        {
            dal.DeleteMother(id);
        }

        public void UpdateMother(int id)
        {
            dal.UpdateMother(id);
        }

        public void UpdateMother(Mother mother)
        {
            dal.UpdateMother(mother);
        }

        public bool FindMother(Mother mother)
        {
            return dal.FindMother(mother);
        }

        public Mother FindMother(int id)
        {
            return dal.FindMother(id);
        }

        // Child
        public bool AddChild(Child child)
        {
            return dal.AddChild(child);
        }

        public void DeleteChild(Child child)
        {
            dal.DeleteChild(child);
        }

        public void DeleteChild(int id)
        {
            dal.DeleteChild(id);
        }

        public void UpdateChild(int id)
        {
            dal.UpdateChild(id);
        }

        public void UPdateChild(Child child)
        {
            dal.UpdateChild(child);
        }

        public bool FindChild(Child child)
        {
            return dal.FindChild(child);
        }

        public Child FindChild(int id)
        {
            return dal.FindChild(id);
        }

        // Contracts
        public bool AddContract(Contract contract)
        {
            Mother mother = FindMother(contract.MotherID);
            Nanny nanny = FindNanny(contract.NannyID);
            Child child = FindChild(contract.ChildID);
            if (mother == null || nanny == null || child == null)
                return false;
            if (child.AgeInMonth < 3)
                return false;
            if (nanny.Children > nanny.MaxChildren)
                return false;
            double discount = 1.0;
            foreach (Contract item in ContractList())
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
            return dal.AddContract(contract);
        }

        public void DeleteContract(Contract contract)
        {
            dal.DeleteContract(contract);
        }

        public void DeleteContract(int contractNumber)
        {
            dal.DeleteContract(contractNumber);
        }

        public void UpdateContract(int contractNumber)
        {
            dal.UpdateContract(contractNumber);
        }

        public void UpdateContract(Contract contract)
        {
            dal.UpdateContract(contract);
        }

        public bool FindContract(Contract contract)
        {
            return dal.FindContract(contract);
        }

        public Contract FindContract(int contractNumber)
        {
            return dal.FindContract(contractNumber);
        }

        // Lists
        public List<Nanny> NannyList()
        {
            return dal.NannyList();
        }

        public List<Mother> MotherList()
        {
            return dal.MotherList();
        }

        public List<Child> ChildList()
        {
            return dal.ChildList();
        }

        public List<Contract> ContractList()
        {
            return dal.ContractList();
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
            List<Nanny> nannyList = new List<Nanny>();
            foreach (Nanny nanny in NannyList())
            {
                if (PotentialHoursMatch(nanny, mother) && PotentialDaysMatch(nanny, mother))
                    nannyList.Add(nanny);
            }
            return nannyList;
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

        public List<Nanny> NannysInKM(Mother mother, int Km)
        {
            List<Nanny> nannyList = MotherConditions(mother);
            foreach (Nanny nanny in nannyList)
                if (IsNannyInKM(mother, nanny, Km) == false)
                    nannyList.Remove(nanny);
            return nannyList;
        }

        public void PropertiesMatch(Mother mother, int Km)
        {
            foreach (Nanny nanny in NannyList())
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
        }

        public List<Nanny> PartialMatch(Mother mother, int Km)
        {
            PropertiesMatch(mother, Km);
            List<Nanny> nannyList = NannyList().OrderBy(nanny => nanny.SumValue).ToList<Nanny>();
            nannyList.RemoveRange(0,nannyList.Count - 5);
            return nannyList;
        }

        public List<Child> ChildrenWithNoNanny()
        {
            List<Child> children = new List<Child>();
            foreach (Child child in ChildList())
            {
                if (child.HaveNanny == false)
                    children.Add(child);
            }
            return children;
        }

        public List<Nanny> ValidVacationsNannys()
        {
            List<Nanny> nannys = new List<Nanny>();
            foreach (Nanny nanny in NannyList())
            {
                if (nanny.IsValidVacationDays == true)
                    nannys.Add(nanny);
            }
            return nannys;
        }

        public List<Contract> SpesificsContracts(Func<Contract, bool> contractCondition)
        {
            List<Contract> contractsList = new List<Contract>();
            foreach (Contract contract in ContractList())
            {
                if (contractCondition(contract) == true)
                    contractsList.Add(contract);
            }
            return contractsList;
        }

        public int NumOfSpesificsContracts(Func<Contract, bool> contractCondition)
        {
            int numOfContracts = 0;
            foreach (Contract contract in ContractList())
            {
                if (contractCondition(contract))
                    numOfContracts++;
            }
            return numOfContracts;
        }
    }
}
