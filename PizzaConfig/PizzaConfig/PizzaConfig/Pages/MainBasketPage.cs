using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace PizzaConfig
{
    class MainBasketPage : ViewModelBase
    {
        public Command removePizzaCommand { get; set; }
        public Command addToFavouriteCommand { get; set; }
        public Command placeOrderCommand { get; set; }

        private ObservableCollection<Pizza> _selectedPizzas;
        public ObservableCollection<Pizza> selectedPizzas
        {
            get => _selectedPizzas;
            set { _selectedPizzas = value; OnPropertyChanged(nameof(selectedPizzas)); }
        }

        private double _totalPrice;
        public double totalPrice
        {
            get => _totalPrice;
            set { _totalPrice = value; OnPropertyChanged(nameof(totalPrice)); }
        }

        public MainBasketPage()
        {
            removePizzaCommand = new Command<Pizza>(pizza => removePizza(pizza));
            addToFavouriteCommand = new Command<Pizza>(pizza => addToFavourite(pizza));
            placeOrderCommand = new Command(placeOrder);

            selectedPizzas = MainPizzaPage.selectedPizzas;
            totalPrice = calculateTotalPrice();
        }

        private void removePizza(Pizza pizza)
        {
            MainPizzaPage.selectedPizzas.Remove(pizza);
            selectedPizzas = MainPizzaPage.selectedPizzas;
            totalPrice = calculateTotalPrice();
        }

        async private void addToFavourite(Pizza pizza)
        {
            Pizza newPizza = NewPizza.createNewPizza(pizza);
            await App.databaseService.savePizza(newPizza);

            displayAlert("Your pizza has been saved to the favourites");
        }

        private void placeOrder()
        {
            totalPrice = 0;
            MainPizzaPage.selectedPizzas.Clear();
            goToMainPage();
            displayAlert("Your order has been placed, please wait patiently for delivery!");
        }

        async private void goToMainPage()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        async private void displayAlert(string message)
        {
            await Application
                .Current
                .MainPage
                .DisplayAlert("Info", message, "OK");
        }

        private double calculateTotalPrice()
        {
            return selectedPizzas.Sum(pizza => pizza.price);
        }
    }
}
