using API.Models.Skill;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Employee
{
    public abstract class EmployeeDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public string DateOfBirth { get; set; }
        public string StringAddress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public List<SkillDTO> Skills { get; set; }
    }
}
