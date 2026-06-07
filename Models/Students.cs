using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class Students
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Student Course is required")]
          public string? Course { get; set; }

        [Required(ErrorMessage ="Student Year is required")]
        [Range(1, 3, ErrorMessage = "Year must be between 1 and 3")]
        public int Year { get; set; }

        public int Age { get; set; }
    }
}
