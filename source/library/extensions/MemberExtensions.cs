using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Arinc424;

internal static class MemberExtensions
{
    internal static bool TryAttribute<R, A>(
        this MemberInfo member,
        Supplement supplement,
        [NotNullWhen(true)] out A? chosen
    )
        where R : Record424
        where A : SupplementAttribute
    {
        var attributes = member.GetCustomAttributes<A>();

        if (!attributes.Any())
        {
            chosen = null;
            return false;
        }

        List<A> target = [], nontarget = [];

        foreach (var attribute in attributes)
        {
            if (attribute.IsMatch<R>())
                target.Add(attribute);
            else if (!attribute.IsTarget)
                nontarget.Add(attribute);
        }
        chosen = (target is [] ? nontarget : target).BySupplement(supplement);

        return chosen is not null;
    }

    internal static A? BySupplement<A>(this IEnumerable<A> attributes, Supplement supplement)
        where A : SupplementAttribute
            => attributes.TakeWhile(x => x.Start <= supplement).LastOrDefault();
}
