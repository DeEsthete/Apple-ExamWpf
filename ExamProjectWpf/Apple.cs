using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProjectWpf
{
    public class Apple
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public int Price { get; set; }
        public int Loss { get; set; }
        public int Profit { get; set; }
        private int delivery = 10;       //доставка
        private int cultivation = 20;    //выращивание
        private int marriage = 10;       //брак

        public int CalculateProfit()
        {
            Profit = Price - Loss;
            return Profit;
        }

        public int CalculateLoss()
        {
            Loss = (delivery + cultivation + marriage);
            return Loss;
        }
    }
}
