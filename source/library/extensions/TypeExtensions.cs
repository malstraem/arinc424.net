using System.Reflection;

namespace Arinc424;

using Building;
using Processing;
using Linking;
using System.Diagnostics.CodeAnalysis;

internal static class TypeExtensions
{
    internal static Composition GetComposition(this Type type, Supplement supplement)
    {
        Stack<Type> types = [];
        Stack<IPipeline> pipelines = [];
        Stack<Relation> relations = [];

        Fill(type, supplement);

        return new Composition([.. types])
        {
            Pipelines = pipelines.Count == 0 ? null : [.. pipelines],
            Relations = relations.Count == 0 ? null : [.. relations]
        };

        void Fill(Type type, Supplement supplement)
        {
            types.Push(type);

            foreach (var pipe in type.GetCustomAttributes<PipelineAttribute>())
            {
                if (supplement >= pipe.Start && supplement <= pipe.End)
                    pipelines.Push(pipe.GetPipeline(supplement));
            }

            var relationships = Relation.Create(type, supplement);

            if (relationships is not null)
                relations.Push(relationships);

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
