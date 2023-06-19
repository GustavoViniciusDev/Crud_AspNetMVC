using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crud_mvc_cSharp.Models
{
    [Table("Bandas")]
    public class Banda
    {
        [Key]
        public int IdBandas { get; set; }

        public string NomeBanda { get; set; }

        public string Genero { get; set; }

        public int QtdAlbuns { get; set; }
    }
}
