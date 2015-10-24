using System.ComponentModel.DataAnnotations;
namespace StarterKit.Web.ViewModels
{
    public class MyMessageViewModel
    {
        [Display(Name="How many commands to send?")]
        public uint CommandCount { get; set; }

        [Display(Name = "How many events to send?")]
        public uint EventCount { get; set; } 
    }
}