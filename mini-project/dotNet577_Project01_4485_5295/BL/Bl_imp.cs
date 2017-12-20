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
    public class Bl_imp : IBl
    {
        Dal_imp dal = new Dal_imp();

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

        public Nanny FindNanny(Nanny nanny)
        {
            return dal.FindNanny(nanny);
        }

        public Nanny FindNanny(int id)
        {
            return dal.FindNanny(id);
        }

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

        public Mother FindMother(Mother mother)
        {
            return dal.FindMother(mother);
        }

        public Mother FindMother(int id)
        {
            return dal.FindMother(id);
        }

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

        public Child FindChild(Child child)
        {
            return dal.FindChild(child);
        }

        public Child FindChild(int id)
        {
            return dal.FindChild(id);
        }

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

        public Contract FindContract(Contract contract)
        {
            return dal.FindContract(contract);
        }

        public Contract FindContract(int contractNumber)
        {
            return dal.FindContract(contractNumber);
        }

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
    }
}
