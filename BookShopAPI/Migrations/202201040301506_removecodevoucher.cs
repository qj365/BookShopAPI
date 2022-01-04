namespace BookShopAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removecodevoucher : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Voucher", "Code");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Voucher", "Code", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
