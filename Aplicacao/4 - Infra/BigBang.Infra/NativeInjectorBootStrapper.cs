using AutoMapper;
using BigBang.Aplicacao.Interfaces.ServicosApp;
using BigBang.Aplicacao.ServicosApp;
using BigBang.Dados.Contexto;
using BigBang.Dados.Repositorios;
using BigBang.Dominio.Interfaces.Repositorios;
using BigBang.Dominio.Interfaces.Servicos;
using BigBang.Dominio.Servicos;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace BigBang.Infra
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Aplicacao
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            services.AddScoped<IPersonagemServicosApp, PersonagemServicosApp>();

            // Dominio
            services.AddScoped<IPersonagemServicos, PersonagemServicos>();

            // Infra
            services.AddScoped<IPersonagemRepositorio, PersonagemRepositorio>();
            services.AddScoped<BigBangContexto>();
        }
    }
}