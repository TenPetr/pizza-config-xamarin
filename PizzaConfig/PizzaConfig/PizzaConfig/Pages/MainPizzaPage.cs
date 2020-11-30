using System.Collections.Generic;
using Xamarin.Forms;

namespace PizzaConfig
{
    class MainPizzaPage : ViewModelBase
    {
        private static string EXTRA_BACON = "Bacon";
        private static string EXTRA_CHEESE = "Cheese";
        private static string EXTRA_OLIVAS = "Olivas";
        private static string SPACE = " • ";

        public Command selectPizzaCommand { get; set; }
        public Command addExtraBaconCommand { get; set; }
        public Command addExtraCheeseCommand { get; set; }
        public Command addExtraOlivasCommand { get; set; }
        public Command goToCheckoutCommand { get; set; }

        public List<Pizza> basePizzas { get; set; }
        public static List<Pizza> selectedPizzas { get; set; }

        public MainPizzaPage()
        {
            addExtraBaconCommand = new Command<Pizza>((pizza) => addExtraBacon(pizza));
            addExtraCheeseCommand = new Command<Pizza>((pizza) => addExtraCheese(pizza));
            addExtraOlivasCommand = new Command<Pizza>((pizza) => addExtraOlivas(pizza));
            selectPizzaCommand = new Command<Pizza>((pizza) => selectAndResetBasePizza(pizza));
            goToCheckoutCommand = new Command(goToCheckout);

            basePizzas = InitialPizzas.createInitialPizzas();
            selectedPizzas = new List<Pizza>();
        }

        private void addExtraBacon(Pizza selectedPizza)
        {
            Pizza wantedPizza = basePizzas.Find((pizza) => pizza == selectedPizza);
            wantedPizza.extras += SPACE + EXTRA_BACON;
        }

        private void addExtraCheese(Pizza selectedPizza)
        {
            Pizza wantedPizza = basePizzas.Find((pizza) => pizza == selectedPizza);
            wantedPizza.extras += SPACE + EXTRA_CHEESE;
        }

        private void addExtraOlivas(Pizza selectedPizza)
        {
            Pizza wantedPizza = basePizzas.Find((pizza) => pizza == selectedPizza);
            wantedPizza.extras += SPACE + EXTRA_OLIVAS;
        }

        private void selectAndResetBasePizza(Pizza pizza)
        {
            Pizza newPizza = NewPizza.createNewPizza(pizza);
            selectedPizzas.Add(newPizza);
            pizza.extras = "";
        }

        async private void goToCheckout()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new BasketPage());
        }
    }
}
