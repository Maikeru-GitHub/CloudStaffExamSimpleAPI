using System.ComponentModel.DataAnnotations;

namespace CloudStaffExamSimpleAPI.Models.DTO
{
    /// <summary>
    /// Data Transfer Object for update a person.
    /// </summary>
    public class UpdatePersonDto
    {
        [StringLength(int.MaxValue, MinimumLength = 1, ErrorMessage = "First Name must not be empty.")]
        public string? FirstName { get; set; }
        [StringLength(int.MaxValue, MinimumLength = 1, ErrorMessage = "Last Name must not be empty.")]
        public string? LastName { get; set; }
        [Range(1, 150, ErrorMessage = "Age must be between 1 and 150")]
        public int? Age { get; set; }
        public bool HasAtLeastOneField()
        {
            return !(string.IsNullOrWhiteSpace(FirstName)
                     && string.IsNullOrWhiteSpace(LastName)
                     && Age == null);
        }
    }
}
