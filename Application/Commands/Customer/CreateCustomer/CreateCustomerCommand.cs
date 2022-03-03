using Application.Repository.Base.Interface;
using AutoMapper;
using Domain.Constants;
using Domain.Record.Request.Customer;
using MediatR;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Customer.CreateCustomer;

public class CreateCustomerCommand : IRequest<Domain.Entities.CustomerApp.Customer>
{
    public readonly CustomerDto CustomerDTO;

    public CreateCustomerCommand(CustomerDto customerDto)
    {
        CustomerDTO = customerDto;
    }
}

public class CreateCustomerCommnadHandler : IRequestHandler<CreateCustomerCommand, Domain.Entities.CustomerApp.Customer>
{
    private readonly IMapper _mapper;
    private readonly IHttpClientFactory _httpClientFactory;
    private IAsyncRepository<Domain.Entities.CustomerApp.Customer> _asyncRepository;

    public CreateCustomerCommnadHandler(IHttpClientFactory httpClientFactory, IAsyncRepository<Domain.Entities.CustomerApp.Customer> asyncRepository, IMapper mapper)
    {
        _httpClientFactory = httpClientFactory;
        _asyncRepository = asyncRepository;
        _mapper = mapper;
    }


    public async Task<Domain.Entities.CustomerApp.Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        using var client = _httpClientFactory.CreateClient(CustomerContant.OTPAPIProfile);
        var response = await client.PostAsync("", new StringContent(""));
        
        // this is a mock for an otp endpoint, this will never be unsuccessful because of the logic in our handler
        if (!response.IsSuccessStatusCode)
            throw new System.Exception("Unable to verify otp code");

        var customerToAdd = _mapper.Map<Domain.Entities.CustomerApp.Customer>(request.CustomerDTO);
        return await _asyncRepository.AddAsync(customerToAdd);
    }
}
