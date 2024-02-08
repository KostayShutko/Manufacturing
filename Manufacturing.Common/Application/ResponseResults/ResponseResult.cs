using System.Text.Json.Serialization;

namespace Manufacturing.Common.Application.ResponseResults;

public class ResponseResultBase : IResponseResult
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? Error { get; init; }
    public bool IsSuccessfull => string.IsNullOrEmpty(Error);
    public bool HasError => !IsSuccessfull;
}

public class ResponseResult : ResponseResultBase
{
    public static ResponseResult CreateSuccess() => new ResponseResult();

    public static ResponseResult<T> CreateSuccess<T>(T result) => ResponseResult<T>.CreateSuccess(result);

    public static ResponseResult CreateFail(string error) => new ResponseResult { Error = error };

    public static ResponseResult<T> CreateFail<T>(string error) => ResponseResult<T>.CreateFail(error);
}

public class ResponseResult<T> : ResponseResultBase
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public T? Data { get; init; }

    public static ResponseResult<T> CreateSuccess(T result) => new ResponseResult<T> { Data = result };

    public static ResponseResult<T> CreateFail(string error) => new ResponseResult<T> { Error = error };
}
