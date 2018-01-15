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
    public class MotherXml
    {
        XElement MotheryRoot;
        string MotherPath;
        public string locaition()
        {
            string str = Assembly.GetExecutingAssembly().Location;
            string localPath = Path.GetDirectoryName(str);
            for (int i = 0; i < 3; i++)
                localPath = Path.GetDirectoryName(localPath);
            MotherPath = localPath + @"\Mothers.xml";
            return MotherPath;
        }
        public MotherXml()
        {
            MotherPath = locaition();
            if (!File.Exists(MotherPath))
                CreateFiles();
            else
                LoadData();
        }
        private void CreateFiles()
        {
            MotheryRoot = new XElement("Mothers");
            MotheryRoot.Save(MotherPath);
        }

        private void LoadData()
        {
            try
            {
                MotheryRoot = XElement.Load(MotherPath);
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }
    }
}
