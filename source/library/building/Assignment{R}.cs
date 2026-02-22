using System.Reflection;
using System.Reflection.Emit;
using System.Text.RegularExpressions;

namespace Arinc424.Building;

/**<summary>
Assignment operation to set <see cref="Record424"/> property.
</summary>*/
internal abstract class Assignment<R>(PropertyInfo property)
    where R : Record424
{
    protected readonly PropertyInfo property = property;

    protected readonly NullabilityState? nullState = property.PropertyType.IsClass
        ? new NullabilityInfoContext().Create(property).ReadState
        : NullabilityState.Unknown;

    protected static Action<R, T> GetCompiledSetter<T>(PropertyInfo property)
    {
        var method = new DynamicMethod(Guid.NewGuid().ToString(), null, [typeof(R), typeof(T)]);

        var gen = method.GetILGenerator();

        gen.Emit(OpCodes.Ldarg_0);
        gen.Emit(OpCodes.Ldarg_1);

        if (Nullable.GetUnderlyingType(property.PropertyType) is not null)
            gen.Emit(OpCodes.Newobj, property.PropertyType.GetConstructor([typeof(T)])!);

        gen.EmitCall(OpCodes.Callvirt, property.GetSetMethod()!, null);

        gen.Emit(OpCodes.Ret);

        return method.CreateDelegate<Action<R, T>>();
    }

    internal abstract void Assign(R record, ReadOnlySpan<char> @string, Queue<Diagnostic> diagnostics);

    internal Regex? Regex { get; } = property.GetCustomAttribute<ValidationAttribute>()?.Regex;
}
