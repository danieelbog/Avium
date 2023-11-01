namespace Web.Core.DTOs.Response
{
    public class ExceptionDto
    {
        public string Type { get; set; }
        public string Message { get; set; }

        ExceptionDto()
        {
                
        }

        public ExceptionDto(string type, string message)
        {
            Type = type;
            Message = message;
        }
    }
}
