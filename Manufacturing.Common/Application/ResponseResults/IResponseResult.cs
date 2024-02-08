namespace Manufacturing.Common.Application.ResponseResults;

public interface IResponseResult
{
    bool IsSuccessfull { get; }
    bool HasError { get; }
    string? Error { get; init; }
}
