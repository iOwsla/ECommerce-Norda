using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divisima.DAL.Entities
{
	public class Brand
	{
		public int ID { get; set; }
		[StringLength(30),Column(TypeName = "varchar(30)"),Required(ErrorMessage = "Marka Adı boş geçilemez."), Display(Name = "Marka Adı")]
		public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
