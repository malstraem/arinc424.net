using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Arinc424;

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
}
