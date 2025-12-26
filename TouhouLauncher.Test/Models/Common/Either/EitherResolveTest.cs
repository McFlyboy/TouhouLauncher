using TouhouLauncher.Models.Common;
using Xunit;

namespace TouhouLauncher.Test.Models.Common.Either;

public class EitherResolveTest
{
    [Fact]
    public void Converts_both_types_to_the_same_type_and_returns_result()
    {
        Either<string, int> either = 3;
        Either<string, int> either2 = "Hello";

        string result = either.Resolve(
            leftValue => $"Message: {leftValue}",
            rightValue => $"The answer is {rightValue}!"
        );
        string result2 = either2.Resolve(
            leftValue => $"Message: {leftValue}",
            rightValue => $"The answer is {rightValue}!"
        );

        Assert.Equal("The answer is 3!", result);
        Assert.Equal("Message: Hello", result2);
    }

    [Fact]
    public void Converts_both_types_into_new_types_packed_into_a_new_either_and_returns_it()
    {
        Either<bool, float> either = 3.2f;

        Either<string, int> result = either.ResolveToEither<string, int>(
            leftValue => leftValue.ToString(),
            rightValue => (int)rightValue
        );

        Assert.Equal(3, result.GetRight());
    }
}
