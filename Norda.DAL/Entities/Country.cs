using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Norda.DAL.Entities
{
    [Table("Country")]
    public class Country
    {
        public int ID { get; set; }

        [StringLength(2), Column(TypeName = "char(2)"), Display(Name = "İkili Kod")]
        public string BinaryCode { get; set; }

        [StringLength(3), Column(TypeName = "char(3)"), Display(Name = "Üçlü Kod")]
        public string TripleCode { get; set; }

        [StringLength(100), Column(TypeName = "varchar(100)"), Display(Name = "Ülke Adı")]
        public string Name { get; set; }

        [StringLength(10), Column(TypeName = "varchar(10)"), Display(Name = "Telefon Kodu")]
        public string PhoneCode { get; set; }
    }
}
