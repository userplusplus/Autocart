using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Test.Models
{
    [Table("user")]
    class User
    {
        private int _id;
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id
        {
            get { return _id; }

            set { this._id = value; }
        }

        private string _email;
        [NotNull, MaxLength(100), Column("email")]
        public string Email
        {
            get { return _email; }

            set { this._email = value; }
        }

        private string _password;
        [NotNull, MaxLength(100), Column("password")]
        public string Password
        {
            get { return _password; }

            set { this._password = value; }
        }
    }
}
