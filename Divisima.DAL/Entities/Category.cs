using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divisima.DAL.Entities
{
	public class Category
	{
		public int ID { get; set; }

		[Display(Name = "Üst Kategori")]
		public int? ParentID { get; set; }

		public Category ParentCategory { get; set; }

		[Display(Name = "Alt Kategoriler")]
		public ICollection<Category> SubCategories { get; set; }

		[StringLength(30), Column(TypeName = "varchar(30)"), Required(ErrorMessage = "Kategori Adı boş geçilemez."), Display(Name = "Kategori Adı")]
		public string Name { get; set; }

		public ICollection<ProductCategory> ProductCategories { get; set; }

		[Display(Name = "Görüntüleme Sırası")]
		public int DisplayIndex { get; set; }
	}
}
