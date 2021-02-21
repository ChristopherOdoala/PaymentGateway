using PaymentGateway.Core.Models;
using PaymentGateway.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Core.Services.Interfaces
{
    public interface IPaymentService
    {
        ResultModel<string> ProcessPayment(ProcessPaymentViewModel model);
    }
}
