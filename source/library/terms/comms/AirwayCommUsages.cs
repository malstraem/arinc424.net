namespace Arinc424.Comms.Terms;

/// <summary>
/// <c>Service Indicator (SERV IND)</c> -> <c>Enroute</c>.
/// </summary>
/// <remarks>See section 5.106, Table 5-21.</remarks>
[String, Flags, Decode<AirwayCommUsagesConverter, AirwayCommUsages>]
[Description("Service Indicator (SERV IND) - Enroute")]
public enum AirwayCommUsages : ushort
{
    Unknown = 0,
    /// <summary>
    /// Aeronautical Enroute Information Service (AEIS).
    /// </summary>
    [Map('A')] AeronauticalInfo = 1,
    /// <summary>
    /// Flight Information Service (FIS).
    /// </summary>
    [Map('F')] FlightInfo = 1 << 1,
    /// <summary>
    /// Air/Ground.
    /// </summary>
    [Offset, Map('A')] AirGround = 1 << 2,
    /// <summary>
    /// Discrete Frequency.
    /// </summary>
    [Map('D')] Discrete = 1 << 3,
    /// <summary>
    /// Air/Air.
    /// </summary>
    [Map('R')] AirToAir = 1 << 4,
    /// <summary>
    /// Mandatory Frequency.
    /// </summary>
    [Map('M')] Mandatory = 1 << 5,
    /// <summary>
    /// Secondary Frequency.
    /// </summary>
    [Map('S')] Secondary = 1 << 6,
    /// <summary>
    /// VHF Direction Finding Service (VDF).
    /// </summary>
    [Offset, Map('D')] DirectionFinding = 1 << 7,
    /// <summary>
    /// Remote Communications Air to Ground (RCAG).
    /// </summary>
    [Map('G')] RemoteAirToGround = 1 << 8,
    /// <summary>
    /// Language other than English.
    /// </summary>
    [Map('L')] NonEnglish = 1 << 9,
    /// <summary>
    /// Military Use Frequency.
    /// </summary>
    [Map('M')] Military = 1 << 10,
    /// <summary>
    /// Remote Communications Outlet (RCO).
    /// </summary>
    [Map('R')] RemoteOutlet = 1 << 11
}

/*internal abstract class AirwayCommUsagesConverter : IStringConverter<AirwayCommUsages>
{
    public static Result<AirwayCommUsages> Convert(ReadOnlySpan<char> @string)
    {
        bool valid = true;

        var value = AirwayCommUsages.Unknown;

        char @char0 = @string[0], @char1 = @string[1], @char2 = @string[2];

        Span<char> bad;

        unsafe { bad = stackalloc char[3]; }

        int count = 0;

        switch (@char0)
        {
            case 'A':
                value |= AirwayCommUsages.AeronauticalInfo; break;
            case 'F':
                value |= AirwayCommUsages.FlightInfo; break;
            case (char)32:
                value |= AirwayCommUsages.Unknown; break;
            default:
                valid = false;
                bad[count] = @char0;
                count++; break;
        }
        switch (@char1)
        {
            case 'A':
                value |= AirwayCommUsages.AirGround; break;
            case 'D':
                value |= AirwayCommUsages.Discrete; break;
            case 'R':
                value |= AirwayCommUsages.AirToAir; break;
            case 'M':
                value |= AirwayCommUsages.Mandatory; break;
            case 'S':
                value |= AirwayCommUsages.Secondary; break;
            case (char)32:
                value |= AirwayCommUsages.Unknown; break;
            default:
                valid = false;
                bad[count] = @char1;
                count++; break;
        }
        switch (@char2)
        {
            case 'D':
                value |= AirwayCommUsages.DirectionFinding; break;
            case 'G':
                value |= AirwayCommUsages.RemoteAirToGround; break;
            case 'L':
                value |= AirwayCommUsages.NonEnglish; break;
            case 'M':
                value |= AirwayCommUsages.Military; break;
            case 'R':
                value |= AirwayCommUsages.RemoteOutlet; break;
            case (char)32:
                value |= AirwayCommUsages.Unknown; break;
            default:
                valid = false;
                bad[count] = @char2;
                count++; break;
        }
        return valid ? value : bad[..count];
    }
}*/
