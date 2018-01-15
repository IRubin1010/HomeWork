using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DS_XML
{
    public class XmlSample
    {
        XElement studentRoot;
        string studentPath;
        public string locaition ()
        {
            string str = Assembly.GetExecutingAssembly().Location;
            string localPath = Path.GetDirectoryName(str);
            for (int i = 0; i < 3; i++)
                localPath = Path.GetDirectoryName(localPath);
            studentPath = localPath + @"\students.xml";
            return studentPath;
        }

        public XmlSample()
        {
            studentPath = locaition();
            if (!File.Exists(studentPath))
                CreateFiles();
            else
                LoadData();
        }

        private void CreateFiles()
        {
            studentRoot = new XElement("students");
            studentRoot.Save(studentPath);
        }

        private void LoadData()
        {
            try
            {
                studentRoot = XElement.Load(studentPath);
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }


    }
}
