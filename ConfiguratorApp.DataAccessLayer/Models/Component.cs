namespace ConfiguratorApp.DataAccessLayer.Models
{
    using ConfiguratorApp.Common.Enums;
    using ConfiguratorApp.DataAccessLayer.Common;
    using System.Collections.Generic;

    public class Component:BaseEntity
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public ComponentType Type { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public int ManufacturerId { get; set; }
        public decimal Price { get; set; }
        public string Picture { get; set; }
        public int Count { get; set; }
        public ICollection<ComputerComponents>  ComputerComponents { get; set; }
    }
}
