using Arinc424.Navigation.Terms;

namespace Arinc424.Converters;

internal abstract class MeritFigureConverter : ICharConverter<MeritFigureConverter, MeritFigure>
{
    public static MeritFigure Convert(char @char) => @char switch
    {
        '0' => MeritFigure.Terminal,
        '1' => MeritFigure.LowAltitude,
        '2' => MeritFigure.HighAltitude,
        '3' => MeritFigure.ExtendedHighAltitude,
        '7' => MeritFigure.NotIncluded,
        '9' => MeritFigure.ServiceOut,
        _ => MeritFigure.Unknown
    };
}
