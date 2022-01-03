namespace BookShopAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedatetime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Voucher", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Voucher", "EndDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Voucher", "EndDate", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Voucher", "StartDate", c => c.DateTime(nullable: false, storeType: "date"));
        }
    }
}
