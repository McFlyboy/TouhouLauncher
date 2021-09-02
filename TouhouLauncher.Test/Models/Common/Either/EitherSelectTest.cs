using TouhouLauncher.Models.Common;
using Xunit;

namespace TouhouLauncher.Test.Models.Common.Either {
	public class EitherSelectTest {
		[Fact]
		public void Converts_left_side_to_new_type_and_returns_new_Either() {
			Either<bool, float> either = true;

			Either<string, float> result = either.SelectLeft(value => value.ToString());

			Assert.Equal("True", result.GetLeft());
		}

		[Fact]
		public void Converts_right_side_to_new_type_and_returns_new_Either() {
			Either<bool, float> either = 3.2f;

			Either<bool, int> result = either.SelectRight(value => (int)value);

			Assert.Equal(3, result.GetRight());
		}
	}
}
