using AutoMapper;
using Domain.Extentions;
using Domain.Record.Request.Customer;
using Domain.Record.Response.Customer;

namespace Application.Mappings.Customer;

public class CustomerMapping : Profile
{
    public CustomerMapping()
    {
        CreateMap<CustomerDto, Domain.Entities.CustomerApp.Customer>()
            .ForMember(p => p.State, m => m.MapFrom(src => $"{src.State}-{src.LGA}"))
            .ForMember(p => p.Password, m => m.MapFrom(src => src.Password.ComputeStringToSha256Hash()));

        CreateMap<Domain.Entities.CustomerApp.Customer, CustomerResponse>();
    }
}
