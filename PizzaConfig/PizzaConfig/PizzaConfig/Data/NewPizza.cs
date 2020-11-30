namespace PizzaConfig
{
    class NewPizza
    {
        public static Pizza createNewPizza(Pizza pizza)
        {
            return new Pizza(pizza.id, pizza.name, pizza.ingrediences, pizza.price, pizza.extras);
        }
    }
}
