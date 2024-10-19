using MediatR;

namespace _5W2H.Application.Models;

public class ResultViewModel
{
    public ResultViewModel(bool isSuccess = true, string message = "")
    {
        IsSuccess = isSuccess;
        Message = message;
    }

    public bool IsSuccess { get; private set; }
    public string Message { get; private set; }

    public static ResultViewModel Success()
        => new();

    public static ResultViewModel Error(string message)
        => new(false, message);
}

public class ResultViewModel<T> : ResultViewModel, IRequest
{
    public ResultViewModel(T? data, bool isSuccess = true, string message = "")
        : base(isSuccess, message)
    {
        Data = data;
    }

    public T? Data { get; private set; }

    // Adicionando a nova propriedade AdditionalData
    public object? AdditionalData { get; set; }

    public static ResultViewModel<T> Success(T data)
        => new(data);

    public static ResultViewModel<T> Error(string message)
        => new(default, false, message);
}
