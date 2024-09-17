namespace Arinc424;

#pragma warning disable CS8618

/// <summary>
/// Simple result pattern to avoid try-catch. Allows to handle bad values while populating properties
/// using <see cref="IStringConverter{TType}"/> or <see cref="ICharConverter{TType}"/> implementations.
/// </summary>
internal readonly ref struct Result<TType> where TType : notnull
{
    internal readonly TType Value;

    internal readonly ReadOnlySpan<char> Bad;

    private Result(TType value) => Value = value;

    private Result(ReadOnlySpan<char> bad) => Bad = bad;

    internal bool Invalid => !Bad.IsEmpty;

    public static implicit operator Result<TType>(TType value) => new(value);

    public static implicit operator Result<TType>(ReadOnlySpan<char> bad) => new(bad);
}
