using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace PizzaConfig
{
    class MainFavouritesPage : ViewModelBase
    {
        public Command removeFavouritePizzaCommand { get; set; }
        public Command addToBasketCommand { get; set; }

        private ObservableCollection<Pizza> _favouritesPizzas;
        public ObservableCollection<Pizza> favouritesPizzas
        {
            get => _favouritesPizzas;
            set { _favouritesPizzas = value; OnPropertyChanged(nameof(favouritesPizzas)); }
        }

        public MainFavouritesPage()
        {
            removeFavouritePizzaCommand = new Command<Pizza>(pizza => removeFavouritePizza(pizza));
            addToBasketCommand = new Command<Pizza>(pizza => addToBasket(pizza));

            getAllPizzas();
        }

        private async void getAllPizzas()
        {
            List<Pizza> pizzas = await App.databaseService.getAllPizzas();
            convertListToObsCollection(pizzas);
        }

        private void convertListToObsCollection(List<Pizza> pizzas)
        {
            foreach (var pizza in pizzas)
            {
                MainPizzaPage.favouritesPizzas.Add(pizza);
            }
            favouritesPizzas = MainPizzaPage.favouritesPizzas;
        }

        private void addToBasket(Pizza pizza)
        {
            Pizza newPizza = NewPizza.createNewPizza(pizza);
            MainPizzaPage.selectedPizzas.Add(newPizza);
            displayAlert("Selected pizza has been added to the basket");
        }

        private async void removeFavouritePizza(Pizza pizza)
        {
            MainPizzaPage.favouritesPizzas.Remove(pizza);
            await App.databaseService.deletePizza(pizza);

            favouritesPizzas = MainPizzaPage.favouritesPizzas;
        }

        async private void displayAlert(string message)
        {
            await Application
                .Current
                .MainPage
                .DisplayAlert("Info", message, "OK");
        }
    }
}
