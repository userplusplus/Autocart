using SQLite;

namespace Test.Models
{
    [Table("product")]
    internal class Product
    {
        private int _id;

        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id
        {
            get { return _id; }

            set { this._id = value; }
        }

        private string _name;

        [NotNull, MaxLength(100), Column("name")]
        public string Name
        {
            get { return _name; }

            set { this._name = value; }
        }

        private decimal _discount;

        [NotNull, Column("discount")]
        public decimal Discount
        {
            get { return _discount; }

            set { this._discount = value; }
        }

        private decimal _price;

        [NotNull, Column("price")]
        public decimal Price
        {
            get { return _price; }

            set { this._price = value; }
        }
    }
}