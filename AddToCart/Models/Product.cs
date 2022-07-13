using System.ComponentModel.DataAnnotations;

namespace AddToCart.Models
{
    public class Product
    {
        [Key]
        [ScaffoldColumn(false)]
        public int PId { get; set; }
        public string Pname { get; set; }
        public int Pprice { get; set; }
        public string Pdescription { get; set; }

    }
}
