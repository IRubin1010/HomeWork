using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationKiosk.DataProtocol
{
    public class IceCream
    {
        [Key]
        public Guid Id { get; set; }
        public int Score { get; set; }
        public string Description { get; set; }
        //public Image Img { get; set; } TODO

        public Guid StoreId { get; set; }
        public Store Store { get; set; }
        

    }
}
