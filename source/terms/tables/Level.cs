namespace Arinc424.Tables.Terms;

[Decode<LevelConverter, Level>]
public class Level(Altitude from, Altitude separation, Altitude to)
{
    /// <summary>
    /// <c>Cruise Level From</c> field.
    /// </summary>
    /// <remarks>See section 5.136.</remarks>
    [Field(40, 44)]
    public Altitude From { get; } = from;

    /// <summary>
    /// <c>Vertical Separation</c> field.
    /// </summary>
    /// <remarks>See section 5.137.</remarks>
    [Field(45, 49)]
    public Altitude Separation { get; } = separation;

    /// <summary>
    /// <c>Cruise Level To</c> field.
    /// </summary>
    /// <remarks>See section 5.136.</remarks>
    [Field(50, 54)]
    public Altitude To { get; } = to;
}
