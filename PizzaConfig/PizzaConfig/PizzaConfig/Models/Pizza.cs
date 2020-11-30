using System.Collections.Generic;

namespace PizzaConfig
{
    class Pizza
    {
        public int id { get; set; }

        public string name { get; set; }

        public string ingrediences { get; set; }

        public double price { get; set; }

        public string extras { get; set; }

        public Pizza(int id, string name, string ingrediences, double price, string extras)
        {
            this.id = id;
            this.name = name;
            this.ingrediences = ingrediences;
            this.price = price;
            this.extras = extras;
        }
    }
}
