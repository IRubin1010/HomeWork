using System;
using System.ComponentModel.DataAnnotations;

namespace InformationKiosk.BE
{
    public class Administrator
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
