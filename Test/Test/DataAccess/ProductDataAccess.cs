using SQLite;
using System;
using System.Collections.ObjectModel;
using Test.Models;
using Xamarin.Forms;

namespace Test.DataAccess
{
    internal class ProductDataAccess
    {
        private SQLiteConnection database;
        private static object collisionLock = new object();
        public ObservableCollection<Product> Products { get; set; }

        public ProductDataAccess()
        {
            database = DependencyService.Get<DatabaseConnection>().DbConnection();
            database.CreateTable<Product>();
            this.Products = new ObservableCollection<Product>(database.Table<Product>());
        }

        //Create a new user/register
        public void AddNewProduct(string name, decimal discount, decimal price)
        {

            var product = new Product
            {
                Name = name,
                Discount = discount,
                Price = price
            };

            database.Insert(product);

            Console.WriteLine("Auto stock id: {0}", product.Id);
        }

        //Get product using id
        public Product GetProduct(int id)
        {
            lock (collisionLock)
            {
                return database.Table<Product>().FirstOrDefault(product => product.Id == id);
            }
        }
    }
}
