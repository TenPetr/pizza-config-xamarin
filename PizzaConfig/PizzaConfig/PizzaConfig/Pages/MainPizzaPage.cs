using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace PizzaConfig
{
    class MainPizzaPage : ViewModelBase
    {
        public Command selectPizzaCommand { get; set; }
        public Command addExtraBaconCommand { get; set; }
        public Command addExtraCheeseCommand { get; set; }
        public Command addExtraOlivasCommand { get; set; }
        public Command goToCheckoutCommand { get; set; }
        public Command goToFavouritesCommand { get; set; }

        public List<Pizza> basePizzas { get; set; }
        public static ObservableCollection<Pizza> selectedPizzas { get; set; }
        public static ObservableCollection<Pizza> favouritesPizzas { get; set; }

        public MainPizzaPage()
        {
            addExtraBaconCommand = new Command<Pizza>(pizza => addExtraBacon(pizza));
            addExtraCheeseCommand = new Command<Pizza>(pizza => addExtraCheese(pizza));
            addExtraOlivasCommand = new Command<Pizza>(pizza => addExtraOlivas(pizza));
            selectPizzaCommand = new Command<Pizza>(pizza => selectAndResetBasePizza(pizza));
            goToCheckoutCommand = new Command(goToCheckout);
            goToFavouritesCommand = new Command(goToFavourites);

            basePizzas = InitialPizzas.createInitialPizzas();
            selectedPizzas = new ObservableCollection<Pizza>();
            favouritesPizzas = new ObservableCollection<Pizza>();
        }

        private void addExtraBacon(Pizza selectedPizza)
        {
            Pizza wantedPizza = basePizzas.Find((pizza) => pizza == selectedPizza);
            wantedPizza.extras += Extras.SPACE + Extras.EXTRA_BACON;
        }

        private void addExtraCheese(Pizza selectedPizza)
        {
            Pizza wantedPizza = basePizzas.Find((pizza) => pizza == selectedPizza);
            wantedPizza.extras += Extras.SPACE + Extras.EXTRA_CHEESE;
        }

        private void addExtraOlivas(Pizza selectedPizza)
        {
            Pizza wantedPizza = basePizzas.Find((pizza) => pizza == selectedPizza);
            wantedPizza.extras += Extras.SPACE + Extras.EXTRA_OLIVAS;
        }

        private void selectAndResetBasePizza(Pizza pizza)
        {
            Pizza newPizza = NewPizza.createNewPizza(pizza);
            selectedPizzas.Add(newPizza);
            resetPizzaExtras(pizza);
        }

        private void resetPizzaExtras(Pizza pizza)
        {
            pizza.extras = "";
        }

        async private void goToCheckout()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new BasketPage());
        }

        async private void goToFavourites()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new FavouritesPage());
        }
    }
}
