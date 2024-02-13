using System.Reflection;

using Arinc.Spec424.Attributes;
using Arinc.Spec424.Records;

namespace Arinc.Spec424.Linking;

internal class LinkingInfo
{
    private readonly IReadOnlyList<LinkInfo> infos;

    private LinkingInfo(IReadOnlyList<LinkInfo> infos) => this.infos = infos;

    internal static bool TryCreate(Type type, out LinkingInfo? linkingInfo)
    {
        linkingInfo = null;

        if (type.IsAbstract)
            return false;

        List<LinkInfo> links = [];

        var properties = type.GetProperties();

        foreach (var property in properties)
        {
            var foreignAttribute = property.GetCustomAttribute<ForeignAttribute>();

            if (foreignAttribute is null)
                continue;

            var possibleAttribute = property.GetCustomAttribute<PossibleAttribute>();

            var possibleTypes = possibleAttribute is null ? [property.PropertyType] : possibleAttribute.Types;

            links.Add(new LinkInfo(property, foreignAttribute, possibleTypes));
        }

        linkingInfo = new LinkingInfo([.. links]);
        return true;
    }

    internal (IReadOnlyList<Link>, Link?) GetLinks(string @string)
    {
        List<Link> links = [];

        Link? airportLink = null;

        foreach (var info in infos)
        {
            string key = @string[info.KeyRange].Trim();

            var link = new Link(info, key);

            if (info.Property.PropertyType == typeof(Airport))
                airportLink = link;
            else
                links.Add(link);
        }
        return (links, airportLink);
    }
}
