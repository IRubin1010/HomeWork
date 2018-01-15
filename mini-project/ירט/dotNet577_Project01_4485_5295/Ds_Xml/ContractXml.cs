using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ds_Xml
{
    class ContractXml
    {
        XElement ContractRoot;
        string ContractPath;
        public string locaition()
        {
            string str = Assembly.GetExecutingAssembly().Location;
            string localPath = Path.GetDirectoryName(str);
            for (int i = 0; i < 3; i++)
                localPath = Path.GetDirectoryName(localPath);
            ContractPath = localPath + @"\Contracts.xml";
            return ContractPath;
        }
        public ContractXml()
        {
            ContractPath = locaition();
            if (!File.Exists(ContractPath))
                CreateFiles();
            else
                LoadData();
        }
        private void CreateFiles()
        {
            ContractRoot = new XElement("Contracts");
            ContractRoot.Save(ContractPath);
        }

        private void LoadData()
        {
            try
            {
                ContractRoot = XElement.Load(ContractPath);
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }
    }
}
