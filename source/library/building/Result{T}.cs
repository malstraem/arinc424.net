namespace Arinc424;

#pragma warning disable CS8618

/// <summary>
/// Simple result pattern to avoid try-catch when populating properties
/// using <see cref="IStringConverter{TType}"/> or <see cref="ICharConverter{TType}"/> implementations.
/// </summary>
internal readonly ref struct Result<TType> where TType : notnull
{
    internal readonly TType Value;

    internal readonly string? Problem;

    private Result(TType value) => Value = value;

    private Result(string problem) => Problem = problem;

    internal bool Invalid => Problem is not null;

    public static implicit operator Result<TType>(TType value) => new(value);

    /// <summary>
    /// Used for fluent converter code cause there is no string to string conversion.
    /// </summary>
    public static implicit operator Result<TType>(string problem) => new(problem);
}
