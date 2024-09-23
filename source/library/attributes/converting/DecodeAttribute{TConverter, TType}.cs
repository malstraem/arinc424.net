namespace Arinc424.Attributes;

/// <summary>
/// Specifies that the string will be converted before assignment using <see cref="FieldAttribute"/> range.
/// </summary>
internal abstract class DecodeAttribute(Supplement start) : SupplementAttribute(start);

/// <inheritdoc/>
/// <typeparam name="TType">Type in which the value will be decoded from the string.</typeparam>
internal abstract class DecodeAttribute<TType>(Supplement start = Supplement.V18) : DecodeAttribute(start) where TType : notnull
{
    internal abstract Result<TType> Convert(ReadOnlySpan<char> @string);
}

/// <typeparam name="TConverter">Associated <see cref="IStringConverter{TType}"/>.</typeparam>
[AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Property, AllowMultiple = true)]
internal class DecodeAttribute<TConverter, TType>(Supplement start = Supplement.V18) : DecodeAttribute<TType>(start)
    where TConverter : IStringConverter<TType>
    where TType : notnull
{
    internal override Result<TType> Convert(ReadOnlySpan<char> @string) => TConverter.Convert(@string);
}

/// <inheritdoc/>
/// <typeparam name="TConverter">Associated <see cref="IStringConverter{TType}"/>.</typeparam>
internal sealed class DecodeAttribute<TConverter, TType, TRecord>(Supplement start = Supplement.V18) : DecodeAttribute<TConverter, TType>(start)
    where TConverter : IStringConverter<TType>
    where TType : notnull
    where TRecord : Record424
{
    internal override bool IsMatch<TMatch>() => typeof(TMatch).IsAssignableTo(typeof(TRecord));

    internal override bool IsTarget => true;
}
