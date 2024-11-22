namespace ApiClientProject;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class HttpClientWrapper
{
    private readonly HttpClient _httpClient;

    public HttpClientWrapper()
    {
        _httpClient = new HttpClient();
    }

    public async Task<ApiResponseModel<List<T>>> GetAsync<T>(string url)
    {
        try
        {
            var response = await _httpClient.GetAsync(url);
            var data = await response.Content.ReadFromJsonAsync<List<T>>();
            return new ApiResponseModel<List<T>>
            {
                Message = response.IsSuccessStatusCode ? "Success" : "Failed",
                StatusCode = response.StatusCode,
                Data = data ?? new List<T>()
            };
        }
        catch (Exception ex)
        {
            return new ApiResponseModel<List<T>>
            {
                Message = $"Error: {ex.Message}",
                StatusCode = System.Net.HttpStatusCode.InternalServerError,
                Data = null
            };
        }
    }

    public async Task<ApiResponseModel<T>> PostAsync<T>(string url, object payload)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync(url, payload);
            var data = await response.Content.ReadFromJsonAsync<T>();
            return new ApiResponseModel<T>
            {
                Message = response.IsSuccessStatusCode ? "Success" : "Failed",
                StatusCode = response.StatusCode,
                Data = data ?? default!
            };
        }
        catch (Exception ex)
        {
            return new ApiResponseModel<T>
            {
                Message = $"Error: {ex.Message}",
                StatusCode = System.Net.HttpStatusCode.InternalServerError,
                Data = default
            };
        }
    }
}
