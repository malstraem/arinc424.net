namespace Arinc424.Procedures;

[DebuggerDisplay($"{{{nameof(Identifier)},nq}}, {nameof(Type)} - {{{nameof(Type)}}}, {nameof(Transition)} - {{{nameof(Transition)},nq}}")]
public abstract class ArrivalSequence : ProcedureSequence<ArrivalPoint>
{
    /// <inheritdoc cref="Terms.ArrivalType"/>
    [Character(20)]
    public Terms.ArrivalType Type { get; set; }
}
