namespace Arinc424;

/**<summary>
<c>Communications Frequency (COMM FREQ)</c> field.
</summary>
<remarks>See section 5.103.</remarks>*/
[Decode<FrequencyConverter, Frequency>]
[Decode<FrequencyConverterV19, Frequency>(Start = Supplement.V19)]
[DebuggerDisplay($"{nameof(Receive)} - {{{nameof(Receive)}}}, {nameof(Transmit)} - {{{nameof(Transmit)}}}, {{{nameof(Unit)}}}")]
public readonly struct Frequency(FrequencyUnit unit, float? transmit, float? receive)
{
    /// <inheritdoc cref="FrequencyUnit"/>
    public FrequencyUnit Unit { get; } = unit;

    public float? Receive { get; } = receive;

    public float? Transmit { get; } = transmit;
}
