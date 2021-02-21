using PaymentGateway.Core.Models;
using PaymentGateway.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Core.Services.Interfaces
{
    public interface IExpensivePaymentGateway
    {
        ResultModel<string> PaymentFor21To500Pounds(ProcessPaymentViewModel model);
    }
}
