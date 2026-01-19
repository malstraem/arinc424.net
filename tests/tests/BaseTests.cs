using System.Collections.Frozen;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Arinc424.Tests;

public abstract class BaseTests
{
    protected readonly FrozenDictionary<Supplement, Meta424> meta;

    protected static readonly JsonSerializerOptions options = new()
    {
        WriteIndented = true,
        IncludeFields = true,
        IgnoreReadOnlyProperties = true,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        ReferenceHandler = ReferenceHandler.Preserve,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    public BaseTests()
    {
        Dictionary<Supplement, Meta424> meta = [];

        foreach (var supplement in Enum.GetValues<Supplement>())
            meta[supplement] = Meta424.Create(supplement);

        this.meta = meta.ToFrozenDictionary();
    }
}
