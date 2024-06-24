using System.ComponentModel.DataAnnotations;

namespace CloudStaffExamSimpleAPI.Models.DTO
{
    /// <summary>
    /// Data Transfer Object for adding a new person.
    /// </summary>
    public class AddPersonDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [Range(1, 150, ErrorMessage = "Age must be between 1 and 150")]
        public int Age { get; set; }
    }
}
