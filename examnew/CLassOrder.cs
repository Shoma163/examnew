using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examnew
{
    public class CLassOrder
    {
        public CLassOrder(int id, string numberOrder, DateTime dateTime, int client, int povar, int waiter, string status)
        {
            Id = id;
            NumberOrder = numberOrder;
            DateTime = dateTime;
            Client = client;
            Povar = povar;
            Waiter = waiter;
            Status = status;
        }

        public int Id { get; set; }
        public string NumberOrder { get; set; }
        public DateTime DateTime { get; set; }
        public int Client { get; set; }
        public int Povar { get; set; }
        public int Waiter { get; set; }
        public string Status { get; set; }
    }
}
