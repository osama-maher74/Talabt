using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Application.Excpetions
{
    public class UnAuthoraizedException : ApplicationException
    {
        public UnAuthoraizedException(string Massage) : base(Massage)
        {
        }
    }
}
