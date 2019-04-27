using CalculadoraFinanceira.Application.Services.Github;
using CalculadoraFinanceira.WebApi.Generic;
using Microsoft.AspNetCore.Mvc;

namespace CalculadoraFinanceira.Controllers
{
    public class GithubController : ControllerCalculadoraFinanceira
    {
        private readonly GithubServices _githubServices;

        public GithubController(GithubServices githubServices)
        {
            _githubServices = githubServices;
        }

        [HttpGet("showmethecode")]
        public object Get() => _githubServices.GetUrl();
    }
}