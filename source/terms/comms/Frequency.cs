namespace Arinc424.Comms.Terms;

/// <summary>
/// <c>Communications Frequency (COMM FREQ)</c> field.
/// </summary>
/// <remarks>See section 5.103.</remarks>
[DebuggerDisplay($"{nameof(Receive)} - {{{nameof(Receive)}}}, {nameof(Transmit)} - {{{nameof(Transmit)}}}, {{{nameof(Unit)}}}")]
public struct Frequency(float receive, float transmit, FrequencyUnit unit)
{
    public float Receive = receive;

    public float Transmit = transmit;

    public FrequencyUnit Unit = unit;
}
