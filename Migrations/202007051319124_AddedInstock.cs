namespace SportsEquipmentRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedInstock : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Equipments", "InStock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Equipments", "InStock");
        }
    }
}
