using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        
        public IResult Confirm(CreditCard creditCard)
        {
            IResult result = BusinessRules.Run(CheckCardNumber(creditCard.CardNumber), 
                CheckExpirationDate(creditCard.ExpirationDate), 
                CheckCvc(creditCard.Cvc), 
                CheckCardOwner(creditCard.CardOwner));

            if (result != null)
            {
                return result;
            }

            return new SuccessfulResult(Messages.PaymentSuccess);
        }

        private IResult CheckCardNumber(string cardNumber)
        {
            if (cardNumber.Length == 16 && cardNumber.Any(c => !char.IsLetter(c))) return new SuccessfulResult();
            return new ErrorResult(Messages.CardNumberError);
        }
        private IResult CheckExpirationDate(string checkExpirationDate)
        {
            if (checkExpirationDate.Length == 5 && checkExpirationDate.Any(c => !char.IsLetter(c)) && checkExpirationDate.Contains("/")) return new SuccessfulResult();
            return new ErrorResult(Messages.ExpirationDateError);
        }
        private IResult CheckCvc(string checkCvc)
        {
            if (checkCvc.Length == 3 && checkCvc.Any(c => !char.IsLetter(c))) return new SuccessfulResult();
            return new ErrorResult(Messages.CvcError);
        }
        private IResult CheckCardOwner(string checkCardOwner)
        {
            if (checkCardOwner.Any(c => char.IsLetter(c))) return new SuccessfulResult();
            return new ErrorResult(Messages.CarOwnerError);
        }
    }
}
