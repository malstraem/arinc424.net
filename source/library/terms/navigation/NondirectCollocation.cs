namespace Arinc424.Navigation.Terms;

/**<summary>
Fifth character of <c>NAVAID Class (CLASS)</c> field,
specific to <see cref="Nondirectional"/>.
</summary>
<remarks>See section 5.35.</remarks>*/
[Char, Transform<NondirectCollocationConverter, NondirectCollocation>]
[Description("NAVAID Class (CLASS) - Collocation")]
public enum NondirectCollocation : byte
{
    Unknown,
    /**<summary>
    Required to received an aural identification signal.
    </summary>*/
    [Map('B')] BeatFrequencyOscillator
}
