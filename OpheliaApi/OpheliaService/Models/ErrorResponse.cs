using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace OpheliaService.Models
{
    public class ErrorResponse
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.InternalServerError;

        public string Message { get; set; } = "Ocurrio un error inesperado.";

        public string ToJsonString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
