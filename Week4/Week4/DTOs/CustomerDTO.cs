using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Week4.CustomValidations;

namespace Week4.DTOs
{
    public class CustomerDTO
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Customer's First Name cannot exceed 50 characters.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Customer's Last Name cannot exceed 50 characters.")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9.]+@gmail\.com$", ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }

        [RegularExpression(@"^\+?[0-9]{10,15}$", ErrorMessage = "Invalid phone number format.")]
        public string Phone { get; set; }

        [StringLength(250, ErrorMessage = "Address cannot exceed 250 characters.")]
        public string Address { get; set; }

        [Required]
        [ValidJoinDate]
        public System.DateTime DateJoined { get; set; }


    }
}