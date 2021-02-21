using PaymentGateway.Core.Helpers;
using PaymentGateway.Core.Models.Enum;
using PaymentGateway.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static PaymentGateway.Core.Models.BaseEntity;

namespace PaymentGateway.Core.Models
{
    public class PaymentState : AuditedEntity
    {
        public string Status { get; set; }
        public PaymentStateEnum PaymentStateEnum { get; set; }


        public static implicit operator PaymentState(PaymentStateViewModel model)
        {
            return model == null ? null : new PaymentState
            {
                PaymentStateEnum = model.PaymentStateEnum,
                Status = model.Status
            };
        }
    }
}
