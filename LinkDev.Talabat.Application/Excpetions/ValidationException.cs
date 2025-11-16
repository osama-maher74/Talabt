namespace LinkDev.Talabat.Application.Excpetions
{
    public class ValidationException:BadRequestException
    {
        //public required IEnumerable<ValditonErorr> Erorrs { get; set; }
        public ValidationException(string message="Bad Request") : base(message)
        {
            
        }
    }
}
