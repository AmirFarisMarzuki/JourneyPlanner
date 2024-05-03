using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JourneyPlanner.Shared.Models
{
    public partial class Delivery
    {
        public int Id { get; set; }
        [FutureDelivery(ErrorMessage = "Delivery date must be a future date.")]
        public DateTime? DeliveryDate { get; set; }
        public string? DeliveryTime { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsCancelled { get; set; }
        public string? DeliveryName { get; set; }
        public string? DeliveryAddress { get; set; }
        public string? Remarks { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }

    }

    public class FutureDeliveryAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime deliveryDate && deliveryDate <= DateTime.Now.AddDays(1))
            {
                return new ValidationResult("Delivery date must be at least one day in the future.");
            }

            return ValidationResult.Success;
        }
    }
}
