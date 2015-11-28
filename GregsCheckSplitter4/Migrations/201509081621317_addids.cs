namespace GregsCheckSplitter4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addids : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Diners", "CheckID", c => c.Int(nullable: false));
            AddColumn("dbo.Parties", "CheckID", c => c.Int(nullable: false));
            DropColumn("dbo.Checks", "CheckTaxTotal");
            DropColumn("dbo.Checks", "CheckTipTotal");
            DropColumn("dbo.Checks", "CheckGrandTotal");
            DropColumn("dbo.Diners", "PartyName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Diners", "PartyName", c => c.String());
            AddColumn("dbo.Checks", "CheckGrandTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Checks", "CheckTipTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Checks", "CheckTaxTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Parties", "CheckID");
            DropColumn("dbo.Diners", "CheckID");
        }
    }
}
