namespace Arinc424;

/// <summary>
/// Simple result pattern implementation to avoid try-catch when populating properties with converters.
/// </summary>
internal readonly ref struct Result<T> where T : notnull
{
    internal readonly T? Value;

    internal readonly string? Problem;

    private Result(T? value, string? problem)
    {
        Value = value;
        Problem = problem;
    }

    internal Result(T value) => Value = value;

    internal Result(string message) => Problem = message;

    internal bool IsError => Problem is not null;

    public static implicit operator Result<T>(T value) => new(value);

    /// <summary>
    /// Auto <see cref="IStringConverter.Convert"/> resolution.
    /// </summary>

    public static implicit operator Result<object>(Result<T> self) => new(self.Value, self.Problem);
}
