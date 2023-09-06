using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divisima.DAL.Entities
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ID { get; set; }

        [StringLength(100),Column(TypeName = "varchar(100)"),Required(ErrorMessage = "Product adı boş geçilemez"),Display(Name = "Product Adı")]
        public string Name { get; set; }
        
        [StringLength(250), Column(TypeName = "varchar(250)"),
         Display(Name = "Product Açıklaması")]
        public string Description { get; set; }

        [Column(TypeName = "text"),
        Display(Name = "Ürün Detayı")]
        public string Detail { get; set; }

        [Column(TypeName = "decimal(18,2)"),
        Display(Name = "Satış Miktarı")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(18,2)"),
        Display(Name = "Stok Miktarı")]
        public int Stock { get; set; }

		[Display(Name = "Marka")]
		public int? BrandID { get; set; }
        public Brand Brand { get; set; }

        public ICollection<ProductPicture> ProductPictures { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }

        [Display(Name = "Görüntüleme Sırası")]
        public int DisplayIndex { get; set; }



		/*
        
        

        public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }

		[Column(TypeName = "decimal(18,2)"), Display(Name = "İndirimli Fiyat")]
		public decimal? DiscountedPrice { get; set; }

		public ICollection<Review> Reviews { get; set; }

        [StringLength(50), Column(TypeName = "varchar(50)"), Display(Name = "Ürün Durumu")]
        public string Status { get; set; }

        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }

        [StringLength(50), Column(TypeName = "varchar(50)"), Display(Name = "Renk")]
        public string Color { get; set; }

        [StringLength(50), Column(TypeName = "varchar(50)"), Display(Name = "Model")]
        public string Model { get; set; }

        [Display(Name = "Garanti Süresi (Ay)")]
        public int WarrantyMonths { get; set; }
        
        */

	}
}
