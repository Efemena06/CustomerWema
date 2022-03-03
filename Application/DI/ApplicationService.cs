using Application.Behaviour.Validation;
using Application.Handlers;
using Application.Repository.Base;
using Application.Repository.Base.Interface;
using Application.Service.Bank;
using Application.Service.Bank.Interface;
using Domain.Constants;
using Domain.Context;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace Application.DI;

public static class ApplicationService
{

    public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(typeof(ApplicationService).Assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseAsyncRepository<>));

        services.AddHttpClient(CustomerContant.OTPAPIProfile)
            .ConfigureHttpClient((serviceProvider, client) =>
            {
                client.BaseAddress = new Uri("https://localhost/api/otp");
            })
            .AddHttpMessageHandler<OtpHandler>();

        services.AddHttpClient(BankConstant.WemaClient)
        .ConfigureHttpClient((serviceProvider, client) =>
        {
            client.BaseAddress = new Uri(configuration["WemaApi:Uri"]);
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", configuration["WemaApi:Subscription"]);
        });

        services.AddScoped<IBankService, BankService>();

        services.AddScoped<OtpHandler>();
        services.AddDbContext<CustomerContext>(opt => opt.UseSqlite("Data Source=Application.db;"));
        
        return services;
    }
}
