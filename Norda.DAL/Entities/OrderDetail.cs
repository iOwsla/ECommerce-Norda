using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Norda.DAL.Entities
{
    [Table("OrderDetail")]
    public class OrderDetail
    {
        public int ID { get; set; }

        public int OrderID { get; set; }
        public Order Order { get; set; }

        public int? ProductID { get; set; }
        public Product Product { get; set; }

        [StringLength(100), Column(TypeName = "varchar(100)"), Display(Name = "Ürün Adı")]
        public string Name { get; set; }

        [StringLength(150), Column(TypeName = "varchar(150)"), Display(Name = "Ürün Resmi")]
        public string Picture { get; set; }

        [Column(TypeName = "decimal(18,2)"), Display(Name = "Ürün Fiyatı")]
        public decimal Price { get; set; }

        [Display(Name = "Miktarı")]
        public int Quantity { get; set; }
    }
}
