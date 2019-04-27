﻿using System.Collections.Generic;

namespace CalculadoraFinanceira.WebApi.ViewModels.Generic
{
    public class RetornoErrosViewModel
    {
        public RetornoErrosViewModel()
        {
            Erros = new List<ValidacaoViewModel>();
        }
        public List<ValidacaoViewModel> Erros { get; set; }
        public bool Sucesso { get => Erros.Count <= 0; }
    }
}