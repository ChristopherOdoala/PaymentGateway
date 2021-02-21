using PaymentGateway.Core.Models;
using PaymentGateway.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Test
{
    public static class TestData
    {
        public static ProcessPaymentViewModel PassPaymentModel2()
        {
            return new ProcessPaymentViewModel
            {
                Amount = 21,
                CardHolder = "James Ackerman",
                CreditCardNumber = "8098678723145676",
                ExpirationDate = DateTime.Parse("2021-03-25T13:33:42.165"),
                SecurityCode = "675"
            };
        }
    }
}
