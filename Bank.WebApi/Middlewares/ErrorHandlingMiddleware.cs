using Bank.WebApi.Exceptions;
using System.Net;
using System.Text.Json;

namespace Bank.WebApi.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            try
            {
                await _next(httpContext);
            }
            catch (Exception error)
            {

                var response = httpContext.Response;
                response.ContentType = "application/json";
                switch (error)
                {
                    case UserNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case AccountNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case IllegalAmountException e:
                        response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                        break;
                    case InsufficientFundsException e:
                        response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                        break;
                    case ClosingNotEmptyAccountException e:
                        response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                var result = JsonSerializer.Serialize(new { message = error?.Message });
                await response.WriteAsync(result);
            }
        }
    }

}
