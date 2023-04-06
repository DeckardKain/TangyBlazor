using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangy_Models
{
    public class StripePaymentDTO
    {

        public StripePaymentDTO()
        {
            SuccessURL = "OrderConfirmation";
        }

        public OrderDTO Order { get; set; }
        public  string SuccessURL { get; set; }        
    }
}
