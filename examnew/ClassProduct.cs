using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examnew
{
    public class ClassProduct
    {
        public ClassProduct(int id, string category, string name, string composition, string photo, string price)
        {
            Id = id;
            Category = category;
            Name = name;
            Composition = composition;
            Photo = photo;
            Price = price;
        }

        public int Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Composition { get; set; }
        public string Photo { get; set; }
        public string Price { get; set; }
    }
}
