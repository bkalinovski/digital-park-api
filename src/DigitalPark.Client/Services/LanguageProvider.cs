using DigitalPark.Application.Common.Enums;
using DigitalPark.Application.Common.Interfaces;

namespace DigitalPark.Client.Services;

public class LanguageProvider : ILanguageProvider
{
    public ActiveLanguage Language => _language;

    private ActiveLanguage _language { get; set; } = ActiveLanguage.En;

    public void SetLanguage(ActiveLanguage language)
    {
        _language = language;
    }
}