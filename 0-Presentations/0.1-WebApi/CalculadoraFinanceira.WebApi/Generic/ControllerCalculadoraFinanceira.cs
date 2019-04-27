using CalculadoraFinanceira.Application.Dtos_Genericos;
using CalculadoraFinanceira.WebApi.ViewModels.Generic;
using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CalculadoraFinanceira.WebApi.Generic
{
    public abstract class ControllerCalculadoraFinanceira : Controller
    {
        public readonly IMapper _mapper;

        public ControllerCalculadoraFinanceira(IMapper mapper)
        {
            _mapper = mapper;
        }

        protected ControllerCalculadoraFinanceira()
        {
        }

        protected RetornoErrosViewModel CalculadoraFinanceiraResult(BaseDto validationErros)
        {
            var erros = _mapper.Map<List<ValidationFailure>, List<ValidacaoViewModel>>(validationErros.Errors.ToList());

            return new RetornoErrosViewModel { Erros = erros };
        }
    }
}