using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LinkDev.Talabt.APIs.Controllers.Erorrs
{
    public class ApiResponse
    {
        public int statusCode { get; set; } 
        public string? message { get; set; }
        public ApiResponse(int statusCode, string? message=null)
        {
            this.statusCode = statusCode;
            this.message = message ?? GetDefultMassageForStatusCode(statusCode);
        }

        private string? GetDefultMassageForStatusCode(int statusCode)
        {
           var massage = statusCode switch
            {
                400 => "Bad Request",
                401 => "Unauthorized",
                404 => "Resource Not Found",
                500 => "Internal Server Error",
                _ => null
            };
            return massage;
        }

        override public string ToString()
        {
            var options = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            return JsonSerializer.Serialize(this, options);
        }
    }

    


}
