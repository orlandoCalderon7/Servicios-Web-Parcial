using System.Net;
using System.Text.Json;

namespace ClinicaCitas.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context); // Continúa con la petición normal
            }
            catch (Exception ex)
            {
                // Si algo falla, atrapa el error aquí y devuelve un JSON estandarizado
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.InternalServerError; // Error 500

                var result = JsonSerializer.Serialize(new
                {
                    error = "Ocurrió un error interno en el servidor.",
                    detalle = ex.Message
                });

                await response.WriteAsync(result);
            }
        }
    }
}