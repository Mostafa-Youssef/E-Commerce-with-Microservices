
using System.ComponentModel.DataAnnotations;

namespace Discount.API.Models.DTO
{
    public class CouponDTO
    {
        [Required(ErrorMessage = "id is required")]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string? Description { get; set; }
        public int Amount { get; set; }
    }
}
