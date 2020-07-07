namespace SportsEquipmentRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedManufacturer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Equipments", "Manufacturer_Id", c => c.Int());
            CreateIndex("dbo.Equipments", "Manufacturer_Id");
            AddForeignKey("dbo.Equipments", "Manufacturer_Id", "dbo.Manufacturers", "Id");
            DropColumn("dbo.Equipments", "Manufacturer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Equipments", "Manufacturer", c => c.String());
            DropForeignKey("dbo.Equipments", "Manufacturer_Id", "dbo.Manufacturers");
            DropIndex("dbo.Equipments", new[] { "Manufacturer_Id" });
            DropColumn("dbo.Equipments", "Manufacturer_Id");
            DropTable("dbo.Manufacturers");
        }
    }
}
