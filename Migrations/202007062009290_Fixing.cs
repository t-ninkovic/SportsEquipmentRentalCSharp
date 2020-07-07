namespace SportsEquipmentRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fixing : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EquipmentRentals", "EquipmentId", "dbo.Equipments");
            DropIndex("dbo.EquipmentRentals", new[] { "EquipmentId" });
            RenameColumn(table: "dbo.EquipmentRentals", name: "EquipmentId", newName: "Equipment_Id");
            AlterColumn("dbo.EquipmentRentals", "Equipment_Id", c => c.Int());
            CreateIndex("dbo.EquipmentRentals", "Equipment_Id");
            AddForeignKey("dbo.EquipmentRentals", "Equipment_Id", "dbo.Equipments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EquipmentRentals", "Equipment_Id", "dbo.Equipments");
            DropIndex("dbo.EquipmentRentals", new[] { "Equipment_Id" });
            AlterColumn("dbo.EquipmentRentals", "Equipment_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.EquipmentRentals", name: "Equipment_Id", newName: "EquipmentId");
            CreateIndex("dbo.EquipmentRentals", "EquipmentId");
            AddForeignKey("dbo.EquipmentRentals", "EquipmentId", "dbo.Equipments", "Id", cascadeDelete: true);
        }
    }
}
