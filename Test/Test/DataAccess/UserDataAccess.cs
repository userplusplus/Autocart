using SQLite;
using System;
using System.Collections.ObjectModel;
using Test.Models;
using Xamarin.Forms;

namespace Test.DataAccess
{
    internal class UserDataAccess
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
        public void AddNewUser(string email, string password)
        {
            /*this.Users.Add(new User
            {
                Email = email,
                Password = password
            });*/

            var user = new User
            {
                Email = email,
                Password = password
            };

            database.Insert(user);

            Console.WriteLine("Auto stock id: {0}", user.Id);
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