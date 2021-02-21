using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Core.Models.Map
{
    public class ProcessPaymentMap : IEntityTypeConfiguration<ProcessPayment>
    {
        public void Configure(EntityTypeBuilder<ProcessPayment> builder)
        {
            builder.Property(t => t.ExpirationDate)
                .IsRequired();

            builder.Property(t => t.CreditCardNumber)
                .IsRequired();

            builder.Property(t => t.CardHolder)
                .IsRequired();

            builder.Property(t => t.Amount)
                .IsRequired();
        }
    }
}
