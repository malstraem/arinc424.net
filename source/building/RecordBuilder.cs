namespace Arinc.Spec424.Building;

internal class RecordBuilder
{
    internal static object Build(BuildInfo info, string @string)
    {
        object record = info.Constructor.Invoke(null);

        foreach (var property in info.IndexInfo)
        {
            char @char = @string[property.Index];

            object value = property.Transform is not null ? property.Transform.Convert(@char) : @char;

            property.Property.SetValue(record, value);
        }

        foreach (var property in info.RangeInfo)
        {
            string? trimmed = @string[property.Range].Trim();

            if (trimmed.Length == 0)
                trimmed = null;

            object? value = property.Decode is not null && trimmed is not null ? property.Decode.Convert(@trimmed) : @trimmed;

            property.Property.SetValue(record, value);
        }

        return record;
    }
}
