using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divisima.DAL.Entities
{
    [Table("ProductPicture")]
    public class ProductPicture
    {
        [Key]
        public int ID { get; set; }

        [StringLength(100), Column(TypeName = "varchar(100)"), Required(ErrorMessage = "Ürün Resim adı boş geçilemez"), Display(Name = "Ürün Resim Adı")]
        public string Name { get; set; }

        [StringLength(250), Column(TypeName = "varchar(250)"),
         Display(Name = "Ürün Resmi")]
        public string Picture { get; set; }

        [Display(Name = "Görüntüleme Sırası")]
        public int DisplayIndex { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }

    }
}
