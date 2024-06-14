namespace Arinc424.Attributes;

/// <summary>
/// Specifies that the value will be decoded by associated converter before assignment using <see cref="FieldAttribute"/> range.
/// </summary>
internal abstract class DecodeAttribute : Attribute
{
    internal abstract bool IsMatch<TMatch>() where TMatch : Record424;
}

/// <inheritdoc/>
/// <typeparam name="TType">Type in which the value will be decoded from the string.</typeparam>
internal abstract class DecodeAttribute<TType> : DecodeAttribute where TType : notnull
{
    internal abstract Result<TType> Convert(ReadOnlySpan<char> @string);

    internal override bool IsMatch<TMatch>() => false;
}

/// <inheritdoc/>
/// <typeparam name="TConverter">Associated <see cref="IStringConverter{TType}"/>.</typeparam>
[AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Property)]
internal class DecodeAttribute<TConverter, TType> : DecodeAttribute<TType>
    where TConverter : IStringConverter<TType> where TType : notnull
{
    internal override Result<TType> Convert(ReadOnlySpan<char> @string) => TConverter.Convert(@string);
}

/// <inheritdoc/>
/// <typeparam name="TConverter">Associated <see cref="IStringConverter{TType}"/>.</typeparam>
//[AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Property, AllowMultiple = true)]
internal sealed class DecodeAttribute<TConverter, TType, TRecord> : DecodeAttribute<TConverter, TType>
    where TConverter : IStringConverter<TType> where TType : notnull where TRecord : Record424
{
    internal override bool IsMatch<TMatch>() => typeof(TMatch).IsAssignableTo(typeof(TRecord));
}
