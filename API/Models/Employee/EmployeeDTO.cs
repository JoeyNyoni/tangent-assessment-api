using API.Models.Skill;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Employee
{
    public abstract class EmployeeDTO
    {
        public string Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string ContactNumber { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string DateOfBirth { get; set; }
        [Required]
        public string StreetAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string Country { get; set; }
        public List<SkillDTO> Skills { get; set; }
    }
}
