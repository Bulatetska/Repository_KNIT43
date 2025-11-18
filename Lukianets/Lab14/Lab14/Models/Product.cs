using System.ComponentModel.DataAnnotations;

namespace MvcStoreLab.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}