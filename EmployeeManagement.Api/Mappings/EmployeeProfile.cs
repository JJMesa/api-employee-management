using AutoMapper;
using EmployeeManagement.Api.Models.Dtos;
using EmployeeManagement.Api.Models.Entities;

namespace EmployeeManagement.Api.Mappings;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        #region Queries

        CreateMap<Employee, EmployeeDto>().ReverseMap();

        #endregion Queries

        #region Commands

        CreateMap<Employee, EmployeeCreationDto>().ReverseMap();
        CreateMap<Employee, EmployeeUpdateDto>().ReverseMap();

        #endregion Commands
    }
}