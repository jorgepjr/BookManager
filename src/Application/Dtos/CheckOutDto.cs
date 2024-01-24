using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class CheckOutDto
    {
        [Required(ErrorMessage = "Field '{0}' is required")]
        public Guid ClientId { get; set; }

        [Required(ErrorMessage = "Field '{0}' is required")]
        public string BookCode { get; set; }

        [Required(ErrorMessage = "Field '{0}' is required")]
        public int Quantity { get; set; }
    }
}
