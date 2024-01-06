using FluentMigrator;
using Nop.Core.Domain.Customers;
using Nop.Data.Migrations;
using Nxg.Core.Domain.Customers;

namespace Nxg.Web.Framework.Migrations
{
    [NopMigration("2022/05/25 09:00:00", "Add BlockAutomaticallySavedCards to Customer", MigrationProcessType.Update)]
    public class AddBlockAutomaticallySavedCardsOnCustomerNxgMigration : AutoReversingMigration
    {
        public override void Up()
        {
            if (!Schema.Table(nameof(Customer)).Column(nameof(CustomerNxg.BlockAutomaticallySavedCards)).Exists())
            {
                Create.Column(nameof(CustomerNxg.BlockAutomaticallySavedCards))
                .OnTable(nameof(Customer))
                .AsBoolean()
                .NotNullable()
                .WithDefaultValue(false);
            }
        }
    }
}