namespace Arinc424;

/// <summary>
/// Simple result pattern implementation to avoid try-catch when populating properties with converters.
/// </summary>
internal readonly ref struct Result<T> where T : notnull
{
    internal readonly T? Value;

    internal readonly string? Message;

    private Result(T? value, string? message)
    {
        Value = value;
        Message = message;
    }

    internal Result(T value) => Value = value;

    internal Result(string message) => Message = message;

    internal bool IsError => Message is not null;

    public static implicit operator Result<T>(T value) => new(value);

    /// <summary>
    /// Auto <see cref="IStringConverter.Convert"/> resolution.
    /// </summary>

    public static implicit operator Result<object>(Result<T> self) => new(self.Value, self.Message);
}
