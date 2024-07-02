using Arinc424.Ports;

namespace Arinc424.Procedures;

public class AirportProcedure<TSequence, TSub> : Procedure<TSequence, TSub> where TSequence : ProcedureSequence<TSub> where TSub : ProcedurePoint
{
    [Foreign(7, 12), Primary]

    [Identifier(7, 10), Icao(11, 12)]
    public Airport Airport { get; set; }
}

public class AirportArrival : AirportProcedure<AirportArrivalSequence, ArrivalPoint>;

public class AirportApproach : AirportProcedure<AirportApproachSequence, ApproachPoint>
{
    [One]
    public GroundPoint? GroundPoint { get; set; }

    [One]
    public AirportSatellitePoint? SatellitePoint { get; set; }
}

public class AirportDeparture : AirportProcedure<AirportDepartureSequence, DeparturePoint>;

public class HeliportProcedure<TSequence, TSub> : Procedure<TSequence, TSub> where TSequence : ProcedureSequence<TSub> where TSub : ProcedurePoint
{
    [Foreign(7, 12), Primary]

    [Identifier(7, 10), Icao(11, 12)]
    public Heliport Heliport { get; set; }
}

public class HeliportArrival : HeliportProcedure<HeliportArrivalSequence, ArrivalPoint>;

public class HeliportApproach : HeliportProcedure<HeliportApproachSequence, ApproachPoint>
{
    [One]
    public HelicopterSatellitePoint? SatellitePoint { get; set; }
}

public class HeliportDeparture : HeliportProcedure<HeliportDepartureSequence, DeparturePoint>;
