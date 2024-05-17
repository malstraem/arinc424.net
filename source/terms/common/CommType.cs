namespace Arinc424;

/// <summary>
/// <c>Communications Type (COMM TYPE)</c> field.
/// </summary>
/// <remarks>See section 5.101.</remarks>
[String]
public enum CommType : byte
{
    Unknown,
    /// <summary>
    /// Area Control Center.
    /// </summary>
    [Map("ACC")] Area,
    /// <summary>
    /// Airlift Command Post.
    /// </summary>
    [Map("ACP")] Airlift,
    /// <summary>
    /// Air to Air.
    /// </summary>
    [Map("AIR")] Air,
    /// <summary>
    /// Approach Control.
    /// </summary>
    [Map("APP")] Approach,
    /// <summary>
    /// Arrival Control.
    /// </summary>
    [Map("ARR")] Arrival,
    /// <summary>
    /// Automatic Surface Observing System (ASOS).
    /// </summary>
    [Map("ASO")] SurfaceObserving,
    /// <summary>
    /// Automatic Terminal Info Service (ATIS).
    /// </summary>
    [Map("ATI")] TerminalInfoService,
    /// <summary>
    /// Airport Weather Information Broadcast (AWIB).
    /// </summary>
    [Map("AWI")] WeatherBroadcast,
    /// <summary>
    /// Automatic Weather Observing Service (AWOS).
    /// </summary>
    [Map("AWO")] WeatherObserving,
    /// <summary>
    /// Aerodrome Weather Information Services (AWIS).
    /// </summary>
    [Map("AWS")] WeatherServices,
    /// <summary>
    /// Class B Airspace.
    /// </summary>
    [Map("CBA")] Bravo,
    /// <summary>
    /// Class C Airspace.
    /// </summary>
    [Map("CCA")] Charlie,
    /// <summary>
    /// Clearance Delivery.
    /// </summary>
    [Map("CLD")] DeliveryClearance,
    /// <summary>
    /// Clearance, Pre-Taxi.
    /// </summary>
    [Map("CPT")] PreTaxiClearance,
    /// <summary>
    /// Control Area (Terminal).
    /// </summary>
    [Map("CTA")] ControlArea,
    /// <summary>
    /// Common Traffic Advisory Frequencies.
    /// </summary>
    [Map("CTF")] CommonTrafficAdvisory,
    [Map("CTL")] Control,
    /// <summary>
    /// Departure Control.
    /// </summary>
    [Map("DEP")] Departure,
    /// <summary>
    /// Director (Approach Control Radar).
    /// </summary>
    [Map("DIR")] Director,
    /// <summary>
    /// Enroute Flight Advisory Service (EFAS).
    /// </summary>
    [Map("EFS")] FlightAdvisory,
    /// <summary>
    /// Emergency.
    /// </summary>
    [Map("EMR")] Emergency,
    /// <summary>
    /// Flight Service Station.
    /// </summary>
    [Map("FSS")] FlightService,
    /// <summary>
    /// Ground Comm Outlet.
    /// </summary>
    [Map("GCO")] GroundOutlet,
    /// <summary>
    /// Ground Control.
    /// </summary>
    [Map("GND")] Ground,
    /// <summary>
    /// Gate Control.
    /// </summary>
    [Map("GTE")] Gate,
    /// <summary>
    /// Helicopter Frequency.
    /// </summary>
    [Map("HEL")] Helicopter,
    [Map("INF")] Information,
    /// <summary>
    /// Mandatory Broadcast Zone.
    /// </summary>
    [Map("MBZ")] BroadcastZone,
    /// <summary>
    /// Military Frequency.
    /// </summary>
    [Map("MIL")] Military,
    [Map("MUL")] Multicom,
    [Map("OPS")] Operations,
    [Map("PAL")] ActivatedLighting,
    [Map("RDO")] Radio,
    [Map("RDR")] Radar,
    /// <summary>
    /// Remote Flight Service Station (RFSS).
    /// </summary>
    [Map("RFS")] RemoteFlightService,
    [Map("RMP")] RampTaxi,
    /// <summary>
    /// Airport Radar Service Area (ARSA).
    /// </summary>
    [Map("RSA")] RadarService,
    /// <summary>
    /// Terminal Control Area (TCA).
    /// </summary>
    [Map("TCA")] TerminalControlArea,
    /// <summary>
    /// Terminal Control Area (TMA).
    /// </summary>
    [Map("TMA")] TerminalManeuveringArea,
    [Map("TML")] Terminal,
    /// <summary>
    /// Terminal Radar Service Area (TRSA).
    /// </summary>
    [Map("TRS")] TerminalRadarService,
    /// <summary>
    /// Transcriber Weather Broadcast (TWEB).
    /// </summary>
    [Map("TWE")] TranscriberWeatherBroadcast,
    /// <summary>
    /// Tower, Air Traffic Control.
    /// </summary>
    [Map("TWR")] Tower,
    /// <summary>
    /// Upper Area Control.
    /// </summary>
    [Map("UAC")] UpperArea,
    [Map("UNI")] Unicom,
    [Map("VOL")] Volmet
}
