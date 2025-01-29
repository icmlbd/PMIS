using AutoMapper;
using PMIS.Models.DTOs.Customers;
using PMIS.Models.EntityModels;

namespace PMIS.API.AutomapperProfiles
{
    public class ApplicationAutomapperProfile : Profile
    {
        public ApplicationAutomapperProfile()
        {
            CreateMap<Customer, CustomerResponseDTO>();
            //CreateMap<CustomerResponseDTO, Customer>();
            CreateMap<CustomerCategory, CategoryDTO>();
            CreateMap<CustomerCreateDTO, Customer>();
            CreateMap<CustomerUpdateDTO, Customer>();
            CreateMap<Customer, CustomerUpdateDTO>();
        }
    }
}
