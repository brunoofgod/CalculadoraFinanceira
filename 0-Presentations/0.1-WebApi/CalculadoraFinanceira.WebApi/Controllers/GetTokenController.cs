using CalculadoraFinanceira.Application.Services.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CalculadoraFinanceira.Controllers
{
    [AllowAnonymous]
    public class GetTokenController : Controller
    {
        private readonly TokenServices _tokenServices;

        public GetTokenController(TokenServices tokenServices)
        {
            _tokenServices = tokenServices;
        }

        [HttpGet("autenticar")]
        public object Get() => _tokenServices.NewToken();
    }
}