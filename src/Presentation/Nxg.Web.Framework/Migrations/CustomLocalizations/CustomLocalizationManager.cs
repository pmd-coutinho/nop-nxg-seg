using Nop.Core.Domain.Localization;
using Nop.Services.Localization;
using Nxg.Web.Framework.Migrations.CustomLocalizations.Localizations;

namespace Nxg.Web.Framework.Migrations.CustomLocalizations;

public interface ICustomLocalizationManager
{
    Task AddCustomLocalizations();
}

public class CustomLocalizationManager : ICustomLocalizationManager
{
    private readonly ILanguageService _languageService;
    private readonly ILocalizationService _localizationService;
    private Dictionary<string, ICustomLocalization> _availableLocales;

    public CustomLocalizationManager(ILanguageService languageService, ILocalizationService localizationService,
        IEnumerable<ICustomLocalization> customLocalizations)
    {
        _languageService = languageService;
        _localizationService = localizationService;
        Init(customLocalizations);
    }

    public async Task AddCustomLocalizations()
    {
        //Portion added to allow multilocalization
        var allLanguages = await _languageService.GetAllLanguagesAsync();

        foreach (var language in allLanguages) await AddCustomLocalizationsToLanguage(language);
    }

    private void Init(IEnumerable<ICustomLocalization> customLocalizations)
    {
        _availableLocales = new Dictionary<string, ICustomLocalization>();

        foreach (var customLocalization in customLocalizations)
            _availableLocales[customLocalization.UniqueSeoCode] = customLocalization;
    }

    private async Task AddCustomLocalizationsToLanguage(Language language)
    {
        var uniqueSeoCode = language.UniqueSeoCode.ToLower().Trim();
        if (_availableLocales.TryGetValue(uniqueSeoCode, out var customLocale))
            await customLocale.AddLocalizations(_localizationService, language.Id);
    }
}