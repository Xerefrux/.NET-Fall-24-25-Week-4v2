//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Week4.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class Customer
    {
        public Customer()
        {
            this.Product_Customer = new HashSet<Product_Customer>();
        }
    
        public int ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }
        public System.DateTime DateJoined { get; set; }
    
        public virtual ICollection<Product_Customer> Product_Customer { get; set; }
    }
}
