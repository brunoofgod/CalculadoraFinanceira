using CalculadoraFinanceira.Application.Generic;
using Microsoft.Extensions.Options;

namespace CalculadoraFinanceira.Application.Services.Github
{
    public class GithubServices : IGithubServices
    {
        private readonly AppSettings _appSettings;

        public GithubServices(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public string GetUrl() => _appSettings.UrlGitHub;
    }
}