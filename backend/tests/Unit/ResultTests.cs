using QCteam.SharedKernel;

namespace QCteam.Tests.Unit;

public class ResultTests
{
    [Fact]
    public void Success_HasNoError_IsSuccess()
    {
        // Act: wywołuje to, co testuje 
        var result = Result.Success();

        // Assert: sprawdza, czy wynik jest prawidłowy
        Assert.True(result.IsSuccess);

        // sprawdza, czy wynik nie ma błędu
        Assert.Null(result.Error); 
    }

    [Fact]
    public void Failure_HasError_IsFailure()
    {
        // Act: wywołuje to, co testuje 
        var error = Error.NotFound("user_not_found", "Nie ma takiego użytkownika");
        var result = Result.Failure(error);

        // Assert: sprawdza, czy wynik jest prawidłowy
        Assert.True(result.IsFailure);

        // sprawdza, czy wynik ma błąd
        Assert.Equal(error, result.Error); 

        // sprawdza, czy wynik nie jest prawidłowy
        Assert.False(result.IsSuccess);
    }
}