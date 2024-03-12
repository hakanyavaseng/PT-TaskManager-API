using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TaskManager.Application.Bases;
using TaskManager.Application.Behaviours;
using TaskManager.Application.Exceptions;

namespace TaskManager.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            //Mediator
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            services.AddTransient<ExceptionMiddleware>(); //Adding global exception handler middleware to IoC


            //AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //FluentValidation
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly()); // Adding fluent validation to IoC
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehaviour<,>)); // Fluent validation pipeline behaviour.
            services.AddRulesFromAssemblyContaining(Assembly.GetExecutingAssembly(), typeof(BaseRules)); // Call custom rule class and add to IoC

        }

        #region BaseRule static class which helps to add all rules in one time to Ioc
        private static IServiceCollection AddRulesFromAssemblyContaining(this IServiceCollection services, Assembly assembly, Type type)
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();

            foreach (var t in types)
            {
                services.AddTransient(t);
            }
            return services;

        }
        #endregion
    }
}
