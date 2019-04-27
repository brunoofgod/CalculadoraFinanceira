using AutoMapper;
using CalculadoraFinanceira.Application.Services.Calculos.Dtos;
using CalculadoraFinanceira.ViewModels.Calculos;
using CalculadoraFinanceira.WebApi.ViewModels.Generic;
using FluentValidation.Results;

namespace CalculadoraFinanceira.Mapper
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<JurosCompostosViewModel, JurosCompostosDto>()
                .ForMember(x => x.Errors, conf => conf.Ignore())
                .ForMember(x => x.ValorFinal, conf => conf.Ignore());

            CreateMap<ValidationFailure, ValidacaoViewModel>()
                .ForMember(x => x.Mensagem, cfg => cfg.MapFrom(c => c.ErrorMessage))
                .ForMember(x => x.Campo, cfg => cfg.MapFrom(c => c.PropertyName));
        }
    }
}