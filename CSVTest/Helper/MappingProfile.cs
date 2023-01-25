using AutoMapper;
using DataAccess.Data;
using Models;

namespace CSVTest.Helper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDTO>().ReverseMap();
            CreateMap<Employee, EmployeeDTO>().ReverseMap();    
        }
    }
}
