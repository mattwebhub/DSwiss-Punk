// Product Model
namespace DSwiss_Punk.Core.Models
{
    public class Product
    {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Tagline { get; set; }
    public string First_brewed { get; set; }
    public string Description { get; set; }
    public string Image_url { get; set; }
        public object Ingredients { get; set; }
        // [CONST] Placeholder properties
    }
}