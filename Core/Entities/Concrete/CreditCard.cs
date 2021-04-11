using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class CreditCard : IEntity
    {
        public int CreditCardId { get; set; }
        public int CustomerId { get; set; }
        public string CardOwner { get; set; }
        public string Cvc { get; set; }
        public string ExpirationDate { get; set; }
        public string CardNumber { get; set; }
    }
}
