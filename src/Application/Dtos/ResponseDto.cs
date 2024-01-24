namespace Application.Dtos
{
    public class ResponseDto
    {
        public ResponseType Type { get; set; }
        public string? Message { get; set; }
    }

    public enum ResponseType
    {
        Info = 0,
        Success = 1,
        Error = 2,
    }
}
