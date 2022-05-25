using MediatR;
using System.Reflection;

namespace ManagePerson.Infrastructure
{
    public static class DependencyInjection
    {
        #region Services Injection
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
        #endregion

    }
}
