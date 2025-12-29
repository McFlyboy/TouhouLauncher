using TouhouLauncher.Models.Common;
using Xunit;

namespace TouhouLauncher.Test.Models.Common.Either;

public class EitherSwapTest
{
    [Fact]
    public void Swaps_positions_of_types_and_returns_new_Either()
    {
        Either<string, int> either = 3;

        Either<int, string> result = either.Swap();

        Assert.True(result.IsLeft);
    }
}
