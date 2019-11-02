using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationKiosk.DataProtocol
{
    public class Reviews
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }

        public int Score { get; set; }

        //public image Image {get; set; }

        public Guid IceCreamId { get; set; }
        public IceCream IceCream { get; set; }
    }
}
