namespace BlazorEcommerce.Shared;

public class ServiceResponse<T>
{
    public ServiceResponse()
    {
    }

    public ServiceResponse(T? data, bool success = true, string msg = "")
    {
        Data = data;
        Success = success;
        Message = msg;
    }

    public T? Data { get; set; } = default!;
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
}