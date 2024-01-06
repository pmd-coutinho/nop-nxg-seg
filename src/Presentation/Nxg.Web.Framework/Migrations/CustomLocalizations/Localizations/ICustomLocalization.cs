using Nop.Services.Localization;

namespace Nxg.Web.Framework.Migrations.CustomLocalizations.Localizations;

public interface ICustomLocalization
{
    public string UniqueSeoCode { get; }
    public Task AddLocalizations(ILocalizationService localizationService, int languageId);

    public Dictionary<string, string> GetTerms();
}