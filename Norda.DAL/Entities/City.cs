using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Norda.DAL.Entities
{
    [Table("City")]
    public class City
    {
        public int ID { get; set; } = 1;

        [StringLength(100), Column(TypeName = "varchar(100)"), Display(Name = "Şehir Adı")]
        public string Name { get; set; }

        public int PlateNo { get; set; }

        public int PhoneCode { get; set; }

        public int RowNumber { get; set; }

        public ICollection<District> Districts { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
