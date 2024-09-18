using Pastelaria.Domain.Endereco;
using Pastelaria.Domain.Perfil;
using Pastelaria.Domain.Telefone;
using Pastelaria.Domain.Teste;
using Pastelaria.Repository;
using Pastelaria.Repository.Infra;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace Pastelaria.Api
{
    public static class SimpleInjectorContainer
    {
        private static readonly Container Container = new Container();

        public static Container Build()
        {
            Container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            Container.Register<IDatabaseConnection, DatabaseConnection>(Lifestyle.Scoped);
            //Container.Register<Notification>(Lifestyle.Scoped);

            RegisterRepositories();

            Container.Verify();
            return Container;
        }

        private static void RegisterRepositories()
        {
            Container.Register<ITesteRepository, TesteRepository>();
            Container.Register<IPerfilRepository, PerfilRepository>();
            Container.Register<ITelefoneRepository, TelefoneRepository>();
            Container.Register<IEnderecoRepository, EnderecoRepository>();
        }
    }
}