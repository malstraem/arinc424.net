using Arinc424.Ports;

namespace Arinc424.Procedures;

public class AirportProcedure<TSequence, TSub> : Procedure<TSequence, TSub> where TSequence : ProcedureSequence<TSub> where TSub : ProcedurePoint
{
    [Identifier(7, 10)]
    public Airport Airport { get; set; }
}

[Section('P', 'E', subsectionIndex: 13)]
public class AirportArrival : AirportProcedure<AirportArrivalSequence, ArrivalPoint>;

[Section('P', 'F', subsectionIndex: 13)]
public class AirportApproach : AirportProcedure<AirportApproachSequence, ApproachPoint>
{
    [One]
    public GroundPoint? GroundPoint { get; set; }

    [One]
    public AirportSatellitePoint? SatellitePoint { get; set; }
}

[Section('P', 'D', subsectionIndex: 13)]
public class AirportDeparture : AirportProcedure<AirportDepartureSequence, DeparturePoint>;

public class HeliportProcedure<TSequence, TSub> : Procedure<TSequence, TSub> where TSequence : ProcedureSequence<TSub> where TSub : ProcedurePoint
{
    [Identifier(7, 10)]
    public Heliport Heliport { get; set; }
}

[Section('H', 'E', subsectionIndex: 13)]
public class HeliportArrival : HeliportProcedure<HeliportArrivalSequence, ArrivalPoint>;

[Section('H', 'F', subsectionIndex: 13)]
public class HeliportApproach : HeliportProcedure<HeliportApproachSequence, ApproachPoint>
{
    [One]
    public HelicopterSatellitePoint? SatellitePoint { get; set; }
}

[Section('H', 'D', subsectionIndex: 13)]
public class HeliportDeparture : HeliportProcedure<HeliportDepartureSequence, DeparturePoint>;
