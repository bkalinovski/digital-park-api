using DigitalPark.Application.Common.Enums;

namespace DigitalPark.Application.Common.Extensions;

internal static class ConverterExtensions
{
    public static string ToStringCode(this ActiveLanguage language)
    {
        return language switch
        {
            ActiveLanguage.Ro => "ro",
            _ => "en"
        };
    }
}