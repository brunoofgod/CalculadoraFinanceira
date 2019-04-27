using AutoMapper;
using CalculadoraFinanceira.Application.Services.Calculos;
using CalculadoraFinanceira.Application.Services.Calculos.Dtos;
using CalculadoraFinanceira.ViewModels.Calculos;
using CalculadoraFinanceira.WebApi.Generic;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CalculadoraFinanceira.WebApi.Controllers
{
    public class CalculosController : ControllerCalculadoraFinanceira
    {
        public readonly CalculoServices _calculoServices;

        public CalculosController(IMapper mapper, CalculoServices calculoServices) : base(mapper)
        {
            _calculoServices = calculoServices;
        }

        [HttpGet("calculajuros")]
        public object Get([FromQuery]JurosCompostosViewModel vm)
        {
            try
            {
                var dto = _calculoServices.JurosCompostos(_mapper.Map<JurosCompostosViewModel, JurosCompostosDto>(vm));
                if (dto.Errors.Count > 0) return BadRequest(CalculadoraFinanceiraResult(dto));

                return Ok(dto.ValorFinal);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}