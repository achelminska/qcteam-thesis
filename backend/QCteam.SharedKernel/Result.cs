namespace QCteam.SharedKernel;

// Wynik operacji bez wartości
public class Result
{
    protected Result(Error? error) => Error = error;

    public Error? Error { get; }
    public bool IsSuccess => Error is null;
    public bool IsFailure => !IsSuccess;

    // Fabryczki do tworzenia Result
    public static Result Success() => new(null);
    public static Result Failure(Error error) => new(error);

    // Konwersja z Error na Result
    // Zamiast return Result.Failure(Error.NotFound("user_not_found", "Nie ma takiego użytkownika")); w serwisach
    // moge napisac return Error.NotFound("user_not_found", "Nie ma takiego użytkownika");
    public static implicit operator Result(Error error) => Failure(error);
}

// Wynik operacji z wartością
public class Result<T> : Result
{   
    private Result(T? value, Error? error) : base(error) => Value = value;
    public T? Value { get; }

    // Fabryczki do tworzenia Result
    public static Result<T> Success(T value) => new(value, null);
    public static new Result<T> Failure(Error error) => new(default, error);

    public static implicit operator Result<T>(T value) => Success(value);
    public static implicit operator Result<T>(Error error) => Failure(error);
}