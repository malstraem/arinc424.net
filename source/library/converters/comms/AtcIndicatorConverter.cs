namespace Arinc424.Converters;

using static Bool;

/// <inheritdoc cref="Procedures.ProcedurePoint.IsAltitudeModifiable"/>
internal abstract class AtcIndicatorConverter : ICharConverter<Bool>
{
    public static bool TryConvert(char @char, out Bool value)
    {
        switch (@char)
        {
            case (char)32:
                value = Unknown; return true;
            case 'A':
                value = Yes; return true;
            case 'S':
                value = No; return true;
            default:
                value = Unknown; return false;
        }
    }
}
