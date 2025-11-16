using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Application.Abstraction.Models.Products
{
    public record ProudctSpacficationParams
    {
        public string? Sort { get; set; }
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public int PageIndex { get; set; }=1;

        public int PageSize { get; set; }=10;

        private string? search;
        public string? Search { get=>search; 
            set { search= value?.ToUpper(); } }
    }
}
 