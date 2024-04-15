using System.Diagnostics;

using Arinc424.Attributes;
using Arinc424.Converters;
using Arinc424.Ports;

namespace Arinc424.Navigation;

#pragma warning disable CS8618

[Continuous]
[DebuggerDisplay($"{{{nameof(Identifier)}}}, Airport - {{{nameof(Airport)}}}")]
public abstract class LandingSystem : Geo, IIcao, IIdentity
{
    [Foreign(7, 12)]
    public Airport Airport { get; set; }

    public string IcaoCode => Airport.IcaoCode;

    /// <summary>
    /// <c>Localizer/MLS/GLS Identifier (LOC, MLS, GLS IDENT)</c> field.
    /// </summary>
    /// <remarks>See section 5.44.</remarks>
    [Field(14, 17)]
    public string Identifier { get; set; }

    /// <inheritdoc cref="Terms.LandingSystemType"/>
    [Character(18), Transform<LandingSystemTypeConverter>]
    public Terms.LandingSystemType Type { get; set; }

    [Foreign(7, 12), Foreign(28, 32), Foreign(11, 12)]
    public Runway Runway { get; set; }

    /// <summary>
    /// <c>Localizer Bearing (LOC BRG)</c> and <c>MLS Azimuth Bearing (MLS AZ BRG)</c> field.
    /// </summary>
    /// <value>Degrees and tenths of a degree.</value>
    /// <remarks>See section 5.47 and 5.167.</remarks>
    [Field(52, 55), Decode<CourseConverter>]
    public Course Bearing { get; set; }

    /// <summary>
    /// <c>Component Elevation</c> field.
    /// </summary>
    /// <remarks>See section 5.74.</remarks>
    [Field(98, 102), Decode<IntConverter>]
    [Field<MicrowaveLandingSystem>(104, 108)]
    public int Elevation { get; set; }
}
