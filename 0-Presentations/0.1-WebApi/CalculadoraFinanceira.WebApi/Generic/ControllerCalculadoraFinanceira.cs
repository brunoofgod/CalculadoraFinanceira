using AutoMapper;
using CalculadoraFinanceira.Application.Generic;
using CalculadoraFinanceira.WebApi.ViewModels.Generic;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CalculadoraFinanceira.WebApi.Generic
{
    [Authorize("Bearer")]
    [ApiController]
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