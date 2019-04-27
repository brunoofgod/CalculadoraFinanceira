using CalculadoraFinanceira.Application.Services.Calculos;
using CalculadoraFinanceira.Application.Services.Calculos.Dtos;
using CalculadoraFinanceira.Application.Services.Calculos.Validation;
using CalculadoraFinanceira.CrossCutting.Extensions;
using Xunit;

namespace CalculadoraFinanceira.Application.Tests
{
    public class CaluloServicesTest
    {
        private CalculoServices CalculoServices => new CalculoServices(new JurosCompostosValidator());

        [Fact]
        public void TestarCaluloJurosCompostos()
        {
            var result = CalculoServices.CalularJurosCompostos(100, 5);
            var expected = 105.10100501M;
            Assert.Equal(result, expected);
        }

        [Fact]
        public void TestarJurosCompostos()
        {
            var service = new CalculoServices(new JurosCompostosValidator());

            var result = service.JurosCompostos(new JurosCompostosDto
            {
                Meses = 5,
                ValorInicial = 100
            });
            var expected = new JurosCompostosDto
            {
                Meses = 5,
                ValorInicial = 100,
                ValorFinal = 105.10100501M
            };

            Assert.NotNull(result);
            Assert.Equal(result.Errors.Count, expected.Errors.Count);
            Assert.Equal(result.ValorFinal, expected.ValorFinal.Truncar(2));
        }


        [Fact]
        public void TesteMesesZerados()
        {
            var service = new CalculoServices(new JurosCompostosValidator());

            var result = service.JurosCompostos(new JurosCompostosDto
            {
                Meses = 0,
                ValorInicial = 100
            });

            Assert.NotNull(result);
            Assert.Equal(1, result.Errors.Count);
        }

        [Fact]
        public void TesteMesesNegativos()
        {
            var service = new CalculoServices(new JurosCompostosValidator());

            var result = service.JurosCompostos(new JurosCompostosDto
            {
                Meses = -1,
                ValorInicial = 100
            });

            Assert.NotNull(result);
            Assert.Equal(1, result.Errors.Count);
        }

        [Fact]
        public void TesteValorInicialZerado()
        {
            var service = new CalculoServices(new JurosCompostosValidator());

            var result = service.JurosCompostos(new JurosCompostosDto
            {
                Meses = 9,
                ValorInicial = 0
            });

            Assert.NotNull(result);
            Assert.Equal(1, result.Errors.Count);
        }
    }
}