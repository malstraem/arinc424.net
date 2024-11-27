namespace Arinc424;

/// <summary>
/// An entity that has a <c>Sequence Number (SEQ NR)</c>.
/// </summary>
public interface ISequenced
{
    /// <summary>
    /// <c>Sequence Number (SEQ NR)</c> field.
    /// </summary>
    /// <remarks>See section 5.12.</remarks>
    int SeqNumber { get; set; }
}
