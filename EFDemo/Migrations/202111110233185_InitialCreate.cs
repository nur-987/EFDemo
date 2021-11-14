namespace EFDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        SchoolId = c.Int(nullable: false, identity: true),
                        SchoolName = c.String(),
                    })
                .PrimaryKey(t => t.SchoolId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        GradYear = c.Int(),
                        Grade = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        School_SchoolId = c.Int(),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Schools", t => t.School_SchoolId)
                .Index(t => t.School_SchoolId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "School_SchoolId", "dbo.Schools");
            DropIndex("dbo.Students", new[] { "School_SchoolId" });
            DropTable("dbo.Students");
            DropTable("dbo.Schools");
        }
    }
}
