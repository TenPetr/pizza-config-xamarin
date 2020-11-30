using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaConfig
{
    public class DatabaseService
    {
        SQLiteAsyncConnection connection;

        public DatabaseService(string path)
        {
            connection = new SQLiteAsyncConnection(path);
            connection.CreateTableAsync<Pizza>().Wait();
        }

        public Task<List<Pizza>> getAllPizzas()
        {
            return connection.Table<Pizza>().ToListAsync();
        }

        public Task<int> savePizza(Pizza pizza)
        {
            return connection.InsertAsync(pizza);
        }

        public Task<int> deletePizza(Pizza pizza)
        {
            return connection.DeleteAsync(pizza);
        }
    }
}
