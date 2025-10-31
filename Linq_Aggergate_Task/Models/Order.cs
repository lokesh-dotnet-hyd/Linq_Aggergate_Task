using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Aggergate_Task.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int PersonId { get; set; }
        public decimal Amount { get; set; }
        public DateTime OrderDate { get; set; }
    }

}
