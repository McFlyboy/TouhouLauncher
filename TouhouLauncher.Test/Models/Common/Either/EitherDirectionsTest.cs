using TouhouLauncher.Models.Common;
using Xunit;

namespace TouhouLauncher.Test.Models.Common.Either;

public class EitherDirectionsTest
{
    [Fact]
    public void Is_left_when_constructed_with_left_type()
    {
        Either<string, int> either = "Hello";

        var result = either.IsLeft;

        Assert.True(result);
    }

    [Fact]
    public void Is_not_left_when_constructed_with_right_type()
    {
        Either<string, int> either = 3;

        var result = either.IsLeft;

        Assert.False(result);
    }

    [Fact]
    public void Is_right_when_constructed_with_right_type()
    {
        Either<string, int> either = 3;

        var result = either.IsRight;

        Assert.True(result);
    }

    [Fact]
    public void Is_not_right_when_constructed_with_left_type()
    {
        Either<string, int> either = "Hello";

        var result = either.IsRight;

        Assert.False(result);
    }
}
