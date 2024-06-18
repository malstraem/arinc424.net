using Arinc424.Ports;

namespace Arinc424.Procedures;

public class AirportProcedure<TSequence, TSub> : Procedure<TSequence, TSub> where TSequence : ProcedureSequence<TSub> where TSub : ProcedurePoint
{
    [Foreign(7, 12), Primary]
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
