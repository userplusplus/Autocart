using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Test.Models;
using SQLite;
using Xamarin.Forms;

namespace Test.DataAccess
{
    class UserDataAccess
    {
        private SQLiteConnection database;
        private static object collisionLock = new object();
        public ObservableCollection<User> Customers { get; set; }

        public UserDataAccess()
        {
            database = DependencyService.Get<DatabaseConnection>().DbConnection();
            database.CreateTable<User>();
            this.Customers = new ObservableCollection<User>(database.Table<User>());
        }

        //Create a new user/register
        public void AddNewUser(string email, string password)
        {
            this.Customers.Add(new User
            {
                Email = email,
                Password = password
            });
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


