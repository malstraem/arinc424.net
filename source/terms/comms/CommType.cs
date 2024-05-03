namespace Arinc424.Comms.Terms;

/// <summary>
/// <c>Communications Type (COMM TYPE)</c> field.
/// </summary>
/// <remarks>See section 5.101.</remarks>
public enum CommType : byte
{
    Unknown,
    /// <summary>
    /// Area Control Center.
    /// </summary>
    Area,
    /// <summary>
    /// Airlift Command Post.
    /// </summary>
    Airlift,
    /// <summary>
    /// Air to Air.
    /// </summary>
    Air,
    /// <summary>
    /// Approach Control.
    /// </summary>
    Approach,
    /// <summary>
    /// Arrival Control.
    /// </summary>
    Arrival,
    /// <summary>
    /// Automatic Surface Observing System (ASOS).
    /// </summary>
    SurfaceObserving,
    /// <summary>
    /// Automatic Terminal Info Service (ATIS).
    /// </summary>
    TerminalInfoService,
    /// <summary>
    /// Airport Weather Information Broadcast (AWIB).
    /// </summary>
    WeatherBroadcast,
    /// <summary>
    /// Automatic Weather Observing Service (AWOS).
    /// </summary>
    WeatherObserving,
    /// <summary>
    /// Aerodrome Weather Information Services (AWIS).
    /// </summary>
    WeatherServices,
    /// <summary>
    /// Class B Airspace.
    /// </summary>
    Bravo,
    /// <summary>
    /// Class C Airspace.
    /// </summary>
    Charlie,
    /// <summary>
    /// Clearance Delivery.
    /// </summary>
    DeliveryClearance,
    /// <summary>
    /// Clearance, Pre-Taxi.
    /// </summary>
    PreTaxiClearance,
    /// <summary>
    /// Control Area (Terminal).
    /// </summary>
    ControlArea,
    /// <summary>
    /// Common Traffic Advisory Frequencies.
    /// </summary>
    CommonTrafficAdvisory,
    Control,
    /// <summary>
    /// Departure Control.
    /// </summary>
    Departure,
    /// <summary>
    /// Director (Approach Control Radar).
    /// </summary>
    Director,
    /// <summary>
    /// Enroute Flight Advisory Service (EFAS).
    /// </summary>
    FlightAdvisory,
    /// <summary>
    /// Emergency.
    /// </summary>
    Emergency,
    /// <summary>
    /// Flight Service Station.
    /// </summary>
    FlightService,
    /// <summary>
    /// Ground Comm Outlet.
    /// </summary>
    GroundOutlet,
    /// <summary>
    /// Ground Control.
    /// </summary>
    Ground,
    /// <summary>
    /// Gate Control.
    /// </summary>
    Gate,
    /// <summary>
    /// Helicopter Frequency.
    /// </summary>
    Helicopter,
    Information,
    /// <summary>
    /// Mandatory Broadcast Zone.
    /// </summary>
    BroadcastZone,
    /// <summary>
    /// Military Frequency.
    /// </summary>
    Military,
    Multicom,
    Operations,
    ActivatedLighting,
    Radio,
    Radar,
    /// <summary>
    /// Remote Flight Service Station (RFSS).
    /// </summary>
    RemoteFlightService,
    RampTaxi,
    /// <summary>
    /// Airport Radar Service Area (ARSA).
    /// </summary>
    RadarService,
    /// <summary>
    /// Terminal Control Area (TCA).
    /// </summary>
    TerminalControlArea,
    /// <summary>
    /// Terminal Control Area (TMA).
    /// </summary>
    TerminalManeuveringArea,
    Terminal,
    /// <summary>
    /// Terminal Radar Service Area (TRSA).
    /// </summary>
    TerminalRadarService,
    /// <summary>
    /// Transcriber Weather Broadcast (TWEB).
    /// </summary>
    TranscriberWeatherBroadcast,
    /// <summary>
    /// Tower, Air Traffic Control.
    /// </summary>
    Tower,
    /// <summary>
    /// Upper Area Control.
    /// </summary>
    UpperArea,
    Unicom,
    Volmet
}
