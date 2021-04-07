using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class PaymentInfo : IEntity
    {
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string Cvc { get; set; }
        public string CardOwner { get; set; }
    }
}
