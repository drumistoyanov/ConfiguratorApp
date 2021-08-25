namespace ConfiguratorApp.DataAccessLayer.Models
{
    using System.Collections.Generic;

    public class Manufacturer 
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Component> Components { get; set; }
    }
}