using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationKiosk.DataProtocol
{
    public class Nutrients
    {
        [Key]
        public Guid Id { get; set; }
        public float Energy { get; set; }
        public float Protein { get; set; }
        public float Fats { get; set; }

        [Required]
        public IceCream IceCream { get; set; }
    }
}
