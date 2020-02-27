﻿using Microsoft.Extensions.DependencyInjection;

namespace Example.Mobile.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IExampleMobileBuilder AddExampleMobile(this IServiceCollection source)
        {
            return new ExampleMobileBuilder(source);
        }
    }
}
