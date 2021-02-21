using PaymentGateway.Core.Helpers;
using PaymentGateway.Core.Models;
using PaymentGateway.Core.Models.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Core.ViewModels
{
    public class PaymentStateViewModel
    {
        public string Status { get; set; }
        public PaymentStateEnum PaymentStateEnum { get; set; }

    }
}
