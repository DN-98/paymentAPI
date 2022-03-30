using System;
using System.ComponentModel.DataAnnotations;

namespace PaymentAPI.Models
{
    public class PaymentItem{
        [Key]
        public int paymentDetailId {get; set;}
        [Required]
        public string cardOwnerName {get; set;}
        [Required]
        public DateTime expirationDate {get; set;}
        [Required]
        public string securityCode {get; set;}
    }
}