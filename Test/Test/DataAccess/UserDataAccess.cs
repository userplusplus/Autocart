using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Test.Models;
using SQLite;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test.DataAccess
{
    class UserDataAccess
    {
        private SQLiteConnection database;
        private static object collisionLock = new object();
        public ObservableCollection<User> Users { get; set; }

        public UserDataAccess()
        {
            database = DependencyService.Get<DatabaseConnection>().DbConnection();
            database.CreateTable<User>();
            this.Users = new ObservableCollection<User>(database.Table<User>());
        }

        //Create a new user/register
        public async void AddNewUser(string email, string password)
        {
            /*this.Users.Add(new User
            {
                Email = email,
                Password = password
            });*/

            var user = new User {
                Email = email,
                Password = password
                };

            await database.InsertAsync(stock);

            Console.WriteLine("Auto stock id: {0}", stock.Id);
        }

        //Check for user using email
        public User GetUser(string email)
        {
            lock (collisionLock)
            {
                return database.Table<User>().FirstOrDefault(customer => customer.Email == email);
            }
        }
    }
}


