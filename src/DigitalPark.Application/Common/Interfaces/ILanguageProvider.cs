using DigitalPark.Application.Common.Enums;

namespace DigitalPark.Application.Common.Interfaces;

public interface ILanguageProvider
{
    ActiveLanguage Language { get; }

    void SetLanguage(ActiveLanguage language);
}