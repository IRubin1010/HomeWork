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
    class ChildXml
    {
        XElement ChildRoot;
        string ChildPath;
        public string locaition()
        {
            string str = Assembly.GetExecutingAssembly().Location;
            string localPath = Path.GetDirectoryName(str);
            for (int i = 0; i < 3; i++)
                localPath = Path.GetDirectoryName(localPath);
            ChildPath = localPath + @"\Childs.xml";
            return ChildPath;
        }
        public ChildXml()
        {
            ChildPath = locaition();
            if (!File.Exists(ChildPath))
                CreateFiles();
            else
                LoadData();
        }
        private void CreateFiles()
        {
            ChildRoot = new XElement("Childs");
            ChildRoot.Save(ChildPath);
        }

        private void LoadData()
        {
            try
            {
                ChildRoot = XElement.Load(ChildPath);
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }
    }
}
