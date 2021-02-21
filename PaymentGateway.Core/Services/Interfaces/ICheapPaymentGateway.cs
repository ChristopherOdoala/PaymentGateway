using PaymentGateway.Core.Models;
using PaymentGateway.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Core.Services.Interfaces
{
    public interface ICheapPaymentGateway
    {
        ResultModel<string> PaymentForLessThan20Pounds(ProcessPaymentViewModel model);
    }
}
