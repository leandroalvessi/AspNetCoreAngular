using AspNetCoreAngular.Application.Interfaces;
using AspNetCoreAngular.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreAngular.IoC
{
    public static class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
