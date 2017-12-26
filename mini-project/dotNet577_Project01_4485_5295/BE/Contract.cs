using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Contract
    {
        public int ContractNumber { get; set; }
        public int NannyID { get; }
        public int ChildID { get; }
        public int MotherID { get; }
        public bool IsMeet { get; }
        public bool ContractSigned { get; }
        public int HourlyFee { get; }
        public int MonthlyFee { get; }
        public bool IsPaymentByHour { get; }
        public double FinalPayment { get; set; }
        public DateTime BeginTransection { get; set; }
        public DateTime EndTransection { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Contract contract = obj as Contract;
            if (contract == null) return false;
            return this.ContractNumber == contract.ContractNumber;
        }

        public Contract Clone()
        {
            Contract contract = (Contract)MemberwiseClone();
            contract.BeginTransection = new DateTime(BeginTransection.Year, BeginTransection.Month, BeginTransection.Day);
            contract.EndTransection = new DateTime(EndTransection.Year, EndTransection.Month, EndTransection.Day);
            return contract;
        }
    }
}
