namespace ConfiguratorApp.DataAccessLayer.Models
{
    public class ComputerComponents
    {
        public int ComputerId { get; set; }
        public Computer Computer { get; set; }
        public int ComponentId { get; set; }
        public Component Component { get; set; }
    }
}
