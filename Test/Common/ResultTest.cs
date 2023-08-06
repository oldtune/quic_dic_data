using Common.Models;
using Xunit;

namespace Test.Common;

public class ResultTest
{
    [Fact]
    public void CreateSuccessResultTest()
    {
        var result = Result<int>.CreateSuccess(3);
        Assert.Equal(true, result.Ok);
        Assert.Equal(3, result.Unwrap());
        Assert.Null(result.GetError());
    }

    [Fact]
    public void CreateFailedResultTest()
    {
        var failedResult = Result.CreateError<int>(new Exception("Test exception"));
        Assert.Equal(false, failedResult.Ok);
        Assert.NotNull(failedResult.GetError());
    }

    [Fact]
    public void FromNullTest()
    {
        var result = Result.FromNotNull<string>(null);
        Assert.Equal(false, result.Ok);
        Assert.NotNull(result.GetError());
        Assert.IsType<NullReferenceException>(result.GetError().Exception());
    }
}