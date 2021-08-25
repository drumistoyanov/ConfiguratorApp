using System.ComponentModel.DataAnnotations;

namespace ConfiguratorApp.Common.Enums
{
    public enum ComponentType
    {
        [Display(Name = "Computer case")]
        Case = 0,
        [Display(Name = "Motherboard")]
        Motherboard,
        [Display(Name = "Central Processing Unit")]
        CPU,
        [Display(Name = "Graphics Projessing Unit")]
        GPU,
        [Display(Name = "Random-access memory")]
        RAM,
        [Display(Name = "HDD/SSD")]
        StorageDevice,
        [Display(Name = "Processor Cooling")]
        Cooling,
        [Display(Name = "Power Unit")]
        PSU
    }
}
