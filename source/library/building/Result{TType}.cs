namespace Arinc424;

/**<summary>
Simple result pattern to avoid try-catch. Allows to handle bad values
while populating properties using <see cref="IStringConverter{TType}"/> implementations.
</summary>*/
internal readonly ref struct Result<TType> where TType : notnull
{
    internal readonly TType Value;

    internal readonly ReadOnlySpan<char> Bad;

    private Result(TType value) => Value = value;
#pragma warning disable CS8618
    private Result(ReadOnlySpan<char> bad) => Bad = bad;
#pragma warning restore CS8618
    internal bool Invalid => !Bad.IsEmpty;

    public static implicit operator Result<TType>(TType value) => new(value);

    public static implicit operator Result<TType>(ReadOnlySpan<char> bad) => new(bad);
}
