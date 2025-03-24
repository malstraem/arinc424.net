namespace Arinc424;

/**<summary>
<c>ARINC 424</c> record that described by sequence of strings.
</summary>
<typeparam name="TSub">Type of sequence.</typeparam>*/
public abstract class Record424<TSub> : Record424 where TSub : Record424
{
    /**<summary>
    A composition across different entities.
    </summary>
    <remarks> For example, <see cref="Routing.Airway">airway</see> contains
    sequence of <see cref="Routing.AirwayPoint">points</see>.</remarks>*/
    public TSub[] Sequence { get; set; }
}
