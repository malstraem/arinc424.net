using System.Reflection;

using Arinc424.Attributes;

namespace Arinc424.Linking;

internal class PrimaryKey(int length, ReadOnlyMemory<Range> ranges) : Key(length, ranges)
{
    internal static bool TryCreate(PropertyInfo[] properties, out PrimaryKey? key)
    {
        key = null;
        int length = 0;
        List<Range> ranges = [];

        foreach (var property in properties)
        {
            if (property.GetCustomAttribute<PrimaryAttribute>() is not null)
            {
                Range range;

                var fieldAttribute = property.GetCustomAttribute<FieldAttribute>();

                if (fieldAttribute is not null)
                {
                    range = fieldAttribute.Range;
                }
                else
                {
                    var foreignAttribute = property.GetCustomAttribute<ForeignAttribute>();

                    if (foreignAttribute is null)
                        continue;

                    range = foreignAttribute.Range;
                }

                length += range.End.Value - range.Start.Value;

                ranges.Add(range);
            }
        }

        if (ranges.Count == 0)
            return false;

        key = new(length, ranges.ToArray());
        return true;
    }

    internal string GetPrimaryKey(ReadOnlySpan<char> @string)
    {
        int index = 0;

        Span<char> chars = stackalloc char[length];

        foreach (var range in ranges.Span)
        {
            for (int i = range.Start.Value; i < range.End.Value; i++)
            {
                char @char = @string[i];

                if (!char.IsWhiteSpace(@char))
                    chars[index++] = @char;
            }
        }
        unsafe
        {
            fixed (char* ptr = chars)
                return new string(ptr, 0, index);
        }
    }
}
