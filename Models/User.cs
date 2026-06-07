using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class User
    {
       
            public int Id { get; set; }  // Primary key for Users table

         
            [Required]
            [EmailAddress]
            public string Email { get; set; } = string.Empty;
            // Email must be valid format

            [Required]
            public string Password { get; set; } = string.Empty;
            // Password field (plain text for now - only for learning)
        
    }
}

