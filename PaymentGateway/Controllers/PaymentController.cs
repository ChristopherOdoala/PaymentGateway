using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Core.Models;
using PaymentGateway.Core.Services.Interfaces;
using PaymentGateway.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public IActionResult MakePayment([FromBody]ProcessPaymentViewModel model)
        {
            if (!ModelState.IsValid)
                return StatusCode(400);
            var result = _paymentService.ProcessPayment(model);
            if (result.ErrorMessages.Any())
                return StatusCode(500);
            return Ok();
        }
    }
}
