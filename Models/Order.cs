using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Order
    {
        public int ID { get; set; }
        public double Price { get; set; }
        public int Customer_ID { get; set; }
        public DateTime DateTime { get; set; }
        Customer? customer { get; set; }
        public override string ToString() => $" {ID} => Price: {Price} => Date: {DateTime} => {Customer_ID} .";
    }
}
