
namespace ConfiguratorApp.DataAccessLayer.Common
{
    using System;

    public abstract class BaseEntity
    {
        public int ID { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
