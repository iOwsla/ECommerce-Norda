using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Norda.DAL.Entities
{
    [Table("Street")]
    public class Street
    {
        public int ID { get; set; } = 1;

        [StringLength(100), Column(TypeName = "varchar(100)"), Display(Name = "Şehir Adı")]
        public string Name { get; set; }

        [StringLength(100), Column(TypeName = "varchar(100)"), Display(Name = "Sokak Adı")]
        public string StreetName { get; set; }

        [StringLength(10), Column(TypeName = "varchar(10)"), Display(Name = "Posta Kodu")]
        public string PostCode { get; set; }

        public int? DistrictID { get; set; }

        public District District { get; set; }
    }
}
