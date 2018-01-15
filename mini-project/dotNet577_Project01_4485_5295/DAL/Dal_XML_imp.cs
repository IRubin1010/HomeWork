using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
//using Ds_Xml;
using System.Xml.Linq;

//namespace DAL
//{
//    class Dal_XML_imp : IDAL
//    {
//        NannyXml nannyXml = new NannyXml();

//        /* Nanny functions */

//        /// <summary>
//        /// create an xelement of nanny
//        /// </summary>
//        /// <param name="nanny">the nanny to create from her the xelement</param>
//        /// <returns>xelement of nanny</returns>
//        XElement createNanny(Nanny nanny)
//        {
//            return new XElement("Nanny",
//                                 new XElement("id", nanny.ID),
//                                 new XElement("Name",
//                                    new XElement("FirstName", nanny.FirstName),
//                                    new XElement("LastName", nanny.LastName)),
//                                 new XElement("BirthDate",nanny.BirthDate),
//                                 new XElement("NannyAge",nanny.NannyAge),
//                                 new XElement("PhoneNumber",nanny.PhoneNumber),
//                                 new XElement("Address",nanny.Address),
//                                 new XElement("Elevator",nanny.Elevator),
//                                 new XElement("Floor",nanny.Floor),
//                                 new XElement("Seniority",nanny.Seniority),
//                                 new XElement("Children",nanny.Children),
//                                 new XElement("MaxChildren",nanny.MaxChildren),
//                                 new XElement("MinAge",nanny.MinAge),
//                                 new XElement("MaxAge",nanny.MaxAge),
//                                 new XElement("IsHourlyFee",nanny.IsHourlyFee),
//                                 new XElement("HourlyFee",nanny.HourlyFee),
//                                 new XElement("MonthlyFee",nanny.MonthlyFee),
//                                 new XElement("IsWork",nanny.IsWork.Select(x=>new XElement("day",x)),
//                                 new XElement("IsValidVacationDays", nanny.IsValidVacationDays),
//                                 new XElement("Recommendations",nanny.Recommendations))
//                               );
//        }

//        /// <summary>
//        /// add nanny to nanny's DB
//        /// </summary>
//        /// <param name="nanny">the nanny to add to NannyXml</param>
//        /// <remarks> if find the nanny on the list - 
//        /// meeans this nanny already exsist throw exception </remarks>
//        public void AddNanny(Nanny nanny)
//        {
//            if (!FindNanny(nanny))
//            {
//                nannyXml.LoadData();
//                nannyXml.NannyRoot.Add(createNanny(nanny));
//                nannyXml.NannyRoot.Save(nannyXml.NannyPath);
//            }
//            else
//                throw new DALException(nanny.FullName() + " already exsist", "Add nanny");
//        }

//        /// <summary>
//        /// delete nanny from nanny's DB
//        /// </summary>
//        /// <param name="nanny">the nanny to delete from NannyList</param>
//        /// <remarks> accept nanny and send to DeleteNanny(int? id) function nanny's id </remarks>
//        public void DeleteNanny(Nanny nanny)
//        {
//            try
//            {
//                DeleteNanny(nanny.ID);
//            }
//            catch (DALException ex)
//            {
//                throw new DALException(nanny.FullName() + " dosn't exsist", ex.sender);
//            }
//        }

//        /// <summary>
//        /// delete nanny from nanny's DB
//        /// </summary>
//        /// <param name="id">nanny's id of the nanny that want to deletee from NannyList</param>
//        /// <remarks> if didn't find to remove, throw exception </remarks>
//        public void DeleteNanny(int? id)
//        {
//            if (!NannyList().Remove(FindNanny(id)))
//                throw new DALException("nanny with ID: " + id + " dosn't exsist", "Delete Nanny");
//        }

//    }
//}
