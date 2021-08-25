using ConfiguratorApp.DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace ConfiguratorApp.WebApp.Models
{
    public class ReadyPcModel
    {
        public DateTime DateCreated { get; set; }
        public int Id { get; set; }
        public List<Component> Components { get; set; }
        public decimal Price { get; set; }
    }
}
