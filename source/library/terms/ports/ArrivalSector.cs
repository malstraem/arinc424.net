namespace Arinc424.Ports.Terms;

public sealed class ArrivalSector : Sector
{
    /// <summary>
    /// <c>Procedure Turn Indicator</c> character.
    /// </summary>
    /// <remarks>See section 5.271.</remarks>
    public Bool TurnRequired { get; set; }
}
