namespace GregsCheckSplitter4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Checks",
                c => new
                    {
                        CheckID = c.Int(nullable: false, identity: true),
                        CheckName = c.String(),
                        CheckTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CheckTaxTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TipPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CheckTipTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CheckGrandTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CheckID);
            
            CreateTable(
                "dbo.Diners",
                c => new
                    {
                        DinerID = c.Int(nullable: false, identity: true),
                        PartyName = c.String(),
                        PartyID = c.Int(nullable: false),
                        DinerName = c.String(),
                        DinerEntree = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DinerDrink = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DinerDessert = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DinerAppetizer = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DinerTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.DinerID);
            
            CreateTable(
                "dbo.Parties",
                c => new
                    {
                        PartyID = c.Int(nullable: false, identity: true),
                        PartyName = c.String(),
                        PartyTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PartyTotalTax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PartyTipPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PartyTotalTip = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PartyGrandTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PartyID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Parties");
            DropTable("dbo.Diners");
            DropTable("dbo.Checks");
        }
    }
}
