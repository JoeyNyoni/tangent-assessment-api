using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.Skill
{
    public class SkillDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearsExperienced { get; set; }
        public string Seniority { get; set; }
        public string EmployeeId { get; set; }
    }
}
