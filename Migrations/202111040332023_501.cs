namespace Code_First_Jashim.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _501 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Liberians", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Liberians", "Email", c => c.String());
        }
    }
}
