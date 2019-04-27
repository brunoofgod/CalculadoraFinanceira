using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;

namespace CalculadoraFinanceira.Application.Generic
{
    public abstract class BaseDto
    {
        public BaseDto()
        {
            Errors = new List<ValidationFailure>();
        }

        public IList<ValidationFailure> Errors { get; set; }

        public bool IsValid
        {
            get
            {
                return Errors.Count <= 0;
            }
        }

        public BaseDto Validar(IValidator validator)
        {
            var validacao = validator.Validate(this);

            Errors = validacao.Errors;

            return this;
        }
    }
}