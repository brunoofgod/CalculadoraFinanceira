using CalculadoraFinanceira.Application.Services.Calculos.Dtos;

namespace CalculadoraFinanceira.Application.Services.Calculos
{
    public interface ICalculoServices
    {
        JurosCompostosDto JurosCompostos(JurosCompostosDto dto);
    }
}