namespace ApiClientProject;

using System.Net;

public class ApiResponseModel<T>
{
    public required string Message { get; set; } = string.Empty;
    public System.Net.HttpStatusCode StatusCode { get; set; }
    public required T? Data { get; set; } = default;
}

