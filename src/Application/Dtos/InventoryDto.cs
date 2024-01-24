using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class InventoryDto
    {
        [Required(ErrorMessage = "Field '{0}' is required")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Field '{0}' is required")]
        public Guid? BookId { get; set; }
    }
}
