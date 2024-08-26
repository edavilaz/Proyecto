using SQLite;

namespace Proyecto.Models
{
    [Table("user")]
    public class User
    {
        // PrimaryKey is typically numeric 
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        // máximo de caracteres y con unique indicamos que no se puede repetir
        [MaxLength(250), Unique]
        public string? Username { get; set; }
    }
}
