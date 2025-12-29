using System;

namespace TouhouLauncher.Models.Common.Extensions;

public static class GenericExtensions
{
    public static TResult Transform<TSource, TResult>(this TSource source, Func<TSource, TResult> transformer) =>
        transformer(source);
}
