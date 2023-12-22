using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examnew
{
    public class ClassOrderProduct
    {
        public ClassOrderProduct(int order, int product, int quatity)
        {
            Order = order;
            Product = product;
            Quatity = quatity;
        }

        public int Order { get; set;}
        public int Product { get; set;}
        public int Quatity { get; set;}
    }
}
