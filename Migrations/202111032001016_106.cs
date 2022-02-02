namespace Code_First_Jashim.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _106 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Liberians", newName: "InfoViewModels");
            RenameColumn(table: "dbo.BookIssues", name: "Liberians_LiberianID", newName: "Liberian_LiberianID");
            RenameIndex(table: "dbo.BookIssues", name: "IX_Liberians_LiberianID", newName: "IX_Liberian_LiberianID");
            CreateTable(
                "dbo.Liberians",
                c => new
                    {
                        LiberianID = c.Int(nullable: false, identity: true),
                        LiberianName = c.String(),
                        Age = c.Int(nullable: false),
                        Email = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.LiberianID);
            
            CreateStoredProcedure(
                "dbo.Liberian_Insert",
                p => new
                    {
                        LiberianName = p.String(),
                        Age = p.Int(),
                        Email = p.String(),
                        Address = p.String(),
                    },
                body:
                    @"INSERT [dbo].[Liberians]([LiberianName], [Age], [Email], [Address])
                      VALUES (@LiberianName, @Age, @Email, @Address)
                      
                      DECLARE @LiberianID int
                      SELECT @LiberianID = [LiberianID]
                      FROM [dbo].[Liberians]
                      WHERE @@ROWCOUNT > 0 AND [LiberianID] = scope_identity()
                      
                      SELECT t0.[LiberianID]
                      FROM [dbo].[Liberians] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[LiberianID] = @LiberianID"
            );
            
            CreateStoredProcedure(
                "dbo.Liberian_Update",
                p => new
                    {
                        LiberianID = p.Int(),
                        LiberianName = p.String(),
                        Age = p.Int(),
                        Email = p.String(),
                        Address = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[Liberians]
                      SET [LiberianName] = @LiberianName, [Age] = @Age, [Email] = @Email, [Address] = @Address
                      WHERE ([LiberianID] = @LiberianID)"
            );
            
            CreateStoredProcedure(
                "dbo.Liberian_Delete",
                p => new
                    {
                        LiberianID = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Liberians]
                      WHERE ([LiberianID] = @LiberianID)"
            );
            
            DropStoredProcedure("dbo.Liberians_Insert");
            DropStoredProcedure("dbo.Liberians_Update");
            DropStoredProcedure("dbo.Liberians_Delete");
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Liberian_Delete");
            DropStoredProcedure("dbo.Liberian_Update");
            DropStoredProcedure("dbo.Liberian_Insert");
            DropTable("dbo.Liberians");
            RenameIndex(table: "dbo.BookIssues", name: "IX_Liberian_LiberianID", newName: "IX_Liberians_LiberianID");
            RenameColumn(table: "dbo.BookIssues", name: "Liberian_LiberianID", newName: "Liberians_LiberianID");
            RenameTable(name: "dbo.InfoViewModels", newName: "Liberians");
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
