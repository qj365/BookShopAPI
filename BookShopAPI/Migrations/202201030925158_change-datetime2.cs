namespace BookShopAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedatetime2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Voucher", "StartDate", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Voucher", "EndDate", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Voucher", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Voucher", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}
