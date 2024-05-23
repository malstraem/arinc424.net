namespace Arinc424;

/// <summary>
/// <c>Sector Bearing (SEC BRG)</c> or <c>Sectorization (SECTOR)</c> field.
/// </summary>
/// <remarks>See section 5.146 or 5.183.</remarks>
[Decode<SectorizationConverter>]
[DebuggerDisplay($"From {{{nameof(Start)}}} to {{{nameof(End)}}}")]
public readonly struct Sectorization(int start, int end)
{
    /// <summary>
    /// Start of sector bearing.
    /// </summary>
    /// <value>Degrees.</value>
    public int Start { get; } = start;

    /// <summary>
    /// End of sector bearing.
    /// </summary>
    /// <value>Degrees.</value>
    public int End { get; } = end;
}
