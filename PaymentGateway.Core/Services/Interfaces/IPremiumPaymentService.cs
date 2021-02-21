using PaymentGateway.Core.Models;
using PaymentGateway.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Core.Services.Interfaces
{
    public interface IPremiumPaymentService
    {
        ResultModel<string> PaymentGreaterThan500Pounds(ProcessPaymentViewModel model); 
    }
}
