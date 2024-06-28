namespace Arinc424.Procedures;

[DebuggerDisplay($"{{{nameof(Identifier)},nq}}, {nameof(Type)} - {{{nameof(Type)}}}, {nameof(Transition)} - {{{nameof(Transition)},nq}}")]
public abstract class DepartureSequence : ProcedureSequence<DeparturePoint>
{
    /// <inheritdoc cref="Terms.DepartureType"/>
    [Character(20)]
    public Terms.DepartureType Type { get; set; }
}
