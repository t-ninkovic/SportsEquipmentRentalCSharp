namespace SportsEquipmentRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdIssueInRental : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EquipmentRentals", "Equipment_Id", "dbo.Equipments");
            DropIndex("dbo.EquipmentRentals", new[] { "Equipment_Id" });
            RenameColumn(table: "dbo.EquipmentRentals", name: "Equipment_Id", newName: "EquipmentId");
            AlterColumn("dbo.EquipmentRentals", "EquipmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.EquipmentRentals", "EquipmentId");
            AddForeignKey("dbo.EquipmentRentals", "EquipmentId", "dbo.Equipments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EquipmentRentals", "EquipmentId", "dbo.Equipments");
            DropIndex("dbo.EquipmentRentals", new[] { "EquipmentId" });
            AlterColumn("dbo.EquipmentRentals", "EquipmentId", c => c.Int());
            RenameColumn(table: "dbo.EquipmentRentals", name: "EquipmentId", newName: "Equipment_Id");
            CreateIndex("dbo.EquipmentRentals", "Equipment_Id");
            AddForeignKey("dbo.EquipmentRentals", "Equipment_Id", "dbo.Equipments", "Id");
        }
    }
}
