using AutoMapper;
using DataAccess.Data;
using Models;

namespace CSVTest.Helper
{
    public static class MappingExtension
    {
        public static EmployeeDTO MapToEmployeeDTO(this Employee employee, IMapper _mapper) => _mapper.Map<Employee, EmployeeDTO>(employee);

        public static Employee MapToEmployee(this EmployeeDTO employeeDTO, IMapper _mapper) => _mapper.Map<EmployeeDTO, Employee>(employeeDTO);

        public static CompanyDTO MapToCompanyDTO(this Company company, IMapper _mapper)=> _mapper.Map<Company, CompanyDTO>(company);

        public static Company MapToCompany(this CompanyDTO companyDTO, IMapper _mapper) => _mapper.Map<CompanyDTO, Company>(companyDTO);
    }
}
