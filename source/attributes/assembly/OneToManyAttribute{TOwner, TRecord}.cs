namespace Arinc.Spec424.Attributes;

[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
internal abstract class OneToManyAttribute(Type ownerType, Type recordType) : Attribute
{

}

internal class OneToManyAttribute<TOwner, TRecord>() : OneToManyAttribute(typeof(TOwner), typeof(TRecord))
{

}
