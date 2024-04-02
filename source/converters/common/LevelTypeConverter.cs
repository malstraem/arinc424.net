namespace Arinc424.Converters;

/// <summary>
/// Converter for <see cref="LevelType"/>.
/// </summary>
internal abstract class LevelTypeConverter : ICharConverter<LevelTypeConverter, LevelType>
{
    public static LevelType Convert(char @char) => @char switch
    {
        'B' => LevelType.All,
        'H' => LevelType.High,
        'L' => LevelType.Low,
        _ => LevelType.Unknown
    };
}
