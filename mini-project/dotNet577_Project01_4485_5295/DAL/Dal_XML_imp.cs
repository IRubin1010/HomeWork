using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Ds_Xml;
using System.Xml.Linq;

namespace DAL
{
    static class Tools
    {
        public static int? NullOrIntValue(this int? parm, XElement element)
        {
            return string.IsNullOrEmpty(element.Value) ? default(int?) : int.Parse(element.Value);
        }
    }
    sealed class Dal_XML_imp : IDAL
    {
        DsXml nannyXml;
        DsXml motherXml;
        DsXml childXml;
        DsXml contractXml;
        DsXml configXml;
        int? tools = null;

        // implement for singelton
        static Dal_XML_imp() { }

        private Dal_XML_imp()
        {
            nannyXml = new DsXml(DsXml.Type.Nanny);
            motherXml = new DsXml(DsXml.Type.Mother);
            childXml = new DsXml(DsXml.Type.Child);
            contractXml = new DsXml(DsXml.Type.Contract);
            configXml = new DsXml(DsXml.Type.Config);
        }

        static readonly IDAL instance = new Dal_XML_imp();

        public static IDAL Instance { get { return instance; } }
        #region nanny function
        /* Nanny functions */

        /// <summary>
        /// create an xelement of nanny
        /// </summary>
        /// <param name="nanny">the nanny to create from her the xelement</param>
        /// <returns>xelement of nanny</returns>
        XElement createNanny(Nanny nanny)
        {
            return new XElement("Nanny",
                                 new XElement("ID", nanny.ID),
                                 new XElement("Name",
                                    new XElement("FirstName", nanny.FirstName),
                                    new XElement("LastName", nanny.LastName)),
                                 new XElement("BirthDate", nanny.BirthDate.ToShortDateString()),
                                 new XElement("NannyAge", nanny.NannyAge),
                                 new XElement("PhoneNumber", nanny.PhoneNumber),
                                 new XElement("Address", nanny.Address),
                                 new XElement("Elevator", nanny.Elevator),
                                 new XElement("Floor", nanny.Floor),
                                 new XElement("Seniority", nanny.Seniority),
                                 new XElement("Children", nanny.Children),
                                 new XElement("MaxChildren", nanny.MaxChildren),
                                 new XElement("MinAge", nanny.MinAge),
                                 new XElement("MaxAge", nanny.MaxAge),
                                 new XElement("IsHourlyFee", nanny.IsHourlyFee),
                                 new XElement("HourlyFee", nanny.HourlyFee),
                                 new XElement("MonthlyFee", nanny.MonthlyFee),
                                 new XElement("IsWork", nanny.IsWork.Select((x, i) => new XElement("day" + ++i, x))),
                                 new XElement("WorkHours", from day in nanny.WorkHours[0]
                                                           select new XElement("begin",
                                                                                 new XElement("hour", day.Hours),
                                                                                 new XElement("minute", day.Minutes),
                                                                                 new XElement("second", day.Seconds)),
                                                            from day in nanny.WorkHours[1]
                                                            select new XElement("end",
                                                                                 new XElement("hour", day.Hours),
                                                                                 new XElement("minute", day.Minutes),
                                                                                 new XElement("second", day.Seconds))),
                                 new XElement("IsValidVacationDays", nanny.IsValidVacationDays),
                                 new XElement("Recommendations", nanny.Recommendations)
                               );
        }
        public Nanny GetNanny(XElement nanny)
        {
            return new Nanny()
            {
                ID = tools.NullOrIntValue(nanny.Element("ID")),
                FirstName = nanny.Element("Name").Element("FirstName").Value,
                LastName = nanny.Element("Name").Element("LastName").Value,
                BirthDate = DateTime.Parse(nanny.Element("BirthDate").Value),
                NannyAge = tools.NullOrIntValue(nanny.Element("NannyAge")),
                PhoneNumber = tools.NullOrIntValue(nanny.Element("PhoneNumber")),
                Address = nanny.Element("Address").Value,
                Elevator = bool.Parse(nanny.Element("Elevator").Value),
                Floor = tools.NullOrIntValue(nanny.Element("Floor")),
                Seniority = tools.NullOrIntValue(nanny.Element("Seniority")),
                Children = tools.NullOrIntValue(nanny.Element("Children")),
                MaxChildren = tools.NullOrIntValue(nanny.Element("MaxChildren")),
                MinAge = tools.NullOrIntValue(nanny.Element("MinAge")),
                MaxAge = tools.NullOrIntValue(nanny.Element("MaxAge")),
                IsHourlyFee = bool.Parse(nanny.Element("IsHourlyFee").Value),
                HourlyFee = tools.NullOrIntValue(nanny.Element("HourlyFee")),
                MonthlyFee = tools.NullOrIntValue(nanny.Element("MonthlyFee")),
                IsValidVacationDays = bool.Parse(nanny.Element("IsValidVacationDays").Value),
                Recommendations = nanny.Element("Recommendations").Value,
                IsWork = (from day in nanny.Element("IsWork").Elements()
                          select bool.Parse(day.Value)).ToArray(),
                WorkHours = new TimeSpan[2][]
                             {
                                 (from day in nanny.Element("WorkHours").Elements("begin")
                                 select new TimeSpan(int.Parse(day.Element("hour").Value),
                                                     int.Parse(day.Element("minute").Value),
                                                     int.Parse(day.Element("second").Value))).ToArray(),
                                 (from day in nanny.Element("WorkHours").Elements("end")
                                 select new TimeSpan(int.Parse(day.Element("hour").Value),
                                                     int.Parse(day.Element("minute").Value),
                                                     int.Parse(day.Element("second").Value))).ToArray()
                             }
            };
        }
        /// <summary>
        /// add nanny to nanny's DB
        /// </summary>
        /// <param name="nanny">the nanny to add to NannyXml</param>
        /// <remarks> if find the nanny on the list - 
        /// meeans this nanny already exsist throw exception </remarks>
        public void AddNanny(Nanny nanny)
        {
            if (!FindNanny(nanny))
            {
                nannyXml.LoadData();
                nannyXml.Root.Add(createNanny(nanny));
                nannyXml.saveFile();
            }
            else
                throw new DALException(nanny.FullName() + " already exsist", "Add nanny");
        }

        /// <summary>
        /// delete nanny from nanny's DB
        /// </summary>
        /// <param name="nanny">the nanny to delete from NannyList</param>
        /// <remarks> accept nanny and send to DeleteNanny(int? id) function nanny's id </remarks>
        public void DeleteNanny(Nanny nanny)
        {
            try
            {
                DeleteNanny(nanny.ID);
            }
            catch (DALException ex)
            {
                throw new DALException(nanny.FullName() + " dosn't exsist", ex.sender);
            }
        }

        /// <summary>
        /// delete nanny from nanny's DB
        /// </summary>
        /// <param name="id">nanny's id of the nanny that want to deletee from NannyList</param>
        /// <remarks> if didn't find to remove, throw exception </remarks>
        public void DeleteNanny(int? id)
        {
            nannyXml.LoadData();
            XElement nannyElement = FindNannyXml(id);
            if (nannyElement == null)
                throw new DALException("nanny with ID: " + id + " dosn't exsist", "Delete Nanny");
            nannyElement.Remove();
            nannyXml.saveFile();
        }

        /// <summary>
        /// update nanny 
        /// </summary>
        /// <remarks></remarks>
        /// <param name="nanny">the new Nanny that replace the old nanny</param>
        /// <remarks>
        /// accept nanny, delete the old nanny and replace it with the new nanny
        /// if didn't find the nanny to delete, or can't add the new nanny throw exception
        /// </remarks>
        public void UpdateNanny(Nanny nanny)
        {
            if (FindNanny(nanny))
            {
                DeleteNanny(nanny);
                try
                {
                    AddNanny(nanny);
                }
                catch (DALException)
                {
                    throw new DALException("can't update " + nanny.FullName() + "details", "update nanny");
                }
            }
            else
                throw new DALException(nanny.FullName() + " dosn't exsist", "update nanny");
        }

        /// <summary>
        /// find nanny
        /// </summary>
        /// <param name="nanny">the nanny that we whant to find</param>
        /// <remarks>
        /// accept nanny and send to FindNanny(int? id) function with nanny id 
        /// return true if find, else return false
        /// </remarks>
        public bool FindNanny(Nanny nanny)
        {
            return FindNanny(nanny.ID) != null;
        }



        /// <summary>
        /// find nanny with given ID
        /// </summary>
        /// <param name="id">the nanny's id that we whant to find</param>
        /// <remarks>
        /// accept nanny id, return nanny if find, else return null
        /// </remarks>
        public Nanny FindNanny(int? id)
        {
            try
            {
                nannyXml.LoadData();
                Nanny Nanny;
                Nanny = (from nanny in nannyXml.Root.Elements("Nanny")
                         where Int32.Parse(nanny.Element("ID").Value) == id
                         select GetNanny(nanny)).FirstOrDefault();
                return Nanny;
            }
            catch (Exception)
            {
                throw;
            }
        }
        XElement FindNannyXml(int? id)
        {
            nannyXml.LoadData();
            XElement nanny;
            nanny = (from nannyElment in nannyXml.Root.Elements("Nanny")
                     where Int32.Parse(nannyElment.Element("ID").Value) == id
                     select nannyElment).FirstOrDefault();
            return nanny;
        }

        /// <summary>
        /// update the numabr of nanny's children
        /// </summary>
        /// <param name="nanny">the nanny that we whant to update her children number</param>
        /// <param name="num">flag, if num = 1 add 1 else sub 1 </param>
        /// <remarks>
        /// accept nanny and a number
        /// if number = 1, add 1 to nanny's children
        /// else reduce nanny's children by 1
        /// if didn't find the nanny throw exception
        /// </remarks>
        public void UpdateNannyChildren(Nanny nanny, int? num)
        {
            try
            {
                XElement nannyElment = FindNannyXml(nanny.ID);
                if (nannyElment != null)
                {
                    if (num == 1)
                        // add 1
                        nannyElment.Element("Children").SetValue(nanny.Children + 1);
                    else
                        //reduce by 1
                        nannyElment.Element("Children").SetValue(nanny.Children - 1);
                    nannyXml.saveFile();
                }
                else
                    throw new DALException(nanny.FullName() + " dosn't exsist", "AddNannyChildren");
            }
            catch (Exception)
            {

                throw new DALException("Failed in", "AddNannyChildren");
            }

        }
        #endregion
        #region mother function
        /// <summary>
        /// create an xelement of mother
        /// </summary>
        /// <param name="mother">the mother to create from her the xelement</param>
        /// <returns>xelement of mother</returns>
        XElement creatMother(Mother mother)
        {
            return new XElement("Mother",
                                 new XElement("ID", mother.ID),
                                 new XElement("Name",
                                                new XElement("FirstName", mother.FirstName),
                                                new XElement("LastName", mother.LastName)),
                                 new XElement("PhoneNumber", mother.PhoneNumber),
                                 new XElement("Address", mother.Address),
                                 new XElement("SearchAreaForNanny", mother.SearchAreaForNanny),
                                 new XElement("WantElevator", mother.WantElevator),
                                 new XElement("MinSeniority", mother.MinSeniority),
                                 new XElement("MaxFloor", mother.MaxFloor),
                                 new XElement("NeedNanny", mother.NeedNanny.Select((x, i) => new XElement("day" + ++i, x))),
                                 new XElement("NeedNannyHours", from day in mother.NeedNannyHours[0]
                                                                select new XElement("begin",
                                                                                      new XElement("hour", day.Hours),
                                                                                      new XElement("minute", day.Minutes),
                                                                                      new XElement("second", day.Seconds)),
                                                            from day in mother.NeedNannyHours[1]
                                                            select new XElement("end",
                                                                                 new XElement("hour", day.Hours),
                                                                                 new XElement("minute", day.Minutes),
                                                                                 new XElement("second", day.Seconds))),
                                 new XElement("Remarks", mother.Remarks)
                                 );
        }
        private Mother GetMother(XElement mother)
        {
            return new Mother()
            {
                ID = tools.NullOrIntValue(mother.Element("ID")),
                FirstName = mother.Element("Name").Element("FirstName").Value,
                LastName = mother.Element("Name").Element("LastName").Value,
                PhoneNumber = tools.NullOrIntValue(mother.Element("PhoneNumber")),
                Address = mother.Element("Address").Value,
                SearchAreaForNanny = mother.Element("SearchAreaForNanny").Value,
                WantElevator = bool.Parse(mother.Element("WantElevator").Value),
                MinSeniority = tools.NullOrIntValue(mother.Element("MinSeniority")),
                MaxFloor = tools.NullOrIntValue(mother.Element("MaxFloor")),
                Remarks = mother.Element("Remarks").Value,
                NeedNanny = (from day in mother.Element("NeedNanny").Elements()
                             select bool.Parse(day.Value)).ToArray(),
                NeedNannyHours = new TimeSpan[2][]
                              {
                                  (from day in mother.Element("NeedNannyHours").Elements("begin")
                                  select new TimeSpan(int.Parse(day.Element("hour").Value),
                                                      int.Parse(day.Element("minute").Value),
                                                      int.Parse(day.Element("second").Value))).ToArray(),
                                  (from day in mother.Element("NeedNannyHours").Elements("end")
                                  select new TimeSpan(int.Parse(day.Element("hour").Value),
                                                      int.Parse(day.Element("minute").Value),
                                                      int.Parse(day.Element("second").Value))).ToArray()
                              }
            };
        }
        /// <summary>
        /// add mother to mother's DB 
        /// </summary>
        /// <param name="mother">the mother to add to MotherList</param>
        /// <remarks>
        /// if find the mother on the list - this nanny already exsist throw exception
        /// </remarks>
        public void AddMother(Mother mother)
        {
            if (!FindMother(mother))
            {
                motherXml.LoadData();
                motherXml.Root.Add(creatMother(mother));
                motherXml.saveFile();
            }
            else
                throw new DALException(mother.FullName() + " already exsist", "Add mother");
        }
        /// <summary>
        /// delete mother from mother's DB
        /// </summary>
        /// <param name="mother">the mother to delete from MotherList</param>
        /// <remarks>
        /// accept mother and send to DeleteMother(int? id) function mother's id 
        /// </remarks>
        public void DeleteMother(Mother mother)
        {
            try
            {
                DeleteMother(mother.ID);
            }
            catch (DALException ex)
            {
                throw new DALException(mother.FullName() + " dosn't exsist", ex.sender);
            }
        }

        /// <summary>
        /// delete mother from mother's DB
        /// </summary>
        /// <param name="id">mother's id of the mother that want to delete from MotherList</param>
        /// <remarks>
        /// if didn't find to remove, throw exception
        /// </remarks>
        public void DeleteMother(int? id)
        {
            motherXml.LoadData();
            XElement motherElement = FindMotherXml(id);
            if (motherElement == null)
                throw new DALException("mother with ID: " + id + " dosn't exsist", "Delete Mother");
            try
            {
                motherElement.Remove();
                motherXml.saveFile();
            }
            catch (Exception)
            {
                throw new DALException("failed in the remove/save", "Delete Mother");
            }
        }

        /// <summary>
        /// update mother
        /// </summary>
        /// <param name="mother">the new mother that replace the old mother</param>
        /// <remarks>
        /// accept mother, delete the old mother and replace it with the new mother
        /// if didn't find the mother to delete, or can't add the new mother throw exception
        /// </remarks>
        public void UpdateMother(Mother mother)
        {
            if (FindMother(mother))
            {
                DeleteMother(mother);
                try
                {
                    AddMother(mother);
                }
                catch (DALException)
                {
                    throw new DALException("can't update " + mother.FullName(), "update mother");
                }
            }
            else
                throw new DALException(mother.FullName() + " dosn't exsist", "update mother");
        }

        /// <summary>
        /// find mother
        /// </summary>
        /// <param name="mother">the mother that we whant to find</param>
        /// <remarks>
        /// accept momther and send to FindMother(int? id) function with mother id 
        /// return true if find, else return false
        /// </remarks>
        public bool FindMother(Mother mother)
        {
            return FindMother(mother.ID) != null;
        }

        /// <summary>
        /// find mother with givan ID
        /// </summary>
        /// <param name="id">>the mother's id that we whant to find</param>
        /// <remarks>
        /// accept mother id, return mother if find, else return null
        /// </remarks>
        public Mother FindMother(int? id)
        {
            try
            {
                motherXml.LoadData();
                Mother Mother;
                Mother = (from mother in motherXml.Root.Elements()
                          where Int32.Parse(mother.Element("ID").Value) == id
                          select GetMother(mother)).FirstOrDefault();
                return Mother;
            }
            catch (Exception)
            {
                throw;
            }
        }

        XElement FindMotherXml(int? id)
        {
            motherXml.LoadData();
            XElement mother;
            mother = (from motherElment in motherXml.Root.Elements("Mother")
                      where Int32.Parse(motherElment.Element("ID").Value) == id
                      select motherElment).FirstOrDefault();
            return mother;
        }
        #endregion
        /* Child functions */

        XElement creatChild(Child child)
        {
            return new XElement("Child",
                                 new XElement("ID", child.ID),
                                 new XElement("MotherID", child.MotherID),
                                 new XElement("FirstName", child.FirstName),
                                 new XElement("BirthDate", child.BirthDate),
                                 new XElement("AgeInMonth", child.AgeInMonth),
                                 new XElement("IsSpecialNeeds", child.IsSpecialNeeds),
                                 new XElement("SpecialNeeds", child.SpecialNeeds),
                                 new XElement("HaveNanny", child.HaveNanny)
                                 );
        }
        private Child GetChild(XElement child)
        {
            return new Child()
            {
                ID = tools.NullOrIntValue(child.Element("ID")),
                MotherID = tools.NullOrIntValue(child.Element("MotherID")),
                FirstName = child.Element("FirstName").Value,
                BirthDate = DateTime.Parse(child.Element("BirthDate").Value),
                AgeInMonth = tools.NullOrIntValue(child.Element("AgeInMonth")),
                IsSpecialNeeds = bool.Parse(child.Element("IsSpecialNeeds").Value),
                SpecialNeeds = child.Element("SpecialNeeds").Value,
                HaveNanny = bool.Parse(child.Element("HaveNanny").Value)
            };
        }
        /// <summary>
        /// add child to child's DB
        /// </summary>
        /// <param name="child">the child to add to ChildList</param>
        /// <remarks>
        /// if find the child on the list - this child already exsist throw exception
        /// </remarks>
        public void AddChild(Child child)
        {
            if (!FindChild(child))
            {
                childXml.LoadData();
                childXml.Root.Add(creatChild(child));
                childXml.saveFile();
            }
            else
                throw new DALException(child.FirstName + " already exsist", "Add child");
        }

        /// <summary>
        /// delete child from child's DB
        /// </summary>
        /// <param name="child">the child to delete from ChildList</param>
        /// <remarks>
        /// accept child and send to DeleteChild(int? id) function child's id 
        /// </remarks>
        public void DeleteChild(Child child)
        {
            try
            {
                DeleteChild(child.ID);
            }
            catch (DALException ex)
            {
                throw new DALException(child.FirstName + " dosn't exsist", ex.sender);
            }
        }

        /// <summary>
        /// delete child from child's DB
        /// </summary>
        /// <param name="id">child's id of the child that want to delete from childList</param>
        /// <remarks>
        /// if didn't find to remove, throw exception
        /// </remarks>
        public void DeleteChild(int? id)
        {
            childXml.LoadData();
            XElement childElement = FindChildXml(id);
            if (childElement == null)
                throw new DALException("child with ID: " + id + " dosn't exsist", "Delete child");
            childElement.Remove();
            childXml.saveFile();
        }

        /// <summary>
        /// update child
        /// </summary>
        /// <param name="child">the new child that replace the old child</param>
        /// <remarks>
        /// accept child, delete the old child and replace it with the new child
        /// if didn't find the child to delete, or can't add the new child throw exception
        /// </remarks>
        public void UpdateChild(Child child)
        {
            if (FindChild(child))
            {
                DeleteChild(child);
                try
                {
                    AddChild(child);
                }
                catch (Exception)
                {
                    throw new DALException("can't update " + child.FirstName, "update child");
                }
            }
            else
                throw new DALException(child.FirstName + " dosn't exsist", "update child");
        }

        /// <summary>
        /// find child
        /// </summary>
        /// <param name="child">the child that we whant to find</param>
        /// <remarks>
        /// accept child and send to FindChild(int? id) function with child id 
        /// return true if find, else return false
        /// </remarks>
        public bool FindChild(Child child)
        {
            return FindChild(child.ID) != null;
        }

        /// <summary>
        /// find child with given ID
        /// </summary>
        /// <param name="id">the child's id that we whant to find</param>
        /// <remarks>
        /// accept child id, return child if find, else return null
        /// </remarks>
        public Child FindChild(int? id)
        {
            try
            {
                childXml.LoadData();
                Child Child;
                Child = (from child in childXml.Root.Elements("Child")
                         where Int32.Parse(child.Element("ID").Value) == id
                         select GetChild(child)).FirstOrDefault();
                return Child;
            }
            catch (Exception)
            {
                throw;
            }
        }



        XElement FindChildXml(int? id)
        {
            childXml.LoadData();
            XElement child;
            child = (from childElment in childXml.Root.Elements("Child")
                     where Int32.Parse(childElment.Element("ID").Value) == id
                     select childElment).FirstOrDefault();
            return child;
        }

        /// <summary>
        /// update if the child has nanny
        /// </summary>
        /// <param name="child">the child that we whant to change if he have a nanny</param>
        /// <param name="change">to what change</param>
        /// <remarks>
        /// get the child, if find the child change the "have nanny" parameter - according to 'change'
        ///                else throw exception  
        /// </remarks>
        public void UpdateHaveNanny(Child child, bool change)
        {
            XElement childElment = FindChildXml(child.ID);
            if (childElment != null)
            {
                childElment.Element("HaveNanny").SetValue(change);
                childXml.saveFile();
            }
            else
                throw new DALException(child.FirstName + " dosn't exsist", "Update Have Nanny");
        }


        /* contract functions */

        XElement createContract(Contract contract)
        {
            return new XElement("Contract",
                                 new XElement("ContractNumber", contract.ContractNumber),
                                 new XElement("NannyID", contract.NannyID),
                                 new XElement("ChildID", contract.ChildID),
                                 new XElement("MotherID", contract.MotherID),
                                 new XElement("IsMeet", contract.IsMeet),
                                 new XElement("IsContractSigned", contract.IsContractSigned),
                                 new XElement("HourlyFee", contract.HourlyFee),
                                 new XElement("MonthlyFee", contract.MonthlyFee),
                                 new XElement("IsPaymentByHour", contract.IsPaymentByHour),
                                 new XElement("FinalPayment", contract.FinalPayment),
                                 new XElement("BeginTransection", contract.BeginTransection),
                                 new XElement("EndTransection", contract.EndTransection));
        }

        private Contract GetContract(XElement contract)
        {
            return new Contract()
            {
                ContractNumber = tools.NullOrIntValue(contract.Element("ContractNumber")),
                NannyID = tools.NullOrIntValue(contract.Element("NannyID")),
                ChildID = tools.NullOrIntValue(contract.Element("ChildID")),
                MotherID = tools.NullOrIntValue(contract.Element("MotherID")),
                IsMeet = bool.Parse(contract.Element("IsMeet").Value),
                IsContractSigned = bool.Parse(contract.Element("IsContractSigned").Value),
                HourlyFee = tools.NullOrIntValue(contract.Element("HourlyFee")),
                MonthlyFee = tools.NullOrIntValue(contract.Element("MonthlyFee")),
                IsPaymentByHour = bool.Parse(contract.Element("IsPaymentByHour").Value),
                FinalPayment = double.Parse(contract.Element("FinalPayment").Value),
                BeginTransection = DateTime.Parse(contract.Element("BeginTransection").Value),
                EndTransection = DateTime.Parse(contract.Element("EndTransection").Value),
            };
        }

        /// <summary>
        /// add contract to contract's DB
        /// </summary>
        /// <param name="contract">the contract to add to ContractList</param>
        /// <remarks>
        /// accept contract, give the contract a number and add to contract list
        /// check that - nanny, mother and child exsist 
        /// check also that there this contract dosn't already exsist
        /// throw exceptions accordingly
        /// </remarks>
        public void AddContract(Contract contract)
        {
            contractXml.LoadData();
            configXml.LoadData();
            int ContractNumber = int.Parse(configXml.Root.Element("ContractNumber").Value);
            Nanny nanny = FindNanny(contract.NannyID);
            Mother mother = FindMother(contract.MotherID);
            Child child = FindChild(contract.ChildID);
            if (nanny != null)
                if (mother != null)
                    if (child != null)
                        if (FindContract(contract.ContractNumber) == null)
                        {
                            // if the contract number equals 0, give a new contract number
                            // if contract number is not 0 - means this is an update contract,
                            // don't give a new contract number
                            if (contract.ContractNumber == null)
                            {
                                contract.ContractNumber = ContractNumber++;
                                configXml.Root.Element("ContractNumber").SetValue(ContractNumber);
                                configXml.saveFile();
                            }
                            contract.IsContractSigned = true;
                            contractXml.Root.Add(createContract(contract));
                            contractXml.saveFile();
                        }
                        else throw new DALException(child.FirstName + " dosn't exsist", "Add contract");
                    else throw new DALException("this contract number already exsist", "Add contract");
                else throw new DALException(mother.FullName() + " dosn't exsist", "Add contract");
            else throw new DALException(nanny.FullName() + " dosn't exsist", "Add contract");
        }

        /// <summary>
        /// delete contract from contract's DB
        /// </summary>
        /// <param name="contract">the contract to delete from ContractList</param>
        /// <remarks>
        /// accept contract and send to DeleteContract(int? id) function contract's number 
        /// </remarks>
        public void DeleteContract(Contract contract)
        {
            try
            {
                DeleteContract(contract.ContractNumber);
            }
            catch (DALException ex)
            {
                throw new DALException("contract number: " + contract.ContractNumber + " dosn't exsist", ex.sender);
            }
        }

        /// <summary>
        /// delete contract from contract's DB
        /// </summary>
        /// <param name="contractNumber">Contract's number of the contract that want to delete</param>
        /// <remarks>
        /// if didn't find to remove, throw exception
        /// </remarks>
        public void DeleteContract(int? contractNumber)
        {
            XElement contract = FindContractXml(contractNumber);
            if (contract != null)
            {
                contract.Remove();
                contractXml.saveFile();
            }
        }

        /// <summary>
        /// update contract
        /// </summary>
        /// <param name="contract">the new child that replace the old child</param>
        /// <remarks>
        /// accept contract, delete the old contract and replace it with the new contract
        /// if didn't find the contract to delete, or can't add the new contract throw exception
        /// </remarks>
        public void UpdateContract(Contract contract)
        {
            if (FindContract(contract))
            {
                DeleteContract(contract);
                try
                {
                    AddContract(contract);
                }
                catch (Exception)
                {
                    throw new DALException("can't update contract", "update contract");
                }
            }
            else
                throw new DALException("contract number: " + contract.ContractNumber + " dosn't exsist", "update contract");
        }

        /// <summary>
        /// find contract
        /// </summary>
        /// <param name="contarct">the contract that we whant to find</param>
        /// <remarks>
        /// accept contract and send to FindContract(int? id) function with contract's nunmber 
        /// return true if find, else return false
        /// </remarks>
        public bool FindContract(Contract contarct)
        {
            return FindContract(contarct.ContractNumber) != null;
        }

        /// <summary>
        /// find contract with given contrat number
        /// </summary>
        /// <param name="contractNumber">the contract's number that we whant to find</param>
        /// <remarks>
        /// accept contract id, return contract if find, else return null
        /// </remarks>
        public Contract FindContract(int? contractNumber)
        {
            try
            {
                contractXml.LoadData();
                return (from contract in contractXml.Root.Elements("Contract")
                        where Int32.Parse(contract.Element("ContractNumber").Value) == contractNumber
                        select GetContract(contract)).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public XElement FindContractXml(int? contractNumber)
        {
            contractXml.LoadData();
            return (from contract in contractXml.Root.Elements("Contract")
                    where int.Parse(contract.Element("ContractNumber").Value) == contractNumber
                    select contract).FirstOrDefault();
        }

        public List<Nanny> CloneNannyList()
        {
            try
            {
                nannyXml.LoadData();
                return (from nanny in nannyXml.Root.Elements()
                        select GetNanny(nanny)).ToList();
            }
            catch { throw; }
        }

        public List<Mother> CloneMotherList()
        {
            try
            {
                motherXml.LoadData();
                return (from mother in motherXml.Root.Elements()
                        select GetMother(mother)).ToList();
            }
            catch { throw; }
        }

        public List<Child> CloneChildList()
        {
            try
            {
                childXml.LoadData();
                return (from child in childXml.Root.Elements()
                        select GetChild(child)).ToList();
            }
            catch { throw; }
        }

        public List<Contract> CloneContractList()
        {
            try
            {
                contractXml.LoadData();
                return (from contract in contractXml.Root.Elements()
                        select GetContract(contract)).ToList();
            }
            catch { throw; }
        }

        public List<Nanny> NannyList()
        {
            return CloneNannyList();
        }

        public List<Mother> MotherList()
        {
            return CloneMotherList();
        }

        public List<Child> ChildList()
        {
            return CloneChildList();
        }

        public List<Contract> ContractList()
        {
            return CloneContractList();
        }
    }
}
