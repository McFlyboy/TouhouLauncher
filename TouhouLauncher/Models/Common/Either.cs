using System;

namespace TouhouLauncher.Models.Common {
	public record Either<TLeft, TRight> where TLeft : notnull where TRight : notnull {
		private readonly object _value;
		private readonly Type _type;

		private Either(TLeft value) {
			_value = value;
			_type = typeof(TLeft);
		}

		private Either(TRight value) {
			_value = value;
			_type = typeof(TRight);
		}

		public bool IsLeft => _type == typeof(TLeft);

		public bool IsRight => _type == typeof(TRight);

		public TLeft GetLeft() => (TLeft)_value;

		public TRight GetRight() => (TRight)_value;

		public TResult Resolve<TResult>(Func<TLeft, TResult> leftResolver, Func<TRight, TResult> rightResolver) =>
			IsLeft ? leftResolver((TLeft)_value) : rightResolver((TRight)_value);

		public Either<TLeftResult, TRightResult> ResolveToEither<TLeftResult, TRightResult>(
			Func<TLeft, TLeftResult> leftResolver,
			Func<TRight, TRightResult> rightResolver
		) where TLeftResult : notnull where TRightResult : notnull =>
			IsLeft ? new(leftResolver((TLeft)_value)) : new(rightResolver((TRight)_value));

		public Either<TResult, TRight> SelectLeft<TResult>(Func<TLeft, TResult> leftSelector) where TResult : notnull =>
			IsLeft ? new(leftSelector((TLeft)_value)) : new((TRight)_value);

		public Either<TLeft, TResult> SelectRight<TResult>(Func<TRight, TResult> rightSelector) where TResult : notnull =>
			IsLeft ? new((TLeft)_value) : new(rightSelector((TRight)_value));

		public Either<TRight, TLeft> Swap() =>
			IsLeft ? new((TLeft)_value) : new((TRight)_value);

		public static implicit operator Either<TLeft, TRight>(TLeft value) => new(value);

		public static implicit operator Either<TLeft, TRight>(TRight value) => new(value);
	}
}
