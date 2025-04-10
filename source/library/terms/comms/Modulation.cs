namespace Arinc424.Comms.Terms;

/**<summary>
 <c>Modulation (MODULN)</c> character.
</summary>
 <remarks>See section 5.197.</remarks>*/
[Char, Transform<ModulationConverter, Modulation>]
[Description("Modulation (MODULN)")]
public enum Modulation : byte
{
    Unknown,
    /**<summary>
     Amplitude Modulated Frequency.
    </summary>*/
    [Map('A')] Amplitude,
    /**<summary>
     Frequency Modulated  Frequency.
    </summary>*/
    [Map('F')] Frequency
}
