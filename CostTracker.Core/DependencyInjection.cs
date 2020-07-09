using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;

namespace CostTracker.Core
{
    public static class DependencyInjection
    {
        public static void AddCostTrackerCore(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}