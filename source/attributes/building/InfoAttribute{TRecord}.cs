using System.Reflection;

using Arinc424.Building;
using Arinc424.Linking;

namespace Arinc424.Attributes;

#pragma warning disable CS8618
internal abstract class InfoAttribute() : Attribute
#pragma warning restore CS8618
{
    protected Type type;

    protected Relations relations;

    protected PrimaryKey? primaryKey;

    protected SectionAttribute section;

    protected int? continuationIndex;

    internal bool IsMatch(string @string) => section.IsMatch(@string);

    internal bool IsContinuation(string @string) => continuationIndex is not null && @string[continuationIndex.Value] is not '0' and not '1';

    internal abstract IEnumerable<Build> Build(Queue<string> strings);

    internal void Link(IEnumerable<Build> builds, Unique unique, Meta424 meta) => relations.Link(builds, unique, meta);

    internal Type Type => type;

    internal Relations Relations => relations;

    internal PrimaryKey? PrimaryKey => primaryKey;

    internal (char, char) Section => (section.Section, section.Subsection);
}

internal abstract class InfoAttribute<TRecord> : InfoAttribute where TRecord : Record424, new()
{
    protected readonly BuildInfo<TRecord> info = new();

    protected readonly ProcessAttribute<TRecord>? process;

    private void InitializeByType()
    {
        type = process is null ? typeof(TRecord) : process.NewType;

        primaryKey = PrimaryKey.Create(type.GetProperties());

        relations = new(type);
    }

    internal InfoAttribute()
    {
        var type = typeof(TRecord);

        section = type.GetCustomAttribute<SectionAttribute>()!;
        process = type.GetCustomAttribute<ProcessAttribute<TRecord>>();
        continuationIndex = type.GetCustomAttribute<ContinuousAttribute>()?.Index;

        this.type = process is null ? typeof(TRecord) : process.NewType;

        InitializeByType();
    }
}
