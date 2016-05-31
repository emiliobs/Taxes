namespace Taxes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddotesToPropertyType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PropertyTypes",
                c => new
                    {
                        PropertyTypeId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.PropertyTypeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PropertyTypes");
        }
    }
}
