using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCoreNET.Models
{
	public class Article
	{
		[Key]
        public int Id { get; set; }
		[Required(ErrorMessage = "Name is required")]
		[Display(Name = "Article Name")]
        public string ArticleName { get; set; }
		[Required(ErrorMessage = "Description is required")]
		public string ArticleDescription { get; set; }
		[Display(Name = "Creation date")]
		public string ArticleDateCreation { get; set; }
		[Display(Name = "Image")]
		[DataType(DataType.ImageUrl)]
		public string ArticleURL { get; set; }
		[Required(ErrorMessage = "Category is required")]
		public int CategoryId { get; set; }
		[ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
    }
}
