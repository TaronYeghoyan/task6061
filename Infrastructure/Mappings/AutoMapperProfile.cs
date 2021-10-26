using AutoMapper;
using Domain.Entities;
using Domain.POCO.DTOs;

namespace Infrastructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //CreateMap<Entity, EntityDto>()
            //.ForMember(x => x., xx => xx.MapFrom(xxx => xxx.))
            //.ReverseMap();

            CreateMap<Product, ProductDto>()
            .ForMember(x => x.id, xx => xx.MapFrom(xxx => xxx.Id))
            .ForMember(x => x.n, xx => xx.MapFrom(xxx => xxx.Name))
            .ForMember(x => x.p, xx => xx.MapFrom(xxx => xxx.Price))
            .ForMember(x => x.bc, xx => xx.MapFrom(xxx => xxx.Barcode))
            .ForMember(x => x.plu, xx => xx.MapFrom(xxx => xxx.PLU))
            .ReverseMap();

            CreateMap<Department, DepartmentDto>()
            .ForMember(x => x.id, xx => xx.MapFrom(xxx => xxx.Id))
            .ForMember(x => x.n, xx => xx.MapFrom(xxx => xxx.Name))
            .ReverseMap();

            CreateMap<Employee, EmployeeDto>()
                .ForMember(x => x.id, xx => xx.MapFrom(xxx => xxx.Id))
                .ForMember(x => x.fn, xx => xx.MapFrom(xxx => xxx.FirstName))
                .ForMember(x => x.d, xx => xx.MapFrom(xxx => xxx.BirthDate))
                .ForMember(x => x.ln, xx => xx.MapFrom(xxx => xxx.LastName))
                .ForMember(x => x.w, xx => xx.MapFrom(xxx => xxx.Wage))
                .ForMember(x => x.wd, xx => xx.MapFrom(xxx => xxx.Workdays))
                .ForMember(x => x.dn, xx => xx.MapFrom(xxx => xxx.Department.Name))
                .ReverseMap();

            CreateMap<Employee, CalculateReportEmployeeDto>()
              .ForMember(x => x.fnln, xx => xx.MapFrom(xxx => $"{xxx.FirstName}  {xxx.LastName}"))
              .ForMember(x => x.dn, xx => xx.MapFrom(xxx => xxx.Department.Name))
              .ForMember(x => x.w, xx => xx.MapFrom(xxx => xxx.Wage))
              .ForMember(x => x.wd, xx => xx.MapFrom(xxx => xxx.Workdays))
              .ForMember(x => x.st, xx => xx.MapFrom(xxx => xxx.Wage))
              .ForMember(x => x.wdt, xx => xx.MapFrom(xxx => xxx.Workdays));
        }
    }
}