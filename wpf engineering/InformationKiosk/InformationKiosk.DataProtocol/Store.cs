using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationKiosk.DataProtocol
{
    public class Store
    {
        [Key]
        public Guid Id { get; set; }
        public string Address { get; set; }
        //public Image Img { get; set; } [TODO]
        public string PhoneNumber { get; set; }
        public string Website { get; set; } // TODO change to URI
        public List<IceCream> IceCreams { get; set; }

    }
}
