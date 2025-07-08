using System.Reflection;
using System.Reflection.Emit;
using System.Text.RegularExpressions;

namespace Arinc424.Building;

using Diagnostics;

/**<summary>
Assignment operation to set <see cref="Record424"/> property.
</summary>*/
internal abstract class Assignment<TRecord>(PropertyInfo property) where TRecord : Record424
{
    protected PropertyInfo property = property;

    internal Regex? Regex { get; } = property.GetCustomAttribute<ValidationAttribute>()?.Regex;

    internal NullabilityInfo? NullabilityInfo { get; } = property.PropertyType.IsClass ? new NullabilityInfoContext().Create(property) : null;

    internal abstract void Assign(TRecord record, ReadOnlySpan<char> @string, Queue<Diagnostic> diagnostics);

    protected static Action<TRecord, TType> GetCompiledSetter<TType>(PropertyInfo property)
    {
        var method = new DynamicMethod(Guid.NewGuid().ToString(), null, [typeof(TRecord), typeof(TType)]);

        var gen = method.GetILGenerator();

        gen.Emit(OpCodes.Ldarg_0);
        gen.Emit(OpCodes.Ldarg_1);

        if (Nullable.GetUnderlyingType(property.PropertyType) is not null)
            gen.Emit(OpCodes.Newobj, property.PropertyType.GetConstructor([typeof(TType)])!);

        gen.EmitCall(OpCodes.Callvirt, property.GetSetMethod()!, null);

        gen.Emit(OpCodes.Ret);

        return method.CreateDelegate<Action<TRecord, TType>>();
    }
}
