using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Application.RequestModels
{
    public record StudentDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Age is required")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Please Select Course")]
        public string? Course { get; set; }
    }
}
