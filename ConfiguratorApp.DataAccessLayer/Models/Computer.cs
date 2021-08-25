namespace ConfiguratorApp.DataAccessLayer.Models
{
    using ConfiguratorApp.DataAccessLayer.Common;
    using System.Collections.Generic;

    public class Computer : BaseEntity
    {
        public ICollection<ComputerComponents> ComputerComponents { get; set; }
        public decimal Price { get; set; }
    }
}
