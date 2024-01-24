using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class BookDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Field '{0}' is required")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Field '{0}' is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Field '{0}' is required")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Field '{0}' is required")]
        public string Year { get; set; }

        [Required(ErrorMessage = "Field '{0}' is required")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Field '{0}' is required")]
        public string Publisher { get; set; }
    }
}
