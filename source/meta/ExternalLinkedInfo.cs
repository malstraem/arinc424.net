using System.Reflection;

using Arinc.Spec424.Attributes;

namespace Arinc.Spec424;

internal record ExternalLinkedInfo
{
    private readonly PropertyInfo[] properties;

    internal ExternalLinkedInfo(Type type, ExternalAttribute externalAttribute)
    {
        properties = new PropertyInfo[externalAttribute.PropertyNames.Length];

        for (int i = 0; i < properties.Length; i++)
        {
            properties[i] = type.GetProperty(externalAttribute.PropertyNames[i]) ?? throw new Exception("oops");
        }
    }

    public string GetKey(object @object)
    {
        string key = string.Empty;

        foreach (var property in properties)
            key += property.GetValue(@object);

        return key;
    }
}
