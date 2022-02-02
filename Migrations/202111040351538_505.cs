namespace Code_First_Jashim.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _505 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.InfoViewModels", "Email", c => c.String(nullable: false));
            DropColumn("dbo.InfoViewModels", "ConfirmedEmail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InfoViewModels", "ConfirmedEmail", c => c.String());
            AlterColumn("dbo.InfoViewModels", "Email", c => c.String());
        }
    }
}
