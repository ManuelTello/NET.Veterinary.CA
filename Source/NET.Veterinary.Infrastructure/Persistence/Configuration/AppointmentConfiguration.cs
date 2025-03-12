using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NET.Veterinary.Domain.AggregateRoots.Appointment;

namespace NET.Veterinary.Infrastructure.Persistence.Configuration
{
    public class AppointmentConfiguration:IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointments");
            
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Id)
                .HasColumnName("id")
                .IsRequired(true)
                .HasColumnType("INTEGER")
                .UseIdentityAlwaysColumn()
                .HasColumnOrder(0);

            builder.OwnsOne(x => x.DateSelect, dateSelected =>
            {
                dateSelected.Property(p => p.Value)
                    .HasConversion(m => DateTime.Parse(m), m => m.ToString(CultureInfo.InvariantCulture))
                    .HasColumnName("date_selected")
                    .IsRequired(true)
                    .HasColumnType("TIMESTAMP WITHOUT TIME ZONE")
                    .HasColumnOrder(1);
            });

            builder.OwnsOne(x => x.Identification, identification =>
            {
                identification.Property(p => p.Value)
                    .HasColumnName("identification")
                    .IsRequired(true)
                    .HasColumnType("INTEGER")
                    .HasColumnOrder(2);
            });

            builder.OwnsOne(x => x.CompleteName, completeName =>
            {
                completeName.Property(p => p.Value)
                    .HasColumnName("patient_name")
                    .IsRequired(true)
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(255)
                    .HasColumnOrder(3);
            });
            
            builder.Property(x => x.DidAssist)
                .HasColumnName("did_assist")
                .IsRequired(true)
                .HasColumnType("BOOLEAN")
                .HasDefaultValue(false)
                .HasColumnOrder(4);
        }
    }
}

