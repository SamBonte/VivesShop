using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace VivesShop.Mvc.WebApp.Models
{
    [Table(nameof(Product))] // om in VivesDbContext aan te geven db tabelnaam waarin zoeken = Product NIET Products
    public class Product
    {
        public int Id { get; set; }

        [DisplayName("Product Name")]
        //[Required(ErrorMessage = "Je moet dit invullen")] // zegt aan gebruiker, voornaam moet meegeven worden
        [Required] // voor ons dit genoeg
        public required string ProductName { get; set; }
        
        [Required]
        public required double ProductPrice { get; set; }
        
    }
}
