namespace QCteam.SharedKernel;

public enum ErrorType
{
    Validation,
    NotFound,
    Conflict,
    Forbidden,
    Unauthorized,
}

// Błąd biznesowy zwracany przez serwisy (zamiast rzucania wyjątków). Warstwa API mapuje go na kod HTTP.
public record Error(ErrorType Type, string Code, string Message)
{
    public static Error Validation(string code, string message) => new(ErrorType.Validation, code, message);
    public static Error NotFound(string code, string message) => new(ErrorType.NotFound, code, message);
    public static Error Conflict(string code, string message) => new(ErrorType.Conflict, code, message);
    public static Error Forbidden(string code = "forbidden", string message = "Brak uprawnień do tej operacji.") => new(ErrorType.Forbidden, code, message);
    public static Error Unauthorized(string code = "unauthorized", string message = "Brak autoryzacji.") => new(ErrorType.Unauthorized, code, message);
}