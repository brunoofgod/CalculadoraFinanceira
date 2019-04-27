using System;

namespace CalculadoraFinanceira.CrossCutting.Extensions
{
    public static class DecimalExtensions
    {
        public static decimal Truncar(this decimal value, int quantidadeDeCasasDecimais)
        {
            decimal valorTrunc = Math.Truncate(value);
            decimal fracao = value - valorTrunc;
            decimal fator = (decimal)Math.Pow(10, quantidadeDeCasasDecimais);

            return (Math.Truncate(fracao * fator) / fator) + valorTrunc;
        }
    }
}