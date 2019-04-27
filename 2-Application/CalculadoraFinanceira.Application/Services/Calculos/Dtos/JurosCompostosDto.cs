using CalculadoraFinanceira.Application.Dtos_Genericos;

namespace CalculadoraFinanceira.Application.Services.Calculos.Dtos
{
    public class JurosCompostosDto : BaseDto
    {
        public int Meses { get; set; }
        public decimal ValorFinal { get; set; }
        public double ValorInicial { get; set; }
    }
}