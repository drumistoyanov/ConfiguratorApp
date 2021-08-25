using System.ComponentModel.DataAnnotations;

namespace ConfiguratorApp.WebApp.Models
{
    public class PCModel
    {
        [Required]
        [Display(Name = "Central Processing Unit")]

        public string CPUId { get; set; }
        [Required]
        [Display(Name = "Computer case")]
        public string CaseId { get; set; }
        [Required]
        [Display(Name = "Processor Cooling")]
        public string CoolingId { get; set; }
        [Required]
        [Display(Name = "Motherboard")]
        public string MotherboardId { get; set; }
        [Required]
        [Display(Name = "Random-access memory")]
        public string RAMId { get; set; }
        [Required]
        [Display(Name = "Graphics Projessing Unit")]
        public string GPUId { get; set; }
        [Required]
        [Display(Name = "Power Unit")]
        public string PSUId { get; set; }
        [Required]
        [Display(Name = "HDD/SSD")]
        public string StorageDeviceId { get; set; }
    }
}
