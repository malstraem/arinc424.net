using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Arinc424;

using Processing;
using Linking;

internal static class TypeExtensions
{
    internal static Type[] Decompose(this Type type, Supplement supplement, out Relation[]? relations, out IPipeline[]? pipes)
    {
        Stack<Type> types = [];
        Stack<Relation> relationStack = [];
        Stack<IPipeline> pipeStack = [];

        Fill(type, supplement);

        pipes = pipeStack.Count > 0 ? [.. pipeStack] : null;
        relations = relationStack.Count > 0 ? [.. relationStack] : null;

        return [.. types];

        void Fill(Type type, Supplement supplement)
        {
            types.Push(type);

            foreach (var pipe in type.GetCustomAttributes<PipelineAttribute>())
            {
                if (supplement >= pipe.Start && supplement <= pipe.End)
                    pipeStack.Push(pipe.GetPipeline(supplement));
            }

            var relation = Relation.Create(type, supplement);

            if (relation is not null)
                relationStack.Push(relation);

            var property = type.GetProperty(nameof(Record424<Record424>.Sequence));

            if (property is null)
                return;

            Fill(property.PropertyType.GetElementType()!, supplement);
        }
    }

    internal static bool TryKeyInfo(this Type type, Supplement supplement, [NotNullWhen(true)] out KeyInfo? info)
    {
        var id = type.GetCustomAttributes<IdAttribute>().BySupplement(supplement);

        if (id is null)
        {
            info = null;
            return false;
        }
        info = id.GetInfo
        (
            type.GetCustomAttributes<IcaoAttribute>().BySupplement(supplement),
            type.GetCustomAttributes<PortAttribute>().BySupplement(supplement)
        );
        return true;
    }
}
