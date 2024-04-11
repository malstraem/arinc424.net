namespace Arinc424.Converters;

internal abstract class TimeCodeConverter : ICharConverter<TimeCodeConverter, TimeCode>
{
    public static TimeCode Convert(char @char) => @char switch
    {
        'C' => TimeCode.WithHolidays,
        'H' => TimeCode.WithoutHolidays,
        'N' => TimeCode.NonContinuously,
        'P' => TimeCode.ByNotam,
        'U' => TimeCode.NotSpecified,
        'S' => TimeCode.InOperationTimeWithoutHolidays,
        'T' => TimeCode.InOperationTimeWithHolidays,
        _ => TimeCode.Unknown
    };
}
