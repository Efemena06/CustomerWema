using Application.Repository.Base.Interface;
using Moq;
using System.Collections.Generic;

namespace XunitTest.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IAsyncRepository<Domain.Entities.CustomerApp.Customer>> GetCustomerRepository()
        {

            var customer = new List<Domain.Entities.CustomerApp.Customer>
            {
                new Domain.Entities.CustomerApp.Customer
                {
                    Email = "uzakari2@gmail.com",
                    LGA = "KD",
                    State = "Kaduna",
                    Password =  "goodman",
                    PhoneNumber = "32478953"
                },
                new Domain.Entities.CustomerApp.Customer
                {
                    Email = "meana@gmail.com",
                    LGA = "KD",
                    State = "Abuja",
                    Password =  "goodman",
                    PhoneNumber = "32478953"
                }
            };

            var mockCustomerRepository = new Mock<IAsyncRepository<Domain.Entities.CustomerApp.Customer>>();
            mockCustomerRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(customer);

            mockCustomerRepository.Setup(repo => repo.AddAsync(It.IsAny<Domain.Entities.CustomerApp.Customer>())).ReturnsAsync(
                (Domain.Entities.CustomerApp.Customer category) =>
                {
                    customer.Add(category);
                    return category;
                });

            return mockCustomerRepository;
        }
    }
}
