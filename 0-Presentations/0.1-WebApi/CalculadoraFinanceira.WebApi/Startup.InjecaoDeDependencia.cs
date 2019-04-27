using CalculadoraFinanceira.Application.Services.Calculos;
using CalculadoraFinanceira.Application.Services.Calculos.Dtos;
using CalculadoraFinanceira.Application.Services.Calculos.Validation;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CalculadoraFinanceira.WebApi
{
    public partial class Startup
    {
        public void CarregarServicos(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddScoped<CalculoServices>();
            services.AddScoped<IValidator<JurosCompostosDto>, JurosCompostosValidator>();
        }
    }
}