using API.Data;
using API.Models.Employee;
using API.Models.Skill;
using AutoMapper;

namespace API.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<Employee, CreateEmployeeDTO>().ReverseMap();
            CreateMap<Employee, GetEmployeeDTO>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeDTO>().ReverseMap();

            CreateMap<Skill, SkillDTO>().ReverseMap();
        }
    }
}
