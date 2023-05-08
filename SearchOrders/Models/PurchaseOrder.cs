using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace SearchOrders.Models
{
    public class PurchaseOrder
    {
        [Required]
        public string Number { get; set; }
        [Required]
        public string ClientCode { get; set; }
        [Required]
        public string ClientName { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        public DateTime? ShipmentDate { get; set; } 
        [Required]
        public int Quantity { get; set; }
        [Required]
        public bool Confirmed { get; set; }
        [Required]
        public double Value { get; set; }
    }
}
