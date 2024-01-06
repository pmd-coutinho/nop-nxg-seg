using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core.Infrastructure;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Services.Stores;
using Nop.Web.Areas.Admin.Controllers;
using Nop.Web.Areas.Admin.Factories;
using Nxg.Web.Framework.Migrations.CustomLocalizations;

namespace Nxg.Web.Areas.Admin.Controllers;

public class LanguageNxgController : LanguageController
{
    private readonly IPermissionService _permissionService;
    private readonly INotificationService _notificationService;
    public LanguageNxgController(ICustomerActivityService customerActivityService, ILanguageModelFactory languageModelFactory, ILanguageService languageService, ILocalizationService localizationService, INopFileProvider fileProvider, INotificationService notificationService, IPermissionService permissionService, IStoreMappingService storeMappingService, IStoreService storeService) : base(customerActivityService, languageModelFactory, languageService, localizationService, fileProvider, notificationService, permissionService, storeMappingService, storeService)
    {
        _notificationService = notificationService;
        _permissionService = permissionService;
    }

    public virtual async Task<IActionResult> RunMigrations()
    {
        if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageLanguages))
            return AccessDeniedView();
        try
        {
            var customLocalizationManager = EngineContext.Current.Resolve<ICustomLocalizationManager>();
            customLocalizationManager.AddCustomLocalizations().GetAwaiter().GetResult();
            _notificationService.SuccessNotification("Migrations run successfully");
        }
        catch (Exception e)
        {
            _notificationService.ErrorNotification("Migrations could not run: " + e.Message);
        }
        return RedirectToAction("List", "Language");
    }
}