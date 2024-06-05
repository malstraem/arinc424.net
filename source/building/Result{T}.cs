namespace Arinc424;

#pragma warning disable CS8618

/// <summary>
/// Simple result pattern implementation to avoid try-catch when populating properties with converters.
/// </summary>
internal readonly ref struct Result<T> where T : notnull
{
    internal readonly T Value;

    internal readonly string? Problem;

    internal Result(T value) => Value = value;

    internal Result(string problem) => Problem = problem;

    internal bool IsError => Problem is not null;

    public static implicit operator Result<T>(T value) => new(value);
}
