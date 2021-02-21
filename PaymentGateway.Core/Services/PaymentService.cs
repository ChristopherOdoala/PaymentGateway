using PaymentGateway.Core.Helpers;
using PaymentGateway.Core.Models;
using PaymentGateway.Core.Repository.Interfaces;
using PaymentGateway.Core.Services.Interfaces;
using PaymentGateway.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Core.Services
{
    public class PaymentService : ICheapPaymentGateway, IExpensivePaymentGateway, IPremiumPaymentService, IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<PaymentState> _paymentStateRepo;
        private readonly IRepository<ProcessPayment> _processPaymentRepo;
        public List<ValidationResult> results;

        public PaymentService(IUnitOfWork unitOfWork, IRepository<PaymentState> paymentStateRepo, IRepository<ProcessPayment> processPaymentRepo)
        {
            _unitOfWork = unitOfWork;
            _paymentStateRepo = paymentStateRepo;
            _processPaymentRepo = processPaymentRepo;
        }

        public ResultModel<string> PaymentFor21To500Pounds(ProcessPaymentViewModel model)
        {
            var resultModel = new ResultModel<string>();

            //For test purpose Service Availability is set to false mocking real payment service availability
            resultModel.ServiceAvailable = false;
            resultModel.AddError("Service unavailable");
            model.PaymentStateViewModel.PaymentStateEnum = Models.Enum.PaymentStateEnum.Failed;
            _unitOfWork.SaveChanges();

            return resultModel;
        }

        public ResultModel<string> PaymentForLessThan20Pounds(ProcessPaymentViewModel model)
        {
            var resultModel = new ResultModel<string>();

            resultModel.ServiceAvailable = true;

            model.PaymentStateViewModel.PaymentStateEnum = Models.Enum.PaymentStateEnum.Processed;
            _unitOfWork.SaveChanges();
            return resultModel;
        }

        public ResultModel<string> PaymentGreaterThan500Pounds(ProcessPaymentViewModel model)
        {
            var resultModel = new ResultModel<string>();

            resultModel.ServiceAvailable = true;

            model.PaymentStateViewModel.PaymentStateEnum = Models.Enum.PaymentStateEnum.Processed;
            _unitOfWork.SaveChanges();
            return resultModel;
        }

        public ResultModel<string> ProcessPayment(ProcessPaymentViewModel model)
        {
            var resultModel = new ResultModel<string>();
            var paymentStatusModel = new PaymentStateViewModel
            {
                PaymentStateEnum = Models.Enum.PaymentStateEnum.Pending,
            };

            model.PaymentStateViewModel = paymentStatusModel;


            try
            {
                resultModel = SelectPaymentProcessor(model);
                var response = (ProcessPayment)model;
                response.PaymentState = (PaymentState)model.PaymentStateViewModel;
                response.PaymentState.Status = response.PaymentState.PaymentStateEnum.GetDescription();

                if (!resultModel.ErrorMessages.Any())
                {
                    _paymentStateRepo.Insert(response.PaymentState);
                    _processPaymentRepo.Insert(response);
                }
                _unitOfWork.SaveChanges();
            }
            catch(Exception ex)
            {
                resultModel.AddError(ex.Message);
                return resultModel;
            }

            return resultModel;
        }

        private ResultModel<string> SelectPaymentProcessor(ProcessPaymentViewModel model)
        {
            var resultModel = new ResultModel<string>();
            if(model.Amount < 20)
            {
                resultModel = PaymentForLessThan20Pounds(model);
                if (resultModel.ErrorMessages.Any())
                    return resultModel;
                return resultModel;
            }
            if (model.Amount >= 21 && model.Amount <= 500)
            {
                resultModel = PaymentFor21To500Pounds(model);
                if (!resultModel.ServiceAvailable)
                {
                    for (int i = 0; i < 1; i++)
                    {
                        resultModel = PaymentForLessThan20Pounds(model);
                        if (!resultModel.ErrorMessages.Any())
                            return resultModel;
                    }
                }
                return resultModel;
            }
            if (model.Amount > 500)
            {
                resultModel = PaymentGreaterThan500Pounds(model);
                if (resultModel.ErrorMessages.Any())
                {
                    for (int i = 0; i < 3; i++)
                    {
                        resultModel = PaymentGreaterThan500Pounds(model);
                        if (!resultModel.ErrorMessages.Any())
                            return resultModel;
                    }
                }
                return resultModel;
            }

            resultModel.AddError("Could not identify payment category");

            return resultModel;
        }

    }
}
