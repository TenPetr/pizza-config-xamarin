using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace PizzaConfig
{
    public class DatabaseService
    {
        private static string DATABASE_NAME = "pizzaDatabase.db3";
        private static string PATH = Path.Combine(Environment.GetFolderPath(
            Environment.SpecialFolder.LocalApplicationData),
            DATABASE_NAME);

        private SQLiteAsyncConnection connection;

        public DatabaseService()
        {
            connection = new SQLiteAsyncConnection(PATH);
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
