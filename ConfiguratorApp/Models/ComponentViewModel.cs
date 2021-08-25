using ConfiguratorApp.Common.Enums;

namespace ConfiguratorApp.WebApp.Models
{
    public class ComponentViewModel
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public string Picture { get; set; }
        public ComponentType Type { get; set; }
        public int Id { get; set; }
        public int Count { get; set; }
    }
}
