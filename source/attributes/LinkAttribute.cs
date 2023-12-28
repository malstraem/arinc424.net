using System.Reflection;
using System.Runtime.CompilerServices;

using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Attributes;

internal abstract class LinkAttribute(Type linkedType, Type recipientType, string propertyName) : Attribute
{
    internal Type RecipientType { get; } = recipientType;

    internal PropertyInfo Property { get; } = linkedType.GetProperty(propertyName) ?? throw new Exception("ops");
}

[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
internal class LinkAttribute<TLinked, TRecipient>([CallerMemberName] string propertyName = "") : LinkAttribute(typeof(TLinked), typeof(TRecipient), propertyName)
    where TLinked : Record424
    where TRecipient : Record424, IIdentifiable
{ }
