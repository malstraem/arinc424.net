using System.Reflection;
using System.Runtime.CompilerServices;

using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Attributes;

internal abstract class ReceiveAttribute(Type recipientType, Type linkedType, string propertyName) : Attribute
{
    internal Type LinkedType { get; } = linkedType;

    internal PropertyInfo Property { get; } = recipientType.GetProperty(propertyName) ?? throw new Exception("ops");
}

[AttributeUsage(AttributeTargets.Property)]
internal class ReceiveAttribute<TRecipient, TRecord>([CallerMemberName] string propertyName = "")
    : ReceiveAttribute(typeof(TRecipient), typeof(TRecord), propertyName) where TRecipient : Record424, IIdentifiable
                                                                          where TRecord : Record424
{ }
