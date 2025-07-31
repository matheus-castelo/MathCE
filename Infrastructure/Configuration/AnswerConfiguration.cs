using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
{
    public void Configure(EntityTypeBuilder<Answer> builder)
    {
        builder.ToTable("Answers");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Text)
            .IsRequired()
            .HasMaxLength(500);
        
        builder.HasOne(a => a.Question)
            .WithMany(q => q.Answers)
            .HasForeignKey(a => a.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasIndex(a => new { a.QuestionId, a.Text })
            .IsUnique()
            .HasDatabaseName("IX_Answers_QuestionId_Text");     
    }
}