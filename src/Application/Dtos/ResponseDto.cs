namespace Application.Dtos
{
    public class ResponseDto
    {
        public ResponseType Type { get; set; }
        public string Message { get; set; }
    }

    public enum ResponseType
    {
        Info,
        Success,
        Error,
    }
}
