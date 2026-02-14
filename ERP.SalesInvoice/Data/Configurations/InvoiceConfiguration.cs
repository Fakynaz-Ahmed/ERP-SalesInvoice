using ERP.SalesInvoice.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.SalesInvoice.Data.Configurations
{
    public class InvoiceConfiguration  : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.InvoiceNumber).IsRequired().HasMaxLength(50);
            builder.Property(i => i.InvoiceDate).IsRequired();
            builder.Property(i => i.TotalAmount).IsRequired().HasPrecision(18, 2);
        }
    }
}
