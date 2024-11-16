using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Week4.DTOs
{
    public class CustomerDTO
    {
        public int ID { get; set; }

        [Required]
        [StringLength(110, ErrorMessage = "Customer name cannot exceed 110 characters.")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9.]+@gmail\.com$", ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }

        [RegularExpression(@"^\+?[0-9]{10,15}$", ErrorMessage = "Invalid phone number format.")]
        public string Phone { get; set; }

        [StringLength(250, ErrorMessage = "Address cannot exceed 250 characters.")]
        public string Address { get; set; }
        public System.DateTime DateJoined { get; set; }


    }
}