using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Norda.DAL.Entities
{
    [Table("Order")]
    public class Order
    {
        public int ID { get; set; }

        [StringLength(10), Column(TypeName = "varchar(10)"), Display(Name = "Sipariş Numarası"), Required(ErrorMessage = "Sipariş Numarası boş geçilemez")]
        public string OrderNumber { get; set; }

        [StringLength(30), Column(TypeName = "varchar(30)"), Display(Name = "Adı"), Required(ErrorMessage = "Ad bilgisi boş geçilemez")]
        public string Name { get; set; }

        [StringLength(30), Column(TypeName = "varchar(30)"), Display(Name = "Soyadı"), Required(ErrorMessage = "Soyad bilgisi boş geçilemez")]
        public string Surname { get; set; }

        [StringLength(100), Column(TypeName = "varchar(100)"), Display(Name = "Adres Tanımı"), Required(ErrorMessage = "Adresbilgisi boş geçilemez")]
        public string Address { get; set; }
        [StringLength(80), Column(TypeName = "varchar(80)"), Display(Name = "Mail"), Required(ErrorMessage = "Mail bilgisi boş geçilemez")]
        public string Mail { get; set; }

        [Display(Name = "Şehir")]
        public int? CityID { get; set; }
        public City City { get; set; }

        [StringLength(5), Column(TypeName = "char(5)"), Display(Name = "Posta Kodu")]
        public string ZipCode { get; set; }

        [StringLength(11), Column(TypeName = "char(11)"), Display(Name = "Telefon"), Required(ErrorMessage = "Telefon bilgisi boş geçilemez")]
        public string Phone { get; set; }

        [Display(Name = "Ödeme Türü")]
        public EPaymentOption PaymentOption { get; set; }

        [Display(Name = "Sipariş Durumu")]
        public EOrderStatus OrderStatus { get; set; }

        [Display(Name = "Sipariş Tarihi")]
        public DateTime RecDate { get; set; }

        [StringLength(20), Column(TypeName = "varchar(10)"), Display(Name = "IP Numarası")]
        public string IPNO { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
