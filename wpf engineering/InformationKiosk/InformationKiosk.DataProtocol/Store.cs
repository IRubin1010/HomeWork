using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationKiosk.DataProtocol
{
    public class Store
    {
        public string Address { get; set; }
        public Image Img { get; set; }
        public string PhoneNumber { get; set; }
        public Uri Website { get; set; }
        public List<Guid> IceCreams { get; set; }

    }
}
