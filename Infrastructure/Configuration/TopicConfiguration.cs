using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class TopicConfiguration : IEntityTypeConfiguration<Topic>
{
    public void Configure(EntityTypeBuilder<Topic> builder)
    {
        builder.ToTable("Topics");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.TopicName)
            .IsRequired()
            .HasMaxLength(300);
        
        builder.Property(t => t.SubTopicName)
            .HasMaxLength(300);
        
        builder.HasMany(t => t.Questions)
            .WithOne(q => q.Topic)
            .HasForeignKey(q => q.TopicId)
            .OnDelete(DeleteBehavior.Restrict);
        
    }
}