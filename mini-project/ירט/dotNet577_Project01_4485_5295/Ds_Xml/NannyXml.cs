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
    public class NannyXml
    {
        public XElement NannyRoot;
        public string NannyPath;
        public string locaition()
        {
            string str = Assembly.GetExecutingAssembly().Location;
            string localPath = Path.GetDirectoryName(str);
            for (int i = 0; i < 3; i++)
                localPath = Path.GetDirectoryName(localPath);
            NannyPath = localPath + @"\Nannys.xml";
            return NannyPath;
        }
        public NannyXml()
        {
            NannyPath = locaition();
            if (!File.Exists(NannyPath))
                CreateFiles();
            else
                LoadData();
        }
        private void CreateFiles()
        {
            NannyRoot = new XElement("Nannys");
            NannyRoot.Save(NannyPath);
        }

        public void LoadData()
        {
            try
            {
                NannyRoot = XElement.Load(NannyPath);
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }
    }
}
