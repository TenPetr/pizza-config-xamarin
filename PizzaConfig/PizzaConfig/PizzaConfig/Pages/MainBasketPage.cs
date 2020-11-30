using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;

namespace PizzaConfig
{
    class MainBasketPage : ViewModelBase
    {
        public Command removePizzaCommand { get; set; }
        public Command addToFavouriteCommand { get; set; }

        public List<Pizza> selectedPizzas { get; set; }
        public double totalPrice { get; set; }

        public MainBasketPage()
        {
            removePizzaCommand = new Command<Pizza>((pizza) => removePizza(pizza));
            addToFavouriteCommand = new Command<Pizza>((pizza) => addToFavourite(pizza));

            selectedPizzas = MainPizzaPage.selectedPizzas;
            totalPrice = calculateTotalPrice();
        }

        private void removePizza(Pizza pizza)
        {
            Trace.WriteLine("awdawd");
        }

        private void addToFavourite(Pizza pizza)
        {
            Trace.WriteLine("awdawd");
        }

        private double calculateTotalPrice()
        {
            return selectedPizzas.Sum(pizza => pizza.price);
        }
    }
}
