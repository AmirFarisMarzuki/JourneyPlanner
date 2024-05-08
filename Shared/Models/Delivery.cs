using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JourneyPlanner.Shared.Models
{
    public partial class Delivery
    {
        public int Id { get; set; }
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
}
