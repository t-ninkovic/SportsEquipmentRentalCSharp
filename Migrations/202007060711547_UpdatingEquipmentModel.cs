namespace SportsEquipmentRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingEquipmentModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Equipments", "Manufacturer_Id", "dbo.Manufacturers");
            DropIndex("dbo.Equipments", new[] { "Manufacturer_Id" });
            RenameColumn(table: "dbo.Equipments", name: "Manufacturer_Id", newName: "ManufacturerId");
            AlterColumn("dbo.Equipments", "ManufacturerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Equipments", "ManufacturerId");
            AddForeignKey("dbo.Equipments", "ManufacturerId", "dbo.Manufacturers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Equipments", "ManufacturerId", "dbo.Manufacturers");
            DropIndex("dbo.Equipments", new[] { "ManufacturerId" });
            AlterColumn("dbo.Equipments", "ManufacturerId", c => c.Int());
            RenameColumn(table: "dbo.Equipments", name: "ManufacturerId", newName: "Manufacturer_Id");
            CreateIndex("dbo.Equipments", "Manufacturer_Id");
            AddForeignKey("dbo.Equipments", "Manufacturer_Id", "dbo.Manufacturers", "Id");
        }
    }
}
