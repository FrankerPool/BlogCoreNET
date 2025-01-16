using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCoreNET.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is Required")]
        [Display(Name ="Name Category")]
        public string Name { get; set; }
        [Display(Name = "Visual Order")]
        [Range(1,100, ErrorMessage ="Value is over range")]
        public int? Order { get; set; }
    }
}
