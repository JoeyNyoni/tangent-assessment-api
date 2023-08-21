using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearsExperienced { get; set; }
        public string Seniority { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
