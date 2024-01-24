using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class ClientDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Field '{0}' is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Field '{0}' is required")]
        public string Email { get; set; }
    }
}
