namespace Arinc424.Comms.Terms;

[DebuggerDisplay($"{nameof(Start)} - {{{nameof(Start)}}}, {nameof(End)} - {{{nameof(End)}}}")]
public struct Sector(int start, int end)
{
    public int Start = start;
    public int End = end;
}
