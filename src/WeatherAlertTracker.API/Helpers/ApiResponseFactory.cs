using WeatherAlertTracker.API.Models;

namespace WeatherAlertTracker.API.Helpers;

public static class ApiResponseFactory
{
    public static ApiResponse<T> Success<T>(
        T data,
        string message)
    {
        return new ApiResponse<T>
        {
            Success = true,
            Message = message,
            Data = data
        };
    }

    internal static object? Error(string v, int status404NotFound)
    {
        throw new NotImplementedException();
    }

    internal static object? Error(int v1, string v2)
    {
        throw new NotImplementedException();
    }

    internal static object? Success(string message)
    {
        throw new NotImplementedException();
    }
}