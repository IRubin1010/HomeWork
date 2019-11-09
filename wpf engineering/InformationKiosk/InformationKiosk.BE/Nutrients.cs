using System;
using System.ComponentModel.DataAnnotations;

namespace InformationKiosk.BE
{
    public class Nutrients
    {
        [Key]
        public Guid Id { get; set; }
        public float Energy { get; set; }
        public float Protein { get; set; }
        public float Fats { get; set; }


        public Guid IceCreamId { get; set; }
    }
}
