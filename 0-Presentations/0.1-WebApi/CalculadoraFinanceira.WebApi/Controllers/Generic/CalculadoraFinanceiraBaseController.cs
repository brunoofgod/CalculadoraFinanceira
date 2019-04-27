using AutoMapper;
using CalculadoraFinanceira.Application.Generic;
using CalculadoraFinanceira.WebApi.ViewModels.Generic;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CalculadoraFinanceira.WebApi.Controllers.Generic
{
    public class CalculadoraFinanceiraBaseController : Controller
    {
        public readonly IMapper _mapper;

        public CalculadoraFinanceiraBaseController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public RetornoErrosViewModel CalculadoraFinanceiraResult(BaseDto validationErros)
        {
            var erros = _mapper.Map<List<ValidationFailure>, List<ValidacaoViewModel>>(validationErros.Errors.ToList());

            return new RetornoErrosViewModel { Erros = erros };
        }
    }
}