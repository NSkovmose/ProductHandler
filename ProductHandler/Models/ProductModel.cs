using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductHandler.Models
{
    [Table("Products")]
    public class ProductModel
    {
        [Key]
        [DisplayName("Produkt ID")]
        public int Id { get; set; }

        [DisplayName("Navn")]
        public string Name { get; set; }

        [DisplayName("Beskrivelse")]
        public string Description { get; set; }

        [DisplayName("Oprettelses dato")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedDate { get; set; }

    }
}
