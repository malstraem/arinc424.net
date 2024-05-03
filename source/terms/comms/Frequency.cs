using System.Diagnostics;

namespace Arinc424.Comms.Terms;

[DebuggerDisplay($"{nameof(Receive)} - {{{nameof(Receive)}}}, {nameof(Transmit)} - {{{nameof(Transmit)}}}, {{{nameof(Unit)}}}")]
public struct Frequency(float receive, float transmit, FrequencyUnit unit)
{
    public float Receive = receive;

    public float Transmit = transmit;

    public FrequencyUnit Unit = unit;
}
