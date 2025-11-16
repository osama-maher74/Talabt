using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Application.Excpetions
{
    public class NotFoundException :ApplicationException
    {
        public NotFoundException(string name,object key )
        : base ($"{name} with id {key} was not found.")
        {
            

        }


    }
}
