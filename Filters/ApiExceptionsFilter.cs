using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace APIHamburgueria.Filters
{
    public class ApiExceptionsFilter : IExceptionFilter
    {

        private readonly ILogger<ApiExceptionsFilter> _logger;
        public ApiExceptionsFilter(ILogger<ApiExceptionsFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, "Ocorreu uma exceção não tratada: Status code 500");

            context.Result = new ObjectResult("Ocorreu uma problema ao tratar sua solicitação: Status code 500")
            {
                StatusCode = StatusCodes.Status500InternalServerError,
            };
        }
    }
}
