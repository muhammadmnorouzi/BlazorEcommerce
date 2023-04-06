namespace BlazorEcommerce.Shared;

public class ServiceResponse<T>
{
    public ServiceResponse(T? data, bool success = true, string message = "")
    {
        Data = data;
        Success = success;
        Message = message;
    }

    public T? Data { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }
}