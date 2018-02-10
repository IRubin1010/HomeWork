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

    public class DsXml
    {
        public enum Type { Nanny, Mother, Child, Contract, Config };
        private string rootName { get; set; }
        public XElement Root { get; set; }
        public string filePath { get; set; }
        // return the location of the file
        public string location()
        {
            string str = Assembly.GetExecutingAssembly().Location;
            string localPath = Path.GetDirectoryName(str);
            for (int i = 0; i < 3; i++)
                localPath = Path.GetDirectoryName(localPath);
            return (localPath + @"\" + rootName + ".xml");
        }
        //constractor
        public DsXml(Type type)
        {
            switch (type)
            {
                case Type.Nanny:
                    rootName = "nannies";
                    break;
                case Type.Mother:
                    rootName = "mothers";
                    break;
                case Type.Child:
                    rootName = "childs";
                    break;
                case Type.Contract:
                    rootName = "contracts";
                    break;
                case Type.Config:
                    rootName = "config";
                    break;
                default:
                    break;
            }
            filePath = location();

            if (!File.Exists(filePath))
                CreateFiles();
            else
                LoadData();
        }
        private void CreateFiles()
        {
            Root = new XElement(rootName);
            if (rootName == "config")
            {
                Root.Add(new XElement("ContractNumber", 10000000));
            }
            Root.Save(filePath);
        }

        public void LoadData()
        {
            try
            {
                Root = XElement.Load(filePath);
            }
            catch
            {
                throw new FileNotFoundException("File upload problem");
            }
        }

        public void saveFile()
        {
            Root.Save(filePath);
        }
    }
}
