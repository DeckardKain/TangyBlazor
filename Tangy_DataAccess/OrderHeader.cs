﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Tangy_DataAccess
{
    public class OrderHeader
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }

        // add navigation prop for user

        [Required]
        [Display(Name ="Order Total")]
        public double OrderTotal { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        [Display(Name = "Shipping Date")]
        public DateTime ShippingDate { get; set; }
        [Required]
        public string Status { get; set; }

        // stripe payment
        public string? SessionId { get; set; }
        public string? PaymentIntentId { get; set; }

        [Display(Name = "Name")]
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }
        [Required]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        [Required]
        public string Email { get; set; }



    }
    
}
