namespace Arinc424.Routing.Terms;

/**<summary>
<c>Marker Shape (SHAPE)</c> character.
</summary>
<remarks>See section 5.112.</remarks>*/
[Char, Transform<MarkerShapeConverter, MarkerShape>]
[Description("Marker Shape (SHAPE)")]
public enum MarkerShape : byte
{
    Unknown,
    [Map('B')] Bone,
    [Map('E')] Elliptical
}
