namespace Arinc424;

/// <summary>
/// <c>ARINC 424</c> record that described by sequence of strings.
/// </summary>
/// <typeparam name="TSub">Type of sequence.</typeparam>
public abstract class Record424<TSub> : Record424 where TSub : Record424
{
    public List<TSub> Sequence { get; set; } = [];
}
