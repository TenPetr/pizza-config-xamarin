using System.Collections.Generic;

namespace PizzaConfig
{
    class InitialPizzas
    {
        public static List<Pizza> createInitialPizzas()
        {
            return new List<Pizza>
            {
                new Pizza(1, "Salami", "Salam, Cheese, Sausage, Tomatoes", 99.49, ""),
                new Pizza(2, "Hawai", "Ananas, Salam, Olive, Tomatoes", 129.99, ""),
                new Pizza(3, "Peperoni", "Peppers, Salam, Cheese, Tomatoes", 179.59, ""),
                new Pizza(4, "Cheesee", "5 types of Cheese, Tomatoes", 119.19, ""),
                new Pizza(4, "Italiano", "Cheese, Salami, Tomatoes, Ketchup", 199.99, "")
            };
        }
    }
}
