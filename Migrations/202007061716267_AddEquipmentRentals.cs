namespace SportsEquipmentRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEquipmentRentals : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EquipmentRentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        EquipmentId = c.Int(nullable: false),
                        RentDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Equipments", t => t.EquipmentId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.EquipmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EquipmentRentals", "EquipmentId", "dbo.Equipments");
            DropForeignKey("dbo.EquipmentRentals", "CustomerId", "dbo.Customers");
            DropIndex("dbo.EquipmentRentals", new[] { "EquipmentId" });
            DropIndex("dbo.EquipmentRentals", new[] { "CustomerId" });
            DropTable("dbo.EquipmentRentals");
        }
    }
}
