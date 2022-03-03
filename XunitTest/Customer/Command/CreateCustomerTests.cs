using Application.Commands.Customer.CreateCustomer;
using Application.Mappings.Customer;
using Application.Repository.Base.Interface;
using AutoMapper;
using Domain.Constants;
using Moq;
using Moq.Protected;
using Shouldly;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using XunitTest.Mocks;

namespace XunitTest.Customer.Command
{
    public class CreateCustomerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Domain.Entities.CustomerApp.Customer>> _mockCategoryRepository;

        public CreateCustomerTests()
        {
            _mockCategoryRepository = RepositoryMocks.GetCustomerRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CustomerMapping>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidCustomer_AddedToCustomerRepo()
        {
            var mockHttpFactory = new Mock<IHttpClientFactory>();

            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(""),
                });

            var client = new HttpClient(mockHttpMessageHandler.Object);
            client.BaseAddress = new Uri("https://localhost/api/otp");
            mockHttpFactory.Setup(p => p.CreateClient(CustomerContant.OTPAPIProfile)).Returns(client);

            var handler = new CreateCustomerCommnadHandler(mockHttpFactory.Object, _mockCategoryRepository.Object, _mapper);

            var customer = new Domain.Record.Request.Customer.CustomerDto
            {
                Email ="sule"
            };
            await handler.Handle(new CreateCustomerCommand(customer), CancellationToken.None);

            var allCustomers = await _mockCategoryRepository.Object.GetAllAsync();
            allCustomers.Count.ShouldBe(3);
        }
    }
}
