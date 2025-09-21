namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        OptionId = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 8000, unicode: false),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OptionId)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Marks = c.Int(nullable: false),
                        QuizId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.Quizs", t => t.QuizId, cascadeDelete: true)
                .Index(t => t.QuizId);
            
            CreateTable(
                "dbo.Quizs",
                c => new
                    {
                        QuizId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 8000, unicode: false),
                        SubjectId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        DurationMin = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.QuizId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.SubjectId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.StudentQuizAttempts",
                c => new
                    {
                        AttemptId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        QuizId = c.Int(nullable: false),
                        StartedAt = c.DateTime(nullable: false),
                        CompletedAt = c.DateTime(),
                        Score = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AttemptId)
                .ForeignKey("dbo.Quizs", t => t.QuizId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.QuizId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Email = c.String(nullable: false, maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Description = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.SubjectId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Email = c.String(nullable: false, maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.TeacherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Options", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Questions", "QuizId", "dbo.Quizs");
            DropForeignKey("dbo.Quizs", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Quizs", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.StudentQuizAttempts", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentQuizAttempts", "QuizId", "dbo.Quizs");
            DropIndex("dbo.StudentQuizAttempts", new[] { "QuizId" });
            DropIndex("dbo.StudentQuizAttempts", new[] { "StudentId" });
            DropIndex("dbo.Quizs", new[] { "TeacherId" });
            DropIndex("dbo.Quizs", new[] { "SubjectId" });
            DropIndex("dbo.Questions", new[] { "QuizId" });
            DropIndex("dbo.Options", new[] { "QuestionId" });
            DropTable("dbo.Teachers");
            DropTable("dbo.Subjects");
            DropTable("dbo.Students");
            DropTable("dbo.StudentQuizAttempts");
            DropTable("dbo.Quizs");
            DropTable("dbo.Questions");
            DropTable("dbo.Options");
        }
    }
}
