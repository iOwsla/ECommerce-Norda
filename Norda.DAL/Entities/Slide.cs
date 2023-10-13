using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divisima.DAL.Entities
{
    [Table("Slide")]
    public class Slide
    {
        [Key]
        public int ID { get; set; }
        [StringLength(50),Column(TypeName = "varchar(50)"),Required(ErrorMessage = "Slayt adı boş geçilemez"),Display(Name = "Slayt Adı")]
        public string Name { get; set; }
        [StringLength(50), Column(TypeName = "varchar(50)"), Required(ErrorMessage = "Slayt başlığı boş geçilemez"), Display(Name = "Slayt Başlığı")]
        public string Title { get; set; }
        [StringLength(250), Column(TypeName = "varchar(250)"),
         Display(Name = "Slayt Açıklaması")]
        public string Description { get; set; }
        [StringLength(150), Column(TypeName = "varchar(150)"),
         Display(Name = "Slayt Resmi")]
        public string Picture { get; set; }
        [StringLength(150), Column(TypeName = "varchar(150)"),
         Display(Name = "Bağlantı Linki")]
        public string Link { get; set; }
        [Display(Name = "Görüntüleme Sırası")]
        public int DisplayIndex { get; set; }

    }
}
