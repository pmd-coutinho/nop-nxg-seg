using FluentMigrator;
using Nop.Core.Domain.Customers;
using Nop.Data.Migrations;
using Nxg.Core.Domain.Customers;

namespace Nxg.Web.Framework.Migrations
{
    [NopMigration("2022/07/29 08:00:00", "Add Auto Created Column to Customer", UpdateMigrationType.Data)]
    public class AddAutoCreatedColumnToCustomerMigration : AutoReversingMigration
    {
        public override void Up()
        {
            if (!Schema.Table(nameof(Customer)).Column(nameof(CustomerNxg.AutoCreated)).Exists())
            {
                Create.Column(nameof(CustomerNxg.AutoCreated))
                    .OnTable(nameof(Customer))
                    .AsBoolean()
                    .WithDefaultValue(false);
            }
        }
    }
}