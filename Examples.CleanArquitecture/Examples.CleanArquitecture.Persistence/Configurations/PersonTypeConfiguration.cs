using Examples.CleanArquitecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Examples.CleanArquitecture.Persistence.Configurations;

public sealed class PersonTypeConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasData(
            new Person
            {
                Id = 1,
                Age = 47,
                Name = "Gonzalo",
                DNI = "13441632",
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            });

        builder.Property(q => q.Name)
            .IsRequired()
            .HasMaxLength(100);

        // TODO: add more restrictions on person's properties.
    }
}
