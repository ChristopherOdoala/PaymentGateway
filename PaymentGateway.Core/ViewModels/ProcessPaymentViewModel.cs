using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace PaymentGateway.Core.ViewModels
{
    public class ProcessPaymentViewModel : IValidatableObject
    {
        [Required(ErrorMessage = "Credit Card Number is required")]
        public string CreditCardNumber { get; set; }
        [Required(ErrorMessage = "Card Holder is required")]
        public string CardHolder { get; set; }
        [Required(ErrorMessage = "Expiration Date is required")]
        public DateTime ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        [Required(ErrorMessage = "Amount is required")]
        public decimal Amount { get; set; }

        public PaymentStateViewModel PaymentStateViewModel { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var creditCardCheck = new Regex(@"^(?:4[0-9]{12}(?:[0-9]{3})?|[25][1-7][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})$");
            if (!creditCardCheck.IsMatch(CreditCardNumber)) // <1>check card number is valid
                yield return new ValidationResult("Invalid credit number");
            if (ExpirationDate < DateTime.Now)
                yield return new ValidationResult("Expiration date cannot be in the past");
            if (Amount <= 0)
                yield return new ValidationResult("Amount cannot be Zero or negative");
        }
    }
}
