using Arinc424.Diagnostics;

namespace Arinc424.Building;

internal static class RecordBuilder<TRecord> where TRecord : Record424, new()
{
    [Obsolete("todo")]
    internal static TRecord Build(string @string, BuildAttribute info, out Queue<Diagnostic>? diagnostics)
    {
        diagnostics = null;

        TRecord record = new() { Source = @string };

        foreach (var indexInfo in info.IndexInfo)
            indexInfo.Process(record);

        foreach (var rangeInfo in info.RangeInfo)
        {
            if (!rangeInfo.TryProcess(record, out var diagnostic))
            {
                // todo: diagnostic log
                Debug.WriteLine(diagnostic.Problem);

                diagnostics ??= new();
                diagnostics.Enqueue(diagnostic);
            }
        }

        foreach (var arrayInfo in info.ArrayInfo)
        {
            // todo: maybe need to replace with result pattern to avoid performance issue on massive invalid data
            try
            {
                // todo: diagnostic log
                arrayInfo.Process(record);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        return record;
    }
}
