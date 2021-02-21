using PaymentGateway.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static PaymentGateway.Core.Models.BaseEntity;

namespace PaymentGateway.Core.Models
{
    public class ProcessPayment : AuditedEntity
    {
        [Required]
        public string CreditCardNumber { get; set; }
        [Required]
        public string CardHolder { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        [Required]
        public decimal Amount { get; set; }

        public Guid PaymentStateId { get; set; }

        [ForeignKey(nameof(PaymentStateId))]
        public PaymentState PaymentState { get; set; }

        public static implicit operator ProcessPayment(ProcessPaymentViewModel model)
        {
            return model == null ? null : new ProcessPayment
            {
                CreditCardNumber = model.CreditCardNumber,
                Amount = model.Amount,
                CardHolder = model.CardHolder,
                ExpirationDate = model.ExpirationDate,
                SecurityCode = model.SecurityCode
            };
        }

    }
}
