namespace HomeCloudApi.Models
{
    public class ServiceResponse<T>
    {
        public string Path { get; set; } = null;
        public string Message { get; set; } = null;
        public bool Success { get; set; } = true;
        public T Content { get; set; }
    }
}