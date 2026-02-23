using System.ComponentModel.DataAnnotations;

namespace Construction_tasks.Models
{
    public class Task
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Address")]
        public String Address { get; set; }

        [Display(Name = "City")]
        public String City { get; set; }

        [Display(Name = "Duration")]
        public String Duration { get; set; }

        [Display(Name = "Estimate")]
        public int Estimate { get; set; }

        [Display(Name = "Manager")]
        public String Manager { get; set; }

        [Display(Name ="Completed")]
        public bool Completed { get; set; }
    }
}
