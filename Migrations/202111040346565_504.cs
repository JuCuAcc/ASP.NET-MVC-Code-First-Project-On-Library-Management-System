namespace Code_First_Jashim.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _504 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InfoViewModels", "ConfirmedEmail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.InfoViewModels", "ConfirmedEmail");
        }
    }
}
