using System.Globalization;
using System.Net;
using System.Reflection;
using System.Runtime.ExceptionServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using Nop.Core;
using Nop.Core.Configuration;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Localization;
using Nop.Core.Http;
using Nop.Core.Infrastructure;
using Nop.Data;
using Nop.Data.Migrations;
using Nop.Services.Authentication;
using Nop.Services.Common;
using Nop.Services.Installation;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Media.RoxyFileman;
using Nop.Services.Plugins;
using Nop.Services.ScheduleTasks;
using Nop.Services.Security;
using Nop.Services.Seo;
using Nop.Web.Framework.Globalization;
using Nop.Web.Framework.Mvc.Routing;
using QuestPDF.Drawing;
using WebMarkupMin.AspNetCore7;
using WebOptimizer;

namespace Nxg.Web.Framework.Infrastructure.Extensions
{
    /// <summary>
    /// Represents extensions of IApplicationBuilder
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        public static void StartNxgEngine(this IApplicationBuilder application)
        {
            var engine = EngineContext.Current;

            //further actions are performed only when the database is installed
            if (DataSettingsManager.IsDatabaseInstalled())
            {
                //update nopCommerce core and db
                var migrationManager = engine.Resolve<IMigrationManager>();
                var assembly = Assembly.GetAssembly(typeof(ApplicationBuilderExtensions));
                migrationManager.ApplyUpMigrations(assembly, MigrationProcessType.Update);
            }
        }
    }
}
