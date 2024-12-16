namespace Arinc424.Navigation.Terms;

/// <summary>
/// <c>Station Declination (STN DEC)</c> field.
/// </summary>
/// <value>Deegres and tenths of degree.</value>
/// <remarks>See section 5.66.</remarks>
[Decode<DeclinationConverter, Declination>]
public readonly struct Declination(float value, DeclinationType type)
{
    public float Value { get; } = value;

    public DeclinationType Type { get; } = type;
}
