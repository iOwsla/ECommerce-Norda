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


    [Table("District")]
    public class District
    {
        public int ID { get; set; }

        [StringLength(100), Column(TypeName = "varchar(100)"), Display(Name = "İlçe Adı")]
        public string Name { get; set; }
        public int? CityID { get; set; }
        public string CityName { get; set; }
        public City City { get; set; }
        public ICollection<Street> Streets { get; set; }
    }

}
