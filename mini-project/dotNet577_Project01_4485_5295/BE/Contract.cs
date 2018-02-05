using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Contract
    {
        //Properties//
        public int? ContractNumber { get; set; }
        public int? NannyID { get; set; }
        public int? ChildID { get; set; }
        public int? MotherID { get; set; }
        public bool IsMeet { get; set; }
        public bool IsContractSigned { get; set; }
        public int? HourlyFee { get; set; }
        public int? MonthlyFee { get; set; }
        public bool IsPaymentByHour { get; set; }
        public double FinalPayment { get; set; }
        public DateTime BeginTransection { get; set; }
        public DateTime EndTransection { get; set; }
        public double distence { get; set; }
        public string Details { get { return "contract number: " + ContractNumber; } }
       
        public Contract()
        {
            BeginTransection = DateTime.Today;
            EndTransection = DateTime.Today;
        }

        //override//

        public override string ToString()
        {
            return ContractNumber.ToString();
        }

        public string Print()
        {
            return "contract number: " + ContractNumber + '\n' +
                    "nanny ID: " + NannyID + '\n' +
                    "child ID: " + ChildID + '\n' +
                    "mother ID: " + MotherID + '\n' +
                    "is Meet: " + IsMeet + '\n' +
                    "is contreact signed: " + IsContractSigned + '\n' +
                    "hourly fee: " + HourlyFee + '\n' +
                    "monthly fee: " + MonthlyFee + '\n' +
                    "is payment by hour: " + IsPaymentByHour + '\n' +
                    "final payment: " + FinalPayment + '\n' +
                    "begin transection: " + BeginTransection.ToShortDateString() + '\n' +
                    "end transection: " + EndTransection.ToShortDateString() + '\n';
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Contract contract = obj as Contract;
            if (contract == null) return false;
            return this.ContractNumber == contract.ContractNumber;
        }

        /// <summary>
        /// clone contract
        /// </summary>
        /// <returns>clone contract object</returns>
        public Contract Clone()
        {
            return (Contract)MemberwiseClone();
        }
    }
}
