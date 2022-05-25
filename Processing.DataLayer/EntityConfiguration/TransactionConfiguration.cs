using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Processing.Core.Entities;

namespace Processing.DataLayer.EntityConfiguration;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
	public void Configure(EntityTypeBuilder<Transaction> builder)
	{
		builder.HasKey(t => t.Id);
		builder.Property(p => p.Id).IsRequired().HasComment("Id").ValueGeneratedOnAdd();
		
		builder.Property(p => p.Amount).IsRequired().HasComment("Transaction amount");
		builder.Property(p => p.CurrencyCode).IsRequired().HasComment("Currency code");
		builder.Property(p => p.TransactionDate).IsRequired().HasComment("Transaction date");
		builder.Property(p => p.Status).IsRequired().HasComment("Transaction status")
			.HasConversion<string>();
		
		builder.HasComment("Transaction");
	}
}