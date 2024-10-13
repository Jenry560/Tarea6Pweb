namespace Tarea6Pweb.Models.Response
{
    public class DataResponse<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Result { get; set; }
    }
}
