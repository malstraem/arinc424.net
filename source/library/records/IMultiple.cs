namespace Arinc424;

/**<summary>
An entity with <c>Multiple Code(MULTI CD)</c>.
</summary>*/
internal interface IMultiple
{
    /**<summary>
    <c>Multiple Code(MULTI CD)</c> character.
    </summary>
    <remarks>See section 5.130.</remarks>*/
    char? Multiplier { get; set; }
}
