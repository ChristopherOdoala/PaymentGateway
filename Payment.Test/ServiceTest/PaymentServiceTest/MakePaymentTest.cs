using Moq;
using PaymentGateway.Core.Models;
using PaymentGateway.Core.Repository.Interfaces;
using PaymentGateway.Core.Services;
using PaymentGateway.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Payment.Test.ServiceTest.PaymentServiceTest
{
    public class MakePaymentTest : BaseClassTest, IClassFixture<ServiceSetup>
    {
        private IPaymentService _paymentService;
        private readonly ServiceSetup _setup;
        public Mock<IRepository<PaymentState>> _paymentStateRepo = new Mock<IRepository<PaymentState>>();
        public Mock<IRepository<ProcessPayment>> _processPaymentRepo = new Mock<IRepository<ProcessPayment>>();
        public MakePaymentTest(ITestOutputHelper output, ServiceSetup serviceSetup) :base(output)
        {
            _setup = serviceSetup;
            _paymentService = new PaymentService(_setup.UnitOfWork, _paymentStateRepo.Object, _processPaymentRepo.Object);
        }

        [Fact]
        public void MakePayment_Successful_WhenDataisValid()
        {
            //Arrange
            var paymentViewModel = TestData.PassPaymentModel2();

            //Act
            var result = _paymentService.ProcessPayment(paymentViewModel);

            //Assert
            Assert.False(result.ErrorMessages.Any());

        }
    }
}
