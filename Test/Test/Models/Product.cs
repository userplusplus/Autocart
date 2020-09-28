using SQLite;

namespace Test.Models
{
    [Table("product")]
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("discount")]
        public decimal Discount { get; set; }

        [Column("price")]
        public decimal Price { get; set; }
    }
}