using Microsoft.Extensions.DependencyInjection;

namespace SWITCH_OVER.Crosscutting.Ioc
{
	public class DependencyInjectionBootstrapper
	{
		public static void RegisterServices(IServiceCollection services)
		{
			ApplicationRegisterServices.Register(services);
			ApiRegisterServices.Register(services);
			RepositoryRegisterServices.Register(services);
		}
	}
}