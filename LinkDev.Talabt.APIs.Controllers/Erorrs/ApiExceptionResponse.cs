using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LinkDev.Talabt.APIs.Controllers.Erorrs
{
    public class ApiExceptionResponse : ApiResponse
    {
        public string? Details { get; set; }
        public ApiExceptionResponse(int statusCode, string? message = null,string? details=null) : base(statusCode, message)
        {

            Details=details;

        }
        override public string ToString()
        {
            var options = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            return JsonSerializer.Serialize(this, options);
        }
    }
}
