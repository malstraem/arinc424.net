namespace Arinc424.Procedures;

[DebuggerDisplay($"{nameof(Type)} - {{{nameof(Type)}}}, {nameof(Transition)} - {{{nameof(Transition)},nq}}")]
public abstract class ApproachSequence : ProcedureSequence<ApproachPoint>
{
    /// <inheritdoc cref="Terms.ApproachType"/>
    [Character(20)]
    public Terms.ApproachType Type { get; set; }
}
