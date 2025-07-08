using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Arinc424;

using Building;
using Processing;
using Linking;

internal static class MemberExtensions
{
    internal static bool TryAttribute<TRecord, TAttribute>(this MemberInfo member, Supplement supplement, [NotNullWhen(true)] out TAttribute? chosen)
        where TRecord : Record424
        where TAttribute : SupplementAttribute
    {
        var attributes = member.GetCustomAttributes<TAttribute>();

        if (!attributes.Any())
        {
            chosen = null;
            return false;
        }

        List<TAttribute> target = [], nontarget = [];

        foreach (var attribute in attributes)
        {
            if (attribute.IsMatch<TRecord>())
                target.Add(attribute);
            else if (!attribute.IsTarget)
                nontarget.Add(attribute);
        }
        chosen = (target is [] ? nontarget : target).BySupplement(supplement);

        return chosen is not null;
    }

    internal static TAttribute? BySupplement<TAttribute>(this IEnumerable<TAttribute> attributes, Supplement supplement)
        where TAttribute : SupplementAttribute
            => attributes.TakeWhile(x => x.Start <= supplement).LastOrDefault();

    internal static Composition GetComposition(this Type type, Supplement supplement)
    {
        Stack<Type> types = [];
        Stack<IPipeline> pipelines = [];
        Stack<Relationships> relations = [];

        Fill(type, supplement);

        return new Composition([.. types]) { Pipelines = [.. pipelines], Relations = [.. relations] };

        void Fill(Type type, Supplement supplement)
        {
            types.Push(type);

            foreach (var pipe in type.GetCustomAttributes<PipelineAttribute>())
            {
                if (supplement >= pipe.Start && supplement <= pipe.End)
                    pipelines.Push(pipe.GetPipeline(supplement));
            }

            var relationships = Relationships.Create(type, supplement);

            if (relationships is not null)
                relations.Push(relationships);

            var property = type.GetProperty(nameof(Record424<Record424>.Sequence));

            if (property is null)
                return;

            Fill(property.PropertyType.GetElementType()!, supplement);
        }
    }
}
