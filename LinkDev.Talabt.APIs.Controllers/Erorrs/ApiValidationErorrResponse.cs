using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabt.APIs.Controllers.Erorrs
{
    public class ApiValidationErorrResponse : ApiResponse
    {
        public IEnumerable<ValditonErorr>? Errors { get; set; }
        public ApiValidationErorrResponse( string? message = null) : base(400, message)
        {

        }

        public class ValditonErorr
        {
        
            public required string Field { get; set; }
            public required IEnumerable<string> Erorrs { get; set; }

        }
    }
}
