using System.ComponentModel.DataAnnotations;

namespace Template.Application.ViewModels
{
    public class OrderViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Total { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
