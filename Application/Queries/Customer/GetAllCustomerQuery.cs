using Application.Repository.Base.Interface;
using AutoMapper;
using Domain.Record.Response.Customer;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Customer;

public class GetAllCustomerQuery : IRequest<List<CustomerResponse>>
{
}


public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQuery, List<CustomerResponse>>
{
    private readonly IAsyncRepository<Domain.Entities.CustomerApp.Customer> _asyncRepository;
    private readonly IMapper _mapper;

    public GetAllCustomerQueryHandler(IAsyncRepository<Domain.Entities.CustomerApp.Customer> asyncRepository, IMapper mapper)
    {
        _asyncRepository = asyncRepository;
        _mapper = mapper;
    }
    public async Task<List<CustomerResponse>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
    {
       return _mapper.Map<List<CustomerResponse>>(await _asyncRepository.GetAllAsync());

        
    }
}
